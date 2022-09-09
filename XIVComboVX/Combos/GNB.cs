namespace XIVComboVX.Combos;

using Dalamud.Game.ClientState.JobGauge.Types;

internal static class GNB {
	public const byte JobID = 37;

	public const uint
		KeenEdge = 16137,
		NoMercy = 16138,
		BrutalShell = 16139,
		DemonSlice = 16141,
		LightningShot = 16143,
		DangerZone = 16144,
		SolidBarrel = 16145,
		GnashingFang = 16146,
		SavageClaw = 16147,
		DemonSlaughter = 16149,
		WickedTalon = 16150,
		SonicBreak = 16153,
		RoughDivide = 16154,
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
			LightningShot = 15,
			DangerZone = 18,
			SolidBarrel = 26,
			BurstStrike = 30,
			DemonSlaughter = 40,
			SonicBreak = 54,
			RoughDivide = 56,
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

		GNBGauge gauge = GetJobGauge<GNBGauge>();
		int maxAmmo = level >= GNB.Levels.CartridgeCharge2 ? 3 : 2;
		var quarterWeave = GetCooldown(actionID).CooldownRemaining < 1 && GetCooldown(actionID).CooldownRemaining > 0.6;

		//Lightning Shot Ranged Feature
		if (IsEnabled(CustomComboPreset.GunbreakerRangedUptime) && !InMeleeRange && level >= GNB.Levels.LightningShot && HasTarget && InCombat)
			return GNB.LightningShot;

		if (quarterWeave && IsEnabled(CustomComboPreset.GunbreakerSolidNoMercy)) {
			if (level >= GNB.Levels.NoMercy && IsOffCooldown(GNB.NoMercy)) {

				if (level >= GNB.Levels.BurstStrike) {

					if ((gauge.Ammo is 0 && lastComboMove is GNB.KeenEdge && IsOffCooldown(GNB.Bloodfest) && IsOffCooldown(GNB.GnashingFang)) || //Opener Conditions
					   (gauge.Ammo == maxAmmo && GetCooldown(GNB.GnashingFang).CooldownRemaining < 4)) {  //Regular NMGF
						return GNB.NoMercy;
					}
				}

				//no cartridges unlocked
				else {
					return GNB.NoMercy;
				}
			}
		}

		//oGCDs
		if (CanWeave(actionID)) {

			//Bloodfest Feature
			if (IsEnabled(CustomComboPreset.GunbreakerSolidBloodfest) && IsOffCooldown(GNB.Bloodfest) && level >= GNB.Levels.Bloodfest) {

				if (SelfHasEffect(GNB.Buffs.NoMercy) && gauge.Ammo == 0 && IsOnCooldown(GNB.GnashingFang)) {
					return GNB.Bloodfest;
				}
			}

			//Outside of No Mercy/30s Gnashing Fang
			if (IsEnabled(CustomComboPreset.GunbreakerSolidDangerZone) && level >= GNB.Levels.DangerZone && IsOffCooldown(GNB.DangerZone) && !SelfHasEffect(GNB.Buffs.NoMercy)) {

				if ((IsOnCooldown(GNB.GnashingFang) && gauge.AmmoComboStep != 1 && GetCooldown(GNB.NoMercy).CooldownRemaining > 17) || //Post Gnashing Fang
					level < GNB.Levels.GnashingFang) {  //Pre Gnashing Fang
					return OriginalHook(GNB.DangerZone);
				}
			}


			// Continuation Feature
			if (IsEnabled(CustomComboPreset.GunbreakerSolidGnashingFang)) {
				if (level >= GNB.Levels.Continuation) {

					if (SelfHasEffect(GNB.Buffs.ReadyToGouge) || SelfHasEffect(GNB.Buffs.ReadyToTear) || SelfHasEffect(GNB.Buffs.ReadyToRip))
						return OriginalHook(GNB.Continuation);
				}
			}

			//During No Mercy
			if (SelfHasEffect(GNB.Buffs.NoMercy)) {
				//Post DD
				if (IsOnCooldown(GNB.DoubleDown)) {
					
					if (IsEnabled(CustomComboPreset.GunbreakerSolidDangerZone) && IsOffCooldown(GNB.DangerZone))
						return OriginalHook(GNB.DangerZone);

					if (IsEnabled(CustomComboPreset.GunbreakerSolidBowShock) && IsOffCooldown(GNB.BowShock))
						return GNB.BowShock;
				}

				//Pre DD
				if (IsOnCooldown(GNB.SonicBreak) && level < GNB.Levels.DoubleDown) {
					
					if (IsEnabled(CustomComboPreset.GunbreakerSolidBowShock) && level >= GNB.Levels.BowShock && IsOffCooldown(GNB.BowShock))
						return GNB.BowShock;

					if (IsEnabled(CustomComboPreset.GunbreakerSolidDangerZone) && level >= GNB.Levels.DangerZone && IsOffCooldown(GNB.DangerZone))
						return OriginalHook(GNB.DangerZone);
				}
			}

			//Rough Divide Feature
			if (level >= GNB.Levels.RoughDivide && IsEnabled(CustomComboPreset.GunbreakerSolidRoughDivide) && !SelfHasEffect(GNB.Buffs.ReadyToBlast) && !IsMoving && TargetDistance <= 1) {

				if (SelfHasEffect(GNB.Buffs.NoMercy) && IsOnCooldown(OriginalHook(GNB.DangerZone)) && IsOnCooldown(GNB.BowShock) && GetCooldown(GNB.RoughDivide).RemainingCharges > Service.Configuration.GunbreakerRoughDivideCharge)
					return GNB.RoughDivide;
			}
		}

		//GCD Skills: DD, Sonic Break
		if (GetCooldown(GNB.NoMercy).CooldownRemaining > 57 || SelfHasEffect(GNB.Buffs.NoMercy)) {
			if (level >= GNB.Levels.DoubleDown) {
				
				if (IsEnabled(CustomComboPreset.GunbreakerSolidDoubleDown) && IsOffCooldown(GNB.DoubleDown) && gauge.Ammo >= 2 && !SelfHasEffect(GNB.Buffs.ReadyToRip) && gauge.AmmoComboStep >= 1)
					return GNB.DoubleDown;

				if (IsEnabled(CustomComboPreset.GunbreakerSolidSonicBreak) && IsOffCooldown(GNB.SonicBreak) && IsOnCooldown(GNB.DoubleDown))
					return GNB.SonicBreak;
			}

			else {
				if (level >= GNB.Levels.SonicBreak) {
					if (IsEnabled(CustomComboPreset.GunbreakerSolidSonicBreak) && IsOffCooldown(GNB.SonicBreak) && !SelfHasEffect(GNB.Buffs.ReadyToRip) && IsOnCooldown(GNB.GnashingFang))
						return GNB.SonicBreak;
				}

				//sub level 54 functionality
				else {

					if (IsEnabled(CustomComboPreset.GunbreakerSolidDangerZone) && level >= GNB.Levels.DangerZone && IsOffCooldown(GNB.DangerZone))
						return OriginalHook(GNB.DangerZone);
				}
			}
		}

		//Gnashing Fang
		if (IsEnabled(CustomComboPreset.GunbreakerSolidGnashingFang) && level >= GNB.Levels.GnashingFang) {

			//Starting Gnashing Fang
			if (IsOffCooldown(GNB.GnashingFang) && gauge.AmmoComboStep == 0 &&
				((gauge.Ammo == maxAmmo && (GetCooldown(GNB.NoMercy).CooldownRemaining > 50 || SelfHasEffect(GNB.Buffs.NoMercy))) || //Regular 60 second GF/NM timing
				(gauge.Ammo == 1 && SelfHasEffect(GNB.Buffs.NoMercy) && GetCooldown(GNB.DoubleDown).CooldownRemaining > 50) || //NMDDGF windows/Fixes desync and drift
				(gauge.Ammo > 0 && GetCooldown(GNB.NoMercy).CooldownRemaining > 17 && GetCooldown(GNB.NoMercy).CooldownRemaining < 35) || //Regular 30 second window                                                                        
				(gauge.Ammo == 1 && GetCooldown(GNB.NoMercy).CooldownRemaining > 50 && ((IsOffCooldown(GNB.Bloodfest) && level >= GNB.Levels.Bloodfest) || level < GNB.Levels.Bloodfest)))) {  //Opener Conditions
				return GNB.GnashingFang;
			}
			
			if (gauge.AmmoComboStep is 1 or 2)
				return OriginalHook(GNB.GnashingFang);
		}

		if (IsEnabled(CustomComboPreset.GunbreakerBurstStrikeFeature)) {
			if (SelfHasEffect(GNB.Buffs.NoMercy) && gauge.AmmoComboStep == 0 && level >= GNB.Levels.BurstStrike) {
				
				if (SelfHasEffect(GNB.Buffs.ReadyToBlast))
					return GNB.Hypervelocity;

				if (gauge.Ammo != 0 && GetCooldown(GNB.GnashingFang).CooldownRemaining > 4)
					return GNB.BurstStrike;
			}

			//final check if Burst Strike is used right before No Mercy ends
			if (IsEnabled(CustomComboPreset.GunbreakerBurstStrikeCont) && SelfHasEffect(GNB.Buffs.ReadyToBlast))
				return GNB.Hypervelocity;
		}

		if (comboTime > 0) {

			if (level >= GNB.Levels.BrutalShell && lastComboMove is GNB.KeenEdge)
				return GNB.BrutalShell;

			if (level >= GNB.Levels.SolidBarrel && lastComboMove is GNB.BrutalShell) {

				if (IsEnabled(CustomComboPreset.GunbreakerBurstStrikeFeature)) {

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

		GNBGauge gauge = GetJobGauge<GNBGauge>();
		var quarterWeave = GetCooldown(actionID).CooldownRemaining < 1 && GetCooldown(actionID).CooldownRemaining > 0.6;
		int maxAmmo = level >= GNB.Levels.CartridgeCharge2 ? 3 : 2;

		//oGCD Skills
		if (CanWeave(actionID)) {

			if (SelfHasEffect(GNB.Buffs.NoMercy) && gauge.Ammo == 0 && IsOffCooldown(GNB.Bloodfest) && level >= GNB.Levels.Bloodfest && IsOnCooldown(GNB.GnashingFang))
				return GNB.Bloodfest;

			//Use No Mercy when Gnashing Fang is ready or nearly ready to be used
			if (quarterWeave && IsEnabled(CustomComboPreset.GunbreakerGnashingFangNoMercy)) {
				
				if (level >= GNB.Levels.NoMercy && IsOffCooldown(GNB.NoMercy) && gauge.Ammo == maxAmmo && IsOffCooldown(GNB.GnashingFang)) {
					return GNB.NoMercy;
				}
			}

			//Outside of No Mercy/30s Gnashing Fang
			if (IsEnabled(CustomComboPreset.GunbreakerGnashingFangDangerZone) && level >= GNB.Levels.DangerZone && IsOffCooldown(GNB.DangerZone) && !SelfHasEffect(GNB.Buffs.NoMercy)) {

				if ((IsOnCooldown(GNB.GnashingFang) && gauge.AmmoComboStep != 1 && GetCooldown(GNB.NoMercy).CooldownRemaining > 17) || //Post Gnashing Fang
					level < GNB.Levels.GnashingFang) {  //Pre Gnashing Fang
					return OriginalHook(GNB.DangerZone);
				}
			}

			// continuation feature by damolitionn
			if (IsEnabled(CustomComboPreset.GunbreakerGnashingFangCont)) {
				
				if (level >= GNB.Levels.Continuation) {
					if (SelfHasEffect(GNB.Buffs.ReadyToGouge) || SelfHasEffect(GNB.Buffs.ReadyToTear) || SelfHasEffect(GNB.Buffs.ReadyToRip))
						return OriginalHook(GNB.Continuation);
				}
			}
		}

		//During No Mercy
		if (SelfHasEffect(GNB.Buffs.NoMercy)) {
			//Post Double Down (No need for a level check as it's gated behind Double Down's usage)
			if (IsOnCooldown(GNB.DoubleDown)) {

				if (IsEnabled(CustomComboPreset.GunbreakerGnashingFangDangerZone) && IsOffCooldown(GNB.DangerZone))
					return OriginalHook(GNB.DangerZone);

				if (IsEnabled(CustomComboPreset.GunbreakerGnashingFangBowShock) && IsOffCooldown(GNB.BowShock))
					return GNB.BowShock;
			}

			//Pre Double Down
			if (IsOnCooldown(GNB.SonicBreak) && level < GNB.Levels.DoubleDown) {

				if (IsEnabled(CustomComboPreset.GunbreakerGnashingFangBowShock) && level >= GNB.Levels.BowShock && IsOffCooldown(GNB.BowShock))
					return GNB.BowShock;

				if (IsEnabled(CustomComboPreset.GunbreakerGnashingFangDangerZone) && level >= GNB.Levels.DangerZone && IsOffCooldown(GNB.DangerZone))
					return OriginalHook(GNB.DangerZone);
			}
		}

		//GCD Skills: DD, Sonic Break
		if (GetCooldown(GNB.NoMercy).CooldownRemaining > 57 || SelfHasEffect(GNB.Buffs.NoMercy)) {
			if (level >= GNB.Levels.DoubleDown) {
				if (IsEnabled(CustomComboPreset.GunbreakerSolidDoubleDown) && IsOffCooldown(GNB.DoubleDown) && gauge.Ammo >= 2 && !SelfHasEffect(GNB.Buffs.ReadyToRip) && gauge.AmmoComboStep >= 1)
					return GNB.DoubleDown;
				if (IsEnabled(CustomComboPreset.GunbreakerSolidSonicBreak) && IsOffCooldown(GNB.SonicBreak) && IsOnCooldown(GNB.DoubleDown))
					return GNB.SonicBreak;
			}

			else {
				if (level >= GNB.Levels.SonicBreak) {
					if (IsEnabled(CustomComboPreset.GunbreakerSolidSonicBreak) && IsOffCooldown(GNB.SonicBreak) && !SelfHasEffect(GNB.Buffs.ReadyToRip) && IsOnCooldown(GNB.GnashingFang))
						return GNB.SonicBreak;
				}

				//sub level 54 functionality
				else {

					if (IsEnabled(CustomComboPreset.GunbreakerSolidDangerZone) && level >= GNB.Levels.DangerZone && IsOffCooldown(GNB.DangerZone))
						return OriginalHook(GNB.DangerZone);
				}
			}
		}


		//GCD Skills: DD, Sonic Break
		if (SelfHasEffect(GNB.Buffs.NoMercy)) {
			if (level >= GNB.Levels.DoubleDown) {

				if (IsEnabled(CustomComboPreset.GunbreakerGnashingFangDoubleDown) && IsOffCooldown(GNB.DoubleDown) && gauge.Ammo >= 2 && !SelfHasEffect(GNB.Buffs.ReadyToRip) && gauge.AmmoComboStep >= 1)
					return GNB.DoubleDown;

				if (IsEnabled(CustomComboPreset.GunbreakerGnashingFangSonicBreak) && IsOffCooldown(GNB.SonicBreak) && IsOnCooldown(GNB.DoubleDown))
					return GNB.SonicBreak;
			}

			else if (level >= GNB.Levels.SonicBreak) {
				if (IsEnabled(CustomComboPreset.GunbreakerGnashingFangSonicBreak) && IsOffCooldown(GNB.SonicBreak) && !SelfHasEffect(GNB.Buffs.ReadyToRip) && IsOnCooldown(GNB.GnashingFang))
					return GNB.SonicBreak;
			}
		}

		if (IsEnabled(CustomComboPreset.GunbreakerGnashingStrikeFeature)) {
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
