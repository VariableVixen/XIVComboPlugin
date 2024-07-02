using Dalamud.Game.ClientState.JobGauge.Types;
using Dalamud.Game.ClientState.Objects.Enums;
using Dalamud.Game.ClientState.Objects.Types;

namespace PrincessRTFM.XIVComboVX.Combos;

internal static class SGE {
	public const byte JobID = 40;

	public const uint
		Dosis = 24283,
		Diagnosis = 24284,
		Kardia = 24285,
		Prognosis = 24286,
		Egeiro = 24287,
		Physis = 24288,
		Phlegma = 24289,
		Eukrasia = 24290,
		Soteria = 24294,
		Icarus = 24295,
		Druochole = 24296,
		Dyskrasia = 24297,
		Kerachole = 24298,
		Ixochole = 24299,
		Zoe = 24300,
		Pepsis = 24301,
		Physis2 = 24302,
		Taurochole = 24303,
		Toxikon = 24304,
		Haima = 24305,
		Phlegma2 = 24307,
		Rhizomata = 24309,
		Holos = 24310,
		Panhaima = 24311,
		Phlegma3 = 24313,
		Krasis = 24317,
		Pneuma = 24318,
		Philosophica = ushort.MaxValue;

	public static class Buffs {
		public const ushort
			Kardion = 2604;
	}

	public static class Debuffs {
		public const ushort
			Placeholder = 0;
	}

	public static class Levels {
		public const ushort
			Dosis = 1,
			Prognosis = 10,
			Egeiro = 12,
			Phlegma = 26,
			Soteria = 35,
			Icarus = 40,
			Druochole = 45,
			Dyskrasia = 46,
			Kerachole = 50,
			Ixochole = 52,
			Physis2 = 60,
			Taurochole = 62,
			Toxikon = 66,
			Haima = 70,
			Phlegma2 = 72,
			Dosis2 = 72,
			Rhizomata = 74,
			Holos = 76,
			Panhaima = 80,
			Phlegma3 = 82,
			Dosis3 = 82,
			Krasis = 86,
			Pneuma = 90,
			Psyche = 92,
			EukrasianPrognosis2 = 96,
			Philosophica = 100;
	}
}

internal class SageSwiftcastRaiserFeature: SwiftRaiseCombo {
	public override CustomComboPreset Preset => CustomComboPreset.SageSwiftcastRaiserFeature;
}

internal class SageSoteria: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.SageSoteriaKardionFeature;
	public override uint[] ActionIDs => [SGE.Soteria];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (SelfHasEffect(SGE.Buffs.Kardion))
			return SGE.Soteria;

		return SGE.Kardia;
	}
}

internal class SageTaurochole: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.SgeAny;
	public override uint[] ActionIDs => [SGE.Taurochole];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (IsEnabled(CustomComboPreset.SageTaurocholeRhizomataFeature)) {
			if (level >= SGE.Levels.Rhizomata && GetJobGauge<SGEGauge>().Addersgall == 0)
				return SGE.Rhizomata;
		}

		if (IsEnabled(CustomComboPreset.SageTaurocholeDruocholeFeature)) {
			if (level >= SGE.Levels.Taurochole && IsOffCooldown(SGE.Taurochole))
				return SGE.Taurochole;

			return SGE.Druochole;
		}

		return actionID;
	}
}

internal class SageDruochole: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.SageDruocholeRhizomataFeature;
	public override uint[] ActionIDs => [SGE.Druochole];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (level >= SGE.Levels.Rhizomata && GetJobGauge<SGEGauge>().Addersgall == 0)
			return SGE.Rhizomata;

		return actionID;
	}
}

internal class SageIxochole: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.SageIxocholeRhizomataFeature;
	public override uint[] ActionIDs => [SGE.Ixochole];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (level >= SGE.Levels.Rhizomata && GetJobGauge<SGEGauge>().Addersgall == 0)
			return SGE.Rhizomata;

		return actionID;
	}
}

internal class SageKerachole: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.SgeAny;
	public override uint[] ActionIDs => [SGE.Kerachole];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
		byte gall = GetJobGauge<SGEGauge>().Addersgall;

		if (IsEnabled(CustomComboPreset.SageKeracholaRhizomataFeature)) {
			if (level >= SGE.Levels.Rhizomata && gall == 0 && CanUse(SGE.Rhizomata))
				return SGE.Rhizomata;
		}

		if (IsEnabled(CustomComboPreset.SageKeracholeHolos)) {
			if (level >= SGE.Levels.Holos && gall == 0 && CanUse(SGE.Holos))
				return SGE.Holos;
		}

		return actionID;
	}
}

internal class SageHolos: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.SageHolosKerachole;
	public override uint[] ActionIDs => [SGE.Holos];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (level < SGE.Levels.Rhizomata)
			return SGE.Kerachole;

		if (level >= SGE.Levels.Holos && CanUse(SGE.Holos))
			return SGE.Holos;

		if (IsEnabled(CustomComboPreset.SageKeracholaRhizomataFeature)) {
			if (GetJobGauge<SGEGauge>().Addersgall == 0)
				return PickByCooldown(actionID, SGE.Rhizomata, SGE.Holos);
		}

		return SGE.Kerachole;
	}
}

internal class SagePhlegma: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.SgeAny;
	public override uint[] ActionIDs => [SGE.Phlegma, SGE.Phlegma2, SGE.Phlegma3];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
		uint phlegma = OriginalHook(actionID);

		// Phlegma, Icarus, Toxikon, and Dosis are all targeted actions, so if you don't have a target, we won't bother checking for any of them
		if (HasTarget) {

			// First, if you have a target in range for Phlegma and it's usable, we just do that
			if (TargetDistance <= 6 && CanUse(phlegma)) {

				if (Common.CheckLucidWeave(CustomComboPreset.SageLucidPhlegma, level, Service.Configuration.SageLucidPhlegmaManaThreshold, actionID))
					return Common.LucidDreaming;

				return phlegma;
			}
			// Fallthrough: target out of range OR phlegma down

			// Prioritise Icarus into Phlegma over Toxikon because Phlegma is higher potency
			if (IsEnabled(CustomComboPreset.SagePhlegmaIcarus) && level >= SGE.Levels.Icarus) {
				float maxRange = CurrentTarget is IBattleNpc target
					&& target.BattleNpcKind is BattleNpcSubKind.Enemy or BattleNpcSubKind.BattleNpcPart
					? Service.Configuration.SagePhlegmaIcarusDistanceThresholdEnemy
					: Service.Configuration.SagePhlegmaIcarusDistanceThresholdAlly;
				if (TargetDistance > maxRange) {
					if (CanUse(SGE.Icarus))
						return SGE.Icarus;
				}
			}
			// Fallthrough: target not far enough OR icarus down OR phlegma down

			// Even if you CAN use Phlegma, if you're too far away and Icarus isn't up, fall back to the lower-potency Toxikon cause it's a target-AOE too
			if (IsEnabled(CustomComboPreset.SagePhlegmaToxicon) && level >= SGE.Levels.Toxikon) {
				if (GetJobGauge<SGEGauge>().Addersting > 0 && (!CanUse(phlegma) || TargetDistance > 6)) {

					if (Common.CheckLucidWeave(CustomComboPreset.SageLucidToxikon, level, Service.Configuration.SageLucidToxikonManaThreshold, actionID))
						return Common.LucidDreaming;

					return OriginalHook(SGE.Toxikon);
				}
			}
			// Fallthrough: no addersting AND ((target out of range AND not far enough) OR phlegma down)

			// Prioritise Dosis over Dyskrasia if you have a target in range because it's much higher potency and a targeted attack
			// It's actually higher potency than Toxikon too, but this is a fallback because the button is MEANT for target-AOE attacks and Dosis is ST
			// Note that this DOESN'T check for Phlegma being down! If it's up but we got here anyway, then the target must be out of range, so Dyskrasia wouldn't hit them either.
			// If you want to use Dyskrasia over Dosis, clear your target with escape or clicking on the ground.
			if (IsEnabled(CustomComboPreset.SagePhlegmaDosis)) {
				if (TargetDistance <= 25) {

					if (Common.CheckLucidWeave(CustomComboPreset.SageLucidDosis, level, Service.Configuration.SageLucidDosisManaThreshold, actionID))
						return Common.LucidDreaming;

					return OriginalHook(SGE.Dosis);
				}
			}
			// Fallthrough: no addersting AND target out of range (incl. for icarus)
		}
		// Fallthrough: (no addersting AND target out of range (incl. for icarus)) OR no target

		// Fall back to Dyskrasia if there's nothing else we can do, because you'd have to be FAIRLY close for Phlegma so hopefully this self-AOE will still hit enough to be worth it
		// This also triggers if you HAVE a target, but they're out of range for Dosis/Icarus (or you just don't have that stuff enabled)
		if (IsEnabled(CustomComboPreset.SagePhlegmaDyskrasia) && level >= SGE.Levels.Dyskrasia) {

			if (Common.CheckLucidWeave(CustomComboPreset.SageLucidDyskrasia, level, Service.Configuration.SageLucidDyskrasiaManaThreshold, actionID))
				return Common.LucidDreaming;

			return OriginalHook(SGE.Dyskrasia);
		}
		// Fallthrough: none (excluding level too low or combos not enabled)

		return actionID;
	}
}

internal class SageDosis: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.SgeAny;
	public override uint[] ActionIDs => [SGE.Dosis];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (Common.CheckLucidWeave(CustomComboPreset.SageLucidDosis, level, Service.Configuration.SageLucidDosisManaThreshold, actionID))
			return Common.LucidDreaming;

		SGEGauge gauge = GetJobGauge<SGEGauge>();

		if (IsMoving && !gauge.Eukrasia) { // if eukrasia is active, eudosis is an instacast so we don't change up

			if (HasTarget) {

				if (IsEnabled(CustomComboPreset.SageDosisPhlegma)) {
					if (!IsEnabled(CustomComboPreset.SageDosisPhlegmaHardcastOnly) || IsHardcasting) {
						if (!IsEnabled(CustomComboPreset.SageDosisPhlegmaCombatOnly) || InCombat) {
							if (level >= SGE.Levels.Phlegma && TargetDistance <= 6) {
								uint phlegma = OriginalHook(SGE.Phlegma);
								if (CanUse(phlegma))
									return phlegma;
							}
						}
					}
				}

				if (IsEnabled(CustomComboPreset.SageDosisToxikon)) {
					if (!IsEnabled(CustomComboPreset.SageDosisToxikonHardcastOnly) || IsHardcasting) {
						if (!IsEnabled(CustomComboPreset.SageDosisToxikonCombatOnly) || InCombat) {
							if (level >= SGE.Levels.Toxikon && gauge.Addersting > 0)
								return OriginalHook(SGE.Toxikon);
						}
					}
				}

			}

			if (IsEnabled(CustomComboPreset.SageDosisDyskrasia)) {
				if (!IsEnabled(CustomComboPreset.SageDosisDyskrasiaHardcastOnly) || IsHardcasting) {
					if (!IsEnabled(CustomComboPreset.SageDosisDyskrasiaCombatOnly) || InCombat) {
						if (level >= SGE.Levels.Dyskrasia)
							return OriginalHook(SGE.Dyskrasia);
					}
				}
			}

		}

		return actionID;
	}
}

internal class SageIcarus: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.SageIcarusPhlegma;
	public override uint[] ActionIDs => [SGE.Icarus];

	protected override uint Invoke(uint actionID, uint lastComboActionId, float comboTime, byte level) {

		if (level >= SGE.Levels.Phlegma && HasTarget && TargetDistance <= 6) {
			uint phlegma = OriginalHook(SGE.Phlegma);
			if (CanUse(phlegma) || TargetDistance <= 1)
				return phlegma;
		}

		return actionID;
	}
}

internal class SageDyskrasia: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.SageLucidDyskrasia;
	public override uint[] ActionIDs => [SGE.Dyskrasia];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (level >= Common.Levels.LucidDreaming) {
			if (LocalPlayer.CurrentMp < Service.Configuration.SageLucidDyskrasiaManaThreshold) {
				if (CanUse(Common.LucidDreaming) && CanWeave(actionID))
					return Common.LucidDreaming;
			}
		}

		return actionID;
	}
}

internal class SageToxikon: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.SageLucidToxikon;
	public override uint[] ActionIDs => [SGE.Toxikon];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (level >= Common.Levels.LucidDreaming) {
			if (LocalPlayer.CurrentMp < Service.Configuration.SageLucidToxikonManaThreshold) {
				if (CanUse(Common.LucidDreaming) && CanWeave(actionID))
					return Common.LucidDreaming;
			}
		}

		return actionID;
	}
}

// Currently not working until action ID set
internal class SagePhilosophica: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.SagePhilosophicaZoe;
	public override uint[] ActionIDs => [SGE.Philosophica];

	protected override uint Invoke(uint actionID, uint lastComboActionId, float comboTime, byte level) {

		if (level < SGE.Levels.Philosophica)
			return SGE.Zoe;

		if (CanUse(SGE.Zoe) && !CanUse(SGE.Philosophica))
			return SGE.Zoe;

		return actionID;
	}
}
