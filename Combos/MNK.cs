namespace XIVComboVeryExpandedPlugin.Combos {
	internal static class MNK {
		public const byte JobID = 20;

		public const uint
			Bootshine = 53,
			DragonKick = 74,
			SnapPunch = 56,
			TwinSnakes = 61,
			Demolish = 66,
			ArmOfTheDestroyer = 62,
			Rockbreaker = 70,
			FourPointFury = 16473;

		public static class Buffs {
			public const short
				TwinSnakes = 101,
				OpoOpoForm = 107,
				RaptorForm = 108,
				CoerlForm = 109,
				PerfectBalance = 110,
				LeadenFist = 1861,
				FormlessFist = 2513;
		}

		public static class Debuffs {
			public const short
				Demolish = 246;
		}

		public static class Levels {
			public const byte
				Rockbreaker = 30,
				Demolish = 30,
				FourPointFury = 45,
				DragonKick = 50;
		}
	}

	internal class MnkAoECombo: CustomCombo {
		protected override CustomComboPreset Preset => CustomComboPreset.MnkAoECombo;

		protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
			if (actionID == MNK.Rockbreaker) {
				if (HasEffect(MNK.Buffs.PerfectBalance) || HasEffect(MNK.Buffs.FormlessFist))
					return MNK.Rockbreaker;

				if (HasEffect(MNK.Buffs.OpoOpoForm))
					return MNK.ArmOfTheDestroyer;

				if (HasEffect(MNK.Buffs.RaptorForm) && level >= MNK.Levels.FourPointFury)
					return MNK.FourPointFury;

				if (HasEffect(MNK.Buffs.CoerlForm) && level >= MNK.Levels.Rockbreaker)
					return MNK.Rockbreaker;

				return MNK.ArmOfTheDestroyer;
			}

			return actionID;
		}
	}

	internal class MnkBootshineFeature: CustomCombo {
		protected override CustomComboPreset Preset => CustomComboPreset.MnkBootshineFeature;

		protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
			if (actionID == MNK.DragonKick) {
				if (HasEffect(MNK.Buffs.LeadenFist) && (
					HasEffect(MNK.Buffs.FormlessFist) || HasEffect(MNK.Buffs.PerfectBalance) ||
					HasEffect(MNK.Buffs.OpoOpoForm) || HasEffect(MNK.Buffs.RaptorForm) || HasEffect(MNK.Buffs.CoerlForm))) {
					return MNK.Bootshine;
				}

				if (level < MNK.Levels.DragonKick)
					return MNK.Bootshine;
			}

			return actionID;
		}
	}
}
