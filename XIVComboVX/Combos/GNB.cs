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

	public const int
		TWOGCD_EMULATION = 4, //Emulates the timer of two GCDs
		DOUBLEDOWN_DESYNCWINDOW = 50, //Checks for Double Down's drift and tries to correct it
		NOMERCYBUFF_EMULATION = 45, //Emulates No Mercy's buff to account for the game's delay in applying the actual buff
		NOMERCYBUFF_MIDPOINT = 35, //Timer to ensure Gnashing Fang is synced to No Mercy's mid point
		NOMERCYBUFF_THRESHOLD = 17; //Threshold to hold Gnashing Fang if it is off cooldown and No Mercy will be ready soon

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

	public static int MaxAmmo(byte level) {
		return level >= Levels.CartridgeCharge2 ? 3 : 2;
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
		bool quarterWeave = GetCooldown(actionID).CooldownRemaining < 1 && GetCooldown(actionID).CooldownRemaining > 0.6;

		// Lightning Shot Ranged Uptime Feature - Replace Solid Barrel with Lightning Shot when out of melee range and in combat.
		if (IsEnabled(CustomComboPreset.GunbreakerRangedUptime) && level >= GNB.Levels.LightningShot) {
			if (!InMeleeRange && HasTarget && InCombat)
				return GNB.LightningShot;
		}

		// No Mercy Feature - Replace Solid Barrel with No Mercy when Gnashing Fang is ready.
		if (quarterWeave && IsEnabled(CustomComboPreset.GunbreakerSolidNoMercy)) {
			if (level >= GNB.Levels.NoMercy && IsOffCooldown(GNB.NoMercy)) {

				if (level >= GNB.Levels.BurstStrike) {
					if (
						(lastComboMove is GNB.KeenEdge && gauge.Ammo == 0 && IsOffCooldown(GNB.Bloodfest) && IsOffCooldown(GNB.GnashingFang)) // Opener conditions
						|| (gauge.Ammo == GNB.MaxAmmo(level) && GetCooldown(GNB.GnashingFang).CooldownRemaining < GNB.TWOGCD_EMULATION) // Regular NMGF
					) {
						return GNB.NoMercy;
					}
				}
				// no cartridges unlocked
				else {
					return GNB.NoMercy;
				}

			}
		}

		// oGCDs
		if (CanWeave(actionID)) {

			// Bloodfest Feature - Replace Solid Barrel with Bloodfest when there is no ammo and you are under No Mercy.
			if (IsEnabled(CustomComboPreset.GunbreakerSolidBloodfest) && level >= GNB.Levels.Bloodfest) {
				if (gauge.Ammo == 0 && IsOffCooldown(GNB.Bloodfest) && IsOnCooldown(GNB.GnashingFang) && SelfHasEffect(GNB.Buffs.NoMercy)) {
					return GNB.Bloodfest;
				}
			}

			// Danger Zone/Blasting Zone Feature - Replace Solid Barrel with Danger Zone/Blasting Zone after Gnashing Fang is used.
			// Outside of No Mercy/30s Gnashing Fang
			if (IsEnabled(CustomComboPreset.GunbreakerSolidDangerZone) && level >= GNB.Levels.DangerZone) {
				if (IsOffCooldown(GNB.DangerZone) && !SelfHasEffect(GNB.Buffs.NoMercy)) {
					if (
						level < GNB.Levels.GnashingFang // Pre Gnashing Fang
						|| (gauge.AmmoComboStep != 1 && IsOnCooldown(GNB.GnashingFang) && GetCooldown(GNB.NoMercy).CooldownRemaining > GNB.NOMERCYBUFF_THRESHOLD) // Post Gnashing Fang
					) {
						return OriginalHook(GNB.DangerZone);
					}
				}
			}

			// Gnashing Fang/Continuation Feature - Replace Solid Barrel with Gnashing Fang and Continuation when Gnashing Fang is available and will hold for No Mercy when it is available.
			if (IsEnabled(CustomComboPreset.GunbreakerSolidGnashingFang) && level >= GNB.Levels.Continuation) {
				if (SelfHasEffect(GNB.Buffs.ReadyToGouge) || SelfHasEffect(GNB.Buffs.ReadyToTear) || SelfHasEffect(GNB.Buffs.ReadyToRip))
					return OriginalHook(GNB.Continuation);
			}

			// During No Mercy
			if (SelfHasEffect(GNB.Buffs.NoMercy)) {

				// Post DD
				if (IsOnCooldown(GNB.DoubleDown)) {
					
					// Danger Zone/Blasting Zone Feature - Replace Solid Barrel with Danger Zone/Blasting Zone after Gnashing Fang is used.
					if (IsEnabled(CustomComboPreset.GunbreakerSolidDangerZone)) {
						uint dangerZone = OriginalHook(GNB.DangerZone);
						if (IsOffCooldown(dangerZone))
							return dangerZone;
					}

					// Bow Shock Feature - Replace Solid Barrel with Bow Shock when you are under No Mercy.
					if (IsEnabled(CustomComboPreset.GunbreakerSolidBowShock) && IsOffCooldown(GNB.BowShock))
						return GNB.BowShock;

				}

				// Pre DD
				if (level < GNB.Levels.DoubleDown && IsOnCooldown(GNB.SonicBreak)) {

					// Bow Shock Feature - Replace Solid Barrel with Bow Shock when you are under No Mercy.
					if (IsEnabled(CustomComboPreset.GunbreakerSolidBowShock) && level >= GNB.Levels.BowShock && IsOffCooldown(GNB.BowShock))
						return GNB.BowShock;

					// Danger Zone/Blasting Zone Feature - Replace Solid Barrel with Danger Zone/Blasting Zone after Gnashing Fang is used.
					if (IsEnabled(CustomComboPreset.GunbreakerSolidDangerZone) && level >= GNB.Levels.DangerZone) {
						uint dangerZone = OriginalHook(GNB.DangerZone);
						if (IsOffCooldown(dangerZone))
							return dangerZone;
					}

				}

			}

			// Rough Divide Feature - Replace Solid Barrel with Rough Divide when you are within the target's hitbox, not moving, and have the No Mercy buff.
			if (IsEnabled(CustomComboPreset.GunbreakerSolidRoughDivide) && level >= GNB.Levels.RoughDivide) {
				if (!IsMoving && TargetDistance <= 1 && !SelfHasEffect(GNB.Buffs.ReadyToBlast) && SelfHasEffect(GNB.Buffs.NoMercy)) {
					if (IsOnCooldown(OriginalHook(GNB.DangerZone)) && IsOnCooldown(GNB.BowShock) && GetCooldown(GNB.RoughDivide).RemainingCharges > Service.Configuration.GunbreakerRoughDivideCharge)
						return GNB.RoughDivide;
				}
			}
		}

		// GCD Skills: DD, Sonic Break
		if (GetCooldown(GNB.NoMercy).CooldownRemaining > 57 || SelfHasEffect(GNB.Buffs.NoMercy)) {

			if (level >= GNB.Levels.DoubleDown) {

				// Double Down Feature - Replace Solid Barrel with Double Down when you are under No Mercy and have the required ammo.
				if (IsEnabled(CustomComboPreset.GunbreakerSolidDoubleDown) && gauge.Ammo >= 2 && gauge.AmmoComboStep >= 1) {
					if (IsOffCooldown(GNB.DoubleDown) && !SelfHasEffect(GNB.Buffs.ReadyToRip))
						return GNB.DoubleDown;
				}

				// Sonic Break Feature - Replace Solid Barrel with Sonic Break when you are under No Mercy.
				if (IsEnabled(CustomComboPreset.GunbreakerSolidSonicBreak) && IsOffCooldown(GNB.SonicBreak) && IsOnCooldown(GNB.DoubleDown))
					return GNB.SonicBreak;

			}
			else {
				
				if (level >= GNB.Levels.SonicBreak) {
					// Sonic Break Feature - Replace Solid Barrel with Sonic Break when you are under No Mercy.
					if (IsEnabled(CustomComboPreset.GunbreakerSolidSonicBreak)) {
						if (IsOffCooldown(GNB.SonicBreak) && IsOnCooldown(GNB.GnashingFang) && !SelfHasEffect(GNB.Buffs.ReadyToRip))
							return GNB.SonicBreak;
					}
				}
				// pre-SB functionality
				// Danger Zone/Blasting Zone Feature - Replace Solid Barrel with Danger Zone/Blasting Zone after Gnashing Fang is used.
				else if (IsEnabled(CustomComboPreset.GunbreakerSolidDangerZone) && level >= GNB.Levels.DangerZone) {
					uint dangerZone = OriginalHook(GNB.DangerZone);
					if (IsOffCooldown(dangerZone))
						return OriginalHook(GNB.DangerZone);
				}

			}
		}

		// Gnashing Fang/Continuation Feature - Replace Solid Barrel with Gnashing Fang and Continuation when Gnashing Fang is available and will hold for No Mercy when it is available.
		if (IsEnabled(CustomComboPreset.GunbreakerSolidGnashingFang) && level >= GNB.Levels.GnashingFang) {

			// Starting Gnashing Fang
			if (gauge.AmmoComboStep == 0 && IsOffCooldown(GNB.GnashingFang) &&
				(
					( // begin regular 60 second GF/NM timing
						gauge.Ammo == GNB.MaxAmmo(level)
						&& (
							GetCooldown(GNB.NoMercy).CooldownRemaining > GNB.NOMERCYBUFF_EMULATION
							|| SelfHasEffect(GNB.Buffs.NoMercy)
						)
					) // end regular 60 second GF/NM timing
					|| ( // begin NMDDGF windows/fixes desync and drift
						gauge.Ammo == 1
						&& GetCooldown(GNB.DoubleDown).CooldownRemaining > GNB.DOUBLEDOWN_DESYNCWINDOW
						&& SelfHasEffect(GNB.Buffs.NoMercy)
					) // end NMDDGF windows/fixes desync and drift
					|| ( // begin regular 30 second window
						gauge.Ammo > 0
						&& GetCooldown(GNB.NoMercy).CooldownRemaining > GNB.NOMERCYBUFF_THRESHOLD
						&& GetCooldown(GNB.NoMercy).CooldownRemaining < GNB.NOMERCYBUFF_MIDPOINT
					) // end regular 30 second window
					|| ( // begin opener conditions
						gauge.Ammo == 1
						&& GetCooldown(GNB.NoMercy).CooldownRemaining > GNB.NOMERCYBUFF_EMULATION
						&& (
							level < GNB.Levels.Bloodfest
							|| IsOffCooldown(GNB.Bloodfest)
						)
					) // end opener conditions
				)
			) {
				return GNB.GnashingFang;
			}
			
			if (gauge.AmmoComboStep is 1 or 2)
				return OriginalHook(GNB.GnashingFang);

		}

		// Burst Strike Feature - Replace Solid Barrel with Burst Strike when charges are full.
		if (IsEnabled(CustomComboPreset.GunbreakerBurstStrikeFeature)) {

			if (level >= GNB.Levels.BurstStrike && gauge.AmmoComboStep == 0 && SelfHasEffect(GNB.Buffs.NoMercy)) {
				
				if (SelfHasEffect(GNB.Buffs.ReadyToBlast))
					return GNB.Hypervelocity;

				if (gauge.Ammo != 0 && GetCooldown(GNB.GnashingFang).CooldownRemaining > GNB.TWOGCD_EMULATION)
					return GNB.BurstStrike;

			}

			// Burst Strike Continuation - Replace Burst Strike with Continuation moves when appropriate.
			// final check if Burst Strike is used right before No Mercy ends
			if (IsEnabled(CustomComboPreset.GunbreakerBurstStrikeCont) && level >= GNB.Levels.EnhancedContinuation && SelfHasEffect(GNB.Buffs.ReadyToBlast))
				return GNB.Hypervelocity;

		}

		if (comboTime > 0) {

			if (level >= GNB.Levels.BrutalShell && lastComboMove is GNB.KeenEdge)
				return GNB.BrutalShell;

			if (level >= GNB.Levels.SolidBarrel && lastComboMove is GNB.BrutalShell) {

				// Burst Strike Feature - Replace Solid Barrel with Burst Strike when charges are full.
				if (IsEnabled(CustomComboPreset.GunbreakerBurstStrikeFeature)) {

					// Burst Strike Continuation - Replace Burst Strike with Continuation moves when appropriate.
					if (IsEnabled(CustomComboPreset.GunbreakerBurstStrikeCont) && level >= GNB.Levels.EnhancedContinuation && SelfHasEffect(GNB.Buffs.ReadyToBlast))
						return GNB.Hypervelocity;

					if (level >= GNB.Levels.BurstStrike && gauge.Ammo == GNB.MaxAmmo(level))
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
		bool quarterWeave = GetCooldown(actionID).CooldownRemaining < 1 && GetCooldown(actionID).CooldownRemaining > 0.6;


		// oGCD Skills
		if (CanWeave(actionID)) {

			if (level >= GNB.Levels.Bloodfest && gauge.Ammo == 0 && IsOffCooldown(GNB.Bloodfest) && IsOnCooldown(GNB.GnashingFang) && SelfHasEffect(GNB.Buffs.NoMercy))
				return GNB.Bloodfest;

			// No Mercy Feature - Replace Gnashing Fang with No Mercy when both No Mercy and Gnashing Fang are ready to be used.
			// Use No Mercy when Gnashing Fang is ready or nearly ready to be used
			if (quarterWeave && IsEnabled(CustomComboPreset.GunbreakerGnashingFangNoMercy) && level >= GNB.Levels.NoMercy) {
				if (gauge.Ammo == GNB.MaxAmmo(level) && IsOffCooldown(GNB.NoMercy) && IsOffCooldown(GNB.GnashingFang)) {
					return GNB.NoMercy;
				}
			}

			// Danger Zone/Blasting Zone Feature - Replace Gnashing Fang with Danger Zone/Blasting Zone when available.
			// Outside of No Mercy/30s Gnashing Fang
			if (IsEnabled(CustomComboPreset.GunbreakerGnashingFangDangerZone) && level >= GNB.Levels.DangerZone) {
				if (IsOffCooldown(GNB.DangerZone) && !SelfHasEffect(GNB.Buffs.NoMercy)) {
					if (
						level < GNB.Levels.GnashingFang // Pre Gnashing Fang
						|| (gauge.AmmoComboStep != 1 && IsOnCooldown(GNB.GnashingFang) && GetCooldown(GNB.NoMercy).CooldownRemaining > GNB.NOMERCYBUFF_THRESHOLD) // Post Gnashing Fang
					) {
						return OriginalHook(GNB.DangerZone);
					}
				}
			}

			// Bow Shock Feature - Replace Gnashing Fang with Bow Shock when available and when you are under No Mercy.
			if (IsEnabled(CustomComboPreset.GunbreakerGnashingFangCont) && level >= GNB.Levels.Continuation) {
				if (SelfHasEffect(GNB.Buffs.ReadyToGouge) || SelfHasEffect(GNB.Buffs.ReadyToTear) || SelfHasEffect(GNB.Buffs.ReadyToRip))
					return OriginalHook(GNB.Continuation);
			}
		}

		// During No Mercy
		if (SelfHasEffect(GNB.Buffs.NoMercy)) {

			// Post Double Down (no need for a level check as it's gated behind Double Down's usage)
			if (IsOnCooldown(GNB.DoubleDown)) {

				// Danger Zone/Blasting Zone Feature - Replace Gnashing Fang with Danger Zone/Blasting Zone when available.
				if (IsEnabled(CustomComboPreset.GunbreakerGnashingFangDangerZone)) {
					uint dangerZone = OriginalHook(GNB.DangerZone);
					if (IsOffCooldown(dangerZone))
						return dangerZone;
				}

				// Bow Shock Feature - Replace Gnashing Fang with Bow Shock when available and when you are under No Mercy.
				if (IsEnabled(CustomComboPreset.GunbreakerGnashingFangBowShock) && IsOffCooldown(GNB.BowShock))
					return GNB.BowShock;

			}

			// Pre Double Down
			if (level < GNB.Levels.DoubleDown && IsOnCooldown(GNB.SonicBreak)) {

				// Bow Shock Feature - Replace Gnashing Fang with Bow Shock when available and when you are under No Mercy.
				if (IsEnabled(CustomComboPreset.GunbreakerGnashingFangBowShock) && level >= GNB.Levels.BowShock && IsOffCooldown(GNB.BowShock))
					return GNB.BowShock;

				// Danger Zone/Blasting Zone Feature - Replace Gnashing Fang with Danger Zone/Blasting Zone when available.
				if (IsEnabled(CustomComboPreset.GunbreakerGnashingFangDangerZone) && level >= GNB.Levels.DangerZone) {
					uint dangerZone = OriginalHook(GNB.DangerZone);
					if (IsOffCooldown(dangerZone))
						return dangerZone;
				}

			}
		}

		// GCD Skills: DD, Sonic Break
		if (GetCooldown(GNB.NoMercy).CooldownRemaining > GNB.NOMERCYBUFF_EMULATION || SelfHasEffect(GNB.Buffs.NoMercy)) {

			if (level >= GNB.Levels.DoubleDown) {

				// Double Down Feature - Replace Gnashing Fang with Double Down when available and when you are under No Mercy and have the required ammo.
				if (IsEnabled(CustomComboPreset.GunbreakerGnashingFangDoubleDown) && gauge.Ammo >= 2 && gauge.AmmoComboStep >= 1) {
					if (IsOffCooldown(GNB.DoubleDown) && !SelfHasEffect(GNB.Buffs.ReadyToRip))
						return GNB.DoubleDown;
				}

				// Sonic Break Feature - Replace Gnashing Fang with Sonic Break when available and when you are under No Mercy.
				if (IsEnabled(CustomComboPreset.GunbreakerGnashingFangSonicBreak) && IsOffCooldown(GNB.SonicBreak) && IsOnCooldown(GNB.DoubleDown))
					return GNB.SonicBreak;

			}

			else {
				if (level >= GNB.Levels.SonicBreak) {
					// Sonic Break Feature - Replace Gnashing Fang with Sonic Break when available and when you are under No Mercy.
					if (IsEnabled(CustomComboPreset.GunbreakerGnashingFangSonicBreak)) {
						if (IsOffCooldown(GNB.SonicBreak) && IsOnCooldown(GNB.GnashingFang) && !SelfHasEffect(GNB.Buffs.ReadyToRip))
							return GNB.SonicBreak;
					}
					// pre-SB functionality
					else if (IsEnabled(CustomComboPreset.GunbreakerGnashingFangDangerZone) && level >= GNB.Levels.DangerZone) {
						uint dangerZone = OriginalHook(GNB.DangerZone);
						if (IsOffCooldown(dangerZone))
							return dangerZone;
					}
				}
			}


			// GCD Skills: DD, Sonic Break
			if (SelfHasEffect(GNB.Buffs.NoMercy)) {

				if (level >= GNB.Levels.DoubleDown) {

					// Double Down Feature - Replace Gnashing Fang with Double Down when available and when you are under No Mercy and have the required ammo.
					if (IsEnabled(CustomComboPreset.GunbreakerGnashingFangDoubleDown) && gauge.Ammo >= 2 && gauge.AmmoComboStep >= 1) {
						if (IsOffCooldown(GNB.DoubleDown) && !SelfHasEffect(GNB.Buffs.ReadyToRip))
							return GNB.DoubleDown;
					}

					// Sonic Break Feature - Replace Gnashing Fang with Sonic Break when available and when you are under No Mercy.
					if (IsEnabled(CustomComboPreset.GunbreakerGnashingFangSonicBreak) && IsOffCooldown(GNB.SonicBreak) && IsOnCooldown(GNB.DoubleDown))
						return GNB.SonicBreak;

				}
				// Sonic Break Feature - Replace Gnashing Fang with Sonic Break when available and when you are under No Mercy.
				else if (IsEnabled(CustomComboPreset.GunbreakerGnashingFangSonicBreak) && level >= GNB.Levels.SonicBreak) {
					if (IsOffCooldown(GNB.SonicBreak) && IsOnCooldown(GNB.GnashingFang) && !SelfHasEffect(GNB.Buffs.ReadyToRip))
						return GNB.SonicBreak;
				}

			}

			// Gnashing Strike Feature - Replace Gnashing Fang with Burst Strike when No Mercy is active and Gnashing Fang and Double Down are on cooldown, or you are too low level to use them.
			if (IsEnabled(CustomComboPreset.GunbreakerGnashingStrikeFeature)) {

				// Using the gauge to read combo steps
				if (gauge.AmmoComboStep > 0)
					return OriginalHook(GNB.GnashingFang);

				// Checks for Gnashing Fang's combo to be finished first
				if (gauge.AmmoComboStep == 0 && SelfHasEffect(GNB.Buffs.NoMercy)) {
					if (level < GNB.Levels.GnashingFang || GetCooldown(GNB.GnashingFang).CooldownRemaining > Service.Configuration.GunbreakerGnashingStrikeCooldownGnashingFang) {
						if (level < GNB.Levels.DoubleDown || GetCooldown(GNB.DoubleDown).CooldownRemaining > Service.Configuration.GunbreakerGnashingStrikeCooldownDoubleDown) {

							if (IsEnabled(CustomComboPreset.GunbreakerBurstStrikeCont) && level >= GNB.Levels.EnhancedContinuation) {
								if (SelfHasEffect(GNB.Buffs.ReadyToBlast)) {
									return GNB.Hypervelocity;
								}
							}

							return GNB.BurstStrike;
						}
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

				if (gauge.Ammo == GNB.MaxAmmo(level))
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
	
