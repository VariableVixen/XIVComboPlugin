using Dalamud.Game.ClientState.Conditions;

namespace XIVComboVeryExpandedPlugin.Combos {
	internal static class NIN {
		public const byte JobID = 30;

		public const uint
			SpinningEdge = 2240,
			GustSlash = 2242,
			Hide = 2245,
			Assassinate = 2246,
			Mug = 2248,
			DeathBlossom = 2254,
			AeolianEdge = 2255,
			TrickAttack = 2258,
			Ninjutsu = 2260,
			Chi = 2261,
			JinNormal = 2263,
			Kassatsu = 2264,
			ArmorCrush = 3563,
			DreamWithinADream = 3566,
			TenChiJin = 7403,
			HakkeMujinsatsu = 16488,
			Meisui = 16489,
			Jin = 18807;

		public static class Buffs {
			public const short
				Kassatsu = 497,
				Suiton = 507,
				Hidden = 614,
				AssassinateReady = 1955;
		}

		public static class Debuffs {
			// public const short placeholder = 0;
		}

		public static class Levels {
			public const byte
				GustSlash = 4,
				AeolianEdge = 26,
				HakkeMujinsatsu = 52,
				ArmorCrush = 54,
				Assassinate = 60,
				Meisui = 72,
				EnhancedKassatsu = 76;
		}
	}

	internal class NinjaArmorCrushCombo: CustomCombo {
		protected override CustomComboPreset Preset => CustomComboPreset.NinjaArmorCrushCombo;

		protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
			if (actionID == NIN.ArmorCrush) {
				if (IsEnabled(CustomComboPreset.NinjaGCDNinjutsuFeature) && OriginalHook(NIN.JinNormal) == OriginalHook(NIN.Jin))
					return OriginalHook(NIN.Ninjutsu);

				if (comboTime > 0) {
					if (lastComboMove == NIN.SpinningEdge && level >= NIN.Levels.GustSlash)
						return NIN.GustSlash;

					if (lastComboMove == NIN.GustSlash && level >= NIN.Levels.ArmorCrush)
						return NIN.ArmorCrush;
				}

				return NIN.SpinningEdge;
			}

			return actionID;
		}
	}

	internal class NinjaAeolianEdgeCombo: CustomCombo {
		protected override CustomComboPreset Preset => CustomComboPreset.NinjaAeolianEdgeCombo;

		protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
			if (actionID == NIN.AeolianEdge) {
				if (IsEnabled(CustomComboPreset.NinjaGCDNinjutsuFeature) && OriginalHook(NIN.JinNormal) == OriginalHook(NIN.Jin))
					return OriginalHook(NIN.Ninjutsu);

				if (comboTime > 0) {
					if (lastComboMove == NIN.SpinningEdge && level >= NIN.Levels.GustSlash)
						return NIN.GustSlash;

					if (lastComboMove == NIN.GustSlash && level >= NIN.Levels.AeolianEdge)
						return NIN.AeolianEdge;
				}

				return NIN.SpinningEdge;
			}

			return actionID;
		}
	}

	internal class NinjaHakkeMujinsatsuCombo: CustomCombo {
		protected override CustomComboPreset Preset => CustomComboPreset.NinjaHakkeMujinsatsuCombo;

		protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
			if (actionID == NIN.HakkeMujinsatsu) {
				if (IsEnabled(CustomComboPreset.NinjaGCDNinjutsuFeature) && OriginalHook(NIN.JinNormal) == OriginalHook(NIN.Jin))
					return OriginalHook(NIN.Ninjutsu);

				if (comboTime > 0 && lastComboMove == NIN.DeathBlossom && level >= NIN.Levels.HakkeMujinsatsu)
					return NIN.HakkeMujinsatsu;

				return NIN.DeathBlossom;
			}

			return actionID;
		}
	}

	internal class NinjaAssassinateFeature: CustomCombo {
		protected override CustomComboPreset Preset => CustomComboPreset.NinjaAssassinateFeature;

		protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
			if (actionID == NIN.DreamWithinADream) {
				if (level >= NIN.Levels.Assassinate && HasEffect(NIN.Buffs.AssassinateReady))
					return NIN.Assassinate;
			}

			return actionID;
		}
	}

	internal class NinjaKassatsuTrickFeature: CustomCombo {
		protected override CustomComboPreset Preset => CustomComboPreset.NinjaKassatsuTrickFeature;

		protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
			if (actionID == NIN.Kassatsu) {
				if (HasEffect(NIN.Buffs.Suiton) || HasEffect(NIN.Buffs.Hidden))
					return NIN.TrickAttack;

				return NIN.Kassatsu;
			}

			return actionID;
		}
	}

	internal class NinjaHideMugFeature: CustomCombo {
		protected override CustomComboPreset Preset => CustomComboPreset.NinjaHideMugFeature;

		protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
			if (actionID == NIN.Hide) {
				if (HasEffect(NIN.Buffs.Suiton) || HasEffect(NIN.Buffs.Hidden))
					return NIN.TrickAttack;

				if (HasCondition(ConditionFlag.InCombat))
					return NIN.Mug;
			}

			return actionID;
		}
	}

	internal class NinjaKassatsuChiJinFeature: CustomCombo {
		protected override CustomComboPreset Preset => CustomComboPreset.NinjaKassatsuChiJinFeature;

		protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
			if (actionID == NIN.Chi) {
				if (level >= NIN.Levels.EnhancedKassatsu && HasEffect(NIN.Buffs.Kassatsu))
					return NIN.Jin;
			}

			return actionID;
		}
	}

	internal class NinjaTCJMeisuiFeature: CustomCombo {
		protected override CustomComboPreset Preset => CustomComboPreset.NinjaTCJMeisuiFeature;

		protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
			if (actionID == NIN.TenChiJin) {
				if (HasEffect(NIN.Buffs.Suiton))
					return NIN.Meisui;

				return NIN.TenChiJin;
			}

			return actionID;
		}
	}
}
