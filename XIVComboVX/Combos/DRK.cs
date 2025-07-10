using Dalamud.Game.ClientState.JobGauge.Types;

using VariableVixen.XIVComboVX;

namespace VariableVixen.XIVComboVX.Combos;

internal static class DRK {
	public const byte JobID = 32;

	public const uint
		HardSlash = 3617,
		Unleash = 3621,
		SyphonStrike = 3623,
		Souleater = 3632,
		BloodWeapon = 3625,
		SaltedEarth = 3639,
		AbyssalDrain = 3641,
		CarveAndSpit = 3643,
		Quietus = 7391,
		Bloodspiller = 7392,
		FloodOfDarkness = 16466,
		EdgeOfDarkness = 16467,
		StalwartSoul = 16468,
		FloodOfShadow = 16469,
		EdgeOfShadow = 16470,
		LivingShadow = 16472,
		SaltAndDarkness = 25755,
		Shadowbringer = 25757;

	public static class Buffs {
		public const ushort
			BloodWeapon = 742,
			Darkside = 751,
			Delirium = 1972;
	}
	public static class Debuffs {
		// public const ushort placeholder = 0;
	}

	public static class Levels {
		public const byte
			SyphonStrike = 2,
			Souleater = 26,
			FloodOfDarkness = 30,
			BloodWeapon = 35,
			EdgeOfDarkness = 40,
			StalwartSoul = 40,
			SaltedEarth = 52,
			AbyssalDrain = 56,
			CarveAndSpit = 60,
			Bloodspiller = 62,
			Quietus = 64,
			Delirium = 68,
			Shadow = 74,
			LivingShadow = 80,
			SaltAndDarkness = 86,
			Shadowbringer = 90;
	}
}

internal class DarkStunInterruptFeature: StunInterruptCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.DarkStunInterruptFeature;
}

internal class DarkSouleater: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.DrkAny;
	public override uint[] ActionIDs { get; } = [DRK.Souleater];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (IsEnabled(CustomComboPreset.DarkSouleaterOvercapFeature)) {
			DRKGauge gauge = GetJobGauge<DRKGauge>();

			if (level >= DRK.Levels.Bloodspiller && (gauge.Blood > 80 || gauge.Blood > 70 && SelfHasEffect(DRK.Buffs.BloodWeapon)))
				return OriginalHook(DRK.Bloodspiller);
		}

		if (level >= DRK.Levels.Delirium && IsEnabled(CustomComboPreset.DarkDeliriumFeature) && SelfHasEffect(DRK.Buffs.Delirium))
			return OriginalHook(DRK.Bloodspiller);

		if (IsEnabled(CustomComboPreset.DarkSouleaterCombo)) {

			if (lastComboMove is DRK.SyphonStrike && level >= DRK.Levels.Souleater)
				return DRK.Souleater;
			if (lastComboMove is DRK.HardSlash && level >= DRK.Levels.SyphonStrike)
				return DRK.SyphonStrike;

			return DRK.HardSlash;
		}

		return actionID;
	}
}

internal class DarkStalwartSoul: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.DrkAny;
	public override uint[] ActionIDs { get; } = [DRK.StalwartSoul];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (IsEnabled(CustomComboPreset.DarkStalwartSoulOvercapFeature)) {
			DRKGauge gauge = GetJobGauge<DRKGauge>();

			if (level >= DRK.Levels.Quietus && (gauge.Blood > 80 || gauge.Blood > 70 && SelfHasEffect(DRK.Buffs.BloodWeapon)))
				return OriginalHook(DRK.Quietus);
		}

		if (level >= DRK.Levels.Delirium && IsEnabled(CustomComboPreset.DarkDeliriumFeature) && SelfHasEffect(DRK.Buffs.Delirium))
			return OriginalHook(DRK.Quietus);

		if (IsEnabled(CustomComboPreset.DarkStalwartSoulCombo)) {

			if (lastComboMove is DRK.Unleash && level >= DRK.Levels.StalwartSoul)
				return DRK.StalwartSoul;

			return DRK.Unleash;
		}

		return actionID;
	}
}

internal class DarkShadowbringerFeature: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.DarkShadowbringerFeature;
	public override uint[] ActionIDs { get; } = [DRK.EdgeOfShadow, DRK.FloodOfShadow];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (level >= DRK.Levels.Shadowbringer && SelfHasEffect(DRK.Buffs.Darkside) && LocalPlayer.CurrentMp < 6000)
			return DRK.Shadowbringer;

		return actionID;
	}
}

internal class DarkCarveAndSpitAbyssalDrain: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.DrkAny;
	public override uint[] ActionIDs { get; } = [DRK.CarveAndSpit, DRK.AbyssalDrain];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (level >= DRK.Levels.BloodWeapon && IsEnabled(CustomComboPreset.DarkBloodWeaponFeature) && IsOffCooldown(DRK.BloodWeapon))
			return DRK.BloodWeapon;

		return actionID;
	}
}

internal class DarkQuietusBloodspiller: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.DrkAny;
	public override uint[] ActionIDs { get; } = [DRK.Quietus, DRK.Bloodspiller];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		// TODO: integrate this functionality into the Stalwart / Souleater features
		if (level >= DRK.Levels.LivingShadow && IsEnabled(CustomComboPreset.DarkLivingShadowFeature) && IsOffCooldown(DRK.LivingShadow))
			return DRK.LivingShadow;

		return actionID;
	}
}

internal class DarkLivingShadow: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.DrkAny;
	public override uint[] ActionIDs { get; } = [DRK.LivingShadow];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
		DRKGauge gauge = GetJobGauge<DRKGauge>();

		// TODO: integrate this functionality into the Quietus / Bloodspiller features

		if (IsEnabled(CustomComboPreset.DarkLivingShadowbringerFeature)) {
			if (level >= DRK.Levels.Shadowbringer && gauge.ShadowTimeRemaining > 0 && HasCharges(DRK.Shadowbringer))
				return DRK.Shadowbringer;
		}

		if (IsEnabled(CustomComboPreset.DarkLivingShadowbringerHpFeature)) {
			if (level >= DRK.Levels.Shadowbringer && HasCharges(DRK.Shadowbringer) && IsOnCooldown(DRK.LivingShadow))
				return DRK.Shadowbringer;
		}

		return actionID;
	}
}
