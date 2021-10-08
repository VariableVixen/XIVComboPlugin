using Dalamud.Game.ClientState.JobGauge.Types;

namespace XIVComboVeryExpandedPlugin.Combos {
	internal static class WHM {
		public const byte JobID = 24;

		public const uint
			Raise = 125,
			Cure = 120,
			Medica = 124,
			Cure2 = 135,
			AfflatusSolace = 16531,
			AfflatusRapture = 16534,
			AfflatusMisery = 16535;

		public static class Buffs {
			// public const short placeholder = 0;
		}

		public static class Debuffs {
			// public const short placeholder = 0;
		}

		public static class Levels {
			public const byte
				Cure2 = 30,
				AfflatusSolace = 52,
				AfflatusRapture = 76;
		}
	}

	internal class WhiteMageSwiftcastRaiserFeature: CustomCombo {
		protected override CustomComboPreset Preset => CustomComboPreset.WhiteMageSwiftcastRaiserFeature;

		protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
			if (actionID == WHM.Raise && GetCooldown(CommonSkills.Swiftcast).CooldownRemaining == 0)
				return CommonSkills.Swiftcast;

			return actionID;
		}
	}

	internal class WhiteMageSolaceMiseryFeature: CustomCombo {
		protected override CustomComboPreset Preset => CustomComboPreset.WhiteMageSolaceMiseryFeature;

		protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
			if (actionID == WHM.AfflatusSolace) {
				WHMGauge gauge = GetJobGauge<WHMGauge>();
				if (gauge.BloodLily == 3)
					return WHM.AfflatusMisery;
			}

			return actionID;
		}
	}

	internal class WhiteMageRaptureMiseryFeature: CustomCombo {
		protected override CustomComboPreset Preset => CustomComboPreset.WhiteMageRaptureMiseryFeature;

		protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
			if (actionID == WHM.AfflatusRapture) {
				WHMGauge gauge = GetJobGauge<WHMGauge>();
				if (gauge.BloodLily == 3)
					return WHM.AfflatusMisery;
			}

			return actionID;
		}
	}

	internal class WhiteMageCureFeature: CustomCombo {
		protected override CustomComboPreset Preset => CustomComboPreset.WhiteMageCureFeature;

		protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
			if (actionID == WHM.Cure2) {
				if (level < WHM.Levels.Cure2)
					return WHM.Cure;
			}

			return actionID;
		}
	}

	internal class WhiteMageAfflatusFeature: CustomCombo {
		protected override CustomComboPreset Preset => CustomComboPreset.WhiteMageAfflatusFeature;

		protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
			if (actionID == WHM.Cure2) {
				WHMGauge gauge = GetJobGauge<WHMGauge>();
				if (IsEnabled(CustomComboPreset.WhiteMageSolaceMiseryFeature) && gauge.BloodLily == 3)
					return WHM.AfflatusMisery;

				if (level >= WHM.Levels.AfflatusSolace && gauge.Lily > 0)
					return WHM.AfflatusSolace;

				return actionID;
			}

			if (actionID == WHM.Medica) {
				WHMGauge gauge = GetJobGauge<WHMGauge>();
				if (IsEnabled(CustomComboPreset.WhiteMageRaptureMiseryFeature) && gauge.BloodLily == 3)
					return WHM.AfflatusMisery;

				if (level >= WHM.Levels.AfflatusRapture && gauge.Lily > 0)
					return WHM.AfflatusRapture;

				return WHM.Medica;
			}

			return actionID;
		}
	}
}
