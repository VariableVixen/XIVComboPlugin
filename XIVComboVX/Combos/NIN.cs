using Dalamud.Game.ClientState.Conditions;
using Dalamud.Game.ClientState.JobGauge.Types;

namespace VariableVixen.XIVComboVX.Combos;

internal static class NIN {
	public const byte JobID = 30;

	public const uint
		SpinningEdge = 2240,
		GustSlash = 2242,
		Hide = 2245,
		Assassinate = 8814,
		ThrowingDagger = 2247,
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
		HellfrogMedium = 7401,
		Bhavacakra = 7402,
		TenChiJin = 7403,
		HakkeMujinsatsu = 16488,
		Meisui = 16489,
		Jin = 18807,
		Bunshin = 16493,
		PhantomKamaitachi = 25774,
		ForkedRaiju = 25777,
		FleetingRaiju = 25778,
		TenriJindo = 36961;

	public static class Buffs {
		public const ushort
			Mudra = 496,
			Kassatsu = 497,
			ShadowWalker = 3848,
			Hidden = 614,
			Bunshin = 1954,
			RaijuReady = 2690,
			PhantomKamaitachiReady = 2723,
			TenriJindoReady = 3851;
	}

	public static class Debuffs {
		// public const ushort placeholder = 0;
	}

	public static class Levels {
		public const byte
			GustSlash = 4,
			Hide = 10,
			ThrowingDagger = 15,
			Mug = 15,
			AeolianEdge = 26,
			Ninjitsu = 30,
			Assassinate = 40,
			Suiton = 45,
			HakkeMujinsatsu = 52,
			ArmorCrush = 54,
			DreamWithinADream = 56,
			Huraijin = 60,
			HellfrogMedium = 62,
			Bhavacakra = 68,
			TenChiJin = 70,
			Meisui = 72,
			EnhancedKassatsu = 76,
			Bunshin = 80,
			PhantomKamaitachi = 82,
			Raiju = 90,
			TenriJindo = 100;
	}
}

internal class NinjaBloodbathReplacer: SecondBloodbathCombo {
	public override CustomComboPreset Preset => CustomComboPreset.NinjaBloodbathReplacer;
}

internal class NinjaArmorCrushCombo: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.NinjaArmorCrushCombo;
	public override uint[] ActionIDs { get; } = [NIN.ArmorCrush];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
		NINGauge gauge = GetJobGauge<NINGauge>();
		bool canRaiju = level >= NIN.Levels.Raiju && SelfHasEffect(NIN.Buffs.RaijuReady);
		bool isDistant = TargetDistance is > 3;

		if (level >= NIN.Levels.Ninjitsu) {
			if (IsEnabled(CustomComboPreset.NinjaGCDNinjutsuFeature) && SelfHasEffect(NIN.Buffs.Mudra))
				return OriginalHook(NIN.Ninjutsu);
		}

		if (CanWeave(actionID)) {
			bool weaveAll = IsEnabled(CustomComboPreset.NinjaSingleTargetSmartWeaveFeature);
			bool weaveBunshin = weaveAll || IsEnabled(CustomComboPreset.NinjaArmorCrushBunshinFeature);
			bool weaveBhavacakra = weaveAll || IsEnabled(CustomComboPreset.NinjaArmorCrushBhavacakraFeature);
			bool weaveAssassinate = weaveAll || IsEnabled(CustomComboPreset.NinjaArmorCrushAssasinateFeature);

			if (weaveBunshin && level >= NIN.Levels.Bunshin && IsOffCooldown(NIN.Bunshin) && GetJobGauge<NINGauge>().Ninki >= 50)
				return NIN.Bunshin;
			if (weaveBhavacakra && level >= NIN.Levels.Bhavacakra && IsOffCooldown(NIN.Bhavacakra) && GetJobGauge<NINGauge>().Ninki >= 50 && !isDistant)
				return OriginalHook(NIN.Bhavacakra);
			if (weaveAssassinate && level >= NIN.Levels.Assassinate && IsOffCooldown(OriginalHook(NIN.DreamWithinADream)) && !isDistant)
				return OriginalHook(NIN.DreamWithinADream);

		}

		if (isDistant) {
			if (canRaiju) {
				if (IsEnabled(CustomComboPreset.NinjaArmorCrushSmartRaijuFeature) || IsEnabled(CustomComboPreset.NinjaArmorCrushForkedRaijuFeature))
					return NIN.ForkedRaiju;
			}

			if (IsEnabled(CustomComboPreset.NinjaArmorCrushThrowingDaggerFeature))
				return level >= NIN.Levels.PhantomKamaitachi && SelfHasEffect(NIN.Buffs.PhantomKamaitachiReady) ? NIN.PhantomKamaitachi : NIN.ThrowingDagger;
		}
		else if (canRaiju) {
			if (IsEnabled(CustomComboPreset.NinjaArmorCrushSmartRaijuFeature) || IsEnabled(CustomComboPreset.NinjaArmorCrushFleetingRaijuFeature))
				return NIN.FleetingRaiju;
		}

		if (lastComboMove is NIN.SpinningEdge) {
			if (level >= NIN.Levels.GustSlash)
				return NIN.GustSlash;
		}

		if (lastComboMove is NIN.GustSlash) {

			if (IsEnabled(CustomComboPreset.NinjaArmorCrushGaugeSaver) && gauge.Kazematoi >= 4)
				return NIN.AeolianEdge;

			if (level >= NIN.Levels.ArmorCrush)
				return NIN.ArmorCrush;

			if (IsEnabled(CustomComboPreset.NinjaArmorCrushFallbackFeature) && level >= NIN.Levels.AeolianEdge)
				return NIN.AeolianEdge;

		}

		if (IsEnabled(CustomComboPreset.NinjaArmorCrushKamaitachiFeature)) {
			if (level >= NIN.Levels.PhantomKamaitachi && SelfHasEffect(NIN.Buffs.PhantomKamaitachiReady) && !SelfHasEffect(NIN.Buffs.Bunshin))
				return NIN.PhantomKamaitachi;
		}

		return NIN.SpinningEdge;
	}
}

internal class NinjaAeolianEdgeCombo: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.NinjaAeolianEdgeCombo;
	public override uint[] ActionIDs { get; } = [NIN.AeolianEdge];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {
		NINGauge gauge = GetJobGauge<NINGauge>();
		bool canRaiju = level >= NIN.Levels.Raiju && SelfHasEffect(NIN.Buffs.RaijuReady);
		bool isDistant = TargetDistance is > 3;

		if (IsEnabled(CustomComboPreset.NinjaGCDNinjutsuFeature)) {
			if (level >= NIN.Levels.Ninjitsu) {
				if (SelfHasEffect(NIN.Buffs.Mudra))
					return OriginalHook(NIN.Ninjutsu);
			}
		}

		if (CanWeave(actionID)) {
			bool weaveAll = IsEnabled(CustomComboPreset.NinjaSingleTargetSmartWeaveFeature);
			bool weaveBunshin = weaveAll || IsEnabled(CustomComboPreset.NinjaAeolianEdgeBunshinFeature);
			bool weaveBhavacakra = weaveAll || IsEnabled(CustomComboPreset.NinjaAeolianEdgeBhavacakraFeature);
			bool weaveAssassinate = weaveAll || IsEnabled(CustomComboPreset.NinjaAeolianEdgeAssasinateFeature);

			if (weaveBunshin && level >= NIN.Levels.Bunshin && IsOffCooldown(NIN.Bunshin) && GetJobGauge<NINGauge>().Ninki >= 50)
				return NIN.Bunshin;
			if (weaveBhavacakra && level >= NIN.Levels.Bhavacakra && IsOffCooldown(NIN.Bhavacakra) && GetJobGauge<NINGauge>().Ninki >= 50 && !isDistant)
				return OriginalHook(NIN.Bhavacakra);
			if (weaveAssassinate && level >= NIN.Levels.Assassinate && IsOffCooldown(OriginalHook(NIN.DreamWithinADream)) && !isDistant)
				return OriginalHook(NIN.DreamWithinADream);

		}

		if (isDistant) {
			if (canRaiju) {
				if (IsEnabled(CustomComboPreset.NinjaAeolianEdgeSmartRaijuFeature) || IsEnabled(CustomComboPreset.NinjaAeolianEdgeForkedRaijuFeature))
					return NIN.ForkedRaiju;
			}

			if (IsEnabled(CustomComboPreset.NinjaAeolianEdgeThrowingDaggerFeature))
				return level >= NIN.Levels.PhantomKamaitachi && SelfHasEffect(NIN.Buffs.PhantomKamaitachiReady) ? NIN.PhantomKamaitachi : NIN.ThrowingDagger;
		}
		else if (canRaiju) {
			if (IsEnabled(CustomComboPreset.NinjaAeolianEdgeSmartRaijuFeature) || IsEnabled(CustomComboPreset.NinjaAeolianEdgeFleetingRaijuFeature))
				return NIN.FleetingRaiju;
		}

		if (lastComboMove is NIN.SpinningEdge) {
			if (level >= NIN.Levels.GustSlash)
				return NIN.GustSlash;
		}

		if (lastComboMove is NIN.GustSlash) {

			if (IsEnabled(CustomComboPreset.NinjaAeolianEdgeGaugeSaver) && gauge.Kazematoi == 0 && level >= NIN.Levels.ArmorCrush)
				return NIN.ArmorCrush;

			if (level >= NIN.Levels.AeolianEdge)
				return NIN.AeolianEdge;

		}

		if (IsEnabled(CustomComboPreset.NinjaAeolianEdgeKamaitachiFeature)) {
			if (level >= NIN.Levels.PhantomKamaitachi && SelfHasEffect(NIN.Buffs.PhantomKamaitachiReady) && !SelfHasEffect(NIN.Buffs.Bunshin))
				return NIN.PhantomKamaitachi;
		}

		return NIN.SpinningEdge;
	}
}

internal class NinjaHakkeMujinsatsuCombo: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.NinjaHakkeMujinsatsuCombo;
	public override uint[] ActionIDs { get; } = [NIN.HakkeMujinsatsu];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (IsEnabled(CustomComboPreset.NinjaGCDNinjutsuFeature)) {
			if (SelfHasEffect(NIN.Buffs.Mudra))
				return OriginalHook(NIN.Ninjutsu);
		}

		if (IsEnabled(CustomComboPreset.NinjaAOESmartWeaveFeature) && CanWeave(actionID)) {
			if (level >= NIN.Levels.HellfrogMedium && GetJobGauge<NINGauge>().Ninki >= 50)
				return OriginalHook(NIN.HellfrogMedium);
		}

		if (level >= NIN.Levels.HakkeMujinsatsu) {
			if (lastComboMove is NIN.DeathBlossom)
				return NIN.HakkeMujinsatsu;
		}

		return NIN.DeathBlossom;
	}
}

internal class NinjaKassatsuTrickFeature: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.NinjaKassatsuTrickFeature;
	public override uint[] ActionIDs { get; } = [NIN.Kassatsu];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (level >= NIN.Levels.Hide) {
			if (SelfHasEffect(NIN.Buffs.Hidden))
				return OriginalHook(NIN.TrickAttack);
		}

		if (level >= NIN.Levels.Suiton) {
			if (SelfHasEffect(NIN.Buffs.ShadowWalker))
				return OriginalHook(NIN.TrickAttack);
		}

		return actionID;
	}
}

internal class NinjaHideMugFeature: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.NinjaSmartHideFeature;
	public override uint[] ActionIDs { get; } = [NIN.Hide];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (level >= NIN.Levels.Hide) {
			if (SelfHasEffect(NIN.Buffs.Hidden) && HasTarget)
				return OriginalHook(NIN.TrickAttack);
		}

		if (level >= NIN.Levels.Suiton) {
			if (SelfHasEffect(NIN.Buffs.ShadowWalker))
				return OriginalHook(NIN.TrickAttack);
		}

		if (level >= NIN.Levels.Mug) {
			if (HasCondition(ConditionFlag.InCombat))
				return OriginalHook(NIN.Mug);
		}

		return actionID;
	}
}

internal class NinjaKassatsuChiJinFeature: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.NinjaKassatsuChiJinFeature;
	public override uint[] ActionIDs { get; } = [NIN.Chi];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (level >= NIN.Levels.EnhancedKassatsu) {
			if (SelfHasEffect(NIN.Buffs.Kassatsu))
				return NIN.Jin;
		}

		return actionID;
	}
}

internal class NinjaTCJMeisuiFeature: CustomCombo {
	public override CustomComboPreset Preset => CustomComboPreset.NinAny;
	public override uint[] ActionIDs { get; } = [NIN.TenChiJin];

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (IsEnabled(CustomComboPreset.NinjaTCJMeisuiFeature)) {
			if (level >= NIN.Levels.Meisui) {
				if (SelfHasEffect(NIN.Buffs.ShadowWalker))
					return NIN.Meisui;
			}
		}

		if (IsEnabled(CustomComboPreset.NinjaTCJTenriJindo)) {
			if (level >= NIN.Levels.TenriJindo && SelfHasEffect(NIN.Buffs.TenriJindoReady))
				return NIN.TenriJindo;
		}

		return actionID;
	}
}
