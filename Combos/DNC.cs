using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVComboVeryExpandedPlugin.Combos {
	internal static class DNC {
		public const byte JobID = 38;

		public const uint
			// Single Target
			Cascade = 15989,
			Fountain = 15990,
			ReverseCascade = 15991,
			Fountainfall = 15992,
			// AoE
			Windmill = 15993,
			Bladeshower = 15994,
			RisingWindmill = 15995,
			Bloodshower = 15996,
			// Dancing
			StandardStep = 15997,
			TechnicalStep = 15998,
			StandardFinish0 = 16003,
			StandardFinish1 = 16191,
			StandardFinish2 = 16192,
			TechnicalFinish0 = 16004,
			TechnicalFinish1 = 16193,
			TechnicalFinish2 = 16194,
			TechnicalFinish3 = 16195,
			TechnicalFinish4 = 16196,
			// Fans
			FanDance1 = 16007,
			FanDance2 = 16008,
			FanDance3 = 16009,
			// Other
			SaberDance = 16005,
			EnAvant = 16010,
			Flourish = 16013,
			Improvisation = 16014;

		public static class Buffs {
			public const short
				FlourishingCascade = 1814,
				FlourishingFountain = 1815,
				FlourishingWindmill = 1816,
				FlourishingShower = 1817,
				StandardStep = 1818,
				TechnicalStep = 1819,
				FlourishingFanDance = 1820;
		}

		public static class Debuffs {
			// public const short placeholder = 0;
		}

		public static class Levels {
			public const byte
				Fountain = 2,
				Windmill = 15,
				ReverseCascade = 20,
				Bladeshower = 25,
				FanDance1 = 30,
				RisingWindmill = 35,
				Fountainfall = 40,
				Bloodshower = 45,
				FanDance2 = 50,
				FanDance3 = 66,
				Flourish = 72,
				SaberDance = 76,
				Improvisation = 80;

		}
	}

	internal class DancerDanceComboCompatibility: CustomCombo {
		protected override CustomComboPreset Preset => CustomComboPreset.DancerDanceComboCompatibility;

		protected override uint[] ActionIDs => Configuration.DancerDanceCompatActionIDs;

		protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
			DNCGauge gauge = GetJobGauge<DNCGauge>();
			if (gauge.IsDancing) {
				uint[] actionIDs = Configuration.DancerDanceCompatActionIDs;

				if (actionID == actionIDs[0] || (actionIDs[0] == 0 && actionID == DNC.Cascade))
					return OriginalHook(DNC.Cascade);

				if (actionID == actionIDs[1] || (actionIDs[1] == 0 && actionID == DNC.Flourish))
					return OriginalHook(DNC.Fountain);

				if (actionID == actionIDs[2] || (actionIDs[2] == 0 && actionID == DNC.FanDance1))
					return OriginalHook(DNC.ReverseCascade);

				if (actionID == actionIDs[3] || (actionIDs[3] == 0 && actionID == DNC.FanDance2))
					return OriginalHook(DNC.Fountainfall);
			}

			return actionID;
		}
	}

	internal class DancerFanDance1Combo: CustomCombo {
		protected override CustomComboPreset Preset => CustomComboPreset.DancerFanDance1Combo;

		protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
			if (actionID == DNC.FanDance1 && level >= DNC.Levels.FanDance3 && HasEffect(DNC.Buffs.FlourishingFanDance))
				return DNC.FanDance3;

			return actionID;
		}
	}

	internal class DancerFanDance2Combo: CustomCombo {
		protected override CustomComboPreset Preset => CustomComboPreset.DancerFanDance2Combo;

		protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
			if (actionID == DNC.FanDance2 && level >= DNC.Levels.FanDance3 && HasEffect(DNC.Buffs.FlourishingFanDance))
				return DNC.FanDance3;

			return actionID;
		}
	}

	internal class DancerDanceStepCombo: CustomCombo {
		protected override CustomComboPreset Preset => CustomComboPreset.DancerDanceStepCombo;

		protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
			if (actionID == DNC.StandardStep) {
				DNCGauge gauge = GetJobGauge<DNCGauge>();
				if (gauge.IsDancing && HasEffect(DNC.Buffs.StandardStep)) {
					if (gauge.CompletedSteps < 2)
						return gauge.NextStep;

					return DNC.StandardFinish2;
				}
			}

			if (actionID == DNC.TechnicalStep) {
				DNCGauge gauge = GetJobGauge<DNCGauge>();
				if (gauge.IsDancing && HasEffect(DNC.Buffs.TechnicalStep)) {
					if (gauge.CompletedSteps < 4)
						return gauge.NextStep;

					return DNC.TechnicalFinish4;
				}
			}

			return actionID;
		}
	}

	internal class DancerFlourishFeature: CustomCombo {
		protected override CustomComboPreset Preset => CustomComboPreset.DancerFlourishFeature;

		protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
			if (actionID == DNC.Flourish) {
				if (level >= DNC.Levels.Fountainfall && HasEffect(DNC.Buffs.FlourishingFountain))
					return DNC.Fountainfall;

				if (level >= DNC.Levels.ReverseCascade && HasEffect(DNC.Buffs.FlourishingCascade))
					return DNC.ReverseCascade;

				if (level >= DNC.Levels.Bloodshower && HasEffect(DNC.Buffs.FlourishingShower))
					return DNC.Bloodshower;

				if (level >= DNC.Levels.RisingWindmill && HasEffect(DNC.Buffs.FlourishingWindmill))
					return DNC.RisingWindmill;

				return DNC.Flourish;
			}

			return actionID;
		}
	}

	internal class DancerSingleTargetMultibutton: CustomCombo {
		protected override CustomComboPreset Preset => CustomComboPreset.DancerSingleTargetMultibutton;

		protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
			if (actionID == DNC.Cascade) {
				// From Fountain
				if (level >= DNC.Levels.Fountainfall && HasEffect(DNC.Buffs.FlourishingFountain))
					return DNC.Fountainfall;

				// From Cascade
				if (level >= DNC.Levels.ReverseCascade && HasEffect(DNC.Buffs.FlourishingCascade))
					return DNC.ReverseCascade;

				// Cascade Combo
				if (lastComboMove == DNC.Cascade && level >= DNC.Levels.Fountain)
					return DNC.Fountain;

				return DNC.Cascade;
			}

			return actionID;
		}
	}

	internal class DancerAoeMultibutton: CustomCombo {
		protected override CustomComboPreset Preset => CustomComboPreset.DancerAoeMultibutton;

		protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
			if (actionID == DNC.Windmill) {
				// From Bladeshower
				if (level >= DNC.Levels.Bloodshower && HasEffect(DNC.Buffs.FlourishingShower))
					return DNC.Bloodshower;

				// From Windmill
				if (level >= DNC.Levels.RisingWindmill && HasEffect(DNC.Buffs.FlourishingWindmill))
					return DNC.RisingWindmill;

				// Windmill Combo
				if (lastComboMove == DNC.Windmill && level >= DNC.Levels.Bladeshower)
					return DNC.Bladeshower;

				return DNC.Windmill;
			}

			return actionID;
		}
	}
}
