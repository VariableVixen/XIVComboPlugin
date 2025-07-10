using Dalamud.Game.ClientState.JobGauge.Types;

using VariableVixen.XIVComboVX;

namespace VariableVixen.XIVComboVX.Combos;

internal static class MCH {
	public const byte JobID = 31;

	public const uint
		// Single target
		CleanShot = 2873,
		HeatedCleanShot = 7413,
		SplitShot = 2866,
		HeatedSplitShot = 7411,
		SlugShot = 2868,
		HeatedSlugshot = 7412,
		// Charges
		GaussRound = 2874,
		Ricochet = 2890,
		// AoE
		SpreadShot = 2870,
		AutoCrossbow = 16497,
		Scattergun = 25786,
		// Rook
		RookAutoturret = 2864,
		RookOverdrive = 7415,
		AutomatonQueen = 16501,
		QueenOverdrive = 16502,
		// Other
		BarrelStabiliser = 7414,
		Tactician = 16889,
		Dismantle = 2887,
		Wildfire = 2878,
		Detonator = 16766,
		Hypercharge = 17209,
		HeatBlast = 7410,
		HotShot = 2872,
		Drill = 16498,
		Bioblaster = 16499,
		AirAnchor = 16500,
		Chainsaw = 25788,
		DoubleCheck = 36979,
		Checkmate = 36980,
		BlazingShot = 36978,
		FullMetalField = 36982,
		Excavator = 36981;

	public static class Buffs {
		public const ushort
			Reassembled = 851,
			Hypercharged = 3864,
			ExcavatorReady = 3865,
			FullMetalMachinist = 3866;
	}

	public static class Debuffs {
		// public const ushort placeholder = 0;
	}

	public static class Levels {
		public const byte
			SlugShot = 2,
			HotShot = 4,
			GaussRound = 15,
			CleanShot = 26,
			Hypercharge = 30,
			HeatBlast = 35,
			RookOverdrive = 40,
			Wildfire = 45,
			Ricochet = 50,
			AutoCrossbow = 52,
			HeatedSplitShot = 54,
			Tactician = 56,
			Drill = 58,
			HeatedSlugshot = 60,
			Dismantle = 62,
			HeatedCleanShot = 64,
			BarrelStabiliser = 66,
			ChargedActionMastery = 74,
			AirAnchor = 76,
			QueenOverdrive = 80,
			Chainsaw = 90,
			DoubleCheck = 92,
			Checkmate = 92,
			Excavator = 96;
	}
}

internal class MachinistCleanShot: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.MachinistMainCombo;
	public override uint[] ActionIDs { get; } = [MCH.CleanShot, MCH.HeatedCleanShot];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
		MCHGauge gauge = GetJobGauge<MCHGauge>();

		if (IsEnabled(CustomComboPreset.MachinistMainComboReassembledOverride)) {

			if (level is >= MCH.Levels.HotShot and < MCH.Levels.Drill) {
				bool canCleanShot = level >= MCH.Levels.CleanShot && lastComboMove is MCH.SlugShot; // note that Hot Shot is LESS potency than Clean Shot when part of the combo
				bool canHeatedShot = level >= MCH.Levels.HeatedSlugshot && lastComboMove is MCH.HeatedSplitShot or MCH.HeatedSlugshot; // HS is also weaker than Heated Slug/Clean Shot
				if (!canCleanShot && !canHeatedShot) {
					if (SelfHasEffect(MCH.Buffs.Reassembled)) {
						if (CanUse(MCH.HotShot))
							return MCH.HotShot;
					}
				}
			}

			if (level >= MCH.Levels.Drill) {
				if (SelfHasEffect(MCH.Buffs.Reassembled)) {
					uint preference = gauge.Battery > 80 || level < MCH.Levels.AirAnchor
						? MCH.Drill
						: MCH.AirAnchor;
					uint choice = 0;

					if (level >= MCH.Levels.Chainsaw)
						choice = PickByCooldown(preference, OriginalHook(MCH.Chainsaw), MCH.Drill, MCH.AirAnchor);

					if (level >= MCH.Levels.AirAnchor)
						choice = PickByCooldown(preference, MCH.Drill, MCH.AirAnchor);

					if (CanUse(MCH.Drill))
						choice = MCH.Drill; // probably shouldn't return actionID so it can run through the chain below

					if (choice > 0 && CanUse(choice))
						return choice;
				}
			}
		}

		if (IsEnabled(CustomComboPreset.MachinistMainComboHeatBlast) && level >= MCH.Levels.HeatBlast && gauge.IsOverheated) {

			if (IsEnabled(CustomComboPreset.MachinistHyperchargeWildfire) && level >= MCH.Levels.Wildfire) {
				if (gauge.OverheatTimeRemaining >= 9_000 && IsOffCooldown(MCH.Wildfire) && HasTarget)
					return MCH.Wildfire;
			}

			if (IsEnabled(CustomComboPreset.MachinistHeatBlastWeaveGaussRoundRicochet) && CanWeave(MCH.HeatBlast)) { // Heat Blast has a 1.5s cooldown instead of the normal GCD

				if (level >= MCH.Levels.Ricochet) {
					uint gauss = OriginalHook(MCH.GaussRound);
					uint ricochet = OriginalHook(MCH.Ricochet);

					return PickByCooldown(gauss, gauss, ricochet);
				}

				return MCH.GaussRound;
			}

			return OriginalHook(MCH.HeatBlast);
		}

		if (comboTime > 0) {

			if (lastComboMove is MCH.SplitShot or MCH.HeatedSplitShot && level >= MCH.Levels.SlugShot)
				return OriginalHook(MCH.SlugShot);

			if (lastComboMove is MCH.SlugShot or MCH.HeatedSlugshot && level >= MCH.Levels.CleanShot)
				return OriginalHook(MCH.CleanShot);

		}

		return OriginalHook(MCH.SplitShot);
	}
}

internal class MachinistGaussRicochet: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.MachinistGaussRoundRicochet;
	public override uint[] ActionIDs { get; } = [MCH.GaussRound, MCH.Ricochet, MCH.DoubleCheck, MCH.Checkmate];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (level >= MCH.Levels.Ricochet) {

			if (IsEnabled(CustomComboPreset.MachinistGaussRoundRicochetLimiter) && !GetJobGauge<MCHGauge>().IsOverheated)
				return actionID;

			return PickByCooldown(actionID, OriginalHook(MCH.Ricochet), OriginalHook(MCH.GaussRound));
		}

		return OriginalHook(MCH.GaussRound);
	}
}

internal class MachinistHypercharge: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.MchAny;
	public override uint[] ActionIDs { get; } = [MCH.Hypercharge];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
		MCHGauge gauge = GetJobGauge<MCHGauge>();

		if (IsEnabled(CustomComboPreset.MachinistHyperchargeStabiliser)) {
			if (level >= MCH.Levels.BarrelStabiliser && !gauge.IsOverheated && gauge.Heat < 50 && !SelfHasEffect(MCH.Buffs.Hypercharged))
				return MCH.BarrelStabiliser;
		}

		if (IsEnabled(CustomComboPreset.MachinistHyperchargeWildfire)) {

			if (level >= MCH.Levels.Wildfire && gauge.IsOverheated) {

				if (gauge.OverheatTimeRemaining >= 9_000 && IsOffCooldown(MCH.Wildfire) && HasTarget)
					return MCH.Wildfire;

				if (IsOnCooldown(MCH.Hypercharge) && !IsOriginal(MCH.Wildfire))
					return MCH.Detonator;

			}

		}

		return actionID;
	}
}

internal class MachinistHeatBlastBlazingShot: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.MchAny;
	public override uint[] ActionIDs { get; } = [MCH.HeatBlast, MCH.BlazingShot];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
		MCHGauge gauge = GetJobGauge<MCHGauge>();

		if (level < MCH.Levels.Hypercharge)
			return MCH.Hypercharge;

		if (IsEnabled(CustomComboPreset.MachinistSmartHeatup) && !gauge.IsOverheated) {
			if (IsEnabled(CustomComboPreset.MachinistHyperchargeStabiliser) && level >= MCH.Levels.BarrelStabiliser) {
				if (!gauge.IsOverheated && gauge.Heat < 50 && !SelfHasEffect(MCH.Buffs.Hypercharged))
					return MCH.BarrelStabiliser;
			}

			return MCH.Hypercharge;
		}

		if (IsEnabled(CustomComboPreset.MachinistHyperchargeWildfire) && level >= MCH.Levels.Wildfire) {
			if (gauge.IsOverheated && gauge.OverheatTimeRemaining >= 9_000 && IsOffCooldown(MCH.Wildfire) && HasTarget)
				return MCH.Wildfire;
		}

		if ((actionID is MCH.HeatBlast or MCH.BlazingShot || level < MCH.Levels.AutoCrossbow) && level >= MCH.Levels.HeatBlast) {
			if (IsEnabled(CustomComboPreset.MachinistHeatBlastWeaveGaussRoundRicochet)) {
				if (gauge.IsOverheated && CanWeave(MCH.HeatBlast)) { // Heat Blast has a 1.5s cooldown instead of the normal GCD
					uint gauss = OriginalHook(MCH.GaussRound);
					uint ricochet = OriginalHook(MCH.Ricochet);

					if (level >= MCH.Levels.Ricochet)
						return PickByCooldown(gauss, gauss, ricochet);

					return gauss;
				}
			}

			return OriginalHook(MCH.HeatBlast);
		}

		return actionID;
	}
}

internal class MachinistSpreadShotFeature: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.MachinistSpreadShot;
	public override uint[] ActionIDs { get; } = [MCH.SpreadShot, MCH.Scattergun];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (level >= MCH.Levels.AutoCrossbow && GetJobGauge<MCHGauge>().IsOverheated)
			return MCH.AutoCrossbow;

		return actionID;
	}
}

internal class MachinistAutoCrossbow: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.MachinistSmartHeatup;
	public override uint[] ActionIDs { get; } = [MCH.AutoCrossbow];

	protected override uint Invoke(uint actionID, uint lastComboActionId, float comboTime, byte level) {
		MCHGauge gauge = GetJobGauge<MCHGauge>();

		if (level < MCH.Levels.Hypercharge) // cannot overheat, so auto crossbow doesn't even work
			return MCH.Hypercharge;

		if (!gauge.IsOverheated) {
			if (IsEnabled(CustomComboPreset.MachinistHyperchargeStabiliser) && level >= MCH.Levels.BarrelStabiliser) {
				if (!gauge.IsOverheated && gauge.Heat < 50 && !SelfHasEffect(MCH.Buffs.Hypercharged))
					return MCH.BarrelStabiliser;
			}

			return MCH.Hypercharge;
		}

		return actionID;
	}
}

internal class MachinistOverdriveFeature: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.MachinistOverdrive;
	public override uint[] ActionIDs { get; } = [MCH.RookAutoturret, MCH.AutomatonQueen];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (level >= MCH.Levels.RookOverdrive && GetJobGauge<MCHGauge>().IsRobotActive)
			return OriginalHook(MCH.RookOverdrive);

		return actionID;
	}
}

internal class MachinistDrillAirAnchorFeature: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.MachinistDrillAirAnchor;
	public override uint[] ActionIDs { get; } = [MCH.HotShot, MCH.AirAnchor, MCH.Drill];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
		uint preference = GetJobGauge<MCHGauge>().Battery > 80
			? MCH.Drill
			: level >= MCH.Levels.AirAnchor
			? MCH.AirAnchor
			: MCH.Drill;

		if (level >= MCH.Levels.Chainsaw && IsEnabled(CustomComboPreset.MachinistDrillAirAnchorPlus))
			return PickByCooldown(preference, OriginalHook(MCH.Chainsaw), MCH.Drill, MCH.AirAnchor);

		if (level >= MCH.Levels.AirAnchor)
			return PickByCooldown(preference, MCH.Drill, MCH.AirAnchor);

		if (level >= MCH.Levels.Drill)
			return PickByCooldown(preference, MCH.HotShot, MCH.Drill);

		return MCH.HotShot;
	}
}

internal class MachinistTacticianDismantle: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.MachinistTacticianDismantle;
	public override uint[] ActionIDs { get; } = [MCH.Tactician, MCH.Dismantle];

	protected override uint Invoke(uint actionID, uint lastComboActionId, float comboTime, byte level) {

		// These three actions cannot be stacked, so even if Dismantle is unavailable, we don't want to waste Tactician
		if (SelfHasEffect(BRD.Buffs.Troubadour) || SelfHasEffect(DNC.Buffs.ShieldSamba))
			return MCH.Dismantle;

		if (level <= MCH.Levels.Dismantle)
			return MCH.Tactician;

		if (!HasTarget || TargetDistance > 25)
			return MCH.Tactician;

		return PickByCooldown(actionID, MCH.Tactician, MCH.Dismantle);
	}
}
