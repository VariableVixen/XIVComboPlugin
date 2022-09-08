namespace XIVComboVX.Combos;

using Dalamud.Game.ClientState.JobGauge.Types;

internal static class GNB {
	public const byte JobID = 37;

	public const uint
		KeenEdge = 16137,
		NoMercy = 16138,
		BrutalShell = 16139,
		DemonSlice = 16141,
		SolidBarrel = 16145,
		GnashingFang = 16146,
		SavageClaw = 16147,
		DemonSlaughter = 16149,
		WickedTalon = 16150,
		SonicBreak = 16153,
		Continuation = 16155,
		JugularRip = 16156,
		AbdomenTear = 16157,
		EyeGouge = 16158,
		BowShock = 16159,
		BurstStrike = 16162,
		FatedCircle = 16163,
		Bloodfest = 16164,
		Hypervelocity = 25759,
		DoubleDown = 25760;

	public static class Buffs {
		public const ushort
			NoMercy = 1831,
			ReadyToRip = 1842,
			ReadyToTear = 1843,
			ReadyToGouge = 1844,
			ReadyToBlast = 2686;
	}

	public static class Debuffs {
		public const ushort
			BowShock = 1838;
	}

	public static class Levels {
		public const byte
			NoMercy = 2,
			BrutalShell = 4,
			SolidBarrel = 26,
			BurstStrike = 30,
			DemonSlaughter = 40,
			SonicBreak = 54,
			GnashingFang = 60,
			BowShock = 62,
			Continuation = 70,
			FatedCircle = 72,
			Bloodfest = 76,
			EnhancedContinuation = 86,
			CartridgeCharge2 = 88,
			DoubleDown = 90;
	}
}

internal class GunbreakerStunInterruptFeature: StunInterruptCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.GunbreakerStunInterruptFeature;
}

internal class GunbreakerSolidBarrel: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.GunbreakerSolidBarrelCombo;
	public override uint[] ActionIDs { get; } = new[] { GNB.SolidBarrel };

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (comboTime > 0) {

			if (level >= GNB.Levels.BrutalShell && lastComboMove is GNB.KeenEdge)
				return GNB.BrutalShell;

			if (level >= GNB.Levels.SolidBarrel && lastComboMove is GNB.BrutalShell) {

				if (IsEnabled(CustomComboPreset.GunbreakerBurstStrikeFeature)) {
					GNBGauge gauge = GetJobGauge<GNBGauge>();
					int maxAmmo = level >= GNB.Levels.CartridgeCharge2 ? 3 : 2;

					if (level >= GNB.Levels.EnhancedContinuation && IsEnabled(CustomComboPreset.GunbreakerBurstStrikeCont) && SelfHasEffect(GNB.Buffs.ReadyToBlast))
						return GNB.Hypervelocity;

					if (level >= GNB.Levels.BurstStrike && gauge.Ammo == maxAmmo)
						return GNB.BurstStrike;

				}

				return GNB.SolidBarrel;
			}
		}

		return GNB.KeenEdge;
	}
}

internal class GunbreakerGnashingFang: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.GnbAny;
	public override uint[] ActionIDs { get; } = new[] { GNB.GnashingFang };

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		
		// continuation feature by damolitionn
		if (IsEnabled(CustomComboPreset.GunbreakerGnashingFangCont)) {
			if (level >= GNB.Levels.Continuation) {

				if (SelfHasEffect(GNB.Buffs.ReadyToGouge) || SelfHasEffect(GNB.Buffs.ReadyToTear) || SelfHasEffect(GNB.Buffs.ReadyToRip))
					return OriginalHook(GNB.Continuation);
			}
		}

		if (IsEnabled(CustomComboPreset.GunbreakerGnashingStrikeFeature)) {
			GNBGauge gauge = GetJobGauge<GNBGauge>();

			// Using the gauge to read combo steps
			if (gauge.AmmoComboStep > 0)
				return OriginalHook(GNB.GnashingFang);

			//Checks for Gnashing Fang's combo to be finished first
			if (SelfHasEffect(GNB.Buffs.NoMercy) && gauge.AmmoComboStep == 0) {
				if (level < GNB.Levels.GnashingFang || GetCooldown(GNB.GnashingFang).CooldownRemaining > Service.Configuration.GunbreakerGnashingStrikeCooldownGnashingFang) {
					if (level < GNB.Levels.DoubleDown || GetCooldown(GNB.DoubleDown).CooldownRemaining > Service.Configuration.GunbreakerGnashingStrikeCooldownDoubleDown) {

						if (level >= GNB.Levels.EnhancedContinuation && IsEnabled(CustomComboPreset.GunbreakerBurstStrikeCont)) {
							if (SelfHasEffect(GNB.Buffs.ReadyToBlast)) {
								return GNB.Hypervelocity;
							}
						}

						return GNB.BurstStrike;
					}
				}
			}
		}

		return OriginalHook(GNB.GnashingFang);
	}
}

internal class GunbreakerBurstStrikeFatedCircle: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.GnbAny;
	public override uint[] ActionIDs { get; } = new[] { GNB.BurstStrike, GNB.FatedCircle };

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (actionID is GNB.BurstStrike
			&& level >= GNB.Levels.EnhancedContinuation
			&& IsEnabled(CustomComboPreset.GunbreakerBurstStrikeCont)
			&& SelfHasEffect(GNB.Buffs.ReadyToBlast)
		) {
			return GNB.Hypervelocity;
		}

		GNBGauge gauge = GetJobGauge<GNBGauge>();

		if (level >= GNB.Levels.DoubleDown
			&& IsEnabled(CustomComboPreset.GunbreakerDoubleDownFeature)
			&& gauge.Ammo >= 2
			&& IsOffCooldown(GNB.DoubleDown)
		) {
			return GNB.DoubleDown;
		}

		if (level >= GNB.Levels.Bloodfest && IsEnabled(CustomComboPreset.GunbreakerEmptyBloodfestFeature) && gauge.Ammo == 0)
			return GNB.Bloodfest;

		return actionID;
	}
}

internal class GunbreakerBowShockSonicBreak: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.GunbreakerBowShockSonicBreakFeature;
	public override uint[] ActionIDs { get; } = new[] { GNB.BowShock, GNB.SonicBreak };

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (level >= GNB.Levels.BowShock)
			return PickByCooldown(actionID, GNB.BowShock, GNB.SonicBreak);

		return actionID;
	}
}

internal class GunbreakerDemonSlaughter: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.GunbreakerDemonSlaughterCombo;
	public override uint[] ActionIDs { get; } = new[] { GNB.DemonSlaughter };

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (level >= GNB.Levels.DemonSlaughter && comboTime > 0 && lastComboMove == GNB.DemonSlice) {

			if (level >= GNB.Levels.FatedCircle && IsEnabled(CustomComboPreset.GunbreakerFatedCircleFeature)) {
				GNBGauge gauge = GetJobGauge<GNBGauge>();
				int maxAmmo = level >= GNB.Levels.CartridgeCharge2 ? 3 : 2;

				if (gauge.Ammo == maxAmmo)
					return GNB.FatedCircle;

			}

			return GNB.DemonSlaughter;
		}

		return GNB.DemonSlice;
	}
}

internal class GunbreakerNoMercy: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.GnbAny;
	public override uint[] ActionIDs { get; } = new[] { GNB.NoMercy };

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
		GNBGauge gauge = GetJobGauge<GNBGauge>();

		if (level >= GNB.Levels.DoubleDown
			&& IsEnabled(CustomComboPreset.GunbreakerNoMercyDoubleDownFeature)
			&& gauge.Ammo >= 2
			&& IsOffCooldown(GNB.DoubleDown)
			&& SelfHasEffect(GNB.Buffs.NoMercy)
		) {
			return GNB.DoubleDown;
		}

		if (level >= GNB.Levels.DoubleDown
			&& IsEnabled(CustomComboPreset.GunbreakerNoMercyAlwaysDoubleDownFeature)
			&& SelfHasEffect(GNB.Buffs.NoMercy)
		) {
			return GNB.DoubleDown;
		}

		if (level >= GNB.Levels.NoMercy
			&& IsEnabled(CustomComboPreset.GunbreakerNoMercyFeature)
			&& SelfHasEffect(GNB.Buffs.NoMercy)
		) {

			if (level >= GNB.Levels.BowShock)
				return PickByCooldown(GNB.BowShock, GNB.SonicBreak, GNB.BowShock);

			if (level >= GNB.Levels.SonicBreak)
				return GNB.SonicBreak;

		}

		return actionID;
	}
}
