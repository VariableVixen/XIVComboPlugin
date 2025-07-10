using VariableVixen.XIVComboVX;

namespace VariableVixen.XIVComboVX.Combos;

internal static class VPR {
	public const byte JobID = 41;
	// Alright, there's some kind of skullduggery going on here. some skills have duplicates with different IDs, some aren't even listed under VPR. Doing my best.
	public const uint
		SteelFangs = 34606, // Might be 39157
		HuntersSting = 39159,
		DreadFangs = 34607,
		WrithingSnap = 34632,
		SwiftskinsSting = 39160,
		SteelMaw = 34614,
		FlankstingStrike = 34610, // Might be 38118 OR 38798
		FlanksbaneFang = 34610,
		HindstingStrike = 34612,
		HindsbaneFang = 34613,
		DreadMaw = 34615,
		Slither = 34646, // Might be 39184
		HuntersBite = 34616,
		SwiftskinsBite = 34617,
		JaggedMaw = 34618,
		BloodiedMaw = 34619,
		SerpentsTail = 35920, // Might be 39183
		DeathRattle = 39174,
		LastLash = 34635,
		Dreadwinder = 34620,
		HuntersCoil = 34621,
		SwiftskinsCoil = 34622, // Might be 39167
		PitOfDread = 34623,
		HuntersDen = 34624,
		SwiftskinsDen = 34625,
		Twinfang = 35921,
		Twinblood = 35922,
		TwinfangBite = 39175,
		TwinbloodBite = 39176,
		TwinfangThresh = 34638,
		TwinbloodThresh = 34639,
		UncoiledFury = 34633, // Might be 39168
		SerpentsIre = 34647,
		Reawaken = 34626,
		FirstGeneration = 39169,
		SecondGeneration = 39170,
		ThirdGeneration = 39171,
		FourthGeneration = 39172,
		UncoiledTwinfang = 39177,
		UncoiledTwinblood = 34645,
		Ouroboros = 39173,
		FirstLegacy = 39179,
		SecondLegacy = 39180,
		ThirdLegacy = 39181,
		FourthLegacy = 39182,
		PiercingFangs = 39158,
		BarbarousBite = 39161,
		RavenousBite = 39163,
		HuntersSnap = 39166,
		SnakeScales = 39185,
		Backlash = 39186, // Might be 39187
		FuriousBacklash = 39188,
		RattlingCoil = 39189,
		WorldSwallower = 39190;

	public static class Buffs {
		public const ushort
			HuntersInstinct = ushort.MaxValue,
			Swiftscaled = ushort.MaxValue,
			FlankstungVenom = 116,
			HindstungVenom = 118,
			FlanksbaneVenom = 117,
			HindsbaneVenom = 119;
	}

	public static class Debuffs {
		public const ushort
			NoxiousGnash = ushort.MaxValue;
	}

	public static class Levels {
		public const byte
			SteelFangs = 1,
			HuntersSting = 5,
			DreadFangs = 10,
			WrithingSnap = 15,
			SwiftskinsSting = 20,
			SteelMaw = 25,
			FlankstingStrike = 30,
			DreadMaw = 35,
			Slither = 40,
			HuntersBite = 40,
			SwiftskinsBite = 45,
			JaggedMaw = 50,
			DeathRattle = 55,
			LastLash = 60,
			Dreadwinder = 65,
			HuntersCoil = 65,
			SwiftskinsCoil = 65,
			PitOfDread = 70,
			HuntersDen = 70,
			SwiftskinsDen = 70,
			TwinfangBite = 75,
			TwinfangThresh = 80,
			UncoiledFury = 82,
			SerpentsIre = 86,
			Reawaken = 90,
			Generations = 90,
			UncoiledTwinfang = 92,
			Ouroboros = 96,
			Legacies = 100;
	}
}

internal class ViperBloodbathReplacer: SecondBloodbathCombo {
	public override CustomComboPreset Preset => CustomComboPreset.ViperBloodbathReplacer;
}
