namespace XIVComboVX.Combos;

using System;
using System.Linq;

using Dalamud.Game.ClientState.JobGauge.Enums;
using Dalamud.Game.ClientState.JobGauge.Types;
using Dalamud.Game.ClientState.Statuses;

using FFXIVClientStructs.FFXIV.Client.Game.UI;

internal static class MNK {
	public const byte ClassID = 2;
	public const byte JobID = 20;

	public const uint
		Bootshine = 53,
		TrueStrike = 54,
		SnapPunch = 56,
		TwinSnakes = 61,
		ArmOfTheDestroyer = 62,
		Demolish = 66,
		PerfectBalance = 69,
		Rockbreaker = 70,
		DragonKick = 74,
		Meditation = 3546,
		ForbiddenChakra = 3547,
		FormShift = 4262,
		RiddleOfEarth = 7394,
		RiddleOfFire = 7395,
		Brotherhood = 7396,
		Bloodbath = 7542,
		FourPointFury = 16473,
		Anatman = 16475,
		SteelPeak = 25761,
		Enlightenment = 16474,
		HowlingFist = 25763,
		MasterfulBlitz = 25764,
		RiddleOfWind = 25766,
		ShadowOfTheDestroyer = 25767;

	public static class Buffs {
		public const ushort
			OpoOpoForm = 107,
			RaptorForm = 108,
			CoerlForm = 109,
			PerfectBalance = 110,
			FifthChakra = 797,
			LeadenFist = 1861,
			Brotherhood = 1185,
			RiddleOfFire = 1181,
			FormlessFist = 2513,
			DisciplinedFist = 3001;
	}

	public static class Debuffs {
		public const ushort
			Demolish = 246;
	}

	public static class Levels {
		public const byte
			TrueStrike = 4,
			SnapPunch = 6,
			Bloodbath = 12,
			Meditation = 15,
			TwinSnakes = 18,
			ArmOfTheDestroyer = 26,
			Rockbreaker = 30,
			Demolish = 30,
			FourPointFury = 45,
			HowlingFist = 40,
			DragonKick = 50,
			PerfectBalance = 50,
			FormShift = 52,
			EnhancedPerfectBalance = 60,
			MasterfulBlitz = 60,
			RiddleOfEarth = 64,
			RiddleOfFire = 68,
			Brotherhood = 70,
			Enlightenment = 70,
			RiddleOfWind = 72,
			ShadowOfTheDestroyer = 82;
	}
}

public unsafe class MNKGCD {
	public static unsafe int MNKSkillSpeed() {
		UIState* uiState = UIState.Instance();
			return uiState->PlayerState.Attributes[45];
	}
}

internal class MonkUltimaCD: CustomCombo {

	public override CustomComboPreset Preset { get; } = CustomComboPreset.MonkUltimaCD;
	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		MNKGauge gauge = GetJobGauge<MNKGauge>();
		BeastChakra beast1 = gauge.BeastChakra[0];
		BeastChakra beast2 = gauge.BeastChakra[1];
		BeastChakra beast3 = gauge.BeastChakra[2];
		Status? disciplined = SelfFindEffect(MNK.Buffs.DisciplinedFist);
		Status? demolish = TargetFindOwnEffect(MNK.Debuffs.Demolish);
		Status? rof = SelfFindEffect(MNK.Buffs.RiddleOfFire);
		Status? pb = SelfFindEffect(MNK.Buffs.PerfectBalance);
		int[,] levelSubAndDiv = new int[,] {
			{ 56, 56 }, { 57, 57 }, { 60, 60 }, { 62, 62 }, { 65, 65 }, { 68, 68 }, { 70, 70 }, { 73, 73 }, { 76, 76 }, { 78, 78 },
			{ 82, 82 }, { 85, 85 }, { 89, 89 }, { 93, 93 }, { 96, 96 }, { 100, 100 }, { 104, 104 }, { 109, 109 }, { 113, 113 }, { 116, 116 },
			{ 122, 122 }, { 127, 127 }, { 133, 133 }, { 138, 138 }, { 144, 144 }, { 150, 150 }, { 155, 155 }, { 162, 162 }, { 168, 168 }, { 173, 173 },
			{ 181, 181 }, { 188, 188 }, { 194, 194 }, { 202, 202 }, { 209, 209 }, { 215, 215 }, { 223, 223 }, { 229, 229 }, { 236, 236 }, { 244, 244 },
			{ 253, 253 }, { 263, 263 }, { 272, 272 }, { 283, 283 }, { 292, 292 }, { 302, 302 }, { 311, 311 }, { 322, 322 }, { 331, 331 }, { 341, 341 },
			{ 342, 366 }, { 344, 392 }, { 345, 418 }, { 346, 444 }, { 347, 470 }, { 349, 496 }, { 350, 522 }, { 351, 548 }, { 352, 574 }, { 354, 600 },
			{ 355, 630 }, { 356, 660 }, { 357, 690 }, { 358, 720 }, { 359, 750 }, { 360, 780 }, { 361, 810 }, { 362, 840 }, { 363, 870 }, { 364, 900 },
			{ 365, 940 }, { 366, 980 }, { 367, 1020 }, { 368, 1060 }, { 370, 1100 }, { 372, 1140 }, { 374, 1180 }, { 376, 1220 }, { 378, 1260 }, { 380, 1300 },
			{ 382, 1360 }, { 384, 1420 }, { 386, 1480 }, { 388, 1540 }, { 390, 1600 }, { 392, 1660 }, { 394, 1720 }, { 396, 1780 }, { 398, 1840 }, { 400, 1900 }
		};
		float greasedLightningModifier;
		if (level < 20)
			greasedLightningModifier = 0.95f;
		else if (level < 40)
			greasedLightningModifier = 0.90f;
		else if (level < 76)
			greasedLightningModifier = 0.85f;
		else
			greasedLightningModifier = 0.80f;
		int skillSpeed = MNKGCD.MNKSkillSpeed();
		int baseBootshineCD = 2500;
		float gcd = (baseBootshineCD * greasedLightningModifier * (1000 + (130 * (levelSubAndDiv[level - 1, 0] - skillSpeed) / levelSubAndDiv[level - 1, 1])) / 10000 / 100);
		float rofcd = GetCooldown(MNK.RiddleOfFire).CooldownRemaining;
		float firegcds = IsOnCooldown(MNK.RiddleOfFire) ? rofcd / gcd : 0;
		float rotate = gcd * 3;
		float disciplinedFistLunar = gcd * 7;
		float demolishLunar = gcd * 8;
		float demolishSolar = gcd * 2;
		float perfectBalanceWindow = gcd * 3;
		float perfectBalanceUpkeep;
		if (beast3 != BeastChakra.NONE)
			perfectBalanceUpkeep = GetCooldown(MNK.Bootshine).CooldownRemaining;
		else if (beast2 != BeastChakra.NONE)
			perfectBalanceUpkeep = GetCooldown(MNK.Bootshine).CooldownRemaining + gcd;
		else if (beast1 != BeastChakra.NONE)
			perfectBalanceUpkeep = GetCooldown(MNK.Bootshine).CooldownRemaining + (gcd * 2);
		else
			perfectBalanceUpkeep = gcd * 3;
		float disciplinedFistBlitzRefresh = perfectBalanceUpkeep + (gcd * 2);
		float demolishBlitzRefresh = perfectBalanceUpkeep + (gcd * 3);
		float disciplinedFistLunarPrep = gcd * 7;
		float demolishLunarPrep = gcd * 8;
		bool clip = GetCooldown(MNK.Bootshine).CooldownRemaining >= 0.51f;
		bool weave = IsOnCooldown(MNK.Bootshine);
		bool buffer = GetCooldown(MNK.Bootshine).CooldownRemaining <= 0.73f;
		if (actionID is MNK.MasterfulBlitz) {
			if (!InCombat
				&& level >= MNK.Levels.Meditation
				&& OriginalHook(MNK.Meditation) == MNK.Meditation) {
				return MNK.Meditation;
			}

			if (!InCombat
				&& level >= MNK.Levels.FormShift
				&& !SelfHasEffect(MNK.Buffs.FormlessFist)) {
				return MNK.FormShift;
			}

			if (
				InCombat
				&& level >= MNK.Levels.RiddleOfFire
				&& (disciplined is not null || SelfHasEffect(MNK.Buffs.PerfectBalance))
				&& IsOffCooldown(MNK.RiddleOfFire)
				&& weave
				&& clip
				&& buffer) {
				return MNK.RiddleOfFire;
			}

			if (
				InCombat
				&& level >= MNK.Levels.Brotherhood
				&& IsOnCooldown(MNK.RiddleOfFire)
				&& (SelfHasEffect(MNK.Buffs.RaptorForm) || SelfHasEffect(MNK.Buffs.PerfectBalance) || (rof is not null && SelfHasEffect(MNK.Buffs.FormlessFist)))
				&& IsOffCooldown(MNK.Brotherhood)
				&& weave
				&& clip) {
				return MNK.Brotherhood;
			}

			if (
				level >= MNK.Levels.Meditation
				&& OriginalHook(MNK.Meditation) != MNK.Meditation
				&& LocalPlayer?.TargetObject is not null
				&& InCombat
				&& (disciplined is not null || level < MNK.Levels.TwinSnakes)
				&& (IsOnCooldown(MNK.RiddleOfFire) || level < MNK.Levels.RiddleOfFire)
				&& clip
				&& weave) {
				return OriginalHook(MNK.SteelPeak);
			}

			if (level >= MNK.Levels.MasterfulBlitz
				&& OriginalHook(MNK.MasterfulBlitz) != MNK.MasterfulBlitz) {
				return OriginalHook(MNK.MasterfulBlitz);
			}

			if (
				InCombat
				&& level >= MNK.Levels.RiddleOfWind
				&& IsOnCooldown(MNK.Brotherhood)
				&& IsOnCooldown(MNK.RiddleOfFire)
				&& (SelfHasEffect(MNK.Buffs.PerfectBalance) || !IsOffCooldown(MNK.PerfectBalance))
				&& IsOffCooldown(MNK.RiddleOfWind)
				&& clip
				&& weave) {
				return MNK.RiddleOfWind;
			}

			if (
				level >= MNK.Levels.PerfectBalance
				&& !SelfHasEffect(MNK.Buffs.PerfectBalance)
				&& SelfHasEffect(MNK.Buffs.RaptorForm)
				&& GetCooldown(MNK.PerfectBalance).RemainingCharges >= 1
				&& level < MNK.Levels.MasterfulBlitz
				&& disciplined is not null
				&& demolish is not null
				&& disciplined.RemainingTime > perfectBalanceWindow
				&& demolish.RemainingTime > perfectBalanceWindow
				&& weave
				&& clip) {
				return MNK.PerfectBalance;
			}

			if (
				level >= MNK.Levels.PerfectBalance
				&& !SelfHasEffect(MNK.Buffs.PerfectBalance)
				&& (IsOnCooldown(MNK.Brotherhood) || level < MNK.Levels.Brotherhood)
				&& level >= MNK.Levels.MasterfulBlitz
				&& SelfHasEffect(MNK.Buffs.RaptorForm)
				&& GetCooldown(MNK.PerfectBalance).RemainingCharges >= 1
				&& (firegcds <= 2 || (rof is not null && (rof.RemainingTime >= perfectBalanceWindow)) || level < MNK.Levels.RiddleOfFire)
				&& (
					!gauge.Nadi.HasFlag(Nadi.SOLAR)
					|| (disciplined is not null
						&& disciplined.RemainingTime >= perfectBalanceWindow
						&& demolish is not null
						&& demolish.RemainingTime >= perfectBalanceWindow))
				&& weave
				&& clip) {
				return MNK.PerfectBalance;
			}

			if (level >= MNK.Levels.Meditation
				&& !HasTarget
				&& pb is null
				&& OriginalHook(MNK.Meditation) == MNK.Meditation) {
				return MNK.Meditation;
			}

			if (level >= MNK.Levels.FormShift
				&& !HasTarget
				&& pb is null
				&& !SelfHasEffect(MNK.Buffs.FormlessFist)) {
				return MNK.FormShift;
			}

			if (level >= MNK.Levels.TwinSnakes
				&& SelfHasEffect(MNK.Buffs.RaptorForm)
				&& pb is null
				&& ((gauge.Nadi.HasFlag(Nadi.SOLAR) && firegcds <= 3 && (disciplined is null || disciplined.RemainingTime < disciplinedFistLunar))
					|| (!gauge.Nadi.HasFlag(Nadi.SOLAR) && (disciplined is null || disciplined.RemainingTime < rotate)))) {
				return MNK.TwinSnakes;
			}

			if (level >= MNK.Levels.Demolish
				&& SelfHasEffect(MNK.Buffs.CoerlForm)
				&& pb is null
				&& ((gauge.Nadi.HasFlag(Nadi.SOLAR) && firegcds <= 3 && (demolish is null || demolish.RemainingTime < demolishLunar))
					|| (!gauge.Nadi.HasFlag(Nadi.SOLAR) && (demolish is null || demolish.RemainingTime < demolishSolar)))) {
				return MNK.Demolish;
			}

			if (SelfHasEffect(MNK.Buffs.PerfectBalance)) {
				if (
				!gauge.BeastChakra.Contains(BeastChakra.RAPTOR)
				&& !gauge.BeastChakra.Contains(BeastChakra.COEURL)
				&& (!gauge.Nadi.HasFlag(Nadi.LUNAR) || (gauge.Nadi.HasFlag(Nadi.LUNAR) && gauge.Nadi.HasFlag(Nadi.SOLAR)) || level < MNK.Levels.MasterfulBlitz)
				&& disciplined is not null
				&& disciplined.RemainingTime > perfectBalanceUpkeep
				&& demolish is not null
				&& demolish.RemainingTime > perfectBalanceUpkeep) {
					if (!SelfHasEffect(MNK.Buffs.LeadenFist) && level >= MNK.Levels.DragonKick) {
						return MNK.DragonKick;
					}

					if (SelfHasEffect(MNK.Buffs.LeadenFist)) {
						return MNK.Bootshine;
					}
				}

				if (
				level >= MNK.Levels.MasterfulBlitz
				&& !gauge.Nadi.HasFlag(Nadi.SOLAR)
				&& ((beast1 == BeastChakra.NONE && beast2 == BeastChakra.NONE) || (beast1 != beast2))
				&& (
					disciplined is null
					|| demolish is null
					|| gauge.Nadi.HasFlag(Nadi.LUNAR)
					|| (!gauge.Nadi.HasFlag(Nadi.LUNAR) && (disciplined.RemainingTime <= disciplinedFistLunarPrep || demolish.RemainingTime <= demolishLunarPrep)))) {
					if (
						!gauge.Nadi.HasFlag(Nadi.LUNAR)
						&& (GetCooldown(MNK.PerfectBalance).RemainingCharges >= 1 || GetCooldown(MNK.PerfectBalance).ChargeCooldownRemaining <= (gcd * 5))) {
						if (beast1 == BeastChakra.OPOOPO && beast2 == BeastChakra.COEURL) {
							return MNK.TwinSnakes;
						}

						if (beast1 == BeastChakra.OPOOPO && beast2 == BeastChakra.NONE) {
							return MNK.Demolish;
						}

						if (beast1 == BeastChakra.NONE) {
							if (!SelfHasEffect(MNK.Buffs.LeadenFist)) {
								return MNK.DragonKick;
							}

							if (SelfHasEffect(MNK.Buffs.LeadenFist)) {
								return MNK.Bootshine;
							}
						}
					}

					if (
						beast1 != BeastChakra.RAPTOR
						&& beast2 != BeastChakra.RAPTOR
						&& (disciplined is null || disciplined.RemainingTime <= disciplinedFistBlitzRefresh)) {
						return MNK.TwinSnakes;
					}

					if (
						beast1 != BeastChakra.COEURL
						&& beast2 != BeastChakra.COEURL
						&& (demolish is null || demolish.RemainingTime <= demolishBlitzRefresh)) {
						return MNK.Demolish;
					}

					if (beast1 != BeastChakra.OPOOPO && beast2 != BeastChakra.OPOOPO) {
						if (!SelfHasEffect(MNK.Buffs.LeadenFist)) {
							return MNK.DragonKick;
						}

						if (SelfHasEffect(MNK.Buffs.LeadenFist)) {
							return MNK.Bootshine;
						}
					}

					if (
						beast1 != BeastChakra.RAPTOR
						&& beast2 != BeastChakra.RAPTOR
						&& disciplined is not null
						&& disciplined.RemainingTime > disciplinedFistBlitzRefresh) {
						return MNK.TrueStrike;
					}

					if (
						beast1 != BeastChakra.COEURL
						&& beast2 != BeastChakra.COEURL
						&& demolish is not null
						&& demolish.RemainingTime > demolishBlitzRefresh) {
						return MNK.SnapPunch;
					}
				}
			}

			if (!SelfHasEffect(MNK.Buffs.PerfectBalance)) {
				if (SelfHasEffect(MNK.Buffs.FormlessFist) || SelfHasEffect(MNK.Buffs.OpoOpoForm)) {
					return level < MNK.Levels.DragonKick || SelfHasEffect(MNK.Buffs.LeadenFist)
						? MNK.Bootshine
						: MNK.DragonKick;
				}

				if (!SelfHasEffect(MNK.Buffs.FormlessFist) && SelfHasEffect(MNK.Buffs.RaptorForm)) {
					if (level < MNK.Levels.TrueStrike) {
						return MNK.Bootshine;
					}

					return level < MNK.Levels.TwinSnakes || (SelfEffectDuration(MNK.Buffs.DisciplinedFist) >= rotate)
						? MNK.TrueStrike
						: MNK.TwinSnakes;
				}

				if (!SelfHasEffect(MNK.Buffs.FormlessFist) && SelfHasEffect(MNK.Buffs.CoerlForm)) {
					return level < MNK.Levels.SnapPunch
						? MNK.Bootshine
						: level < MNK.Levels.Demolish || (TargetOwnEffectDuration(MNK.Debuffs.Demolish) >= rotate)
							? MNK.SnapPunch
							: MNK.Demolish;
				}

				return level < MNK.Levels.DragonKick
						? MNK.Bootshine
						: MNK.DragonKick;
			}
		}

		return actionID;
	}
}

internal class MonkAoECombo: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.MonkAoECombo;

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (actionID is MNK.ArmOfTheDestroyer or MNK.ShadowOfTheDestroyer) {
			if (!IsEnabled(CustomComboPreset.MonkAoECombo_Destroyers))
				return actionID;
		}
		else if (actionID is MNK.MasterfulBlitz) {
			if (!IsEnabled(CustomComboPreset.MonkAoECombo_MasterBlitz))
				return actionID;
		}
		else if (actionID is MNK.Rockbreaker) {
			if (!IsEnabled(CustomComboPreset.MonkAoECombo_Rockbreaker))
				return actionID;
		}
		else {
			return actionID;
		}

		if (level >= MNK.Levels.HowlingFist) {
			if (InCombat && HasTarget && CanWeave(actionID) && SelfHasEffect(MNK.Buffs.FifthChakra)) {
				uint real = OriginalHook(MNK.HowlingFist);
				if (CanUse(real))
					return real;
			}
		}

		MNKGauge gauge = GetJobGauge<MNKGauge>();

		// Blitz
		if (level >= MNK.Levels.MasterfulBlitz && !gauge.BeastChakra.Contains(BeastChakra.NONE))
			return OriginalHook(MNK.MasterfulBlitz);

		if (level >= MNK.Levels.PerfectBalance && SelfHasEffect(MNK.Buffs.PerfectBalance)) {

			// Solar
			if (level >= MNK.Levels.EnhancedPerfectBalance && !gauge.Nadi.HasFlag(Nadi.SOLAR)) {
				if (level >= MNK.Levels.FourPointFury && !gauge.BeastChakra.Contains(BeastChakra.RAPTOR))
					return MNK.FourPointFury;

				if (level >= MNK.Levels.Rockbreaker && !gauge.BeastChakra.Contains(BeastChakra.COEURL))
					return MNK.Rockbreaker;

				if (level >= MNK.Levels.ArmOfTheDestroyer && !gauge.BeastChakra.Contains(BeastChakra.OPOOPO))
					// Shadow of the Destroyer
					return OriginalHook(MNK.ArmOfTheDestroyer);

				return level >= MNK.Levels.ShadowOfTheDestroyer
					? MNK.ShadowOfTheDestroyer
					: MNK.Rockbreaker;
			}

			// Lunar.  Also used if we have both Nadi as Tornado Kick/Phantom Rush isn't picky, or under 60.
			return level >= MNK.Levels.ShadowOfTheDestroyer
				? MNK.ShadowOfTheDestroyer
				: MNK.Rockbreaker;
		}

		// FPF with FormShift
		if (level >= MNK.Levels.FormShift && SelfHasEffect(MNK.Buffs.FormlessFist)) {
			if (level >= MNK.Levels.FourPointFury)
				return MNK.FourPointFury;
		}

		// 1-2-3 combo
		if (level >= MNK.Levels.FourPointFury && SelfHasEffect(MNK.Buffs.RaptorForm))
			return MNK.FourPointFury;

		if (level >= MNK.Levels.ArmOfTheDestroyer && SelfHasEffect(MNK.Buffs.OpoOpoForm))
			// Shadow of the Destroyer
			return OriginalHook(MNK.ArmOfTheDestroyer);

		if (level >= MNK.Levels.Rockbreaker && SelfHasEffect(MNK.Buffs.CoerlForm))
			return MNK.Rockbreaker;

		// Shadow of the Destroyer
		return OriginalHook(MNK.ArmOfTheDestroyer);
	}
}

internal class MonkSTCombo: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.MonkSTCombo;
	public override uint[] ActionIDs => new[] { MNK.Bootshine };

	// All credit to Evolutious on the github - they wrote the code themselves and sent it to me.
	// All I did was adjust the style to better fit the rest of the plugin, and change a few hardcoded values to adjustable ones.
	// Update post-6.2: I've also integrated a few other combos better and added one that was missing.
	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
		MNKGauge gauge = GetJobGauge<MNKGauge>();

		// *** oGCD Rotation ***
		if (CanWeave(MNK.Bootshine)) {

			// Bloodbath
			if (level >= MNK.Levels.Bloodbath) {
				if (IsOffCooldown(MNK.Bloodbath) && PlayerHealthPercentage < Service.Configuration.MonkBloodbathHealthPercentage)
					return MNK.Bloodbath;
			}

			// Riddle of Earth
			if (level >= MNK.Levels.RiddleOfEarth) {
				if (IsOffCooldown(MNK.RiddleOfEarth) && PlayerHealthPercentage < Service.Configuration.MonkRiddleOfEarthHealthPercentage)
					return MNK.RiddleOfEarth;
			}

			// Steel Peak/The Forbidden Chakra
			if (level >= MNK.Levels.Meditation) {
				if (gauge.Chakra == 5 && InCombat)
					return OriginalHook(MNK.Meditation);
			}

			// Perfect Balance
			if (level >= MNK.Levels.PerfectBalance && !SelfHasEffect(MNK.Buffs.PerfectBalance)) {
				// These all go to the same codepath, but combining them would be some eldritch frankencondition, so they're kept separate for readability. -PrincessRTFM
				if (level >= MNK.Levels.Brotherhood) {
					if (SelfHasEffect(MNK.Buffs.RiddleOfFire) && SelfEffectDuration(MNK.Buffs.RiddleOfFire) < 10.0 && !SelfHasEffect(MNK.Buffs.FormlessFist) && SelfHasEffect(MNK.Buffs.DisciplinedFist) && SelfHasEffect(MNK.Buffs.Brotherhood))
						return MNK.PerfectBalance;
				}
				else if (level >= MNK.Levels.RiddleOfFire) {
					if (SelfHasEffect(MNK.Buffs.RiddleOfFire) && SelfEffectDuration(MNK.Buffs.RiddleOfFire) >= 10.0 && !SelfHasEffect(MNK.Buffs.FormlessFist) && SelfHasEffect(MNK.Buffs.DisciplinedFist))
						return MNK.PerfectBalance;
				}
				else if (level >= MNK.Levels.FormShift) {
					if (level < MNK.Levels.RiddleOfFire && !SelfHasEffect(MNK.Buffs.FormlessFist) && SelfHasEffect(MNK.Buffs.DisciplinedFist))
						return MNK.PerfectBalance;
				}
				else if (level < MNK.Levels.FormShift) {
					if (SelfHasEffect(MNK.Buffs.DisciplinedFist))
						return MNK.PerfectBalance;
				}
			}

			// Riddle of Fire
			if (level >= MNK.Levels.RiddleOfFire) {
				if (!IsOnCooldown(MNK.RiddleOfFire) && SelfHasEffect(MNK.Buffs.DisciplinedFist))
					return MNK.RiddleOfFire;
			}

			// Brotherhood
			if (level >= MNK.Levels.Brotherhood) {
				if (SelfHasEffect(MNK.Buffs.PerfectBalance) && !IsOnCooldown(MNK.Brotherhood) && (gauge.BeastChakra.Contains(BeastChakra.RAPTOR) || gauge.BeastChakra.Contains(BeastChakra.COEURL) || gauge.BeastChakra.Contains(BeastChakra.OPOOPO)))
					return MNK.Brotherhood;
			}

			// Riddle of Wind
			if (level >= MNK.Levels.RiddleOfWind) {
				if (!IsOnCooldown(MNK.RiddleOfWind) && IsOnCooldown(MNK.RiddleOfFire))
					return MNK.RiddleOfWind;
			}

		}

		// Masterful Blitz
		if (level >= MNK.Levels.MasterfulBlitz) {
			if (!gauge.BeastChakra.Contains(BeastChakra.NONE))
				return OriginalHook(MNK.MasterfulBlitz);
		}

		// Master's Gauge
		if (level >= MNK.Levels.PerfectBalance) {
			if (SelfHasEffect(MNK.Buffs.PerfectBalance)) {

				// Solar
				if (level >= MNK.Levels.EnhancedPerfectBalance) {
					if (!gauge.Nadi.HasFlag(Nadi.SOLAR)) {

						if (!gauge.BeastChakra.Contains(BeastChakra.RAPTOR)) {
							return IsEnabled(CustomComboPreset.MonkTwinSnakesFeature) && SelfEffectDuration(MNK.Buffs.DisciplinedFist) > Service.Configuration.MonkTwinSnakesBuffTime
								? MNK.TrueStrike
								: MNK.TwinSnakes;
						}

						if (!gauge.BeastChakra.Contains(BeastChakra.COEURL)) {
							return level < MNK.Levels.Demolish || (IsEnabled(CustomComboPreset.MonkDemolishFeature) && TargetOwnEffectDuration(MNK.Debuffs.Demolish) > Service.Configuration.MonkDemolishDebuffTime)
								? MNK.SnapPunch
								: MNK.Demolish;
						}

						if (!gauge.BeastChakra.Contains(BeastChakra.OPOOPO)) {
							return level < MNK.Levels.DragonKick || SelfHasEffect(MNK.Buffs.LeadenFist)
								? MNK.Bootshine
								: MNK.DragonKick;
						}

						return level >= MNK.Levels.DragonKick
							? MNK.DragonKick
							: MNK.Bootshine;
					}
				}

				// Lunar.  Also used if we have both Nadi as Tornado Kick/Phantom Rush isn't picky, or under 60.
				return level < MNK.Levels.DragonKick || SelfHasEffect(MNK.Buffs.LeadenFist)
					? MNK.Bootshine
					: MNK.DragonKick;
			}
		}

		// 1-2-3 combo
		if (level >= MNK.Levels.TrueStrike) {
			if (SelfHasEffect(MNK.Buffs.RaptorForm) || SelfHasEffect(MNK.Buffs.FormlessFist)) {
				return level < MNK.Levels.TwinSnakes || (IsEnabled(CustomComboPreset.MonkTwinSnakesFeature) && SelfEffectDuration(MNK.Buffs.DisciplinedFist) > Service.Configuration.MonkTwinSnakesBuffTime)
					? MNK.TrueStrike
					: MNK.TwinSnakes;
			}
		}

		if (level >= MNK.Levels.SnapPunch) {
			if (SelfHasEffect(MNK.Buffs.CoerlForm)) {
				return level < MNK.Levels.Demolish || (IsEnabled(CustomComboPreset.MonkDemolishFeature) && TargetOwnEffectDuration(MNK.Debuffs.Demolish) > Service.Configuration.MonkDemolishDebuffTime)
					? MNK.SnapPunch
					: MNK.Demolish;
			}
		}

		if (SelfHasEffect(MNK.Buffs.OpoOpoForm)) {
			return level < MNK.Levels.DragonKick || SelfHasEffect(MNK.Buffs.LeadenFist)
				? MNK.Bootshine
				: MNK.DragonKick;
		}

		// Dragon Kick
		return level < MNK.Levels.DragonKick || SelfHasEffect(MNK.Buffs.LeadenFist)
			? MNK.Bootshine
			: MNK.DragonKick;
	}
}

internal class MonkHowlingFistEnlightenment: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.MonkHowlingFistMeditationFeature;
	public override uint[] ActionIDs => new[] { MNK.HowlingFist, MNK.Enlightenment };

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
		MNKGauge gauge = GetJobGauge<MNKGauge>();

		if (level >= MNK.Levels.Meditation && gauge.Chakra < 5)
			return MNK.Meditation;

		return actionID;
	}
}

internal class MonkDragonKick: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.MnkAny;
	public override uint[] ActionIDs => new[] { MNK.DragonKick };

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
		MNKGauge gauge = GetJobGauge<MNKGauge>();

		if (IsEnabled(CustomComboPreset.MonkDragonKickMeditationFeature)) {
			if (level >= MNK.Levels.Meditation && gauge.Chakra < 5 && !InCombat)
				return MNK.Meditation;
		}

		if (IsEnabled(CustomComboPreset.MonkDragonKickSteelPeakFeature)) {
			if (level >= MNK.Levels.Meditation && gauge.Chakra == 5 && InCombat)
				return OriginalHook(MNK.Meditation);
		}

		if (IsEnabled(CustomComboPreset.MonkDragonKickBalanceFeature)) {
			if (level >= MNK.Levels.MasterfulBlitz && !gauge.BeastChakra.Contains(BeastChakra.NONE))
				return OriginalHook(MNK.MasterfulBlitz);
		}

		if (IsEnabled(CustomComboPreset.MonkBootshineFeature)) {
			if (level < MNK.Levels.DragonKick || SelfHasEffect(MNK.Buffs.LeadenFist))
				return MNK.Bootshine;
		}

		return actionID;
	}
}

internal class MonkTwinSnakes: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.MonkTwinSnakesFeature;
	public override uint[] ActionIDs => new[] { MNK.TwinSnakes };

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (level < MNK.Levels.TwinSnakes || SelfEffectDuration(MNK.Buffs.DisciplinedFist) > Service.Configuration.MonkTwinSnakesBuffTime)
			return MNK.TrueStrike;

		return actionID;
	}
}

internal class MonkDemolish: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.MonkDemolishFeature;
	public override uint[] ActionIDs => new[] { MNK.Demolish };

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (level < MNK.Levels.Demolish || TargetOwnEffectDuration(MNK.Debuffs.Demolish) > Service.Configuration.MonkDemolishDebuffTime)
			return MNK.SnapPunch;

		return actionID;
	}
}

internal class MonkPerfectBalance: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.MonkPerfectBalanceFeature;
	public override uint[] ActionIDs => new[] { MNK.PerfectBalance };

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (level >= MNK.Levels.MasterfulBlitz && (!GetJobGauge<MNKGauge>().BeastChakra.Contains(BeastChakra.NONE) || SelfHasEffect(MNK.Buffs.PerfectBalance)))
			// Chakra actions
			return OriginalHook(MNK.MasterfulBlitz);

		return actionID;
	}
}

internal class MonkRiddleOfFire: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.MnkAny;
	public override uint[] ActionIDs => new[] { MNK.RiddleOfFire };

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (IsEnabled(CustomComboPreset.MonkBrotherlyFire)) {
			if (level >= MNK.Levels.Brotherhood && IsOffCooldown(MNK.Brotherhood) && IsOnCooldown(MNK.RiddleOfFire))
				return MNK.Brotherhood;
		}

		if (IsEnabled(CustomComboPreset.MonkFireWind)) {
			if (level >= MNK.Levels.RiddleOfWind && IsOffCooldown(MNK.RiddleOfWind) && IsOnCooldown(MNK.RiddleOfFire))
				return MNK.RiddleOfWind;
		}

		return actionID;
	}
}
