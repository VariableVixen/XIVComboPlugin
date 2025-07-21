using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;

using Dalamud.Game.ClientState.Conditions;
using Dalamud.Game.ClientState.JobGauge.Types;
using Dalamud.Game.ClientState.Objects.SubKinds;
using Dalamud.Game.ClientState.Objects.Types;
using Dalamud.Game.ClientState.Statuses;
using Dalamud.Plugin.Services;
using Dalamud.Utility;

using FFXIVClientStructs.FFXIV.Client.UI.Agent;

using Lumina.Excel;

using VariableVixen.XIVComboVX.Attributes;
using VariableVixen.XIVComboVX.Combos;
using VariableVixen.XIVComboVX.GameData;

using ActionManager = FFXIVClientStructs.FFXIV.Client.Game.ActionManager;
using ExcelAction = Lumina.Excel.Sheets.Action;
using RecastDetail = FFXIVClientStructs.FFXIV.Client.Game.RecastDetail;

namespace VariableVixen.XIVComboVX;

internal abstract class CustomCombo {
	public const uint InvalidObjectID = 0xE000_0000;

	public abstract CustomComboPreset Preset { get; }
	public virtual uint[] ActionIDs { get; } = [];
	private readonly HashSet<uint> affectedIDs;
	public readonly string ModuleName;

	public byte JobID { get; }
	public byte ClassID => this.JobID switch {
		>= 19 and <= 25 => (byte)(this.JobID - 18),
		27 or 28 => 26,
		30 => 29,
		_ => this.JobID,
	};

	protected CustomCombo() {
		CustomComboInfoAttribute presetInfo = this.Preset.GetAttribute<CustomComboInfoAttribute>()!;
		this.JobID = presetInfo.JobID;
		this.ModuleName = this.GetType().Name;
		this.affectedIDs = [.. this.ActionIDs];
	}

	public bool TryInvoke(uint actionID, uint lastComboActionId, float comboTime, byte level, uint classJobID, out uint newActionID) {
		newActionID = 0;

		if (!Service.Configuration.Active)
			return false;

		if (classJobID is >= 8 and <= 15)
			classJobID = DOH.JobID;

		if (classJobID is >= 16 and <= 18)
			classJobID = DOL.JobID;

		if (this.JobID > 0 && this.JobID != classJobID && this.ClassID != classJobID) {
			Service.TickLogger.Info($"{LogTag.Combo} Wrong class/job for {this.ModuleName}");
			return false;
		}
		if (this.affectedIDs.Count > 0 && !this.affectedIDs.Contains(actionID)) {
			Service.TickLogger.Error($"{LogTag.Combo} {this.ModuleName} does not affect action #{actionID} - this replacer should not have been invoked!");
			return false;
		}
		if (!IsEnabled(this.Preset)) {
			Service.TickLogger.Info($"{LogTag.Combo} Preset {this.Preset} is disabled, replacer {this.ModuleName} is inactive");
			return false;
		}

		if (comboTime <= 0)
			lastComboActionId = 0;

		Service.TickLogger.Info($"{LogTag.Combo} {this.ModuleName}.Invoke({actionID}, {lastComboActionId}, {comboTime}, {level})");
		try {
			uint resultingActionID = this.Invoke(actionID, lastComboActionId, comboTime, level);
			if (resultingActionID == 0 || actionID == resultingActionID) {
				Service.TickLogger.Debug($"{LogTag.Combo} No replacement from {this.ModuleName}");
				return false;
			}

			Service.TickLogger.Info($"{LogTag.Combo} Became #{resultingActionID}");
			newActionID = resultingActionID;
			return true;
		}
		catch (Exception ex) {
			Service.TickLogger.Error($"{LogTag.Combo} Error in {this.ModuleName}.Invoke({actionID}, {lastComboActionId}, {comboTime}, {level})", ex);
			return false;
		}
	}
	protected abstract uint Invoke(uint actionID, uint lastComboActionId, float comboTime, byte level);

	protected static bool IsEnabled(CustomComboPreset preset) {
		if ((int)preset < 0) {
			Service.TickLogger.Info($"{LogTag.Combo} Aborting is-enabled check, {preset.GetDebugLabel()} is forcibly disabled");
			return false;
		}
		if ((int)preset < 100) {
			Service.TickLogger.Info($"{LogTag.Combo} Bypassing is-enabled check for preset {preset.GetDebugLabel()}");
			return true;
		}
		bool enabled = Service.Configuration.IsEnabled(preset);
		Service.TickLogger.Info($"{LogTag.Combo} Checking status of preset {preset.GetDebugLabel()} - {enabled}");
		return enabled;
	}

	#region Caching

	// Invalidate these
	protected static readonly Dictionary<(uint StatusID, uint? TargetID, uint? SourceID), Status?> statusCache = [];
	protected static readonly Dictionary<uint, CooldownData> cooldownCache = [];
	protected static bool? canInterruptTarget = null;
	protected static uint? dancerNextDanceStep = null;

	// Do not invalidate these
	protected static readonly Dictionary<uint, byte> cooldownGroupCache = [];
	protected static readonly Dictionary<Type, JobGaugeBase> jobGaugeCache = [];
	protected static readonly Dictionary<(uint ActionID, uint ClassJobID, byte Level), (ushort CurrentMax, ushort Max)> chargesCache = [];

	// These are updated directly, not actually invalidated
	protected static IPlayerCharacter LocalPlayer { get; private set; } = null!;

	// vixen and the terrible horrible no good very bad hack
	internal static IPlayerCharacter? CachedLocalPlayer => LocalPlayer;

	[SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "delegate conformance")]
	internal static void ResetCacheEveryTick(IFramework framework) => ResetCache();
	internal static void ResetCache() {
		Service.TickLogger.Debug($"{LogTag.DataCache} Resetting cache");
		statusCache.Clear();
		cooldownCache.Clear();
		canInterruptTarget = null;
		dancerNextDanceStep = null;
		LocalPlayer = Service.Client.LocalPlayer!;
	}

	#endregion

#pragma warning disable IDE0045 // Convert to conditional expression - helper function readability

	#region Common calculations and shortcuts

	protected static bool CheckLucidWeave(CustomComboPreset preset, byte level, uint manaThreshold, uint baseAction) {

		if (level >= Common.Levels.LucidDreaming && IsEnabled(preset)) {
			if (LocalPlayer.CurrentMp < manaThreshold && CanWeave(baseAction) && CanUse(Common.LucidDreaming))
				return true;
		}

		return false;
	}

	protected static uint PickByCooldown(uint preference, params uint[] actions) {

		static (uint ActionID, CooldownData Data) selector(uint actionID) => (actionID, GetCooldown(actionID));

		static (uint ActionID, CooldownData Data) compare(uint preference, (uint ActionID, CooldownData Data) a, (uint ActionID, CooldownData Data) b) {

			// VS decided that the conditionals could be "simplified" to this.
			// Someone should maybe teach VS what "simplified" actually means.
			(uint ActionID, CooldownData Data) choice = // it begins ("it" = suffering)
				!a.Data.IsCooldown && !b.Data.IsCooldown // welcome to hell, population: anyone trying to maintain this
					? preference == a.ActionID // both off CD
						? a // return the original if it's the first one
						: b // or else the second, no matter what
					: a.Data.IsCooldown && b.Data.IsCooldown // one/both are on CD
						? a.Data.HasCharges && b.Data.HasCharges // both on CD
							? a.Data.RemainingCharges == b.Data.RemainingCharges // both have charges
								? a.Data.ChargeCooldownRemaining < b.Data.ChargeCooldownRemaining // both have the same number of charges left
									? a // a will get a charge back before b
									: b // b will get a charge back before a
								: a.Data.RemainingCharges > b.Data.RemainingCharges // one has more charges than the other
									? a // a has more charges
									: b // b has more charges
							: a.Data.HasCharges // only one has charges or neither does
								? a.Data.RemainingCharges > 0 // only a has charges
									? a // and there are charges remaining
									: a.Data.ChargeCooldownRemaining < b.Data.CooldownRemaining // but there aren't any available
										? a // a will recover a charge before b comes off cooldown
										: b // b will come off cooldown before a recovers a charge
								: b.Data.HasCharges // a does not have charges
									? b.Data.RemainingCharges > 0 // but b does
										? b // and it has at least one available
										: b.Data.ChargeCooldownRemaining < a.Data.CooldownRemaining // but there are no charges available
											? b // b will recover a charge before a comes off cooldown
											: a // a will come off cooldown before b recovers a charge
									: a.Data.CooldownRemaining < b.Data.CooldownRemaining // neither action has charges
										? a // a has less cooldown time left
										: b // b has less cooldown time left
						: a.Data.IsCooldown // only one on CD
							? b // b is off cooldown
							: a; // a is off cooldown

			// You know that one scene in Doctor Who on the really long spaceship that's being sucked into a black hole?
			// And time's dilated at one end but not the other?
			// And there's that hospital in the end by the black hole?
			// And there's that one patient that's just constantly hitting the "pain" button?
			// And they've got a TTS-style voice just constantly repeating "PAIN. PAIN. PAIN. PAIN. PAIN." from it?
			// Yeah.

			Service.TickLogger.Debug($"{LogTag.Combo} CDCMP: {a.ActionID}, {b.ActionID}: {choice.ActionID}\n{a.Data.DebugLabel}\n{b.Data.DebugLabel}");
			return choice;
		}

		uint id = actions
			.Select(selector)
			.Aggregate((a1, a2) => compare(preference, a1, a2))
			.ActionID;
		Service.TickLogger.Info($"{LogTag.Combo} Final selection: {id}");
		return id;
	}

	protected static bool IsJob(params uint[] jobs) {
		IPlayerCharacter? p = LocalPlayer;
		if (p is null)
			return false;
		uint current = p.ClassJob.RowId;
		foreach (uint job in jobs) {
			if (current == job)
				return true;
		}
		return false;
	}

	protected static uint OriginalHook(uint actionID) => Service.IconReplacer.OriginalHook(actionID);

	protected static bool IsOriginal(uint actionID) => OriginalHook(actionID) == actionID;

	#endregion

	#region Player details/stats

	protected static bool HasCondition(ConditionFlag flag) => Service.Conditions[flag];

	protected static bool InCombat => Service.Conditions[ConditionFlag.InCombat];

	protected static bool HasPetPresent => Service.BuddyList.PetBuddy is not null;

	protected static double PlayerHealthPercentage => (double)LocalPlayer.CurrentHp / LocalPlayer.MaxHp * 100.0;

	protected static bool ShouldSwiftcast => IsOffCooldown(Common.Swiftcast)
		&& !SelfHasEffect(Common.Buffs.LostChainspell)
		&& !SelfHasEffect(RDM.Buffs.Dualcast);
	protected static bool IsFastcasting => SelfHasEffect(Common.Buffs.Swiftcast1)
		|| SelfHasEffect(Common.Buffs.Swiftcast2)
		|| SelfHasEffect(Common.Buffs.Swiftcast3)
		|| SelfHasEffect(RDM.Buffs.Dualcast)
		|| SelfHasEffect(Common.Buffs.LostChainspell);
	protected static bool IsHardcasting => !IsFastcasting;

	protected static T GetJobGauge<T>() where T : JobGaugeBase {
		if (!jobGaugeCache.TryGetValue(typeof(T), out JobGaugeBase? gauge))
			gauge = jobGaugeCache[typeof(T)] = Service.JobGauge.Get<T>();

		return (T)gauge;
	}

	protected static unsafe bool IsMoving => AgentMap.Instance() is not null && AgentMap.Instance()->IsPlayerMoving;

	#endregion

	#region Target details/stats

	protected static IGameObject? CurrentTarget => Service.Targets.SoftTarget ?? Service.Targets.Target;

	protected static bool HasTarget => CurrentTarget is not null;
	protected static bool CanInterrupt {
		get {
			if (!canInterruptTarget.HasValue) {
				IGameObject? target = CustomCombo.CurrentTarget;
				canInterruptTarget = target is IBattleChara actor
					&& actor.IsCasting
					&& actor.IsCastInterruptible;
			}
			return canInterruptTarget.Value;
		}
	}

	protected static double TargetDistance {
		get {
			if (LocalPlayer is null || CurrentTarget is null)
				return 0;

			IGameObject target = CurrentTarget;

			Vector2 tPos = new(target.Position.X, target.Position.Z);
			Vector2 sPos = new(LocalPlayer.Position.X, LocalPlayer.Position.Z);

			return Vector2.Distance(tPos, sPos) - target.HitboxRadius - LocalPlayer.HitboxRadius;
		}
	}
	protected static bool InMeleeRange => TargetDistance <= 3;

	protected static double TargetCurrentHp => CurrentTarget is IBattleChara npc ? npc.CurrentHp : 0;
	protected static double TargetMaxHp => CurrentTarget is IBattleChara npc ? npc.MaxHp : 0;
	protected static double TargetHealthPercentage => CurrentTarget is IBattleChara npc ? npc.CurrentHp / npc.MaxHp * 100 : 0;

	#endregion

	#region Cooldowns and charges

	protected static unsafe CooldownData GetCooldown(uint actionID) {
		if (cooldownCache.TryGetValue(actionID, out CooldownData found))
			return found;

		ActionManager* actionManager = ActionManager.Instance();
		if (actionManager is null)
			return cooldownCache[actionID] = default;

		if (!cooldownGroupCache.TryGetValue(actionID, out byte cooldownGroup)) {
			ExcelSheet<ExcelAction> sheet = Service.GameData.GetExcelSheet<ExcelAction>()!;
			ExcelAction row = sheet.GetRow(actionID)!;
			cooldownGroupCache[actionID] = cooldownGroup = row.CooldownGroup;
		}

		RecastDetail* cooldownPtr = actionManager->GetRecastGroupDetail(cooldownGroup - 1);
		cooldownPtr->ActionId = actionID;

		CooldownData cd = cooldownCache[actionID] = *(CooldownData*)cooldownPtr;
		Service.TickLogger.Debug($"{LogTag.Combo} Retrieved cooldown data for action #{actionID}: {cd.DebugLabel}");
		return cd;
	}

	protected static bool IsOnCooldown(uint actionID) => GetCooldown(actionID).IsCooldown;

	protected static bool IsOffCooldown(uint actionID) => !GetCooldown(actionID).IsCooldown;

	protected static bool HasCharges(uint actionID) => GetCooldown(actionID).HasCharges;

	protected static bool CanUse(uint actionID) => GetCooldown(actionID).Available;

	protected static bool CanWeave(uint actionID, double weaveTime = 0.7) => GetCooldown(actionID).CooldownRemaining > weaveTime;
	protected static bool CanSpellWeave(uint actionID, double weaveTime = 0.5) => GetCooldown(actionID).CooldownRemaining > weaveTime && !LocalPlayer.IsCasting;

	#endregion

	#region Effects

	protected static Status? FindEffect(uint statusID, IGameObject? actor, uint? sourceID) {
		(uint statusID, uint? ObjectId, uint? sourceID) key = (statusID, actor?.EntityId, sourceID);

		if (statusCache.TryGetValue(key, out Status? found)) {
			Service.TickLogger.Info($"{LogTag.StatusEffect} Found cached status data for #{statusID}: "
				+ (found is null
					? "not active"
					: $"{found.Param} stacks, {found.RemainingTime} seconds"
				)
			);
			return found;
		}

		if (actor is null)
			return statusCache[key] = null;
		if (actor is not IBattleChara chara)
			return statusCache[key] = null;

		foreach (Status? status in chara.StatusList) {
			if (status is null)
				continue;
			if (status.StatusId == statusID && (!sourceID.HasValue || status.SourceId is 0 or InvalidObjectID || status.SourceId == sourceID)) {
				Service.TickLogger.Info($"{LogTag.StatusEffect} Caching status data for #{statusID}: {status.Param} stacks, {status.RemainingTime} seconds");
				return statusCache[key] = status;
			}
		}

		Service.TickLogger.Info($"{LogTag.StatusEffect} Caching null status for #{statusID}");
		return statusCache[key] = null;
	}

	protected static Status? SelfFindEffect(ushort effectId) => FindEffect(effectId, LocalPlayer, null);
	protected static bool SelfHasEffect(ushort effectId) => SelfFindEffect(effectId) is not null;
	protected static float SelfEffectDuration(ushort effectId) => SelfFindEffect(effectId)?.RemainingTime ?? 0;
	protected static float SelfEffectStacks(ushort effectId) => SelfFindEffect(effectId)?.Param ?? 0;

	protected static Status? TargetFindAnyEffect(ushort effectId) => FindEffect(effectId, CurrentTarget, null);
	protected static bool TargetHasAnyEffect(ushort effectId) => TargetFindAnyEffect(effectId) is not null;
	protected static float TargetAnyEffectDuration(ushort effectId) => TargetFindAnyEffect(effectId)?.RemainingTime ?? 0;
	protected static float TargetAnyEffectStacks(ushort effectId) => TargetFindAnyEffect(effectId)?.Param ?? 0;

	protected static Status? TargetFindOwnEffect(ushort effectId) => FindEffect(effectId, CurrentTarget, LocalPlayer?.EntityId);
	protected static bool TargetHasOwnEffect(ushort effectId) => TargetFindOwnEffect(effectId) is not null;
	protected static float TargetOwnEffectDuration(ushort effectId) => TargetFindOwnEffect(effectId)?.RemainingTime ?? 0;
	protected static float TargetOwnEffectStacks(ushort effectId) => TargetFindOwnEffect(effectId)?.Param ?? 0;

	#endregion

#pragma warning restore IDE0045 // Convert to conditional expression
}
