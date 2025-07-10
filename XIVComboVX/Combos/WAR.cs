using Dalamud.Game.ClientState.JobGauge.Types;

namespace VariableVixen.XIVComboVX.Combos;

internal static class WAR {
	public const byte JobID = 21;

	public const uint
		HeavySwing = 31,
		Maim = 37,
		Berserk = 38,
		ThrillOfBattle = 40,
		Overpower = 41,
		StormsPath = 42,
		StormsEye = 45,
		Tomahawk = 46,
		InnerBeast = 49,
		SteelCyclone = 51,
		Infuriate = 52,
		FellCleave = 3549,
		Decimate = 3550,
		RawIntuition = 3551,
		Equilibrium = 3552,
		Upheaval = 7387,
		InnerRelease = 7389,
		MythrilTempest = 16462,
		ChaoticCyclone = 16463,
		NascentFlash = 16464,
		InnerChaos = 16465,
		Bloodwhetting = 25751,
		Orogeny = 25752,
		PrimalRend = 25753;

	public static class Buffs {
		public const ushort
			Berserk = 86,
			InnerRelease = 1177,
			NascentChaos = 1897,
			PrimalRendReady = 2624,
			PrimalRuinationReady = ushort.MaxValue,
			SurgingTempest = 2677;
	}

	public static class Debuffs {
		// public const ushort placeholder = 0;
	}

	public static class Levels {
		public const byte
			Maim = 4,
			Berserk = 6,
			Overpower = 10,
			Tomahawk = 15,
			StormsPath = 26,
			ThrillOfBattle = 30,
			InnerBeast = 35,
			MythrilTempest = 40,
			StormsEye = 50,
			Infuriate = 50,
			FellCleave = 54,
			RawIntuition = 56,
			Equilibrium = 58,
			Decimate = 60,
			Upheaval = 64,
			InnerRelease = 70,
			ChaoticCyclone = 72,
			MythrilTempestTrait = 74,
			NascentFlash = 76,
			InnerChaos = 80,
			Bloodwhetting = 82,
			Orogeny = 86,
			PrimalRend = 90;
	}
}

internal class WarriorStunInterruptFeature: StunInterruptCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.WarriorStunInterruptFeature;
}

internal class WarriorStormsPathCombo: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.WarriorStormsPathCombo;
	public override uint[] ActionIDs { get; } = [WAR.StormsPath];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (IsEnabled(CustomComboPreset.WarriorSmartWeaveSingleTargetPath)) {
			if (level >= WAR.Levels.Upheaval) {
				if (SelfHasEffect(WAR.Buffs.SurgingTempest) || !IsEnabled(CustomComboPreset.WarriorSmartWeaveSingleTargetPathOnlyBuffed)) {
					if (CanWeave(actionID) && CanUse(WAR.Upheaval))
						return WAR.Upheaval;
				}
			}
		}

		if (IsEnabled(CustomComboPreset.WarriorInnerReleaseFeature) && level >= WAR.Levels.InnerRelease && SelfHasEffect(WAR.Buffs.InnerRelease))
			return OriginalHook(WAR.FellCleave);

		uint finalAction = WAR.StormsPath;
		byte finalLevel = WAR.Levels.StormsPath;
		if (IsEnabled(CustomComboPreset.WarriorSmartStormCombo)) {
			if (level >= WAR.Levels.StormsEye) {
				if (SelfEffectDuration(WAR.Buffs.SurgingTempest) <= Service.Configuration.WarriorStormBuffSaverBuffTime) {
					finalAction = WAR.StormsEye;
					finalLevel = WAR.Levels.StormsEye;
				}
			}
		}

		bool inCombo = false;
		uint nextCombo = 0;
		if (lastComboMove is WAR.Maim && level >= finalLevel) {
			inCombo = true;
			nextCombo = finalAction;
		}
		if (lastComboMove is WAR.HeavySwing && level >= WAR.Levels.Maim) {
			inCombo = true;
			nextCombo = WAR.Maim;
		}

		if (IsEnabled(CustomComboPreset.WarriorGaugeOvercapPathFeature)) {
			if (level >= WAR.Levels.InnerBeast) {
				if (GetJobGauge<WARGauge>().BeastGauge > (inCombo ? 90 : 70))
					return OriginalHook(WAR.FellCleave);
			}
		}

		return inCombo ? nextCombo : WAR.HeavySwing;
	}
}

internal class WarriorStormsEyeCombo: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.WarriorStormsEyeCombo;
	public override uint[] ActionIDs { get; } = [WAR.StormsEye];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (IsEnabled(CustomComboPreset.WarriorSmartWeaveSingleTargetEye)) {
			if (level >= WAR.Levels.Upheaval) {
				if (SelfHasEffect(WAR.Buffs.SurgingTempest) || !IsEnabled(CustomComboPreset.WarriorSmartWeaveSingleTargetEyeOnlyBuffed)) {
					if (CanWeave(actionID) && CanUse(WAR.Upheaval))
						return WAR.Upheaval;
				}
			}
		}

		if (IsEnabled(CustomComboPreset.WarriorInnerReleaseFeature)) {
			if (level >= WAR.Levels.InnerRelease) {
				if (SelfHasEffect(WAR.Buffs.InnerRelease))
					return OriginalHook(WAR.FellCleave);
			}
		}

		bool inCombo = false;
		uint nextCombo = 0;
		if (lastComboMove is WAR.Maim && level >= WAR.Levels.StormsEye) {
			inCombo = true;
			nextCombo = IsEnabled(CustomComboPreset.WarriorStormsEyeBuffOvercapSaver) && SelfEffectDuration(WAR.Buffs.SurgingTempest) > 30
				? WAR.StormsPath
				: WAR.StormsEye;
		}
		if (lastComboMove is WAR.HeavySwing && level >= WAR.Levels.Maim) {
			inCombo = true;
			nextCombo = WAR.Maim;
		}

		if (IsEnabled(CustomComboPreset.WarriorGaugeOvercapEyeFeature)) {
			if (level >= WAR.Levels.InnerBeast) {
				if (GetJobGauge<WARGauge>().BeastGauge > (inCombo ? 90 : 80))
					return OriginalHook(WAR.FellCleave);
			}
		}

		return inCombo ? nextCombo : WAR.HeavySwing;
	}
}

internal class WarriorMythrilTempestCombo: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.WarriorMythrilTempestCombo;

	public override uint[] ActionIDs { get; } = [WAR.MythrilTempest];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (IsEnabled(CustomComboPreset.WarriorSmartWeaveAOE)) {
			if (level >= WAR.Levels.Orogeny) {
				if (SelfHasEffect(WAR.Buffs.SurgingTempest) || !IsEnabled(CustomComboPreset.WarriorSmartWeaveAOEOnlyBuffed)) {
					if (CanWeave(actionID) && CanUse(WAR.Orogeny))
						return WAR.Orogeny;
				}
			}
		}

		if (IsEnabled(CustomComboPreset.WarriorInnerReleaseFeature)) {
			if (SelfHasEffect(WAR.Buffs.InnerRelease))
				return OriginalHook(WAR.Decimate);
		}

		bool inCombo = false;
		uint nextCombo = 0;
		if (lastComboMove is WAR.Overpower && level >= WAR.Levels.MythrilTempest) {
			inCombo = true;
			nextCombo = WAR.MythrilTempest;
		}

		if (IsEnabled(CustomComboPreset.WarriorGaugeOvercapTempestFeature)) {
			if (level >= WAR.Levels.MythrilTempestTrait) {
				if (GetJobGauge<WARGauge>().BeastGauge > (inCombo ? 90 : 80))
					return OriginalHook(WAR.Decimate);
			}
		}

		return inCombo ? nextCombo : WAR.Overpower;
	}
}

internal class WarriorNascentFlashFeature: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.WarriorNascentFlashFeature;
	public override uint[] ActionIDs { get; } = [WAR.NascentFlash];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (level < WAR.Levels.NascentFlash)
			return WAR.RawIntuition;

		return actionID;
	}
}

internal class WarriorFellCleaveDecimate: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.WarAny;
	public override uint[] ActionIDs { get; } = [WAR.InnerBeast, WAR.FellCleave, WAR.SteelCyclone, WAR.Decimate];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (IsEnabled(CustomComboPreset.WarriorPrimalBeastFeature)) {
			if (level >= WAR.Levels.PrimalRend && SelfHasEffect(WAR.Buffs.PrimalRendReady))
				return WAR.PrimalRend;
		}

		uint normal = OriginalHook(actionID);

		if (IsEnabled(CustomComboPreset.WarriorInfuriateBeastFeature) && level >= WAR.Levels.Infuriate) {
			WARGauge gauge = GetJobGauge<WARGauge>();
			int threshold = IsEnabled(CustomComboPreset.WarriorInfuriateBeastRaidModeFeature)
				? 60
				: 50;

			if (gauge.BeastGauge >= 50 && normal is WAR.InnerChaos or WAR.ChaoticCyclone)
				return normal;

			if (gauge.BeastGauge < threshold && !SelfHasEffect(WAR.Buffs.InnerRelease))
				return WAR.Infuriate;
		}

		return normal;
	}
}

internal class WarriorBerserkInnerRelease: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.WarriorPrimalReleaseFeature;
	public override uint[] ActionIDs { get; } = [WAR.Berserk, WAR.InnerRelease];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (level >= WAR.Levels.PrimalRend && (SelfHasEffect(WAR.Buffs.PrimalRendReady) || SelfHasEffect(WAR.Buffs.PrimalRuinationReady)))
			return OriginalHook(WAR.PrimalRend);

		return actionID;
	}
}

internal class WarriorBloodwhetting: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.WarriorHealthyBalancedDietFeature;
	public override uint[] ActionIDs { get; } = [WAR.Bloodwhetting, WAR.RawIntuition];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
		uint rawBlood = OriginalHook(WAR.RawIntuition);

		if (level >= WAR.Levels.RawIntuition && IsOffCooldown(rawBlood))
			return rawBlood;

		if (level >= WAR.Levels.ThrillOfBattle && IsOffCooldown(WAR.ThrillOfBattle))
			return WAR.ThrillOfBattle;

		if (level >= WAR.Levels.Equilibrium && IsOffCooldown(WAR.Equilibrium))
			return WAR.Equilibrium;

		return actionID;
	}
}
