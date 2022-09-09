namespace XIVComboVX.Combos;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

using Dalamud.Game.ClientState.Conditions;
using Dalamud.Game.ClientState.JobGauge.Types;
using Dalamud.Game.ClientState.Objects.SubKinds;
using Dalamud.Game.ClientState.Objects.Types;
using Dalamud.Game.ClientState.Statuses;
using Dalamud.Utility;

using FFXIVClientStructs.FFXIV.Client.UI.Agent;

using XIVComboVX.Attributes;
using XIVComboVX.GameData;

internal abstract class CustomCombo {
	public const uint InvalidObjectID = 0xE000_0000;

	public abstract CustomComboPreset Preset { get; }
	public virtual uint[] ActionIDs { get; } = Array.Empty<uint>();
	public readonly HashSet<uint> AffectedIDs;
	public readonly string ModuleName;

	public byte JobID { get; }
	public byte ClassID => this.JobID switch {
		>= 19 and <= 25 => (byte)(this.JobID - 18),
		27 or 28 => 26,
		30 => 29,
		_ => this.JobID,
	};

	protected CustomCombo() {
		CustomComboInfoAttribute presetInfo = this.Preset.GetAttribute<CustomComboInfoAttribute>();
		this.JobID = presetInfo.JobID;
		this.ModuleName = this.GetType().Name;
		this.AffectedIDs = new(this.ActionIDs);
	}

	public bool TryInvoke(uint actionID, uint lastComboActionId, float comboTime, byte level, out uint newActionID) {
		newActionID = 0;

		if (!Service.Configuration.Active)
			return false;

		uint classJobID = LocalPlayer!.ClassJob.Id;

		if (classJobID is >= 8 and <= 15)
			classJobID = DOH.JobID;

		if (classJobID is >= 16 and <= 18)
			classJobID = DOL.JobID;

		if (this.JobID != classJobID && this.ClassID != classJobID) {
			//Service.Logger.debug($"{this.ModuleName} not applied: class/job ID mismatch ({this.ClassID}/{this.JobID} != {classJobID})");
			return false;
		}
		if (this.AffectedIDs.Count > 0 && !this.AffectedIDs.Contains(actionID)) {
			//Service.Logger.debug($"{this.ModuleName} not applied: action ID ({actionID}) not affected");
			return false;
		}
		if (!IsEnabled(this.Preset)) {
			//Service.Logger.debug($"{this.ModuleName} not applied: preset not enabled");
			return false;
		}

		if (comboTime <= 0)
			lastComboActionId = 0;

		Service.Logger.debug($"{this.ModuleName}.Invoke({actionID}, {lastComboActionId}, {comboTime}, {level})");
		try {
			uint resultingActionID = this.Invoke(actionID, lastComboActionId, comboTime, level);
			if (resultingActionID == 0 || actionID == resultingActionID) {
				Service.Logger.debug("NO REPLACEMENT");
				return false;
			}

			Service.Logger.debug($"Became #{resultingActionID}");
			newActionID = resultingActionID;
			return true;
		}
		catch (Exception ex) {
			Service.Logger.error($"Error in {this.ModuleName}.Invoke({actionID}, {lastComboActionId}, {comboTime}, {level})", ex);
			return false;
		}
	}
	protected abstract uint Invoke(uint actionID, uint lastComboActionId, float comboTime, byte level);

	protected internal static bool IsEnabled(CustomComboPreset preset) {
		if ((int)preset < 100) {
			Service.Logger.debug($"Bypassing is-enabled check for preset #{(int)preset}");
			return true;
		}
		bool enabled = Service.Configuration.IsEnabled(preset);
		Service.Logger.debug($"Checking status of preset #{(int)preset} - {enabled}");
		return enabled;
	}

	#region Common calculations and shortcuts

	protected static uint PickByCooldown(uint preference, params uint[] actions) {

		static (uint ActionID, CooldownData Data) Selector(uint actionID) {
			return (actionID, GetCooldown(actionID));
		}

		static (uint ActionID, CooldownData Data) Compare(uint preference, (uint ActionID, CooldownData Data) a, (uint ActionID, CooldownData Data) b) {

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

			Service.Logger.debug($"CDCMP: {a.ActionID}, {b.ActionID}: {choice.ActionID}\n{a.Data.DebugLabel}\n{b.Data.DebugLabel}");
			return choice;
		}

		uint id = actions
			.Select(Selector)
			.Aggregate((a1, a2) => Compare(preference, a1, a2))
			.ActionID;
		Service.Logger.debug($"Final selection: {id}");
		return id;
	}

	[Obsolete("Makes advanced logic a little harder to implement and tends to look messy", true)]
	protected static bool PartialChainCombo(byte level, uint last, out uint next, params (byte lvl, uint id)[] sequence) {
		next = 0;

		// Shortcut out if there's no previous combo move
		if (last == 0)
			return false;

		// Work backwards, find the latest item in the chain that can be used (level >= lvl) and is ready to be used (last == prev.id)
		for (int i = sequence.Length - 1; i > 0; --i) {
			(byte lvl, uint id) = sequence[i];
			uint prev = sequence[i - 1].id;
			if (level >= lvl && prev == last) {
				next = id;
				return true;
			}
		}

		// If nothing is found, then return false to indicate that this case doesn't apply
		return false;
	}

	[Obsolete("Makes advanced logic MUCH harder to implement, use PartialChainCombo if absolutely necessary", true)]
	protected static uint SimpleChainCombo(byte level, uint last, float time, params (byte lvl, uint id)[] sequence) {
		if (time > 0 && PartialChainCombo(level, last, out uint next, sequence))
			return next;
		return sequence[0].id;
	}

	protected static bool IsJob(params uint[] jobs) {
		PlayerCharacter? p = LocalPlayer;
		if (p is null)
			return false;
		uint current = p.ClassJob.Id;
		foreach (uint job in jobs) {
			if (current == job)
				return true;
		}
		return false;
	}

	protected internal static uint OriginalHook(uint actionID)
		=> Service.IconReplacer.OriginalHook(actionID);

	protected static bool IsOriginal(uint actionID)
		=> OriginalHook(actionID) == actionID;

	#endregion

	#region Player details/stats

	protected static PlayerCharacter LocalPlayer
		=> Service.Client.LocalPlayer!;

	protected internal static bool HasCondition(ConditionFlag flag)
		=> Service.Conditions[flag];

	protected internal static bool InCombat
		=> Service.Conditions[ConditionFlag.InCombat];

	protected internal static bool HasPetPresent
		=> Service.BuddyList.PetBuddyPresent;

	protected static double PlayerHealthPercentage
		=> (double)LocalPlayer.CurrentHp / LocalPlayer.MaxHp * 100.0;

	protected internal static bool ShouldSwiftcast
		=> IsOffCooldown(Common.Swiftcast)
			&& !SelfHasEffect(Common.Buffs.LostChainspell)
			&& !SelfHasEffect(RDM.Buffs.Dualcast);
	protected internal static bool IsFastcasting
		=> SelfHasEffect(Common.Buffs.Swiftcast1)
			|| SelfHasEffect(Common.Buffs.Swiftcast2)
			|| SelfHasEffect(Common.Buffs.Swiftcast3)
			|| SelfHasEffect(RDM.Buffs.Dualcast)
			|| SelfHasEffect(Common.Buffs.LostChainspell);

	protected internal static T GetJobGauge<T>() where T : JobGaugeBase
		=> Service.DataCache.GetJobGauge<T>();

	protected internal static unsafe bool IsMoving
		=> AgentMap.Instance() is not null && AgentMap.Instance()->IsPlayerMoving > 0;

	#endregion

	#region Target details/stats

	protected static GameObject? CurrentTarget
		=> Service.Targets.Target;

	protected static bool HasTarget
		=> CurrentTarget is not null;
	protected internal static bool CanInterrupt
		=> Service.DataCache.CanInterruptTarget;

	protected internal static double TargetDistance {
		get {
			if (LocalPlayer is null || CurrentTarget is null)
				return 0;

			GameObject target = CurrentTarget;

			Vector2 tPos = new(target.Position.X, target.Position.Z);
			Vector2 sPos = new(LocalPlayer.Position.X, LocalPlayer.Position.Z);

			return Vector2.Distance(tPos, sPos) - target.HitboxRadius - LocalPlayer.HitboxRadius;
		}
	}
	protected internal static bool InMeleeRange
		=> TargetDistance <= 3;

	protected static double TargetCurrentHp
		=> CurrentTarget is BattleChara npc ? npc.CurrentHp : 0;
	protected static double TargetMaxHp
		=> CurrentTarget is BattleChara npc ? npc.MaxHp : 0;
	protected static double TargetHealthPercentage
		=> CurrentTarget is BattleChara npc ? npc.CurrentHp / npc.MaxHp * 100 : 0;

	#endregion

	#region Cooldowns and charges

	protected internal static CooldownData GetCooldown(uint actionID)
		=> Service.DataCache.GetCooldown(actionID);

	protected internal static bool IsOnCooldown(uint actionID)
		=> GetCooldown(actionID).IsCooldown;

	protected internal static bool IsOffCooldown(uint actionID)
		=> !GetCooldown(actionID).IsCooldown;

	protected internal static bool HasCharges(uint actionID)
		=> GetCooldown(actionID).HasCharges;

	protected internal static bool CanUse(uint actionID)
		=> GetCooldown(actionID).Available;

	protected internal static bool CanWeave(uint actionID, double weaveTime = 0.7)
	   => GetCooldown(actionID).CooldownRemaining > weaveTime;
	protected internal static bool CanSpellWeave(uint actionID, double weaveTime = 0.5)
		=> GetCooldown(actionID).CooldownRemaining > weaveTime && !LocalPlayer.IsCasting;

	#endregion

	#region Effects

	protected internal static Status? SelfFindEffect(ushort effectId)
		=> FindEffect(effectId, LocalPlayer, null);
	protected internal static bool SelfHasEffect(ushort effectId)
		=> SelfFindEffect(effectId) is not null;
	protected internal static float SelfEffectDuration(ushort effectId)
		=> SelfFindEffect(effectId)?.RemainingTime ?? 0;
	protected internal static float SelfEffectStacks(ushort effectId)
		=> SelfFindEffect(effectId)?.StackCount ?? 0;

	protected internal static Status? TargetFindAnyEffect(ushort effectId)
		=> FindEffect(effectId, CurrentTarget, null);
	protected internal static bool TargetHasAnyEffect(ushort effectId)
		=> TargetFindAnyEffect(effectId) is not null;
	protected internal static float TargetAnyEffectDuration(ushort effectId)
		=> TargetFindAnyEffect(effectId)?.RemainingTime ?? 0;
	protected internal static float TargetAnyEffectStacks(ushort effectId)
		=> TargetFindAnyEffect(effectId)?.StackCount ?? 0;

	protected internal static Status? TargetFindOwnEffect(ushort effectId)
		=> FindEffect(effectId, CurrentTarget, LocalPlayer?.ObjectId);
	protected internal static bool TargetHasOwnEffect(ushort effectId)
		=> TargetFindOwnEffect(effectId) is not null;
	protected internal static float TargetOwnEffectDuration(ushort effectId)
		=> TargetFindOwnEffect(effectId)?.RemainingTime ?? 0;
	protected internal static float TargetOwnEffectStacks(ushort effectId)
		=> TargetFindOwnEffect(effectId)?.StackCount ?? 0;

	protected internal static Status? FindEffect(ushort effectId, GameObject? actor, uint? sourceId)
		=> Service.DataCache.GetStatus(effectId, actor, sourceId);

	#endregion

	#region Job-specific utilities

	protected internal static uint DancerDancing() {
		DNCGauge gauge = GetJobGauge<DNCGauge>();

		if (gauge.IsDancing) {
			bool fast = SelfHasEffect(DNC.Buffs.StandardStep);
			int max = fast ? 2 : 4;

			if (gauge.CompletedSteps >= max)
				return OriginalHook(fast ? DNC.StandardStep : DNC.TechnicalStep);

			return gauge.NextStep;
		}

		return 0;
	}

	#endregion
}
