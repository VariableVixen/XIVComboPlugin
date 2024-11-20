using Dalamud.Game.ClientState.Conditions;

namespace PrincessRTFM.XIVComboVX.Combos;

internal static class DOL {
	public const byte JobID = 99,
		MinID = 16,
		BtnID = 17,
		FshID = 18;

	public static class Buffs {
		public const ushort
			EurekaMoment = 2765,
			CollectorsStandard = 2418,
			CollectorsHighStandard = 3911,
			PrimingTouch = 3910;
	}

	public static class Debuffs {
		public const ushort
			Placeholder = 0;
	}

	public static class Levels {
		public const byte
			Snagging = 36,
			Gig = 61,
			Salvage = 67,
			VeteranTrade = 63,
			NaturesBounty = 69,
			SurfaceSlap = 71,
			PrizeCatch = 81,
			WiseToTheWorld = 90,
			PrimingTouch = 95;

	}
}

public static class BTN {
	public const uint
		Triangulate = 210,
		ArborCall = 211,
		FieldMastery = 218,
		ArborCall2 = 290,
		FieldMastery2 = 220,
		Sneak = 304,
		FieldMastery3 = 294,
		PioneersGift = 21178,
		TwelvesBounty = 282,
		FloraMastery = 4086,
		BountifulHarvest = 4087,
		AgelessWords = 215,
		BlessedHarvest = 222,
		BlessedHarvest2 = 224,
		TruthOfForests = 221,
		Collect = 815,
		Scour = 22186,
		BrazenWoodsman = 22187,
		MeticulousWoodsman = 22188,
		Scrutiny = 22189,
		PioneersGift2 = 25590,
		LuckOfThePioneer = 4095,
		BountifulHarvest2 = 273,
		GivingLand = 4590,
		NophicasTidings = 21204,
		CollectorsFocus = 21206,
		WiseToTheWorld = 26522,
		PrimingTouch = 34872;
}
public static class MIN {
	public const uint
		Prospect = 227,
		LayOfTheLand = 228,
		SharpVision = 235,
		LayOfTheLand2 = 291,
		SharpVision2 = 237,
		Sneak = 303,
		SharpVision3 = 295,
		MountaineersGift = 21177,
		TwelvesBounty = 280,
		ClearVision = 4072,
		BountifulYield = 4073,
		SolidReason = 232,
		KingsYield = 239,
		KingsYield2 = 241,
		TruthOfMountains = 238,
		Collect = 240,
		Scour = 22182,
		BrazenProspector = 22183,
		MeticulousProspector = 22184,
		Scrutiny = 22185,
		MountaineersGift2 = 25589,
		LuckOfTheMountaineer = 4081,
		BountifulYield2 = 272,
		GivingLand = 4589,
		NaldthalsTidings = 21203,
		CollectorsFocus = 21205,
		WiseToTheWorld = 26521,
		PrimingTouch = 34871;
}

public static class FSH {
	public const uint
		Mooch2 = 268,
		DoubleHook = 269,
		Bait = 288,
		Cast = 289,
		Hook = 296,
		Quit = 299,
		Snagging = 4100,
		Patience = 4102,
		Chum = 4104,
		FishEyes = 4105,
		Patience2 = 4106,
		SurfaceSlap = 4595,
		IdenticalCast = 4596,
		Gig = 7632,
		VeteranTrade = 7906,
		NaturesBounty = 7909,
		Salvage = 7910,
		ThaliaksFavour = 26804,
		MakeshiftBait = 26805,
		PrizeCatch = 26806,
		VitalSight = 26870,
		BaitedBreath = 26871,
		ElectricCurrent = 26872,
		TripleHook = 27523,
		SparefulHand = 37045,
		BigGameFishing = 37046;


	public static class Buffs {
		public const ushort
			AnglersArt = 2778;
	}
}

internal class NonFishingFeatures: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.DolAny;
	// No ActionIDs are set because this applies to a wide enough variety of actions that it's too much duplication

	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (IsEnabled(CustomComboPreset.GatherEurekaFeature)) {
			if (actionID is MIN.SolidReason or BTN.AgelessWords) {
				if (level >= DOL.Levels.WiseToTheWorld) {
					if (SelfHasEffect(DOL.Buffs.EurekaMoment)) {
						return IsJob(DOL.MinID)
							? MIN.WiseToTheWorld
							: BTN.WiseToTheWorld;
					}
				}
			}
		}

		if (IsEnabled(CustomComboPreset.GatherJobCorrectionFeature)) {
			switch (LocalPlayer.ClassJob.RowId) {
				case DOL.BtnID:
					return actionID switch {
						MIN.Prospect => IsEnabled(CustomComboPreset.GatherJobCorrectionIgnoreDetectionsFeature) ? actionID : BTN.Triangulate,
						MIN.LayOfTheLand => IsEnabled(CustomComboPreset.GatherJobCorrectionIgnoreDetectionsFeature) ? actionID : BTN.ArborCall,
						MIN.SharpVision => BTN.FieldMastery,
						MIN.LayOfTheLand2 => IsEnabled(CustomComboPreset.GatherJobCorrectionIgnoreDetectionsFeature) ? actionID : BTN.ArborCall2,
						MIN.SharpVision2 => BTN.FieldMastery2,
						MIN.Sneak => BTN.Sneak,
						MIN.SharpVision3 => BTN.FieldMastery3,
						MIN.MountaineersGift => BTN.PioneersGift,
						MIN.TwelvesBounty => BTN.TwelvesBounty,
						MIN.ClearVision => BTN.FloraMastery,
						MIN.BountifulYield => OriginalHook(BTN.BountifulHarvest),
						MIN.SolidReason => BTN.AgelessWords,
						MIN.KingsYield => BTN.BlessedHarvest,
						MIN.KingsYield2 => BTN.BlessedHarvest2,
						MIN.TruthOfMountains => IsEnabled(CustomComboPreset.GatherJobCorrectionIgnoreDetectionsFeature) ? actionID : BTN.TruthOfForests,
						MIN.Collect => BTN.Collect,
						MIN.Scour => BTN.Scour,
						MIN.BrazenProspector => BTN.BrazenWoodsman,
						MIN.MeticulousProspector => BTN.MeticulousWoodsman,
						MIN.Scrutiny => BTN.Scrutiny,
						MIN.MountaineersGift2 => BTN.PioneersGift2,
						MIN.LuckOfTheMountaineer => BTN.LuckOfThePioneer,
						MIN.BountifulYield2 => OriginalHook(BTN.BountifulHarvest2),
						MIN.GivingLand => BTN.GivingLand,
						MIN.NaldthalsTidings => BTN.NophicasTidings,
						MIN.CollectorsFocus => BTN.CollectorsFocus,
						MIN.WiseToTheWorld => BTN.WiseToTheWorld,
						MIN.PrimingTouch => BTN.PrimingTouch,
						_ => actionID,
					};
				case DOL.MinID:
					return actionID switch {
						BTN.Triangulate => IsEnabled(CustomComboPreset.GatherJobCorrectionIgnoreDetectionsFeature) ? actionID : MIN.Prospect,
						BTN.ArborCall => IsEnabled(CustomComboPreset.GatherJobCorrectionIgnoreDetectionsFeature) ? actionID : MIN.LayOfTheLand,
						BTN.FieldMastery => MIN.SharpVision,
						BTN.ArborCall2 => IsEnabled(CustomComboPreset.GatherJobCorrectionIgnoreDetectionsFeature) ? actionID : MIN.LayOfTheLand2,
						BTN.FieldMastery2 => MIN.SharpVision2,
						BTN.Sneak => MIN.Sneak,
						BTN.FieldMastery3 => MIN.SharpVision3,
						BTN.PioneersGift => MIN.MountaineersGift,
						BTN.TwelvesBounty => MIN.TwelvesBounty,
						BTN.FloraMastery => MIN.ClearVision,
						BTN.BountifulHarvest => OriginalHook(MIN.BountifulYield),
						BTN.AgelessWords => MIN.SolidReason,
						BTN.BlessedHarvest => MIN.KingsYield,
						BTN.BlessedHarvest2 => MIN.KingsYield2,
						BTN.TruthOfForests => IsEnabled(CustomComboPreset.GatherJobCorrectionIgnoreDetectionsFeature) ? actionID : MIN.TruthOfMountains,
						BTN.Collect => MIN.Collect,
						BTN.Scour => MIN.Scour,
						BTN.BrazenWoodsman => MIN.BrazenProspector,
						BTN.MeticulousWoodsman => MIN.MeticulousProspector,
						BTN.Scrutiny => MIN.Scrutiny,
						BTN.PioneersGift2 => MIN.MountaineersGift2,
						BTN.LuckOfThePioneer => MIN.LuckOfTheMountaineer,
						BTN.BountifulHarvest2 => OriginalHook(MIN.BountifulYield2),
						BTN.GivingLand => MIN.GivingLand,
						BTN.NophicasTidings => MIN.NaldthalsTidings,
						BTN.CollectorsFocus => MIN.CollectorsFocus,
						BTN.WiseToTheWorld => MIN.WiseToTheWorld,
						BTN.PrimingTouch => MIN.PrimingTouch,
						_ => actionID,
					};
			}
		}

		return actionID;
	}


}

internal class FisherSwapFeatures: CustomCombo {
	public override CustomComboPreset Preset { get; } = CustomComboPreset.DolAny;
	// No ActionIDs are set because this applies to a wide enough variety of actions that it's too much duplication

	private static uint thaliak(uint actionID, byte level) {
		if (level >= 15 && SelfEffectStacks(FSH.Buffs.AnglersArt) >= 3) {

			if (actionID is FSH.Chum && LocalPlayer.CurrentGp < 100)
				return FSH.ThaliaksFavour;

			else if (actionID is FSH.Patience && LocalPlayer.CurrentGp < 200)
				return FSH.ThaliaksFavour;

			else if (actionID is FSH.Patience2 && LocalPlayer.CurrentGp < 560)
				return FSH.ThaliaksFavour;

			else if (actionID is FSH.FishEyes && LocalPlayer.CurrentGp < 550)
				return FSH.ThaliaksFavour;

			else if (actionID is FSH.Mooch2 && LocalPlayer.CurrentGp < 100 && CanUse(FSH.Mooch2))
				return FSH.ThaliaksFavour;

			else if (actionID is FSH.VeteranTrade && LocalPlayer.CurrentGp < 200)
				return FSH.ThaliaksFavour;

			else if (actionID is FSH.NaturesBounty && LocalPlayer.CurrentGp < 100)
				return FSH.ThaliaksFavour;

			else if (actionID is FSH.SurfaceSlap && LocalPlayer.CurrentGp < 200)
				return FSH.ThaliaksFavour;

			else if (actionID is FSH.IdenticalCast && LocalPlayer.CurrentGp < 350)
				return FSH.ThaliaksFavour;

			else if (actionID is FSH.BaitedBreath && LocalPlayer.CurrentGp < 300)
				return FSH.ThaliaksFavour;

			else if (actionID is FSH.PrizeCatch && LocalPlayer.CurrentGp < 200)
				return FSH.ThaliaksFavour;

		}
		return actionID;
	}
	protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level) {

		if (HasCondition(ConditionFlag.Fishing)) {

			if (actionID is FSH.Cast && IsEnabled(CustomComboPreset.FisherCastHookFeature))
				return FSH.Hook;

			else if (actionID is FSH.DoubleHook && IsEnabled(CustomComboPreset.FisherCastMultiHookFeature21) && LocalPlayer.CurrentGp < 400)
				return FSH.Hook;

			else if (actionID is FSH.TripleHook && IsEnabled(CustomComboPreset.FisherCastMultiHookFeature32) && LocalPlayer.CurrentGp < 700)
				return IsEnabled(CustomComboPreset.FisherCastMultiHookFeature21) && LocalPlayer.CurrentGp < 400 ? FSH.Hook : FSH.DoubleHook;

		}
		else if (HasCondition(ConditionFlag.Diving)) {

			if (actionID is FSH.Cast && IsEnabled(CustomComboPreset.FisherCastGigFeature))
				return FSH.Gig;

			else if (actionID is FSH.SurfaceSlap && IsEnabled(CustomComboPreset.FisherSurfaceTradeFeature))
				return thaliak(FSH.VeteranTrade, level);

			else if (actionID is FSH.PrizeCatch && IsEnabled(CustomComboPreset.FisherPrizeBountyFeature))
				return thaliak(FSH.NaturesBounty, level);

			else if (actionID is FSH.Snagging && IsEnabled(CustomComboPreset.FisherSnaggingSalvageFeature))
				return FSH.Salvage;

			else if (actionID is FSH.IdenticalCast && IsEnabled(CustomComboPreset.FisherIdenticalSightFeature))
				return FSH.VitalSight;

			else if (actionID is FSH.MakeshiftBait && IsEnabled(CustomComboPreset.FisherMakeshiftBreathFeature))
				return thaliak(FSH.BaitedBreath, level);

			else if (actionID is FSH.Chum && IsEnabled(CustomComboPreset.FisherElectricChumFeature))
				return FSH.ElectricCurrent;

		}
		else {

			if (actionID is FSH.Hook && IsEnabled(CustomComboPreset.FisherCastHookFeature))
				return FSH.Cast;

			else if (actionID is FSH.TripleHook && IsEnabled(CustomComboPreset.FisherCastTripleHookFeature))
				return FSH.Cast;

			else if (actionID is FSH.DoubleHook && IsEnabled(CustomComboPreset.FisherCastDoubleHookFeature))
				return FSH.Cast;

		}

		return thaliak(actionID, level);
	}
}

internal class PrimedMetFeature: CustomCombo {

	public override CustomComboPreset Preset { get; } = CustomComboPreset.PrimedMetFeature;

	public override uint[] ActionIDs => [MIN.MeticulousProspector, BTN.MeticulousWoodsman];

	protected override uint Invoke(uint actionID, uint lastComboActionId, float comboTime, byte level) {

		if (level >= DOL.Levels.PrimingTouch) {
			if (LocalPlayer.CurrentGp >= 400) {
				if (SelfHasEffect(DOL.Buffs.CollectorsStandard) || SelfHasEffect(DOL.Buffs.CollectorsHighStandard)) {
					if (!SelfHasEffect(DOL.Buffs.PrimingTouch))
						return IsJob(DOL.MinID) ? MIN.PrimingTouch : BTN.PrimingTouch;
				}
			}
		}

		return actionID;

	}
}
