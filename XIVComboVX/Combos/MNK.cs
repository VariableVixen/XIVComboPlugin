using System;
using System.Linq;

using Dalamud.Game.ClientState.JobGauge.Enums;
using Dalamud.Game.ClientState.JobGauge.Types;

using VariableVixen.XIVComboVX;

namespace VariableVixen.XIVComboVX.Combos;

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
		RiddleOfEarth = 7394,
		RiddleOfFire = 7395,
		Brotherhood = 7396,
		FourPointFury = 16473,
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

// apparently MNK had some big changes, and neither of the devs plays, cares for, or even understands MNK, so guess what doesn't have combos until someone else writes them?
// Aside from one replacer, which is shared by several classes and is, in fact, a great idea.
// All credit to Frigid for coming up with AND the initial implementation, which Vixen just stuck into a common class for convenience.

internal class MonkBloodbathReplacer: SecondBloodbathCombo {
	public override CustomComboPreset Preset => CustomComboPreset.MonkBloodbathReplacer;
}
