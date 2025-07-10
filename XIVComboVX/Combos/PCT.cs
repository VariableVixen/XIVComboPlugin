using Dalamud.Game.ClientState.JobGauge.Types;

namespace VariableVixen.XIVComboVX.Combos;
internal class PCT {
	public const byte JobID = 42;

	public const uint
		FireRed = 34650,
		AeroGreen = 34651,
		WaterBlue = 34652,
		BlizzardCyan = 34653,
		EarthYellow = 34654,
		ThunderMagenta = 34655,
		ExtraFireRed = 34656,
		ExtraAeroGreen = 34657,
		ExtraWaterBlue = 34658,
		ExtraBlizzardCyan = 34659,
		ExtraEarthYellow = 34660,
		ExtraThunderMagenta = 34661,
		HolyWhite = 34662,
		CometBlack = 34663,
		PomMotif = 34664,
		WingMotif = 34665,
		ClawMotif = 34666,
		MawMotif = 34667,
		HammerMotif = 34668,
		StarrySkyMotif = 34669,
		PomMuse = 34670,
		WingedMuse = 34671,
		ClawedMuse = 34672,
		FangedMuse = 34673,
		StrikingMuse = 34674,
		StarryMuse = 34675,
		MogOftheAges = 34676,
		Retribution = 34677,
		HammerStamp = 34678,
		HammerBrush = 34679,
		PolishingHammer = 34680,
		StarPrism = 34681,
		SubtractivePalette = 34683,
		Smudge = 34684,
		TemperaCoat = 34685,
		TemperaGrassa = 34686,
		RainbowDrip = 34688,
		CreatureMotif = 34689,
		WeaponMotif = 34690,
		LandscapeMotif = 34691,
		LivingMuse = 35347,
		SteelMuse = 35348,
		ScenicMuse = 35349;

	public static class Buffs {
		public const ushort
			SubtractivePalette = 4102,
			SubtractivePaletteStack = 3674,
			Chroma2Ready = 3675,
			Chroma3Ready = 3676,
			RainbowReady = 3679,
			HammerReady = 3680,
			StarPrismReady = 3681,
			Installation = 3688,
			ArtisticInstallation = 3689,
			SubtractivePaletteReady = 3690,
			InvertedColors = 3691;
	}

	public static class Debuffs {
		public const ushort
			DebuffPH = ushort.MaxValue;
	}

	public static class Levels {
		public const byte
			FireRed = 1,
			AeroGreen = 5,
			TemperaCoat = 10,
			WaterBlue = 15,
			Smudge = 20,
			ExtraFireRed = 25,
			CreatureMotif = 30,
			PomMotif = 30,
			WingMotif = 30,
			PomMuse = 30,
			WingedMuse = 30,
			MogOftheAges = 30,
			ExtraAeroGreen = 35,
			ExtraWaterBlue = 45,
			HammerMotif = 50,
			HammerStamp = 50,
			WeaponMotif = 50,
			StrikingMuse = 50,
			SubtractivePalette = 60,
			BlizzardCyan = 60,
			EarthYellow = 60,
			ThunderMagenta = 60,
			ExtraBlizzardCyan = 60,
			ExtraEarthYellow = 60,
			ExtraThunderMagenta = 60,
			StarrySkyMotif = 70,
			LandscapeMotif = 70,
			HolyWhite = 80,
			HammerBrush = 86,
			PolishingHammer = 86,
			TemperaGrassa = 88,
			CometBlack = 90,
			RainbowDrip = 92,
			ClawMotif = 96,
			MawMotif = 96,
			ClawedMuse = 96,
			FangedMuse = 96,
			StarryMuse = 70,
			Retribution = 96,
			StarPrism = 100;
	}
}

internal class PictomancerSTCombo: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.PictomancerSTComboFeature;
	public override uint[] ActionIDs { get; } = [PCT.BlizzardCyan];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte levels) {

		if (!SelfHasEffect(PCT.Buffs.SubtractivePaletteStack)) {

			if (SelfHasEffect(PCT.Buffs.Chroma2Ready))
				return PCT.AeroGreen;

			if (SelfHasEffect(PCT.Buffs.Chroma3Ready))
				return PCT.WaterBlue;

			return PCT.FireRed;
		}

		return actionID;
	}
}

internal class PictomancerAoECombo: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.PictomancerAOEComboFeature;
	public override uint[] ActionIDs { get; } = [PCT.ExtraBlizzardCyan];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte levels) {

		if (!SelfHasEffect(PCT.Buffs.SubtractivePaletteStack)) {

			if (SelfHasEffect(PCT.Buffs.Chroma2Ready))
				return PCT.ExtraAeroGreen;

			if (SelfHasEffect(PCT.Buffs.Chroma3Ready))
				return PCT.ExtraWaterBlue;

			return PCT.ExtraFireRed;
		}

		return actionID;

	}
}

internal class PictomancerHammerCombo: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.PictomancerWeaponMotifCombo;
	public override uint[] ActionIDs { get; } = [PCT.SteelMuse];

	protected override uint Invoke(uint actionID, uint lastComboActionId, float comboTime, byte level) {
		PCTGauge gauge = GetJobGauge<PCTGauge>();

		if (IsEnabled(CustomComboPreset.PictomancerWeaponMotifCombo)) {

			if (IsEnabled(CustomComboPreset.PictomancerHammerCombo) && SelfHasEffect(PCT.Buffs.HammerReady))
				return OriginalHook(PCT.HammerStamp);

			if (gauge.WeaponMotifDrawn)
				return OriginalHook(PCT.SteelMuse);

		}

		return OriginalHook(PCT.WeaponMotif);
	}


	internal class PictomancerScenicCombo: CustomCombo {
		public override CustomComboPreset Preset { get; } = CustomComboPreset.PictomancerScenicCombo;
		public override uint[] ActionIDs { get; } = [PCT.ScenicMuse];

		protected override uint Invoke(uint actionID, uint lastComboActionId, float comboTime, byte level) {
			PCTGauge gauge = GetJobGauge<PCTGauge>();

			if (IsEnabled(CustomComboPreset.PictomancerScenicCombo)) {

				if (IsEnabled(CustomComboPreset.PictomancerStarPrismCombo) && level >= 100 && SelfHasEffect(PCT.Buffs.StarPrismReady))
					return PCT.StarPrism;

				if (gauge.LandscapeMotifDrawn)
					return PCT.ScenicMuse;

			}

			return PCT.StarrySkyMotif;
		}
	}
}


internal class PictoimancerHolyCometCombo: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.PictomancerHolyCometCombo;
	public override uint[] ActionIDs { get; } = [PCT.HolyWhite];

	protected override uint Invoke(uint actionID, uint lastComboActionId, float comboTime, byte level) {
		PCTGauge gauge = GetJobGauge<PCTGauge>();

		if (level >= PCT.Levels.CometBlack && SelfHasEffect(PCT.Buffs.InvertedColors))
			return PCT.CometBlack;

		return actionID;
	}
}



internal class PictomancerCreatureCombo: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.PictomancerLivingMuseCombo;
	public override uint[] ActionIDs { get; } = [PCT.LivingMuse];

	protected override uint Invoke(uint actionID, uint lastComboActionId, float comboTime, byte level) {
		PCTGauge gauge = GetJobGauge<PCTGauge>();

		if (gauge.CreatureMotifDrawn)
			return OriginalHook(PCT.LivingMuse);

		return OriginalHook(PCT.CreatureMotif);
	}
}
