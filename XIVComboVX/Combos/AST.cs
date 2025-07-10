namespace VariableVixen.XIVComboVX.Combos;

internal static class AST {
	public const byte JobID = 33;

	public const uint
		Ascend = 3603,
		Benefic = 3594,
		Malefic = 3596,
		Malefic2 = 3598,
		Lightspeed = 3606,
		Benefic2 = 3610,
		Synastry = 3612,
		CollectiveUnconscious = 3613,
		Gravity = 3615,
		Balance = 4401,
		Bole = 4404,
		Arrow = 4402,
		Spear = 4403,
		Ewer = 4405,
		Spire = 4406,
		EarthlyStar = 7439,
		Malefic3 = 7442,
		MinorArcana = 7443,
		SleeveDraw = 7448,
		Divination = 16552,
		CelestialOpposition = 16553,
		Malefic4 = 16555,
		Horoscope = 16557,
		NeutralSect = 16559,
		FallMalefic = 25871,
		Gravity2 = 25872,
		Exaltation = 25873,
		Macrocosmos = 25874;

	public static class Buffs {
		public const ushort
			LordOfCrownsDrawn = 2054,
			LadyOfCrownsDrawn = 2055,
			ClarifyingDraw = 2713;
	}

	public static class Debuffs {
		// public const ushort placeholder = 0;
	}

	public static class Levels {
		public const byte
			Benefic2 = 26,
			Draw = 30,
			Astrodyne = 50,
			MinorArcana = 70,
			CrownPlay = 70;
	}
}

internal class AstrologianSwiftcastRaiserFeature: SwiftRaiseCombo {
	public override CustomComboPreset Preset => CustomComboPreset.AstrologianSwiftcastRaiserFeature;
}


internal class AstrologianBeneficFeature: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.AstrologianBeneficFeature;
	public override uint[] ActionIDs { get; } = [AST.Benefic2];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (level < AST.Levels.Benefic2)
			return AST.Benefic;

		return actionID;
	}
}
