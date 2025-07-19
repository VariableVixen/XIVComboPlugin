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

		if (this.JobID > 0 && this.JobID != classJobID && this.ClassID != classJobID)
			return false;
		if (this.affectedIDs.Count > 0 && !this.affectedIDs.Contains(actionID))
			return false;
		if (!IsEnabled(this.Preset))
			return false;

		if (comboTime <= 0)
			lastComboActionId = 0;

		Service.TickLogger.Info($"{this.ModuleName}.Invoke({actionID}, {lastComboActionId}, {comboTime}, {level})");
		try {
			uint resultingActionID = this.Invoke(actionID, lastComboActionId, comboTime, level);
			if (resultingActionID == 0 || actionID == resultingActionID) {
				Service.TickLogger.Info("NO REPLACEMENT");
				return false;
			}

			Service.TickLogger.Info($"Became #{resultingActionID}");
			newActionID = resultingActionID;
			return true;
		}
		catch (Exception ex) {
			Service.TickLogger.Error($"Error in {this.ModuleName}.Invoke({actionID}, {lastComboActionId}, {comboTime}, {level})", ex);
			return false;
		}
	}
	protected abstract uint Invoke(uint actionID, uint lastComboActionId, float comboTime, byte level);

	protected static bool IsEnabled(CustomComboPreset preset) {
		if ((int)preset < 0) {
			Service.TickLogger.Info($"Aborting is-enabled check, {preset}#{(int)preset} is forcibly disabled");
			return false;
		}
		if ((int)preset < 100) {
			Service.TickLogger.Info($"Bypassing is-enabled check for preset #{(int)preset}");
			return true;
		}
		bool enabled = Service.Configuration.IsEnabled(preset);
		Service.TickLogger.Info($"Checking status of preset #{(int)preset} - {enabled}");
		return enabled;
	}

	#region Caching

	// Invalidate these
	private static readonly Dictionary<(uint StatusID, uint? TargetID, uint? SourceID), Status?> statusCache = [];
	private static readonly Dictionary<uint, CooldownData> cooldownCache = [];
	private static bool? canInterruptTarget = null;
	private static uint? dancerNextDanceStep = null;

	// Do not invalidate these
	private static readonly Dictionary<uint, byte> cooldownGroupCache = [];
	private static readonly Dictionary<Type, JobGaugeBase> jobGaugeCache = [];
	private static readonly Dictionary<(uint ActionID, uint ClassJobID, byte Level), (ushort CurrentMax, ushort Max)> chargesCache = [];

	// These are updated directly, not actually invalidated
	protected static IPlayerCharacter LocalPlayer { get; private set; } = null!;

	// vixen and the terrible horrible no good very bad hack
	internal static IPlayerCharacter? CachedLocalPlayer => LocalPlayer;

	internal static void ResetCache(IPlayerCharacter player) {
		statusCache.Clear();
		cooldownCache.Clear();
		canInterruptTarget = null;
		dancerNextDanceStep = null;
		LocalPlayer = player;
	}

	#endregion

	#region Common calculations and shortcuts

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

			Service.TickLogger.Debug($"CDCMP: {a.ActionID}, {b.ActionID}: {choice.ActionID}\n{a.Data.DebugLabel}\n{b.Data.DebugLabel}");
			return choice;
		}

		uint id = actions
			.Select(selector)
			.Aggregate((a1, a2) => compare(preference, a1, a2))
			.ActionID;
		Service.TickLogger.Info($"Final selection: {id}");
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
		Service.TickLogger.Debug($"Retrieved cooldown data for action #{actionID}: {cd.DebugLabel}");
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

	protected static Status? FindEffect(uint statusID, IGameObject? actor, uint? sourceID) {
		(uint statusID, uint? ObjectId, uint? sourceID) key = (statusID, actor?.EntityId, sourceID);
		if (statusCache.TryGetValue(key, out Status? found))
			return found;

		if (actor is null)
			return statusCache[key] = null;

		if (actor is not IBattleChara chara)
			return statusCache[key] = null;

		foreach (Status? status in chara.StatusList) {
			if (status.StatusId == statusID && (!sourceID.HasValue || status.SourceId == 0 || status.SourceId == InvalidObjectID || status.SourceId == sourceID))
				return statusCache[key] = status;
		}

		return statusCache[key] = null;
	}

	#endregion

	#region Job-specific utilities
	// These are only in here - at the abstract root class of all combos everywhere - because they need to access cached values.
	// I don't want those cached values to be accessible from anywhere outside of CustomCombo and its children, because they're
	// only reset JUST before any combos run, so as to avoid unnecessary work.
#pragma warning disable IDE0045 // Convert to conditional expression - helper function readability

	internal static bool CheckLucidWeave(CustomComboPreset preset, byte level, uint manaThreshold, uint baseAction) {

		if (IsEnabled(preset)) {
			if (level >= Common.Levels.LucidDreaming) {
				if (LocalPlayer.CurrentMp < manaThreshold) {
					if (CanWeave(baseAction)) {
						if (CanUse(Common.LucidDreaming))
							return true;
					}
				}
			}
		}

		return false;
	}

	protected static bool DancerSmartDancing(out uint nextStep) {
		if (dancerNextDanceStep is null) {
			DNCGauge gauge = GetJobGauge<DNCGauge>();

			if (gauge.IsDancing) {
				bool fast = SelfHasEffect(DNC.Buffs.StandardStep);
				int max = fast ? 2 : 4;

				dancerNextDanceStep = gauge.CompletedSteps >= max
					? OriginalHook(fast ? DNC.StandardStep : DNC.TechnicalStep)
					: gauge.NextStep;
			}
			else {
				dancerNextDanceStep = 0;
			}
		}

		nextStep = dancerNextDanceStep.Value;
		return nextStep > 0;
	}
	public static byte RedmageManaForMeleeChain(byte level) {
		byte mana = RDM.ManaCostMelee1;
		if (level >= RDM.Levels.Zwerchhau) {
			mana += RDM.ManaCostMelee2;
			if (level >= RDM.Levels.Redoublement)
				mana += RDM.ManaCostMelee3;
		}
		return mana;
	}

	public static bool RedmageCheckFinishers(ref uint actionID, uint lastComboMove, byte level) {
		const int
			finisherDelta = 11,
			imbalanceDiffMax = 30;

		if (lastComboMove is RDM.Verflare or RDM.Verholy && level >= RDM.Levels.Scorch) {
			actionID = RDM.Scorch;
			return true;
		}

		if (lastComboMove is RDM.Scorch && level >= RDM.Levels.Resolution) {
			actionID = RDM.Resolution;
			return true;
		}

		RDMGauge gauge = GetJobGauge<RDMGauge>();

		if (gauge.ManaStacks == 3 && level >= RDM.Levels.Verflare) {
			int black = gauge.BlackMana;
			int white = gauge.WhiteMana;
			bool canFinishWhite = level >= RDM.Levels.Verholy;
			int blackThreshold = white + imbalanceDiffMax;
			int whiteThreshold = black + imbalanceDiffMax;
			bool verfireUp = level >= RDM.Levels.Verfire && SelfHasEffect(RDM.Buffs.VerfireReady);
			bool verstoneUp = level >= RDM.Levels.Verstone && SelfHasEffect(RDM.Buffs.VerstoneReady);

			if (black >= white && canFinishWhite) {
				// If we can already Verstone, but we can't Verfire, and Verflare WON'T imbalance us, use Verflare
				if (verstoneUp && !verfireUp && black + finisherDelta <= blackThreshold)
					actionID = RDM.Verflare;
				else
					actionID = RDM.Verholy;
			}
			// If we can already Verfire, but we can't Verstone, and we can use Verholy, and it WON'T imbalance us, use Verholy
			else if (verfireUp && !verstoneUp && canFinishWhite && white + finisherDelta <= whiteThreshold) {
				actionID = RDM.Verholy;
			}
			else {
				actionID = RDM.Verflare;
			}

			return true;
		}

		return false;
	}

	public static bool RedmageCheckMeleeST(ref uint actionID, uint lastComboMove, byte level, bool checkComboStart) {
		RDMGauge gauge = GetJobGauge<RDMGauge>();
		byte black = gauge.BlackMana;
		byte white = gauge.WhiteMana;
		byte mana = black != white || black == 100
			? Math.Min(black, white)
			: (byte)0;
		bool buff = level >= RDM.Levels.Manafication && SelfHasEffect(RDM.Buffs.MagickedSwordplay);

		if (lastComboMove is RDM.Zwerchhau or RDM.EnchantedZwerchhau && level >= RDM.Levels.Redoublement && (buff || mana >= RDM.ManaCostMelee3)) {
			actionID = RDM.EnchantedRedoublement;
			return true;
		}

		if (lastComboMove is RDM.Riposte or RDM.EnchantedRiposte && level >= RDM.Levels.Zwerchhau && (buff || mana >= RDM.ManaCostMelee2)) {
			actionID = RDM.EnchantedZwerchhau;
			return true;
		}

		if (checkComboStart && (buff || mana >= RedmageManaForMeleeChain(level))) {
			actionID = RDM.EnchantedRiposte;
			return true;
		}

		return false;
	}

	public static bool RedmageCheckMeleeAOE(ref uint actionID, uint lastComboMove, byte level, bool checkComboStart) {
		if (level < RDM.Levels.EnchantedMoulinets)
			return false;

		RDMGauge gauge = GetJobGauge<RDMGauge>();
		byte mana = Math.Min(gauge.BlackMana, gauge.WhiteMana);
		bool buff = level >= RDM.Levels.Manafication && SelfHasEffect(RDM.Buffs.MagickedSwordplay);

		if (lastComboMove is RDM.EnchantedMoulinetDeux && (buff || mana >= RDM.ManaCostMelee3)) {
			actionID = RDM.EnchantedMoulinetTrois;
			return true;
		}

		if (lastComboMove is RDM.Moulinet or RDM.EnchantedMoulinet && (buff || mana >= RDM.ManaCostMelee2)) {
			actionID = RDM.EnchantedMoulinetDeux;
			return true;
		}

		if (checkComboStart && (buff || mana >= RDM.ManaCostMelee1)) {
			actionID = RDM.EnchantedMoulinet;
			return true;
		}

		return false;
	}

	public static bool RedmageCheckPrefulgenceThorns(uint actionID, out uint replacementID, byte level, bool allowPrefulgence = true, bool allowThorns = true) {
		replacementID = actionID;
		return CheckPrefulgenceThorns(ref replacementID, level, allowPrefulgence, allowThorns);
	}
	public static bool CheckPrefulgenceThorns(ref uint actionID, byte level, bool allowPrefulgence = true, bool allowThorns = true) {
		if (!allowPrefulgence && !allowThorns) // nothing to do
			return false;

		float prefulgenceTimeLeft = allowPrefulgence && level >= RDM.Levels.Prefulgence
			? SelfEffectDuration(RDM.Buffs.PrefulgenceReady)
			: 0f;
		float thornsTimeLeft = allowThorns && level >= RDM.Levels.ViceOfThorns
			? SelfEffectDuration(RDM.Buffs.ThornedFlourish)
			: 0f;

		if (prefulgenceTimeLeft > 0) {

			// If we're almost out of time to use VoT but Prefulgence has enough time left to use VoT and also itself, use VoT first to save it from being lost
			if (thornsTimeLeft is > 0 and < 3 && prefulgenceTimeLeft >= 3)
				actionID = RDM.ViceOfThorns;
			else
				actionID = RDM.Prefulgence;

			return true;
		}

		if (thornsTimeLeft > 0) {
			actionID = RDM.ViceOfThorns;
			return true;
		}

		return false;
	}

	public static bool RedmageCheckAbilityAttacks(ref uint actionID, byte level, CustomComboPreset checkPrefulgence, CustomComboPreset checkThorns) {
		if (!IsEnabled(CustomComboPreset.RedMageContreFleche))
			return false;

		bool
			allowPrefulgence = IsEnabled(checkPrefulgence),
			allowThorns = IsEnabled(checkThorns);
		if (CheckPrefulgenceThorns(ref actionID, level, allowPrefulgence, allowThorns))
			return true;

		if (level >= RDM.Levels.ContreSixte) {
			actionID = PickByCooldown(actionID, RDM.Fleche, RDM.ContreSixte);
			return true;
		}

		if (level >= RDM.Levels.Fleche) {
			actionID = RDM.Fleche;
			return true;
		}

		return false;
	}

#pragma warning restore IDE0045 // Convert to conditional expression
	#endregion
}
