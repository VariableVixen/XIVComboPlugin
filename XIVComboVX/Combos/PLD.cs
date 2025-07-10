using VariableVixen.XIVComboVX;

namespace VariableVixen.XIVComboVX.Combos;

internal static class PLD {
	public const byte JobID = 19;

	public const uint
		FastBlade = 9,
		RiotBlade = 15,
		Sentinel = 17,
		Guardian = ushort.MaxValue,
		FightOrFlight = 20,
		RageOfHalone = 21,
		CircleOfScorn = 23,
		ShieldLob = 24,
		SpiritsWithin = 29,
		GoringBlade = 3538,
		RoyalAuthority = 3539,
		Sheltron = 3542,
		TotalEclipse = 7381,
		Requiescat = 7383,
		Imperator = ushort.MaxValue,
		HolySpirit = 7384,
		Prominence = 16457,
		HolyCircle = 16458,
		Confiteor = 16459,
		Atonement = 16460,
		Supplication = ushort.MaxValue,
		Sepulchre = ushort.MaxValue,
		Intervene = 16461,
		Expiacion = 25747,
		BladeOfFaith = 25748,
		BladeOfTruth = 25749,
		BladeOfValor = 25750,
		BladeOfHonor = ushort.MaxValue;

	public static class Buffs {
		public const ushort
			GoringBladeReady = ushort.MaxValue,
			AttonementReady = ushort.MaxValue,
			SupplicationReady = ushort.MaxValue,
			SepulchreReady = ushort.MaxValue,
			BladeOfHonorReady = ushort.MaxValue,
			FightOrFlight = 76,
			Requiescat = 1368,
			//SwordOath = 1902,
			DivineMight = 2673,
			ConfiteorReady = 3019;
	}

	public static class Debuffs {
		public const ushort
			GoringBlade = 725,
			BladeOfValor = 2721;
	}

	public static class Levels {
		public const byte
			FightOrFlight = 2,
			RiotBlade = 4,
			TotalEclipse = 6,
			ShieldLob = 15,
			SpiritsWithin = 30,
			Sheltron = 35,
			Sentinel = 38,
			CircleOfScorn = 50,
			RageOfHalone = 26,
			Prominence = 40,
			GoringBlade = 54,
			RoyalAuthority = 60,
			HolySpirit = 64,
			Requiescat = 68,
			HolyCircle = 72,
			Intervene = 74,
			Atonement = 76,
			Confiteor = 80,
			Expiacion = 86,
			BladeOfFaith = 90,
			BladeOfTruth = 90,
			BladeOfValor = 90;
	}
}

internal class PaladinStunInterruptFeature: StunInterruptCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.PaladinStunInterruptFeature;
}

internal class PaladinRoyalAuthorityCombo: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.PaladinRoyalAuthorityCombo;
	public override uint[] ActionIDs { get; } = [PLD.RageOfHalone, PLD.RoyalAuthority];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (CanWeave(actionID)) {

			if (IsEnabled(CustomComboPreset.PaladinRoyalWeaveFightOrFlight) && level >= PLD.Levels.FightOrFlight) {
				if (CanUse(PLD.FightOrFlight))
					return PLD.FightOrFlight;
			}

			if (IsEnabled(CustomComboPreset.PaladinRoyalWeaveSpiritsWithin) && level >= PLD.Levels.SpiritsWithin) {
				uint actual = OriginalHook(PLD.SpiritsWithin);
				if (CanUse(actual))
					return actual;
			}

		}

		if (IsEnabled(CustomComboPreset.PaladinRoyalConfiteor) && level >= PLD.Levels.Confiteor) {
			if (SelfHasEffect(PLD.Buffs.Requiescat))
				return OriginalHook(PLD.Confiteor);
		}

		if (IsEnabled(CustomComboPreset.PaladinRoyalAuthorityGoringBlade) && level >= PLD.Levels.GoringBlade) {
			if (SelfHasEffect(PLD.Buffs.GoringBladeReady))
				return PLD.GoringBlade;
		}

		if (IsEnabled(CustomComboPreset.PaladinRoyalAuthorityHolySpirit)) {
			if (level >= PLD.Levels.HolySpirit) {
				if (SelfHasEffect(PLD.Buffs.DivineMight))
					return PLD.HolySpirit;
			}
		}

		if (lastComboMove is PLD.FastBlade) {
			if (level >= PLD.Levels.RiotBlade)
				return PLD.RiotBlade;
		}
		else if (lastComboMove is PLD.RiotBlade) {
			if (level >= PLD.Levels.RageOfHalone)
				return OriginalHook(PLD.RageOfHalone);
		}

		if (IsEnabled(CustomComboPreset.PaladinRoyalAuthorityRangeSwapFeature)) {
			if (level >= PLD.Levels.Intervene) {
				if (TargetDistance is > 3 and <= 20)
					return PLD.Intervene;
			}
			else if (IsEnabled(CustomComboPreset.PaladinInterveneSyncFeature)) {
				if (level >= PLD.Levels.ShieldLob) {
					if (TargetDistance is > 3 and <= 20)
						return PLD.ShieldLob;
				}
			}
		}

		if (IsEnabled(CustomComboPreset.PaladinAtonementFeature)) {
			if (level >= PLD.Levels.Atonement) {
				if (SelfHasEffect(PLD.Buffs.AttonementReady))
					return PLD.Atonement;
				if (SelfHasEffect(PLD.Buffs.SupplicationReady))
					return PLD.Supplication;
				if (SelfHasEffect(PLD.Buffs.SepulchreReady))
					return PLD.Sepulchre;
			}
		}

		return PLD.FastBlade;
	}
}

internal class PaladinProminenceCombo: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.PaladinProminenceCombo;
	public override uint[] ActionIDs { get; } = [PLD.Prominence];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (CanWeave(actionID)) {

			if (IsEnabled(CustomComboPreset.PaladinProminenceWeaveFightOrFlight) && level >= PLD.Levels.FightOrFlight) {
				if (CanUse(PLD.FightOrFlight))
					return PLD.FightOrFlight;
			}

			if (IsEnabled(CustomComboPreset.PaladinProminenceWeaveCircleOfScorn) && level >= PLD.Levels.CircleOfScorn) {
				if (CanUse(PLD.CircleOfScorn))
					return PLD.CircleOfScorn;
			}

		}

		if (IsEnabled(CustomComboPreset.PaladinProminenceConfiteor) && level >= PLD.Levels.Confiteor) {
			if (SelfHasEffect(PLD.Buffs.Requiescat))
				return OriginalHook(PLD.Confiteor);
		}

		if (IsEnabled(CustomComboPreset.PaladinProminenceHolyCircle)) {
			if (level >= PLD.Levels.HolyCircle) {
				if (SelfHasEffect(PLD.Buffs.DivineMight))
					return PLD.HolyCircle;
			}
		}

		if (lastComboMove is PLD.TotalEclipse && level >= PLD.Levels.Prominence)
			return PLD.Prominence;

		return PLD.TotalEclipse;
	}
}

internal class PaladinHolySpiritHolyCircle: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.PaladinHolyConfiteor;
	public override uint[] ActionIDs { get; } = [PLD.HolySpirit, PLD.HolyCircle];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (level >= PLD.Levels.Confiteor) {
			if (SelfHasEffect(PLD.Buffs.Requiescat))
				return OriginalHook(PLD.Confiteor);
		}

		return actionID;
	}
}

internal class PaladinRequiescat: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.PaladinRequiescatConfiteor;
	public override uint[] ActionIDs { get; } = [PLD.Requiescat, PLD.Imperator];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (level >= PLD.Levels.Confiteor) {
			if (SelfHasEffect(PLD.Buffs.ConfiteorReady))
				return OriginalHook(PLD.Confiteor);
		}

		return actionID;
	}
}

internal class PaladinInterveneSyncFeature: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.PaladinInterveneSyncFeature;
	public override uint[] ActionIDs { get; } = [PLD.Intervene];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) => level < PLD.Levels.Intervene ? PLD.ShieldLob : actionID;
}

internal class PaladinSheltron: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.PaladinSheltronSentinel;
	public override uint[] ActionIDs { get; } = [PLD.Sheltron];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
		uint sentinel = OriginalHook(PLD.Sentinel);
		return level > PLD.Levels.Sentinel && CanUse(sentinel) ? sentinel : actionID;
	}
}
