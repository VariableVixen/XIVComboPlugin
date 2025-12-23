using Dalamud.Game.ClientState.JobGauge.Types;
using Dalamud.Game.ClientState.Statuses;

namespace VariableVixen.XIVComboVX.Combos;

internal static class DNC {
	public const byte JobID = 38;

	public const uint
		// Single Target
		Cascade = 15989,
		Fountain = 15990,
		ReverseCascade = 15991,
		Fountainfall = 15992,
		// AoE
		Windmill = 15993,
		Bladeshower = 15994,
		RisingWindmill = 15995,
		Bloodshower = 15996,
		// Dancing
		StandardStep = 15997,
		TechnicalStep = 15998,
		Tillana = 25790,
		// Fans
		FanDance1 = 16007,
		FanDance2 = 16008,
		FanDance3 = 16009,
		FanDance4 = 25791,
		// Other
		CuringWaltz = 16015,
		SecondWind = 7541,
		SaberDance = 16005,
		EnAvant = 16010,
		Devilment = 16011,
		Flourish = 16013,
		Improvisation = 16014,
		StarfallDance = 25792,
		LastDance = 36983,
		DanceOfTheDawn = 36985,
		FinishingMove = 36984;

	public static class Buffs {
		public const ushort
			ShieldSamba = 1826,
			FlourishingSymmetry = 3017,
			FlourishingFlow = 3018,
			FlourishingFinish = 2698,
			FlourishingStarfall = 2700,
			SilkenSymmetry = 2693,
			SilkenFlow = 2694,
			StandardStep = 1818,
			TechnicalStep = 1819,
			ThreefoldFanDance = 1820,
			FourfoldFanDance = 2699,
			LastDanceReady = 3867,
			DanceOfTheDawnReady = 3869,
			FinishingMoveReady = 3868;
	}

	public static class Debuffs {
		// public const ushort placeholder = 0;
	}

	public static class Levels {
		public const byte
			Fountain = 2,
			Windmill = 15,
			StandardStep = 15,
			ReverseCascade = 20,
			Bladeshower = 25,
			FanDance1 = 30,
			RisingWindmill = 35,
			Fountainfall = 40,
			Bloodshower = 45,
			FanDance2 = 50,
			CuringWaltz = 52,
			Devilment = 62,
			FanDance3 = 66,
			TechnicalStep = 70,
			Flourish = 72,
			SaberDance = 76, // [sic] - should be Sabre but america
			Tillana = 82,
			FanDance4 = 86,
			StarfallDance = 90;

	}
}

internal abstract class DancerCombo: CustomCombo {
#pragma warning disable IDE0045 // Convert to conditional expression - helper function readability

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

#pragma warning restore IDE0045 // Convert to conditional expression
}

internal class DancerDanceComboCompatibility: DancerCombo {
	public override CustomComboPreset Preset => CustomComboPreset.DancerDanceComboCompatibility;
	public override uint[] ActionIDs => [
		Service.Configuration.DancerEmboiteRedActionID,
		Service.Configuration.DancerEntrechatBlueActionID,
		Service.Configuration.DancerJeteGreenActionID,
		Service.Configuration.DancerPirouetteYellowActionID,
	];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
		if (level >= DNC.Levels.StandardStep && GetJobGauge<DNCGauge>().IsDancing) {
			uint[] actionIDs = this.ActionIDs;

			if (actionID == actionIDs[0])
				return OriginalHook(DNC.Cascade);

			if (actionID == actionIDs[1])
				return OriginalHook(DNC.Fountain);

			if (actionID == actionIDs[2])
				return OriginalHook(DNC.ReverseCascade);

			if (actionID == actionIDs[3])
				return OriginalHook(DNC.Fountainfall);

		}

		return actionID;
	}
}

internal class DancerFanDanceCombos: DancerCombo {
	public override CustomComboPreset Preset => CustomComboPreset.DncAny;
	public override uint[] ActionIDs { get; } = [DNC.FanDance1, DNC.FanDance2];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
		bool can4 = level >= DNC.Levels.FanDance4 && SelfHasEffect(DNC.Buffs.FourfoldFanDance);
		bool can3 = level >= DNC.Levels.FanDance3 && SelfHasEffect(DNC.Buffs.ThreefoldFanDance);

		if (actionID is DNC.FanDance1) {
			if (IsEnabled(CustomComboPreset.DancerFanDance14Combo) && can4)
				return DNC.FanDance4;
			if (IsEnabled(CustomComboPreset.DancerFanDance13Combo) && can3)
				return DNC.FanDance3;
		}
		else if (actionID is DNC.FanDance2) {
			if (IsEnabled(CustomComboPreset.DancerFanDance24Combo) && can4)
				return DNC.FanDance4;
			if (IsEnabled(CustomComboPreset.DancerFanDance23Combo) && can3)
				return DNC.FanDance3;
		}

		return actionID;
	}
}

internal class DancerDanceStepCombo: DancerCombo {
	public override CustomComboPreset Preset => CustomComboPreset.DancerDanceStepCombo;
	public override uint[] ActionIDs { get; } = [DNC.StandardStep, DNC.TechnicalStep];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
		if (level >= DNC.Levels.StandardStep && DancerSmartDancing(out uint danceStep))
			return danceStep;

		if (level >= DNC.Levels.TechnicalStep) {

			if (SelfHasEffect(DNC.Buffs.FlourishingFinish) && GetCooldown(DNC.StandardStep).CooldownRemaining >= 3) // tillana does esprit +50, check for that?
				return DNC.Tillana;

			if (IsEnabled(CustomComboPreset.DancerDanceStepComboSmartStandard) && CanUse(DNC.TechnicalStep) && GetCooldown(DNC.StandardStep).CooldownRemaining > 3)
				return DNC.TechnicalStep;

			if (IsEnabled(CustomComboPreset.DancerDanceStepComboSmartTechnical) && !CanUse(DNC.TechnicalStep) && CanUse(DNC.StandardStep))
				return DNC.StandardStep;

		}
		else if (IsEnabled(CustomComboPreset.DancerDanceStepComboSmartTechnical)) {
			return DNC.StandardStep;
		}

		return actionID;
	}
}

internal class DancerFlourishFeature: DancerCombo {
	public override CustomComboPreset Preset => CustomComboPreset.DancerFlourishFeature;
	public override uint[] ActionIDs { get; } = [DNC.Flourish];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (level >= DNC.Levels.FanDance4 && SelfHasEffect(DNC.Buffs.FourfoldFanDance))
			return DNC.FanDance4;

		return actionID;
	}
}

internal class DancerSingleTargetMultibutton: DancerCombo {
	public override CustomComboPreset Preset => CustomComboPreset.DancerSingleTargetMultibutton;
	public override uint[] ActionIDs { get; } = [DNC.Cascade];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
		if (IsEnabled(CustomComboPreset.DancerSmartDanceFeature)) {
			if (level >= DNC.Levels.StandardStep && DancerSmartDancing(out uint danceStep))
				return danceStep;
		}

		DNCGauge gauge = GetJobGauge<DNCGauge>();

		if (CanWeave(actionID)) {

			if (IsEnabled(CustomComboPreset.DancerSingleTargetFanDanceWeave)) {

				if (level >= DNC.Levels.FanDance1) {
					if (level >= DNC.Levels.FanDance3 && SelfHasEffect(DNC.Buffs.ThreefoldFanDance))
						return DNC.FanDance3;
					else if (gauge.Feathers > 0)
						return DNC.FanDance1;
				}

				if (IsEnabled(CustomComboPreset.DancerSingleTargetFanDanceFallback)) {
					if (level >= DNC.Levels.FanDance2) {
						if (level >= DNC.Levels.FanDance4 && SelfHasEffect(DNC.Buffs.FourfoldFanDance))
							return DNC.FanDance4;
						else if (gauge.Feathers > 0)
							return DNC.FanDance2;
					}
				}

			}

			if (IsEnabled(CustomComboPreset.DancerSingleTargetFlourishWeave)) {
				if (level >= DNC.Levels.Flourish && InCombat && CanUse(DNC.Flourish)) {
					if (!(
						SelfHasEffect(DNC.Buffs.FlourishingSymmetry)
						|| SelfHasEffect(DNC.Buffs.FlourishingFlow)
						|| SelfHasEffect(DNC.Buffs.ThreefoldFanDance)
						|| SelfHasEffect(DNC.Buffs.FourfoldFanDance)
					)) {
						return DNC.Flourish;
					}
				}
			}

			if (IsEnabled(CustomComboPreset.DancerSingleTargetDevilmentWeave) && level >= DNC.Levels.Devilment) {
				if (CanUse(DNC.Devilment))
					return DNC.Devilment;
			}

		}

		if (IsEnabled(CustomComboPreset.DancerSingleTargetStarfall) && level >= DNC.Levels.StarfallDance) {
			IStatus? starfall = SelfFindEffect(DNC.Buffs.FlourishingStarfall);
			if (starfall is not null && starfall.RemainingTime <= Service.Configuration.DancerSingleTargetStarfallBuffThreshold)
				return DNC.StarfallDance;
		}

		if (IsEnabled(CustomComboPreset.DancerSingleTargetGaugeSpender) && level >= DNC.Levels.SaberDance && gauge.Esprit >= Service.Configuration.DancerSingleTargetGaugeThreshold)
			return OriginalHook(DNC.SaberDance);

		if (level >= DNC.Levels.Fountainfall && (SelfHasEffect(DNC.Buffs.FlourishingFlow) || SelfHasEffect(DNC.Buffs.SilkenFlow)))
			return DNC.Fountainfall;

		if (level >= DNC.Levels.ReverseCascade && (SelfHasEffect(DNC.Buffs.FlourishingSymmetry) || SelfHasEffect(DNC.Buffs.SilkenSymmetry)))
			return DNC.ReverseCascade;

		if (lastComboMove is DNC.Cascade && level >= DNC.Levels.Fountain)
			return DNC.Fountain;

		return actionID;
	}
}

internal class DancerAoeMultibutton: DancerCombo {
	public override CustomComboPreset Preset => CustomComboPreset.DancerAoeMultibutton;
	public override uint[] ActionIDs { get; } = [DNC.Windmill];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
		if (IsEnabled(CustomComboPreset.DancerSmartDanceFeature)) {
			if (level >= DNC.Levels.StandardStep && DancerSmartDancing(out uint danceStep))
				return danceStep;
		}

		DNCGauge gauge = GetJobGauge<DNCGauge>();

		if (CanWeave(actionID)) {

			if (IsEnabled(CustomComboPreset.DancerAoeFanDanceWeave)) {

				if (level >= DNC.Levels.FanDance2) {
					if (level >= DNC.Levels.FanDance4 && SelfHasEffect(DNC.Buffs.FourfoldFanDance))
						return DNC.FanDance4;
					else if (gauge.Feathers > 0)
						return DNC.FanDance2;
				}

				if (IsEnabled(CustomComboPreset.DancerAoeFanDanceFallback)) {
					if (level >= DNC.Levels.FanDance1) {
						if (level >= DNC.Levels.FanDance3 && SelfHasEffect(DNC.Buffs.ThreefoldFanDance))
							return DNC.FanDance3;
						else if (gauge.Feathers > 0)
							return DNC.FanDance1;
					}
				}

			}

			if (IsEnabled(CustomComboPreset.DancerAoeFlourishWeave)) {
				if (level >= DNC.Levels.Flourish && InCombat && CanUse(DNC.Flourish)) {
					if (!(
						SelfHasEffect(DNC.Buffs.FlourishingSymmetry)
						|| SelfHasEffect(DNC.Buffs.FlourishingFlow)
						|| SelfHasEffect(DNC.Buffs.ThreefoldFanDance)
						|| SelfHasEffect(DNC.Buffs.FourfoldFanDance)
					)) {
						return DNC.Flourish;
					}
				}
			}

		}

		if (IsEnabled(CustomComboPreset.DancerAoeStarfall) && level >= DNC.Levels.StarfallDance) {
			IStatus? starfall = SelfFindEffect(DNC.Buffs.FlourishingStarfall);
			if (starfall is not null && starfall.RemainingTime <= Service.Configuration.DancerAoeStarfallBuffThreshold)
				return DNC.StarfallDance;
		}

		if (IsEnabled(CustomComboPreset.DancerAoeGaugeSpender) && level >= DNC.Levels.SaberDance && gauge.Esprit >= Service.Configuration.DancerAoeGaugeThreshold)
			return OriginalHook(DNC.SaberDance);

		if (level >= DNC.Levels.Bloodshower && (SelfHasEffect(DNC.Buffs.FlourishingFlow) || SelfHasEffect(DNC.Buffs.SilkenFlow)))
			return DNC.Bloodshower;

		if (level >= DNC.Levels.RisingWindmill && (SelfHasEffect(DNC.Buffs.FlourishingSymmetry) || SelfHasEffect(DNC.Buffs.SilkenSymmetry)))
			return DNC.RisingWindmill;

		if (lastComboMove is DNC.Windmill && level >= DNC.Levels.Bladeshower)
			return DNC.Bladeshower;

		return actionID;
	}
}

internal class DancerDevilmentFeature: DancerCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.DancerDevilmentFeature;
	public override uint[] ActionIDs { get; } = [DNC.Devilment];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (level >= DNC.Levels.StarfallDance && SelfHasEffect(DNC.Buffs.FlourishingStarfall))
			return DNC.StarfallDance;

		return actionID;
	}
}

internal class DancerCuringWindFeature: DancerCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.DncAny;
	public override uint[] ActionIDs { get; } = [DNC.CuringWaltz];

	protected override uint Invoke(uint actionID, uint lastComboActionId, float comboTime, byte level) {

		if (IsEnabled(CustomComboPreset.DancerCuringWaltzLevelSync)) {
			if (level < DNC.Levels.CuringWaltz)
				return DNC.SecondWind;
		}

		if (IsEnabled(CustomComboPreset.DancerCuringWaltzCooldownSwap)) {
			if (!CanUse(DNC.CuringWaltz))
				return DNC.SecondWind;
		}

		return actionID;
	}
}
