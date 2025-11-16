using Dalamud.Game.ClientState.JobGauge.Types;

namespace VariableVixen.XIVComboVX.Combos;

internal static class SMN
{
    public const byte ClassID = 26;
    public const byte JobID = 27;

    public const uint

        Ruin = 163,
        Ruin2 = 172,
        Ruin3 = 3579,
        Ruin4 = 7426,
        Fester = 181,
        Painflare = 3578,
        DreadwyrmTrance = 3581,
        Deathflare = 3582,
        SummonBahamut = 7427,
        EnkindleBahamut = 7429,
        Physick = 16230,
        EnergySyphon = 16510,
        Outburst = 16511,
        EnkindlePhoenix = 16516,
        EnergyDrain = 16508,
        SummonCarbuncle = 25798,
        RadiantAegis = 25799,
        Aethercharge = 25800,
        SearingLight = 25801,
        SummonRuby = 25802,
        SummonTopaz = 25803,
        SummonEmerald = 25804,
        SummonIfrit = 25805,
        SummonTitan = 25806,
        SummonGaruda = 25807,
        AstralFlow = 25822,
        TriDisaster = 25826,
        Rekindle = 25830,
        SummonPhoenix = 25831,
        CrimsonCyclone = 25835,
        MountainBuster = 25836,
        Slipstream = 25837,
        SummonIfrit2 = 25838,
        SummonTitan2 = 25839,
        SummonGaruda2 = 25840,
        CrimsonStrike = 25885,
        Gemshine = 25883,
        PreciousBrilliance = 25884,
        Necrosis = 36990,
        SearingFlash = 36991,
        SummonSolarBahamut = 36992,
        Sunflare = 36996,
        LuxSolaris = 36997,
        EnkindleSolarBahamut = 36998,
		Resurrection = 173;

    public static class Buffs
    {
        public const ushort
            Aetherflow = 304,
            FurtherRuin = 2701,
            SearingLight = 2703,
            IfritsFavor = 2724,
            GarudasFavor = 2725,
            TitansFavor = 2853,
            RubysGlimmer = 3873,
            LuxSolarisReady = 3874,
            CrimsonStrikeReady = 4403;
    }

    public static class Debuffs
    {
        public const ushort
            Placeholder = 0;
    }

    public static class Levels
    {
        public const byte
            SummonCarbuncle = 2,
            RadiantAegis = 2,
            Gemshine = 6,
            EnergyDrain = 10,
            Fester = 10,
            PreciousBrilliance = 26,
            Painflare = 40,
            EnergySyphon = 52,
            Ruin3 = 54,
            Ruin4 = 62,
            SearingLight = 66,
            EnkindleBahamut = 70,
            Rekindle = 80,
            ElementalMastery = 86,
            SummonPhoenix = 80,
            Necrosis = 92,
            SummonSolarBahamut = 100,
            LuxSolaris = 100,
			Resurrection = 12;
    }
}

internal class SummonerSwiftcastRaiserFeature: SwiftRaiseCombo {
	public override CustomComboPreset Preset => CustomComboPreset.SummonerSwiftcastRaiserFeature;
}

// returning Soon™ (when we have the time to go over everything)

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

		if (level < SMN.Levels.EnergySyphon && !GetJobGauge<SMNGauge>().HasAetherflowStacks)
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

		if (IsEnabled(CustomComboPreset.SummonerFurtherRuinFeature) && level >= SMN.Levels.Ruin4 && gauge.SummonTimerRemaining == 0 && gauge.AttunementTimerRemaining == 0 && SelfHasEffect(SMN.Buffs.FurtherRuin))
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

		if (IsEnabled(CustomComboPreset.SummonerFurtherOutburstFeature) && level >= SMN.Levels.Ruin4 && gauge.SummonTimerRemaining == 0 && gauge.AttunementTimerRemaining == 0 && SelfHasEffect(SMN.Buffs.FurtherRuin))
			return SMN.Ruin4;

		return actionID;
	}
}
/*
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
