using Dalamud.Game.ClientState.JobGauge.Types;

namespace VariableVixen.XIVComboVX.Combos;

internal static class BLM {
	public const byte JobID = 25;

	public const uint
		Fire = 141,
		Blizzard = 142,
		Thunder = 144,
		Fire2 = 147,
		Transpose = 149,
		Fire3 = 152,
		Thunder3 = 153,
		Blizzard3 = 154,
		Scathe = 156,
		Freeze = 159,
		Flare = 162,
		LeyLines = 3573,
		Blizzard4 = 3576,
		Fire4 = 3577,
		BetweenTheLines = 7419,
		Despair = 16505,
		UmbralSoul = 16506,
		Xenoglossy = 16507,
		Blizzard2 = 25793,
		HighFire2 = 25794,
		HighBlizzard2 = 25795,
		Paradox = 25797,
		HighThunder = 36986,
		HighThunder2 = 36987,
		Retrace = 36988,
		FlareStar = 36989;

	public static class Buffs {
		public const ushort
			Thundercloud = 164,
			Firestarter = 165,
			LeyLines = 737,
			EnhancedFlare = 2960;
	}

	public static class Debuffs {
		public const ushort
			Thunder = 161,
			Thunder3 = 163,
			HighThunder = 3871,
			Highthunder2 = 3872;
	}

	public static class Levels {
		public const byte
			Blizzard = 1,
			Fire = 2,
			Transpose = 4,
			Thunder = 6,
			Blizzard2 = 12,
			Scathe = 15,
			Fire2 = 18,
			Thunder2 = 26,
			Manaward = 30,
			Manafont = 30,
			Fire3 = 35,
			Blizzard3 = 35,
			UmbralSoul = 35,
			Freeze = 40,
			Thunder3 = 45,
			AetherialManipulation = 50,
			Flare = 50,
			LeyLines = 52,
			Blizzard4 = 58,
			Fire4 = 60,
			BetweenTheLines = 62,
			Thunder4 = 64,
			Triplecast = 66,
			Foul = 70,
			Despair = 72,
			Xenoglossy = 80,
			HighFire2 = 82,
			HighBlizzard2 = 82,
			Amplifier = 86,
			Paradox = 90,
			HighThunder = 92,
			HighTunder2 = 92,
			Retrace = 96,
			FlareStar = 100;
	}
}

/* returning Soon™ (when we have the time to go over everything)

internal class BlackFireBlizzard4: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.BlmAny;
	public override uint[] ActionIDs => [BLM.Fire4, BLM.Blizzard4];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
		BLMGauge gauge = GetJobGauge<BLMGauge>();

		if (IsEnabled(CustomComboPreset.BlackUmbralSoulFeature)) {
			if (actionID is BLM.Blizzard4 && level >= BLM.Levels.UmbralSoul && gauge.InUmbralIce && !HasTarget)
				return BLM.UmbralSoul;
		}

		if (actionID is BLM.Fire4 or BLM.Blizzard4) {

			if (IsEnabled(CustomComboPreset.BlackEnochianFeature)) {

				if (gauge.InAstralFire) {

					if (IsEnabled(CustomComboPreset.BlackEnochianDespairFeature) && level >= BLM.Levels.Despair && LocalPlayer?.CurrentMp < 2400)
						return BLM.Despair;

					if (IsEnabled(CustomComboPreset.BlackEnochianNoSyncFeature) || level >= BLM.Levels.Fire4)
						return BLM.Fire4;

					return BLM.Fire;
				}

				if (gauge.InUmbralIce) {

					if (IsEnabled(CustomComboPreset.BlackEnochianNoSyncFeature) || level >= BLM.Levels.Blizzard4)
						return BLM.Blizzard4;

					return BLM.Blizzard;
				}
			}
		}

		return actionID;
	}
}

internal class BlackTranspose: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.BlackManaFeature;
	public override uint[] ActionIDs => [BLM.Transpose];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
		BLMGauge gauge = GetJobGauge<BLMGauge>();

		if (level >= BLM.Levels.UmbralSoul && gauge.IsEnochianActive && gauge.InUmbralIce)
			return BLM.UmbralSoul;

		return actionID;
	}
}

internal class BlackLeyLines: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.BlackLeyLinesFeature;
	public override uint[] ActionIDs => [BLM.LeyLines];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (level >= BLM.Levels.BetweenTheLines && SelfHasEffect(BLM.Buffs.LeyLines))
			return BLM.BetweenTheLines;

		return actionID;
	}
}

internal class BlackFireFeature: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.BlmAny;
	public override uint[] ActionIDs { get; } = [BLM.Fire];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
		BLMGauge gauge = GetJobGauge<BLMGauge>();

		if (level >= BLM.Levels.Paradox && gauge.IsParadoxActive && (gauge.InUmbralIce || LocalPlayer?.CurrentMp >= 1600))
			return BLM.Paradox;

		if (level >= BLM.Levels.Fire3
			&& (
				(IsEnabled(CustomComboPreset.BlackFireAstralFeature) && gauge.AstralFireStacks <= 1)
				|| (IsEnabled(CustomComboPreset.BlackFireProcFeature) && SelfHasEffect(BLM.Buffs.Firestarter))
			)
		) {
			return BLM.Fire3;
		}

		return OriginalHook(BLM.Fire);
	}
}

internal class BlackBlizzard: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.BlmAny;
	public override uint[] ActionIDs => [BLM.Blizzard, BLM.Blizzard3];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
		BLMGauge gauge = GetJobGauge<BLMGauge>();

		if (IsEnabled(CustomComboPreset.BlackUmbralSoulFeature)) {
			if (level >= BLM.Levels.UmbralSoul && gauge.InUmbralIce && !HasTarget)
				return BLM.UmbralSoul;
		}

		if (IsEnabled(CustomComboPreset.BlackBlizzardFeature)) {

			if (level >= BLM.Levels.Paradox && gauge.IsParadoxActive && (gauge.InUmbralIce || LocalPlayer?.CurrentMp >= 1600))
				return BLM.Paradox;

			if (level >= BLM.Levels.Blizzard3)
				return BLM.Blizzard3;

			return BLM.Blizzard;
		}

		return actionID;
	}
}

internal class BlackFreezeFlare: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.BlmAny;
	public override uint[] ActionIDs => [BLM.Freeze, BLM.Flare];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
		BLMGauge gauge = GetJobGauge<BLMGauge>();

		if (actionID is BLM.Freeze) {
			if (IsEnabled(CustomComboPreset.BlackUmbralSoulFeature)) {
				if (level >= BLM.Levels.UmbralSoul && gauge.InUmbralIce && !HasTarget)
					return BLM.UmbralSoul;
			}
		}

		if (IsEnabled(CustomComboPreset.BlackFreezeFlareFeature)) {
			if (level >= BLM.Levels.Freeze && gauge.InUmbralIce)
				return BLM.Freeze;

			if (level >= BLM.Levels.Flare && gauge.InAstralFire)
				return BLM.Flare;
		}

		return actionID;
	}
}

internal class BlackFire2: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.BlackFire2Feature;
	public override uint[] ActionIDs => [BLM.Fire2, BLM.HighFire2];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
		BLMGauge gauge = GetJobGauge<BLMGauge>();

		if (IsEnabled(CustomComboPreset.BlackFireBlizzard2Option)) {
			if (gauge.AstralFireStacks < 3)
				return actionID;
		}

		if (level >= BLM.Levels.Flare
			&& gauge.InAstralFire &&
			(gauge.UmbralHearts == 1 || LocalPlayer?.CurrentMp < 3800 || SelfHasEffect(BLM.Buffs.EnhancedFlare))
		) {
			return BLM.Flare;
		}

		return actionID;
	}
}

internal class BlackBlizzard2: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.BlmAny;
	public override uint[] ActionIDs => [BLM.Blizzard2, BLM.HighBlizzard2];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
		BLMGauge gauge = GetJobGauge<BLMGauge>();

		if (IsEnabled(CustomComboPreset.BlackUmbralSoulFeature)) {
			if (level >= BLM.Levels.UmbralSoul && gauge.InUmbralIce && !HasTarget)
				return BLM.UmbralSoul;
		}

		if (IsEnabled(CustomComboPreset.BlackBlizzard2Feature)) {
			if (IsEnabled(CustomComboPreset.BlackFireBlizzard2Option)) {
				if (gauge.UmbralIceStacks < 3)
					return actionID;
			}

			if (level >= BLM.Levels.Freeze && gauge.InUmbralIce)
				return BLM.Freeze;
		}

		return actionID;
	}
}

internal class BlackScathe: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.BlackScatheFeature;
	public override uint[] ActionIDs => [BLM.Scathe];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (level >= BLM.Levels.Xenoglossy && GetJobGauge<BLMGauge>().PolyglotStacks > 0)
			return BLM.Xenoglossy;

		return actionID;
	}
}



internal class BlackFireToIce3: CustomCombo {
	public override CustomComboPreset Preset { get;} = CustomComboPreset.BlackFireToIce3;
	public override uint[] ActionIDs => [BLM.Blizzard3];
	protected override uint Invoke(uint actionID, uint lastComboActionId, float comboTime, byte level) {
		BLMGauge gauge = GetJobGauge<BLMGauge>();

		if (gauge.InAstralFire && LocalPlayer.CurrentMp >= 1600 && level >= BLM.Blizzard3)
			return BLM.Blizzard;

		return BLM.Blizzard3;

	}
}

internal class BlackIceToFire3: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.BlackIceToFire3;
	public override uint[] ActionIDs => [BLM.Fire3];
	protected override uint Invoke(uint actionID, uint lastComboActionId, float comboTime, byte level) {
		BLMGauge gauge = GetJobGauge<BLMGauge>();

		if (gauge.InUmbralIce && level >= BLM.Fire3)
			return BLM.Fire;

		return BLM.Fire3;

	}
}

*/
