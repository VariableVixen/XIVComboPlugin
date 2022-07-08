namespace XIVComboVX.Combos;

using System;

using Dalamud.Game.ClientState.Conditions;
using Dalamud.Game.ClientState.JobGauge.Types;

internal static class RDM {
	public const byte JobID = 35;

	public const uint
		Verraise = 7523,
		Verthunder = 7505,
		Corpsacorps = 7506,
		Veraero = 7507,
		Scatter = 7509,
		Displacement = 7515,
		Veraero2 = 16525,
		Verthunder2 = 16524,
		Impact = 16526,
		Embolden = 7520,
		Manafication = 7521,
		Redoublement = 7516,
		EnchantedRedoublement = 7529,
		Zwerchhau = 7512,
		EnchantedZwerchhau = 7528,
		Riposte = 7504,
		EnchantedRiposte = 7527,
		Jolt = 7503,
		Verstone = 7511,
		Verfire = 7510,
		Moulinet = 7513,
		Fleche = 7517,
		Acceleration = 7518,
		ContreSixte = 7519,
		Jolt2 = 7524,
		Verholy = 7526,
		Verflare = 7525,
		Swiftcast = 7561,
		Engagement = 16527,
		Scorch = 16530,
		Resolution = 25858;

	public static class Buffs {
		public const ushort
			VerfireReady = 1234,
			VerstoneReady = 1235,
			Acceleration = 1238,
			Dualcast = 1249;
	}

	public static class Debuffs {
		// public const ushort placeholder = 0;
	}

	public static class Levels {
		public const byte
			Jolt = 2,
			Verthunder = 4,
			Corpsacorps = 6,
			Veraero = 10,
			Scatter = 15,
			Swiftcast = 18,
			Verthunder2 = 18,
			Veraero2 = 22,
			Zwerchhau = 35,
			Displacement = 40,
			Engagement = 40,
			Fleche = 45,
			Redoublement = 50,
			Acceleration = 50,
			Vercure = 54,
			ContreSixte = 56,
			Embolden = 58,
			Manafication = 60,
			Jolt2 = 62,
			Verraise = 64,
			Impact = 66,
			Verflare = 68,
			Verholy = 70,
			Scorch = 80,
			Resolution = 90;
	}
}

internal class RedMageSwiftcastRaiserFeature: SwiftRaiseCombo {
	public override CustomComboPreset Preset => CustomComboPreset.RedMageSwiftcastRaiserFeature;
	public override uint[] ActionIDs { get; } = new[] { RDM.Verraise };
}

internal class RedMageAoECombo: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.RedMageAoECombo;
	public override uint[] ActionIDs { get; } = new[] { RDM.Veraero2, RDM.Verthunder2 };

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (lastComboMove is RDM.Scorch && level >= RDM.Levels.Resolution)
			return RDM.Resolution;

		if (lastComboMove is RDM.Verflare or RDM.Verholy && level >= RDM.Levels.Scorch)
			return RDM.Scorch;

		if (level >= RDM.Levels.Scatter && (IsFastcasting || SelfHasEffect(RDM.Buffs.Acceleration)))
			return OriginalHook(RDM.Scatter);

		return actionID;
	}
}

internal class RedMageMeleeCombo: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.RedMageMeleeCombo;
	public override uint[] ActionIDs { get; } = new[] { RDM.Redoublement, RDM.Moulinet };

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
		const int
			FINISHER_DELTA = 11,
			IMBALANCE_DIFF_MAX = 30;

		if (IsEnabled(CustomComboPreset.RedMageMeleeComboPlus)) {
			RDMGauge gauge = GetJobGauge<RDMGauge>();
			int black = gauge.BlackMana;
			int white = gauge.WhiteMana;
			bool isFinishing1 = gauge.ManaStacks == 3;
			bool isFinishing2 = comboTime > 0 && lastComboMove is RDM.Verholy or RDM.Verflare;
			bool isFinishing3 = comboTime > 0 && lastComboMove is RDM.Scorch;
			bool canFinishWhite = level >= RDM.Levels.Verholy;
			bool canFinishBlack = level >= RDM.Levels.Verflare;
			int blackThreshold = white + IMBALANCE_DIFF_MAX;
			int whiteThreshold = black + IMBALANCE_DIFF_MAX;
			bool verfireUp = SelfHasEffect(RDM.Buffs.VerfireReady);
			bool verstoneUp = SelfHasEffect(RDM.Buffs.VerstoneReady);

			if (isFinishing3 && level >= RDM.Levels.Resolution)
				return RDM.Resolution;
			if (isFinishing2 && level >= RDM.Levels.Scorch)
				return RDM.Scorch;

			if (isFinishing1 && canFinishBlack) {

				if (black >= white && canFinishWhite) {

					if (verstoneUp && !verfireUp && (black + FINISHER_DELTA <= blackThreshold))
						return RDM.Verflare;

					return RDM.Verholy;
				}

				if (verfireUp && !verstoneUp && canFinishWhite && (white + FINISHER_DELTA <= whiteThreshold))
					return RDM.Verholy;

				return RDM.Verflare;
			}
		}

		if (actionID is RDM.Redoublement) {

			if (IsEnabled(CustomComboPreset.RedMageMeleeComboCloser)) {
				if (HasTarget && !InMeleeRange)
					return RDM.Corpsacorps;
			}

			if (lastComboMove is RDM.Zwerchhau or RDM.EnchantedZwerchhau && level >= RDM.Levels.Redoublement)
				return OriginalHook(RDM.Redoublement);

			if (lastComboMove is RDM.Riposte or RDM.EnchantedRiposte && level >= RDM.Levels.Zwerchhau)
				return OriginalHook(RDM.Zwerchhau);

			return OriginalHook(RDM.Riposte);
		}

		return OriginalHook(actionID);
	}
}

internal class RedMageVerprocCombo: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.RedMageVerprocCombo;
	public override uint[] ActionIDs { get; } = new[] { RDM.Verstone, RDM.Verfire };

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (lastComboMove == RDM.Scorch && level >= RDM.Levels.Resolution)
			return RDM.Resolution;

		if (lastComboMove is RDM.Verflare or RDM.Verholy && level >= RDM.Levels.Scorch)
			return RDM.Scorch;

		RDMGauge gauge = GetJobGauge<RDMGauge>();

		if (actionID is RDM.Verstone) {

			if (gauge.ManaStacks == 3 && level >= RDM.Levels.Verholy)
				return RDM.Verholy;

			if (IsEnabled(CustomComboPreset.RedMageVerprocComboPlus)
				&& level >= RDM.Levels.Veraero
				&& (IsFastcasting || SelfHasEffect(RDM.Buffs.Acceleration))
			) {
				return OriginalHook(RDM.Veraero);
			}

			if (IsEnabled(CustomComboPreset.RedMageVeraeroOpenerFeature)
				&& level >= RDM.Levels.Veraero
				&& !HasCondition(ConditionFlag.InCombat)
				&& !SelfHasEffect(RDM.Buffs.VerstoneReady)
			) {
				return OriginalHook(RDM.Veraero);
			}

			if (SelfHasEffect(RDM.Buffs.VerstoneReady))
				return RDM.Verstone;

		}
		else if (actionID is RDM.Verfire) {

			if (gauge.ManaStacks == 3 && level >= RDM.Levels.Verflare)
				return RDM.Verflare;

			if (IsEnabled(CustomComboPreset.RedMageVerprocComboPlus)
				&& level >= RDM.Levels.Verthunder
				&& (IsFastcasting || SelfHasEffect(RDM.Buffs.Acceleration))
			) {
				return OriginalHook(RDM.Verthunder);
			}

			if (IsEnabled(CustomComboPreset.RedMageVerthunderOpenerFeature)
				&& level >= RDM.Levels.Verthunder
				&& !HasCondition(ConditionFlag.InCombat)
				&& !SelfHasEffect(RDM.Buffs.VerfireReady)
			) {
				return OriginalHook(RDM.Verthunder);
			}

			if (SelfHasEffect(RDM.Buffs.VerfireReady))
				return RDM.Verfire;

		}

		return OriginalHook(RDM.Jolt2);
	}
}

internal class RedMageContreFlecheFeature: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.RedMageContreFlecheFeature;
	public override uint[] ActionIDs { get; } = new[] { RDM.Fleche, RDM.ContreSixte };

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (level >= RDM.Levels.ContreSixte)
			return PickByCooldown(actionID, RDM.Fleche, RDM.ContreSixte);

		if (level >= RDM.Levels.Fleche)
			return RDM.Fleche;

		return actionID;
	}
}

internal class RedMageSmartcastAoECombo: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.RedMageSmartcastAoEFeature;
	public override uint[] ActionIDs { get; } = new[] { RDM.Veraero2, RDM.Verthunder2 };

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
		const int DELTA = 7;

		if (IsEnabled(CustomComboPreset.RedMageSmartcastAoEWeave)) {
			if (level >= RDM.Levels.ContreSixte) {
				if (CanWeave(actionID)) {
					if (IsEnabled(CustomComboPreset.RedMageContreFlecheFeature)) {
						uint chosen = PickByCooldown(RDM.ContreSixte, RDM.Fleche, RDM.ContreSixte);
						if (IsOffCooldown(chosen))
							return chosen;
					}
					else if (IsOffCooldown(RDM.ContreSixte)) {
						return RDM.ContreSixte;
					}
				}
			}
			else if (level >= RDM.Levels.Fleche && IsEnabled(CustomComboPreset.RedMageContreFlecheFeature)) {
				if (CanWeave(actionID)) {
					if (IsOffCooldown(RDM.Fleche))
						return RDM.Fleche;
				}
			}
		}

		if (IsFastcasting || SelfHasEffect(RDM.Buffs.Acceleration) || level < RDM.Levels.Verthunder2)
			return OriginalHook(RDM.Impact);

		if (level < RDM.Levels.Veraero2)
			return RDM.Verthunder2;

		RDMGauge gauge = GetJobGauge<RDMGauge>();
		int black = gauge.BlackMana;
		int white = gauge.WhiteMana;

		if (white < black || Math.Min(100, black + DELTA) == white)
			return RDM.Veraero2;

		if (black < white || Math.Min(100, white + DELTA) == black)
			return RDM.Verthunder2;

		return actionID;
	}
}

internal class RedmageSmartcastSingleCombo: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.RedMageSmartcastSingleFeature;
	public override uint[] ActionIDs { get; } = new[] { RDM.Veraero, RDM.Verthunder, RDM.Verstone, RDM.Verfire };

	protected override uint Invoke(uint actionID, uint lastComboActionId, float comboTime, byte level) {
		const int
			LONG_DELTA = 6,
			PROC_DELTA = 5,
			FINISHER_DELTA = 11,
			IMBALANCE_DIFF_MAX = 30;

		if (IsEnabled(CustomComboPreset.RedMageSmartcastSingleWeave)) {
			if (level >= RDM.Levels.Fleche) {
				if (CanWeave(actionID)) {
					if (IsEnabled(CustomComboPreset.RedMageContreFlecheFeature)) {
						if (level >= RDM.Levels.ContreSixte) {
							uint chosen = PickByCooldown(RDM.Fleche, RDM.Fleche, RDM.ContreSixte);
							if (IsOffCooldown(chosen))
								return chosen;
						}
					}
					if (IsOffCooldown(RDM.Fleche))
						return RDM.Fleche;
				}
			}
		}

		bool verfireUp = SelfHasEffect(RDM.Buffs.VerfireReady);
		bool verstoneUp = SelfHasEffect(RDM.Buffs.VerstoneReady);
		RDMGauge gauge = GetJobGauge<RDMGauge>();
		int black = gauge.BlackMana;
		int white = gauge.WhiteMana;
		bool isFinishing1 = gauge.ManaStacks == 3;
		bool isFinishing2 = comboTime > 0 && lastComboActionId is RDM.Verholy or RDM.Verflare;
		bool isFinishing3 = comboTime > 0 && lastComboActionId is RDM.Scorch;
		bool canFinishWhite = level >= RDM.Levels.Verholy;
		bool canFinishBlack = level >= RDM.Levels.Verflare;
		int blackThreshold = white + IMBALANCE_DIFF_MAX;
		int whiteThreshold = black + IMBALANCE_DIFF_MAX;

		// No matter what this is (opener or combat), follow the finisher combo chains.
		// There is never a reason to NOT use the finishers when you have them.
		if (isFinishing3 && level >= RDM.Levels.Resolution)
			return RDM.Resolution;
		if (isFinishing2 && level >= RDM.Levels.Scorch)
			return RDM.Scorch;

		if (actionID is RDM.Veraero or RDM.Verthunder) {

			if (level < RDM.Levels.Verthunder)
				return RDM.Jolt;

			if (level is < RDM.Levels.Veraero and >= RDM.Levels.Verthunder)
				return OriginalHook(RDM.Verthunder);

			// This is for the long opener only, so we're not bothered about fast casting or finishers or anything like that
			// However, we DO want to prevent the mana levels from being perfectly even, cause that fucks up Manafication into melee as an opener

			if (black < white || Math.Min(100, white + LONG_DELTA) == black)
				return OriginalHook(RDM.Verthunder);

			if (white < black || Math.Min(100, black + LONG_DELTA) == white)
				return OriginalHook(RDM.Veraero);

			return actionID;
		}

		if (actionID is RDM.Verstone or RDM.Verfire) {
			bool fastCasting = IsFastcasting;
			bool accelerated = SelfHasEffect(RDM.Buffs.Acceleration);

			if (isFinishing1 && canFinishBlack) {

				if (black >= white && canFinishWhite) {

					// If we can already Verstone, but we can't Verfire, and Verflare WON'T imbalance us, use Verflare
					if (verstoneUp && !verfireUp && (black + FINISHER_DELTA <= blackThreshold))
						return RDM.Verflare;

					return RDM.Verholy;
				}

				// If we can already Verfire, but we can't Verstone, and we can use Verholy, and it WON'T imbalance us, use Verholy
				if (verfireUp && !verstoneUp && canFinishWhite && (white + FINISHER_DELTA <= whiteThreshold))
					return RDM.Verholy;

				return RDM.Verflare;
			}

			if (fastCasting || accelerated) {

				if (level is < RDM.Levels.Veraero and >= RDM.Levels.Verthunder)
					return RDM.Verthunder;

				if (verfireUp == verstoneUp) {

					// Either both procs are already up or neither is - use whatever gives us the mana we need
					if (black < white)
						return OriginalHook(RDM.Verthunder);

					if (white < black)
						return OriginalHook(RDM.Veraero);

					// If mana levels are equal, prioritise the colour that the original button was
					return actionID is RDM.Verstone
						? OriginalHook(RDM.Veraero)
						: OriginalHook(RDM.Verthunder);
				}

				if (verfireUp) {

					// If Veraero is feasible, use it
					if (white + LONG_DELTA <= whiteThreshold)
						return OriginalHook(RDM.Veraero);

					return OriginalHook(RDM.Verthunder);
				}

				if (verstoneUp) {

					// If Verthunder is feasible, use it
					if (black + LONG_DELTA <= blackThreshold)
						return OriginalHook(RDM.Verthunder);

					return OriginalHook(RDM.Veraero);
				}
			}

			if (verfireUp && verstoneUp) {

				// Decide by mana levels
				if (black < white)
					return RDM.Verfire;

				if (white < black)
					return RDM.Verstone;

				// If mana levels are equal, prioritise the original button
				return actionID;
			}

			// Only use Verfire if it won't imbalance us
			if (verfireUp && black + PROC_DELTA <= blackThreshold)
				return RDM.Verfire;

			// Only use Verstone if it won't imbalance us
			if (verstoneUp && white + PROC_DELTA <= whiteThreshold)
				return RDM.Verstone;

			// If neither's up or the one that is would imbalance us, just use Jolt
			return OriginalHook(RDM.Jolt2);
		}

		return actionID;
	}
}

internal class RedMageAcceleration: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.RedMageAccelerationSwiftcastFeature;
	public override uint[] ActionIDs => new[] { RDM.Acceleration };

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (level >= RDM.Levels.Acceleration) {
			bool canAccelerate = HasCharges(RDM.Acceleration);
			bool canSwiftcast = HasCharges(RDM.Swiftcast);

			if (IsEnabled(CustomComboPreset.RedMageAccelerationSwiftcastOption) && canAccelerate && canSwiftcast)
				return RDM.Swiftcast;

			if (canAccelerate)
				return RDM.Acceleration;

			if (canSwiftcast)
				return RDM.Swiftcast;

			return RDM.Acceleration;
		}

		return RDM.Swiftcast;
	}
}

internal class RedMageEmbolden: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.RedMageEmboldenFeature;
	public override uint[] ActionIDs => new[] { RDM.Embolden };

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (level >= RDM.Levels.Manafication && IsOffCooldown(RDM.Manafication) && IsOnCooldown(RDM.Embolden))
			return RDM.Manafication;

		return actionID;
	}
}

internal class RedMageGapControl: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.RdmAny;
	public override uint[] ActionIDs => new[] { RDM.Corpsacorps, RDM.Displacement };

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
		if (level < RDM.Levels.Displacement)
			return actionID;

		if ((actionID is RDM.Corpsacorps && IsEnabled(CustomComboPreset.RedMageMeleeGapReverserBackstep)) || (actionID is RDM.Displacement && IsEnabled(CustomComboPreset.RedMageMeleeGapReverserLunge))) {
			if (HasTarget)
				return InMeleeRange ? RDM.Displacement : RDM.Corpsacorps;
		}

		return actionID;
	}
}
