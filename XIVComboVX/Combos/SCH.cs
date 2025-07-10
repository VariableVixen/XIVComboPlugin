using Dalamud.Game.ClientState.JobGauge.Types;

using Microsoft.Win32.SafeHandles;

namespace VariableVixen.XIVComboVX.Combos;

internal static class SCH {
	public const byte JobID = 28;

	public const uint
		Resurrection = 173,
		Aetherflow = 166,
		EnergyDrain = 167,
		SacredSoil = 188,
		Lustrate = 189,
		Indomitability = 3583,
		Broil = 3584,
		DeploymentTactics = 3585,
		EmergencyTactics = 3586,
		Dissipation = 3587,
		Excogitation = 7434,
		Broil2 = 7435,
		ChainStratagem = 7436,
		Aetherpact = 7437,
		WhisperingDawn = 16537,
		FeyIllumination = 16538,
		ArtOfWar = 16539,
		Broil3 = 16541,
		Recitation = 16542,
		FeyBless = 16543,
		SummonSeraph = 16545,
		Consolation = 16546,
		SummonEos = 17215,
		SummonSelene = 17216,
		Ruin = 17869,
		Ruin2 = 17870,
		Broil4 = 25865,
		ArtOfWar2 = 25866,
		BanefulImpaction = 37012;

	public static class Buffs {
		public const ushort
			Dissipation = 791,
			Recitation = 1896,
			ImpactImminent = 3882;
	}

	public static class Debuffs {
		// public const ushort placeholder = 0;
	}

	public static class Levels {
		public const byte
			Aetherflow = 45,
			Lustrate = 45,
			Excogitation = 62,
			ChainStratagem = 66,
			Recitation = 74,
			Consolation = 80,
			SummonSeraph = 80,
			BanefulImpaction = 92;
	}
}

internal class ScholarSwiftcastRaiserFeature: SwiftRaiseCombo {
	public override CustomComboPreset Preset => CustomComboPreset.ScholarSwiftcastRaiserFeature;
}

internal class ScholarArtOfWar: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.ScholarLucidArtOfWar;
	public override uint[] ActionIDs { get; } = [SCH.ArtOfWar, SCH.ArtOfWar2];

	protected override uint Invoke(uint actionID, uint lastComboActionId, float comboTime, byte level) {

		if (Common.CheckLucidWeave(this.Preset, level, Service.Configuration.ScholarLucidArtOfWarManaThreshold, actionID))
			return Common.LucidDreaming;

		return actionID;
	}
}

internal class ScholarRuinBoil: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.SchAny;
	public override uint[] ActionIDs { get; } = [SCH.Ruin, SCH.Broil, SCH.Broil2, SCH.Broil3, SCH.Broil4];

	protected override uint Invoke(uint actionID, uint lastComboActionId, float comboTime, byte level) {

		if (Common.CheckLucidWeave(CustomComboPreset.ScholarLucidRuinBroil, level, Service.Configuration.ScholarLucidRuinBroilManaThreshold, actionID))
			return Common.LucidDreaming;

		if (IsEnabled(CustomComboPreset.ScholarMobileRuinBroil)) {
			if (IsMoving)
				return SCH.Ruin2;
		}

		return actionID;
	}
}

internal class ScholarFeyBless: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.ScholarSeraphConsolationFeature;
	public override uint[] ActionIDs { get; } = [SCH.FeyBless];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (level >= SCH.Levels.Consolation && GetJobGauge<SCHGauge>().SeraphTimer > 0)
			return SCH.Consolation;

		return actionID;
	}
}

internal class ScholarExcogitation: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.ScholarExcogFallbackFeature;
	public override uint[] ActionIDs { get; } = [SCH.Excogitation];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (IsEnabled(CustomComboPreset.ScholarExcogitationRecitationFeature)) {
			if (level >= SCH.Levels.Recitation && IsOffCooldown(SCH.Recitation))
				return SCH.Recitation;
		}

		if (IsEnabled(CustomComboPreset.ScholarExcogFallbackFeature)) {
			if (level < SCH.Levels.Excogitation || IsOnCooldown(SCH.Excogitation))
				return SCH.Lustrate;
		}

		return actionID;
	}
}

internal class ScholarEnergyDrain: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.ScholarEnergyDrainAetherflowFeature;
	public override uint[] ActionIDs { get; } = [SCH.EnergyDrain];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (level >= SCH.Levels.Aetherflow && GetJobGauge<SCHGauge>().Aetherflow == 0)
			return SCH.Aetherflow;

		return actionID;
	}
}

internal class ScholarLustrate: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.SmnAny;
	public override uint[] ActionIDs { get; } = [SCH.Lustrate];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (IsEnabled(CustomComboPreset.ScholarLustrateRecitationFeature)) {
			if (level >= SCH.Levels.Recitation && IsOffCooldown(SCH.Recitation))
				return SCH.Recitation;
		}

		if (IsEnabled(CustomComboPreset.ScholarLustrateExcogitationFeature)) {
			if (level >= SCH.Levels.Excogitation && IsOffCooldown(SCH.Excogitation))
				return SCH.Excogitation;
		}

		if (IsEnabled(CustomComboPreset.ScholarLustrateAetherflowFeature)) {
			if (level >= SCH.Levels.Aetherflow && GetJobGauge<SCHGauge>().Aetherflow == 0)
				return SCH.Aetherflow;
		}

		return actionID;
	}
}

internal class ScholarIndomitability: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.ScholarIndomAetherflowFeature;
	public override uint[] ActionIDs { get; } = [SCH.Indomitability];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (level >= SCH.Levels.Aetherflow && GetJobGauge<SCHGauge>().Aetherflow == 0 && !SelfHasEffect(SCH.Buffs.Recitation))
			return SCH.Aetherflow;

		return actionID;
	}
}

internal class ScholarSummon: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.ScholarSeraphFeature;
	public override uint[] ActionIDs { get; } = [SCH.SummonEos, SCH.SummonSelene];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
		SCHGauge gauge = GetJobGauge<SCHGauge>();

		if (gauge.SeraphTimer > 0 || HasPetPresent)
			return OriginalHook(SCH.SummonSeraph);

		return actionID;
	}
}

internal class ScholarChainStratagem: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.ScholarChainStratagemBanefulImpaction;
	public override uint[] ActionIDs { get; } = [SCH.ChainStratagem];

	protected override uint Invoke(uint actionID, uint lastComboActionId, float comboTime, byte level) {

		if (level >= SCH.Levels.BanefulImpaction && SelfHasEffect(SCH.Buffs.ImpactImminent))
			return SCH.BanefulImpaction;

		return actionID;
	}
}
