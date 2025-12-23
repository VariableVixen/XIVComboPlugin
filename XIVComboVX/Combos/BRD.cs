using Dalamud.Game.ClientState.JobGauge.Enums;
using Dalamud.Game.ClientState.JobGauge.Types;
using Dalamud.Game.ClientState.Statuses;

namespace VariableVixen.XIVComboVX.Combos;

internal static class BRD {
	public const byte JobID = 23;

	public const uint
		HeavyShot = 97,
		StraightShot = 98,
		VenomousBite = 100,
		RagingStrikes = 101,
		QuickNock = 106,
		Barrage = 107,
		Bloodletter = 110,
		Windbite = 113,
		RainOfDeath = 117,
		BattleVoice = 118,
		EmpyrealArrow = 3558,
		WanderersMinuet = 3559,
		IronJaws = 3560,
		Sidewinder = 3562,
		PitchPerfect = 7404,
		CausticBite = 7406,
		Stormbite = 7407,
		RefulgentArrow = 7409,
		BurstShot = 16495,
		ApexArrow = 16496,
		Shadowbite = 16494,
		Ladonsbite = 25783,
		BlastArrow = 25784,
		RadiantFinale = 25785;

	public static class Buffs {
		public const ushort
			Troubadour = 1934,
			Repertoire = 3137,
			WanderersMinuet = 2216,
			BlastShotReady = 2692,
			HawksEye = 3861;
	}

	public static class Debuffs {
		public const ushort
			VenomousBite = 124,
			Windbite = 129,
			CausticBite = 1200,
			Stormbite = 1201;
	}

	public static class Levels {
		public const byte
			StraightShot = 2,
			RagingStrikes = 4,
			VenomousBite = 6,
			Bloodletter = 12,
			Windbite = 30,
			RainOfDeath = 45,
			BattleVoice = 50,
			PitchPerfect = 52,
			EmpyrealArrow = 54,
			IronJaws = 56,
			Sidewinder = 60,
			BiteUpgrade = 64,
			RefulgentArrow = 70,
			Shadowbite = 72,
			BurstShot = 76,
			ApexArrow = 80,
			Ladonsbite = 82,
			BlastShot = 86,
			RadiantFinale = 90;
	}
}

internal class BardHeavyBurstShot: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.BrdAny;
	public override uint[] ActionIDs { get; } = [BRD.HeavyShot, BRD.BurstShot];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (CanWeave(actionID)) {

			if (IsEnabled(CustomComboPreset.BardWeavePitchPerfect) && level >= BRD.Levels.PitchPerfect) {
				BRDGauge gauge = GetJobGauge<BRDGauge>();

				if (gauge.Song is Song.Wanderer && gauge.Repertoire > 0) {
					IStatus? minuet = SelfFindEffect(BRD.Buffs.WanderersMinuet);

					if (gauge.SongTimer / 1000f <= Service.Configuration.BardWanderersMinuetBuffThreshold)
						return BRD.PitchPerfect;

					if (gauge.Repertoire == 3)
						return BRD.PitchPerfect;
				}
			}

			if (IsEnabled(CustomComboPreset.BardWeaveBattleVoice) && level >= BRD.Levels.BattleVoice) {
				if (CanUse(BRD.BattleVoice))
					return BRD.BattleVoice;
			}

			if (IsEnabled(CustomComboPreset.BardWeaveRagingStrikes) && level >= BRD.Levels.RagingStrikes) {
				if (CanUse(BRD.RagingStrikes))
					return BRD.RagingStrikes;
			}

			if (IsEnabled(CustomComboPreset.BardWeaveSidewinder) && level >= BRD.Levels.Sidewinder) {
				if (CanUse(BRD.Sidewinder))
					return BRD.Sidewinder;
			}

			if (IsEnabled(CustomComboPreset.BardWeaveEmpyrealArrow) && level >= BRD.Levels.EmpyrealArrow) {
				if (CanUse(BRD.EmpyrealArrow))
					return BRD.EmpyrealArrow;
			}

			if (IsEnabled(CustomComboPreset.BardWeaveBloodletter) && level >= BRD.Levels.Bloodletter) {
				if (CanUse(BRD.Bloodletter))
					return BRD.Bloodletter;
			}

			if (IsEnabled(CustomComboPreset.BardWeaveDeathRain) && level >= BRD.Levels.RainOfDeath) {
				if (CanUse(BRD.RainOfDeath))
					return BRD.RainOfDeath;
			}

		}

		if (IsEnabled(CustomComboPreset.BardStraightShotIronJaws) && level >= BRD.Levels.VenomousBite) {
			ushort poisonStatusId = level >= BRD.Levels.BiteUpgrade
				? BRD.Debuffs.CausticBite
				: BRD.Debuffs.VenomousBite;
			uint poisonActionId = level >= BRD.Levels.BiteUpgrade
				? BRD.CausticBite
				: BRD.VenomousBite;
			ushort windStatusId = level >= BRD.Levels.BiteUpgrade
				? BRD.Debuffs.Stormbite
				: BRD.Debuffs.Windbite;
			uint windActionId = level >= BRD.Levels.BiteUpgrade
				? BRD.Stormbite
				: BRD.Windbite;
			IStatus? poison = TargetFindOwnEffect(poisonStatusId);
			IStatus? wind = level >= BRD.Levels.Windbite
				? TargetFindOwnEffect(windStatusId)
				: null;

			if (wind is null && level >= BRD.Levels.Windbite)
				return windActionId;

			if (poison is null)
				return poisonActionId;

			if (wind is not null && wind.RemainingTime < Service.Configuration.BardBiteDebuffThreshold) {
				return level >= BRD.Levels.IronJaws
					? BRD.IronJaws
					: windActionId;
			}

			if (poison.RemainingTime < Service.Configuration.BardBiteDebuffThreshold) {
				return level >= BRD.Levels.IronJaws
					? BRD.IronJaws
					: poisonActionId;
			}

		}

		if (IsEnabled(CustomComboPreset.BardApexFeature)) {

			if (level >= BRD.Levels.BlastShot && SelfHasEffect(BRD.Buffs.BlastShotReady))
				return BRD.BlastArrow;

			if (level >= BRD.Levels.ApexArrow && GetJobGauge<BRDGauge>().SoulVoice == 100)
				return BRD.ApexArrow;

		}

		if (IsEnabled(CustomComboPreset.BardStraightShotUpgradeFeature)) {
			if (level >= BRD.Levels.StraightShot && SelfHasEffect(BRD.Buffs.HawksEye))
				return OriginalHook(BRD.StraightShot);
		}

		return actionID;
	}
}

internal class BardIronJaws: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.BardIronBites;
	public override uint[] ActionIDs { get; } = [BRD.IronJaws];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (level < BRD.Levels.Windbite)
			return BRD.VenomousBite;

		if (level < BRD.Levels.IronJaws) {

			IStatus? venomous = TargetFindOwnEffect(BRD.Debuffs.VenomousBite);
			IStatus? windbite = TargetFindOwnEffect(BRD.Debuffs.Windbite);

			return venomous is null
				? BRD.VenomousBite
				: windbite is null
				? BRD.Windbite
				: venomous.RemainingTime < windbite.RemainingTime
				? BRD.VenomousBite
				: BRD.Windbite;
		}

		if (level < BRD.Levels.BiteUpgrade) {

			bool venomous = TargetHasOwnEffect(BRD.Debuffs.VenomousBite);
			bool windbite = TargetHasOwnEffect(BRD.Debuffs.Windbite);

			return venomous && windbite
				? BRD.IronJaws
				: windbite
				? BRD.VenomousBite
				: BRD.Windbite;
		}

		bool caustic = TargetHasOwnEffect(BRD.Debuffs.CausticBite);
		bool stormbite = TargetHasOwnEffect(BRD.Debuffs.Stormbite);

		return caustic && stormbite
			? BRD.IronJaws
			: stormbite
			? BRD.CausticBite
			: BRD.Stormbite;
	}
}

internal class BardQuickNockLadonsbite: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.BrdAny;
	public override uint[] ActionIDs { get; } = [BRD.QuickNock, BRD.Ladonsbite];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (IsEnabled(CustomComboPreset.BardApexFeature)) {

			if (level >= BRD.Levels.ApexArrow && GetJobGauge<BRDGauge>().SoulVoice == 100)
				return BRD.ApexArrow;

			if (level >= BRD.Levels.BlastShot && SelfHasEffect(BRD.Buffs.BlastShotReady))
				return BRD.BlastArrow;

		}

		if (IsEnabled(CustomComboPreset.BardQuickNockLadonsbiteShadowbite)) {
			if (level >= BRD.Levels.Shadowbite && SelfHasEffect(BRD.Buffs.HawksEye))
				return BRD.Shadowbite;
		}

		return actionID;
	}
}

internal class BardShadowbite: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.BrdAny;
	public override uint[] ActionIDs { get; } = [BRD.Shadowbite];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (IsEnabled(CustomComboPreset.BardApexFeature)) {

			if (level >= BRD.Levels.ApexArrow && GetJobGauge<BRDGauge>().SoulVoice == 100)
				return BRD.ApexArrow;

			if (level >= BRD.Levels.BlastShot && SelfHasEffect(BRD.Buffs.BlastShotReady))
				return BRD.BlastArrow;

		}

		if (IsEnabled(CustomComboPreset.BardShadowbiteDeathRain)) {

			if (level < BRD.Levels.Shadowbite)
				return BRD.RainOfDeath;

			if (CanWeave(actionID) && CanUse(BRD.RainOfDeath))
				return BRD.RainOfDeath;

		}

		return actionID;
	}
}

internal class BardEmpyrealSidewinder: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.BardEmpyrealSidewinder;
	public override uint[] ActionIDs { get; } = [BRD.Sidewinder, BRD.EmpyrealArrow];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
		return level >= BRD.Levels.Sidewinder
			? PickByCooldown(actionID, BRD.EmpyrealArrow, BRD.Sidewinder)
			: actionID;
	}
}

internal class BardRadiantFinale: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.BrdAny;
	public override uint[] ActionIDs { get; } = [BRD.RadiantFinale];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (IsEnabled(CustomComboPreset.BardRadiantStrikesFeature)) {
			if (level >= BRD.Levels.RagingStrikes && IsOffCooldown(BRD.RagingStrikes))
				return BRD.RagingStrikes;
		}

		if (IsEnabled(CustomComboPreset.BardRadiantVoiceFeature)) {
			if (level >= BRD.Levels.BattleVoice && IsOffCooldown(BRD.BattleVoice))
				return BRD.BattleVoice;
		}

		if (IsEnabled(CustomComboPreset.BardRadiantStrikesFeature)) {
			if (level < BRD.Levels.RadiantFinale)
				return BRD.RagingStrikes;
		}

		if (IsEnabled(CustomComboPreset.BardRadiantVoiceFeature)) {
			if (level < BRD.Levels.RadiantFinale)
				return BRD.BattleVoice;
		}

		return actionID;
	}
}
