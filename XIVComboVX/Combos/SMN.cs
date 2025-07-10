using Dalamud.Game.ClientState.JobGauge.Types;

namespace VariableVixen.XIVComboVX.Combos;

internal static class SMN {
	public const byte JobID = 27;

	public const uint
			//Buttons that can be put on the bar
			Ruin = 173,
			SummonCarbuncle = 25798,
			RadiantAegis = 25799,
			Physick = 16230,
			Aethercharge = 25800,
			Gemshine = 25883,
			EnergyDrain = 25883,
			Fester = 181,
			Resurrection = 173,
			SummonTopaz = 25803,
			SummonEmerald = 25804,
			Outburst = 16511,
			PreciousBrilliance = 25884,
			Ruin2 = 172,
			SummonIfrit = 25805,
			SummonTitan = 25806,
			Painflare = 3578,
			SummonGardua = 25807,
			EnergySyphon = 16510,
			Ruin3 = 3579,
			AstralFlow = 25822,
			Ruin4 = 7426,
			SearingLight = 7426,
			EnkindleBahamut = 7429,
			SummonIfrit2 = 25838,
			SummonGaruda2 = 25807,
			SummonTitan2 = 25839,
			SearingFlash = 36991,
			LuxSolaris = 36997,
			//Buttons that cannot be put on the bar
			AstralImpulse = 25820,
			AstralFlare = 25821,
			Deathflare = 3582,
			Wyrmwave = 7428,
			AkhMorn = 7449,
			RubyRite = 25823,
			TopazRite = 25824,
			EmeraldRite = 25825,
			SummonPhoenix = 25831,
			FountainOfFire = 16514,
			BrandOfPurgatory = 16515,
			Rekindle = 25830,
			EnkindlePhoenix = 16516,
			EverlastingFlight = 16517,
			ScarletFlame = 16519,
			Revelation = 16518,
			RubyCatastrophe = 25832,
			TopazCatastrophe = 25833,
			EmeraldCatastrophe = 25834,
			CrimsonCyclone = 25835,
			CrimsonStrike = 25885,
			MountainBuster = 25836,
			Slipstream = 25837,
			SummonSolarBahamut = 36992,
			UmbralImpulse = 36994,
			UmbralFlare = 36995,
			Sunflare = 36996,
			EnkindleSolarBahamut = 36998,
			Luxwave = 36993,
			Exodus = 36999;

	public static class Buffs {
		public const ushort
			FurtherRuin = 2701,
			IfritsFavor = 2724,
			GarudasFavor = 2725,
			TitansFavor = 2853;
	}

	public static class Debuffs {
		// public const ushort placeholder = 0;
	}

	public static class Levels {
		public const byte
			//Buttons that can be put on the bar
			Ruin = 1,
			SummonCarbuncle = 2,
			RadiantAegis = 2,
			Physick = 4,
			Aethercharge = 6,
			Gemshine = 6,
			EnergyDrain = 10,
			Fester = 10,
			Resurrection = 12,
			SummonTopaz = 15,
			SummonEmerald = 22,
			Outburst = 26,
			PreciousBrilliance = 26,
			Ruin2 = 30,
			SummonIfrit = 30,
			SummonTitan = 35,
			Painflare = 40,
			SummonGaruda = 45,
			EnergySyphon = 52,
			Ruin3 = 54,
			AstralFlow = 60,
			Ruin4 = 62,
			SearingLight = 66,
			EnkindleBahamut = 70,
			SummonIfrit2 = 90,
			SummonGaruda2 = 90,
			SummonTitan2 = 90,
			SearingFlash = 96,
			LuxSolaris = 100,
			//Buttons that cannot be put on the bar
			AstralImpulse = 58,
			AstralFlare = 58,
			Deathflare = 60,
			Wyrmwave = 70,
			AkhMorn = 70,
			RubyRite = 72,
			TopazRite = 72,
			EmeraldRite = 72,
			SummonPhoenix = 80,
			FountainOfFire = 80,
			BrandOfPurgatory = 80,
			Rekindle = 80,
			EnkindlePhoenix = 80,
			EverlastingFlight = 80,
			ScarletFlame = 80,
			Revelation = 80,
			RubyCatastrophe = 82,
			TopazCatastrophe = 82,
			EmeraldCatastrophe = 82,
			CrimsonCyclone = 86,
			CrimsonStrike = 86,
			MountainBuster = 86,
			Slipstream = 86,
			SummonSolarBahamut = 100,
			UmbralImpulse = 100,
			UmbralFlare = 100,
			Sunflare = 100,
			EnkindleSolarBahamut = 100,
			Luxwave = 100,
			Exodus = 100;


	}
}

internal class SummonerSwiftcastRaiserFeature: SwiftRaiseCombo {
	public override CustomComboPreset Preset => CustomComboPreset.SummonerSwiftcastRaiserFeature;
}

/* returning Soon™ (when we have the time to go over everything)

internal class SummonerEDFesterCombo: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.SummonerEDFesterCombo;
	public override uint[] ActionIDs { get; } = [SMN.Fester];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (level >= SMN.Levels.EnergyDrain && !GetJobGauge<SMNGauge>().HasAetherflowStacks)
			return SMN.EnergyDrain;

		return actionID;
	}
}

internal class SummonerESPainflareCombo: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.SummonerESPainflareCombo;
	public override uint[] ActionIDs { get; } = [SMN.Painflare];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (level >= SMN.Levels.EnergySyphon && !GetJobGauge<SMNGauge>().HasAetherflowStacks)
			return SMN.EnergySyphon;

		if (level < SMN.Levels.Painflare)
			return SMN.EnergyDrain;

		return actionID;
	}
}

internal class SummonerRuinFeature: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.SmnAny;
	public override uint[] ActionIDs { get; } = [SMN.Ruin, SMN.Ruin2, SMN.Ruin3];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
		SMNGauge gauge = GetJobGauge<SMNGauge>();

		if (IsEnabled(CustomComboPreset.SummonerRuinTitansFavorFeature) && level >= SMN.Levels.ElementalMastery && SelfHasEffect(SMN.Buffs.TitansFavor))
			return SMN.MountainBuster;

		if (IsEnabled(CustomComboPreset.SummonerRuinFeature) && level >= SMN.Levels.Gemshine && (gauge.IsIfritAttuned || gauge.IsTitanAttuned || gauge.IsGarudaAttuned))
			return OriginalHook(SMN.Gemshine);

		if (IsEnabled(CustomComboPreset.SummonerFurtherRuinFeature) && level >= SMN.Levels.Ruin4 && gauge.SummonTimerRemaining == 0 && gauge.AttunmentTimerRemaining == 0 && SelfHasEffect(SMN.Buffs.FurtherRuin))
			return SMN.Ruin4;

		return actionID;
	}
}

internal class SummonerOutburstFeature: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.SmnAny;
	public override uint[] ActionIDs { get; } = [SMN.Outburst, SMN.TriDisaster];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
		SMNGauge gauge = GetJobGauge<SMNGauge>();

		if (IsEnabled(CustomComboPreset.SummonerOutburstTitansFavorFeature) && level >= SMN.Levels.ElementalMastery && SelfHasEffect(SMN.Buffs.TitansFavor))
			return SMN.MountainBuster;

		if (IsEnabled(CustomComboPreset.SummonerOutburstFeature) && level >= SMN.Levels.PreciousBrilliance && (gauge.IsIfritAttuned || gauge.IsTitanAttuned || gauge.IsGarudaAttuned))
			return OriginalHook(SMN.PreciousBrilliance);

		if (IsEnabled(CustomComboPreset.SummonerFurtherOutburstFeature) && level >= SMN.Levels.Ruin4 && gauge.SummonTimerRemaining == 0 && gauge.AttunmentTimerRemaining == 0 && SelfHasEffect(SMN.Buffs.FurtherRuin))
			return SMN.Ruin4;

		return actionID;
	}
}

internal class SummonerShinyFeature: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.SmnAny;
	public override uint[] ActionIDs { get; } = [SMN.Gemshine, SMN.PreciousBrilliance];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
		SMNGauge gauge = GetJobGauge<SMNGauge>();

		if (IsEnabled(CustomComboPreset.SummonerShinyTitansFavorFeature) && level >= SMN.Levels.ElementalMastery && SelfHasEffect(SMN.Buffs.TitansFavor))
			return SMN.MountainBuster;

		if (IsEnabled(CustomComboPreset.SummonerShinyEnkindleFeature) && level >= SMN.Levels.EnkindleBahamut && !gauge.IsIfritAttuned && !gauge.IsTitanAttuned && !gauge.IsGarudaAttuned && gauge.SummonTimerRemaining > 0)
			return OriginalHook(SMN.EnkindleBahamut);

		if (IsEnabled(CustomComboPreset.SummonerFurtherShinyFeature) && level >= SMN.Levels.Ruin4 && gauge.SummonTimerRemaining == 0 && gauge.AttunmentTimerRemaining == 0 && SelfHasEffect(SMN.Buffs.FurtherRuin))
			return SMN.Ruin4;

		return actionID;
	}
}

internal class SummonerDemiFeature: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.SummonerDemiEnkindleFeature;
	public override uint[] ActionIDs { get; } = [SMN.Aethercharge, SMN.DreadwyrmTrance, SMN.SummonBahamut];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
		SMNGauge gauge = GetJobGauge<SMNGauge>();

		if (level >= SMN.Levels.EnkindleBahamut && !gauge.IsIfritAttuned && !gauge.IsTitanAttuned && !gauge.IsGarudaAttuned && gauge.SummonTimerRemaining > 0)
			return OriginalHook(SMN.EnkindleBahamut);

		return actionID;
	}
}

internal class SummonerRadiantCarbundleFeature: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.SummonerRadiantCarbuncleFeature;
	public override uint[] ActionIDs { get; } = [SMN.RadiantAegis];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (level >= SMN.Levels.SummonCarbuncle && !HasPetPresent && GetJobGauge<SMNGauge>().Attunement == 0)
			return SMN.SummonCarbuncle;

		return actionID;
	}
}

internal class SummonerSlipcastFeature: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.SummonerSlipcastFeature;
	public override uint[] ActionIDs { get; } = [SMN.AstralFlow, SMN.Slipstream];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (SelfHasEffect(SMN.Buffs.GarudasFavor) && IsOffCooldown(Common.Swiftcast))
			return Common.Swiftcast;

		return OriginalHook(actionID);
	}
}
*/
