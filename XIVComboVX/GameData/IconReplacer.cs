using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Dalamud.Game.ClientState.Objects.SubKinds;
using Dalamud.Hooking;

using FFXIVClientStructs.FFXIV.Client.Game;

namespace VariableVixen.XIVComboVX.GameData;

internal class IconReplacer: IDisposable {

	private delegate ulong IsIconReplaceableDelegate(uint actionID);
	private delegate uint GetIconDelegate(nint actionManager, uint actionID);
	private delegate nint GetActionCooldownSlotDelegate(nint actionManager, int cooldownGroup);

	private readonly Hook<IsIconReplaceableDelegate> isIconReplaceableHook;
	private readonly Hook<GetIconDelegate> getIconHook;

	private nint actionManager = nint.Zero;

	private readonly Dictionary<uint, List<CustomCombo>> customCombos = [];

	public IconReplacer() {
		Service.Log.Information($"{LogTag.CoreSetup} Loading registered combos");
		int total = 0;
		IEnumerable<CustomCombo> combos = Assembly.GetAssembly(this.GetType())!.GetTypes()
			.Where(t => !t.IsAbstract && (t.BaseType == typeof(CustomCombo) || t.BaseType?.BaseType == typeof(CustomCombo)))
			.Select(t => {
				++total;
				return Activator.CreateInstance(t);
			})
			.Cast<CustomCombo>();
		foreach (CustomCombo combo in combos) {
			uint[] actions = combo.ActionIDs;
			if (actions.Length == 0)
				actions = [0];
			foreach (uint id in actions) {
				if (!this.customCombos.TryGetValue(id, out List<CustomCombo>? all)) {
					all = [];
					this.customCombos[id] = all;
				}
				all.Add(combo);
			}
		}
		Service.Log.Information($"{LogTag.CoreSetup} Loaded {total} replacers for {this.customCombos.Count} actions");

		this.getIconHook = Service.Interop.HookFromAddress<GetIconDelegate>(ActionManager.Addresses.GetAdjustedActionId.Value, this.getIconDetour);
		this.isIconReplaceableHook = Service.Interop.HookFromAddress<IsIconReplaceableDelegate>(Service.Address.IsActionIdReplaceable, this.isIconReplaceableDetour);

		this.getIconHook.Enable();
		this.isIconReplaceableHook.Enable();

	}

	public void Dispose() {
		this.getIconHook?.Disable();
		this.isIconReplaceableHook?.Disable();

		this.getIconHook?.Dispose();
		this.isIconReplaceableHook?.Dispose();
	}

	private ulong isIconReplaceableDetour(uint actionID) => 1;

	private unsafe uint getIconDetour(nint actionManager, uint actionID) {
		try {
			this.actionManager = actionManager;

			if (!Service.Configuration.Active)
				return this.OriginalHook(actionID);

			if (!this.customCombos.TryGetValue(actionID, out List<CustomCombo>? combos) && !this.customCombos.TryGetValue(0, out combos)) {
				Service.TickLogger.Info($"{LogTag.Combo} No replacers found for action {Labels.Action(actionID)}");
				return this.OriginalHook(actionID);
			}

			IPlayerCharacter? player = Service.ObjectTable.LocalPlayer;
			if (player?.IsValid() is not true) {
				CustomCombo.CachedLocalPlayer = null;
				Service.TickLogger.Warning($"{LogTag.Combo} Cannot replace action {Labels.Action(actionID)} without a player");
				return this.OriginalHook(actionID);
			}
			CustomCombo.CachedLocalPlayer = player;

			uint lastComboActionId = *(uint*)Service.Address.LastComboMove;
			float comboTime = *(float*)Service.Address.ComboTimer;
			byte level = player.Level;
			uint classJobID = player.ClassJob.RowId;

			Service.TickLogger.Info($"{LogTag.Combo} Checking {combos.Count} replacer{(combos.Count == 1 ? "" : "s")} for action {Labels.Action(actionID)}");
			foreach (CustomCombo combo in combos) {
				if (combo.TryInvoke(actionID, lastComboActionId, comboTime, level, classJobID, out uint newActionID))
					return this.OriginalHook(newActionID);
			}

			Service.TickLogger.Info($"{LogTag.Combo} No replacement for {Labels.Action(actionID)}");
			return this.OriginalHook(actionID);
		}
		catch (Exception ex) {
			Service.TickLogger.Error($"{LogTag.Combo} Don't crash the game", ex);
			return this.getIconHook.Original(actionManager, actionID);
		}
	}


	public uint OriginalHook(uint actionID) => this.getIconHook.Original(this.actionManager, actionID);

}
