using System;

using Dalamud.Utility;

using PrincessRTFM.XIVComboVX.Attributes;
using PrincessRTFM.XIVComboVX.Combos;

namespace PrincessRTFM.XIVComboVX;

public enum CustomComboPreset {
	#region Universal
	[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", 0)]
	AdvAny = 0,

	[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", AST.JobID)]
	AstAny = AdvAny + AST.JobID,

	[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", BLM.JobID)]
	BlmAny = AdvAny + BLM.JobID,

	[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", BRD.JobID)]
	BrdAny = AdvAny + BRD.JobID,

	[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", DNC.JobID)]
	DncAny = AdvAny + DNC.JobID,

	[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", DRG.JobID)]
	DrgAny = AdvAny + DRG.JobID,

	[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", DRK.JobID)]
	DrkAny = AdvAny + DRK.JobID,

	[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", GNB.JobID)]
	GnbAny = AdvAny + GNB.JobID,

	[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", MCH.JobID)]
	MchAny = AdvAny + MCH.JobID,

	[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", MNK.JobID)]
	MnkAny = AdvAny + MNK.JobID,

	[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", NIN.JobID)]
	NinAny = AdvAny + NIN.JobID,

	[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", PLD.JobID)]
	PldAny = AdvAny + PLD.JobID,

	[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", RDM.JobID)]
	RdmAny = AdvAny + RDM.JobID,

	[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", RPR.JobID)]
	RprAny = AdvAny + RPR.JobID,

	[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", SAM.JobID)]
	SamAny = AdvAny + SAM.JobID,

	[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", SCH.JobID)]
	SchAny = AdvAny + SCH.JobID,

	[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", SGE.JobID)]
	SgeAny = AdvAny + SGE.JobID,

	[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", SMN.JobID)]
	SmnAny = AdvAny + SMN.JobID,

	[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", WAR.JobID)]
	WarAny = AdvAny + WAR.JobID,

	[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", WHM.JobID)]
	WhmAny = AdvAny + WHM.JobID,

	[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", DOH.JobID)]
	DohAny = AdvAny + DOH.JobID,

	[CustomComboInfo("Any", "This should not be displayed. This always returns true when used with IsEnabled.", DOL.JobID)]
	DolAny = AdvAny + DOL.JobID,

	[CustomComboInfo("None", "This should not be displayed. This always returns false when used with IsEnabled.", 99)]
	None = 99,
	#endregion
	// ====================================================================================
	#region ASTROLOGIAN (33xx)
	// last used = 8

	[CustomComboInfo("Swiftcast Ascend", "Ascend turns into Swiftcast when available and reasonable.", AST.JobID)]
	AstrologianSwiftcastRaiserFeature = 3300,

	[CustomComboInfo("Benefic 2 to Benefic Level Sync", "Changes Benefic 2 to Benefic when below level 26.", AST.JobID)]
	AstrologianBeneficFeature = 3303,

	#endregion
	// ====================================================================================
	#region BLACK MAGE (25xx)

	//[CustomComboInfo("Enochian Feature", "Change Fire 4 or Blizzard 4 to whichever action you can currently use.", BLM.JobID)]
	//BlackEnochianFeature = 2500,

	//[ParentPreset(BlackEnochianFeature)]
	//[CustomComboInfo("Enochian Despair Feature", "Change Fire 4 or Blizzard 4 to Despair when in Astral Fire with less than 2400 mana.", BLM.JobID)]
	//BlackEnochianDespairFeature = 2510,

	//[ParentPreset(BlackEnochianFeature)]
	//[CustomComboInfo("Enochian No Sync Feature", "Fire 4 and Blizzard 4 will not sync to Fire 1 and Blizzard 1.", BLM.JobID)]
	//BlackEnochianNoSyncFeature = 2518,

	//[CustomComboInfo("Umbral Soul/Transpose Switcher", "Change Transpose into Umbral Soul when Umbral Soul is usable.", BLM.JobID)]
	//BlackManaFeature = 2501,

	//[CustomComboInfo("(Between the) Ley Lines", "Change Ley Lines into BTL when Ley Lines is active.", BLM.JobID)]
	//BlackLeyLinesFeature = 2502,

	//[CustomComboInfo("Fire 1/3 Astral Feature", "Fire 1 becomes Fire 3 with 1 or fewer stacks of Astral Fire.", BLM.JobID)]
	//BlackFireAstralFeature = 2503,

	//[CustomComboInfo("Fire 1/3 Proc Feature", "Fire 1 becomes Fire 3 when Firestarter proc is up.", BLM.JobID)]
	//BlackFireProcFeature = 2509,

	//[CustomComboInfo("Blizzard 1/3 Feature", "Replace Blizzard 1 with Blizzard 3 when unlocked.", BLM.JobID)]
	//BlackBlizzardFeature = 2504,

	//[CustomComboInfo("Freeze/Flare Feature", "Freeze and Flare become whichever action you can currently use.", BLM.JobID)]
	//BlackFreezeFlareFeature = 2505,

	//[CustomComboInfo("Fire 2 Feature", "(High) Fire 2 becomes Flare in Astral Fire with 1 or fewer Umbral Hearts.", BLM.JobID)]
	//BlackFire2Feature = 2507,

	//[CustomComboInfo("Ice 2 Feature", "(High) Blizzard 2 becomes Freeze in Umbral Ice.", BLM.JobID)]
	//BlackBlizzard2Feature = 2508,

	//[CustomComboInfo("Fire 2/Ice 2 Option", "Fire 2 and Blizzard 2 will not change unless you're at max Astral Fire or Umbral Ice.", BLM.JobID)]
	//BlackFireBlizzard2Option = 2514,

	//[CustomComboInfo("Umbral Soul Feature", "Replace your ice spells with Umbral Soul, while in Umbral Ice and having no target.", BLM.JobID)]
	//BlackUmbralSoulFeature = 2517,

	//[CustomComboInfo("Scathe/Xenoglossy Feature", "Scathe becomes Xenoglossy when available.", BLM.JobID)]
	//BlackScatheFeature = 2506,

	#endregion
	// ====================================================================================
	#region BARD (23xx)

	[CustomComboInfo("Weave: Pitch Perfect", "Replaces Heavy Shot with Pitch Perfect when weaving and either Wanderer's Minuet is about to expire or Pitch Perfect reaches three stacks.", BRD.JobID)]
	BardWeavePitchPerfect = 2314,

	[CustomComboInfo("Weave: Battle Voice", "Replaces Heavy Shot with Battle Voice when weaving.", BRD.JobID)]
	BardWeaveBattleVoice = 2315,

	[CustomComboInfo("Weave: Raging Strikes", "Replaces Heavy Shot with Raging Strikes when weaving.", BRD.JobID)]
	BardWeaveRagingStrikes = 2316,

	[CustomComboInfo("Weave: Sidewinder", "Replaces Heavy Shot with Sidewinder when weaving.", BRD.JobID)]
	BardWeaveSidewinder = 2317,

	[CustomComboInfo("Weave: Empyreal Arrow", "Replaces Heavy Shot with Empyreal Arrow when weaving.", BRD.JobID)]
	BardWeaveEmpyrealArrow = 2318,

	[CustomComboInfo("Weave: Bloodletter", "Replaces Heavy Shot with Bloodletter when weaving.", BRD.JobID)]
	BardWeaveBloodletter = 2319,

	[CustomComboInfo("Weave: Rain of Death", "Replaces Heavy Shot with Rain of Death when weaving.", BRD.JobID)]
	BardWeaveDeathRain = 2320,

	[CustomComboInfo("Heavy Shot into Straight Shot", "Replaces Heavy Shot/Burst Shot with Straight Shot/Refulgent Arrow when procced.", BRD.JobID)]
	BardStraightShotUpgradeFeature = 2301,

	[CustomComboInfo("Heavy Jaws", "Replaces Heavy Shot/Burst Shot with Iron Jaws when your DoTs are below a configurable threshold.", BRD.JobID)]
	BardStraightShotIronJaws = 2322,

	[CustomComboInfo("Iron Bites", "Iron Jaws is replaced with Caustic Bite/Stormbite if one or both are not up.\nAlternates between the two if Iron Jaws isn't available.", BRD.JobID)]
	BardIronBites = 2302,

	[CustomComboInfo("Apex Arrow Feature", "Replaces Heavy Shot/Burst Shot, Quick Nock/Ladonsbite, and Shadowbite\nwith Blast Arrow when available, or Apex Arrow if gauge is full.", BRD.JobID)]
	BardApexFeature = 2303,

	[CustomComboInfo("Quick Nock / Ladonsbite into Shadowbite", "Replaces Quick Nock and Ladonsbite with Shadowbite when available.", BRD.JobID)]
	BardQuickNockLadonsbiteShadowbite = 2304,

	[CustomComboInfo("Rain of Shadows", "Replaces Shadowbite with Rain of Death when weaving or under level.", BRD.JobID)]
	BardShadowbiteDeathRain = 2321,

	[CustomComboInfo("Empyreal Sidewinder", "Replace Sidewinder and Empyreal Arrow with each other depending on which is available.", BRD.JobID)]
	BardEmpyrealSidewinder = 2309,

	[CustomComboInfo("Radiant Strikes Feature", "Replace Radiant Finale with Raging Strikes if Raging Strikes is available.\nThis takes priority over Battle Voice if Radiant Voice is enabled.", BRD.JobID)]
	BardRadiantStrikesFeature = 2311,

	[CustomComboInfo("Radiant Voice Feature", "Replace Radiant Finale with Battle Voice if Battle Voice is available.", BRD.JobID)]
	BardRadiantVoiceFeature = 2310,

	#endregion
	// ====================================================================================
	#region DANCER (38xx)

	[CustomComboInfo("Single Target Multibutton", "Change Cascade into procs and combos as available.", DNC.JobID)]
	DancerSingleTargetMultibutton = 3800,

	[ParentPreset(DancerSingleTargetMultibutton)]
	[CustomComboInfo("Gauge Spender", "Also change into Saber Dance when you have at least the set amount of Esprit Gauge.", DNC.JobID)]
	DancerSingleTargetGaugeSpender = 3819,

	[ParentPreset(DancerSingleTargetMultibutton)]
	[CustomComboInfo("Starfall Saver", "Also change into Starfall Dance when your Flourishing Starfall effect has no more than a certain duration left.", DNC.JobID)]
	DancerSingleTargetStarfall = 3821,

	[ParentPreset(DancerSingleTargetMultibutton)]
	[CustomComboInfo("Flourish Weaving", "Also change into Flourish when you can weave without clipping AND have none of the effects Flourish grants.", DNC.JobID)]
	DancerSingleTargetFlourishWeave = 3817,

	[ParentPreset(DancerSingleTargetMultibutton)]
	[CustomComboInfo("Devilment Weaving", "Also change into Devilment when you can weave without clipping and Devilment is off cooldown.", DNC.JobID)]
	DancerSingleTargetDevilmentWeave = 3823,

	[ParentPreset(DancerSingleTargetMultibutton)]
	[CustomComboInfo("Fan Dance 1/3 Weaving", "Also change into Fan Dance 1/3 when you can weave without clipping.", DNC.JobID)]
	DancerSingleTargetFanDanceWeave = 3810,

	[ParentPreset(DancerSingleTargetFanDanceWeave)]
	[CustomComboInfo("Fan Dance 2/4 Fallback", "Also change into Fan Dance 2/4, with lower priority than 1/3.", DNC.JobID)]
	DancerSingleTargetFanDanceFallback = 3812,

	[CustomComboInfo("AoE Multibutton", "Change Windmill into procs and combos as available.", DNC.JobID)]
	DancerAoeMultibutton = 3801,

	[ParentPreset(DancerAoeMultibutton)]
	[CustomComboInfo("Gauge Spender", "Also change into Saber Dance when you have at least the set amount of Esprit Gauge.", DNC.JobID)]
	DancerAoeGaugeSpender = 3820,

	[ParentPreset(DancerAoeMultibutton)]
	[CustomComboInfo("Starfall Saver", "Also change into Starfall Dance when your Flourishing Starfall effect has no more than a certain duration left.", DNC.JobID)]
	DancerAoeStarfall = 3822,

	[ParentPreset(DancerAoeMultibutton)]
	[CustomComboInfo("Flourish Weaving", "Also change into Flourish when you can weave without clipping AND have none of the effects Flourish grants.", DNC.JobID)]
	DancerAoeFlourishWeave = 3818,

	[ParentPreset(DancerAoeMultibutton)]
	[CustomComboInfo("Fan Dance 2/4 Weaving", "Also change into Fan Dance 2/4 when you can weave without clipping.", DNC.JobID)]
	DancerAoeFanDanceWeave = 3811,

	[ParentPreset(DancerAoeFanDanceWeave)]
	[CustomComboInfo("Fan Dance 1/3 Fallback", "Also change into Fan Dance 1/3, with lower priority than 2/4.", DNC.JobID)]
	DancerAoeFanDanceFallback = 3813,

	[CustomComboInfo("Flourish Dance 4", "Change Flourish into Fan Dance 4 when available.", DNC.JobID)]
	DancerFlourishFeature = 3804,

	[Conflicts(DancerDanceComboCompatibility)]
	[CustomComboInfo("Dance Step Combo", "Change Standard Step and Technical Step into each dance step while dancing.", DNC.JobID)]
	DancerDanceStepCombo = 3805,

	[ParentPreset(DancerDanceStepCombo)]
	[CustomComboInfo("Alternative Dance: Standard Step", "Also change Standard Step into Technical Step when ready and Standard Step's cooldown has more than 3 seconds left.", DNC.JobID)]
	DancerDanceStepComboSmartStandard = 3824,

	[ParentPreset(DancerDanceStepCombo)]
	[CustomComboInfo("Alternative Dance: Technical Step", "Also change Technical Step into Standard Step when Technical Step is unavailable or on cooldown.", DNC.JobID)]
	DancerDanceStepComboSmartTechnical = 3825,

	[ParentPreset(DancerDanceStepCombo)]
	[CustomComboInfo("Smart Dance", "Change your normal ST/AOE combos into the next dance steps (and then the finishers) while dancing.", DNC.JobID)]
	DancerSmartDanceFeature = 3814,

	[CustomComboInfo("Devilment Feature", "Change Devilment into Starfall Dance after use.", DNC.JobID)]
	DancerDevilmentFeature = 3807,

	[CustomComboInfo("Fan Dance 1/3 Combo", "Change Fan Dance 1 into Fan Dance 3 when available.", DNC.JobID)]
	DancerFanDance13Combo = 3802,

	[CustomComboInfo("Fan Dance 1/4 Combo", "Change Fan Dance 1 into Fan Dance 4 when available.", DNC.JobID)]
	DancerFanDance14Combo = 3808,

	[CustomComboInfo("Fan Dance 2/3 Combo", "Change Fan Dance 2 into Fan Dance 3 when available.", DNC.JobID)]
	DancerFanDance23Combo = 3803,

	[CustomComboInfo("Fan Dance 2/4 Combo", "Change Fan Dance 2 into Fan Dance 4 when available.", DNC.JobID)]
	DancerFanDance24Combo = 3809,

	[CustomComboInfo("Curing Wind Level Sync", "Change Curing Waltz into Second Wind when under level.", DNC.JobID)]
	DancerCuringWaltzLevelSync = 3815,

	[CustomComboInfo("Curing Wind Cooldown Swap", "Change Curing Waltz into Second Wind when Waltz is on CD.", DNC.JobID)]
	DancerCuringWaltzCooldownSwap = 3816,

	[Conflicts(DancerDanceStepCombo)]
	[Deprecated(DancerDanceStepCombo, DancerSmartDanceFeature)]
	[CustomComboInfo("Dance Step Feature", "Change custom actions into dance steps while dancing." +
		"\nYou can get Action IDs with Garland Tools by searching for the action and clicking the cog.", DNC.JobID)]
	DancerDanceComboCompatibility = 3806,

	#endregion
	// ====================================================================================
	#region DRAGOON (22xx)

	[CustomComboInfo("Second Wind / Bloodbath", "Replace Bloodbath and Second Wind with each other based on cooldown, or with only Second Wind when under level.\nIf both are available, the button will default to whichever you placed on your hotbar.", DRG.JobID)]
	DragoonBloodbathReplacer = 2218,

	//[CustomComboInfo("Coerthan Torment Combo", "Replace Coerthan Torment with its combo chain.", DRG.JobID)]
	//DragoonCoerthanTormentCombo = 2200,

	//[CustomComboInfo("Coerthan Torment Wyrmwind Feature", "Replace Coerthan Torment with Wyrmwind Thrust when you have two Firstminds' Focus.", DRG.JobID)]
	//DragoonCoerthanWyrmwindFeature = 2209,

	//[CustomComboInfo("Chaos Thrust Combo", "Replace Chaos Thrust with its combo chain.", DRG.JobID)]
	//DragoonChaosThrustCombo = 2201,

	//[ParentPreset(DragoonChaosThrustCombo)]
	//[CustomComboInfo("Chaos Thrust from Disembowl", "Start the Chaos Thrust combo chain with Disembowl instead of True Thrust.", DRG.JobID)]
	//DragoonChaosThrustLateOption = 2207,

	//[CustomComboInfo("Full Thrust Combo", "Replace Full Thrust with its combo chain.", DRG.JobID)]
	//DragoonFullThrustCombo = 2202,

	//[ParentPreset(DragoonFullThrustCombo)]
	//[CustomComboInfo("Full Thrust from Vorpal", "Start the Full Thrust combo chain with Vorpal Thrust instead of True Thrust.", DRG.JobID)]
	//DragoonFullThrustLateOption = 2208,

	//[ParentPreset(DragoonFullThrustCombo)]
	//[CustomComboInfo("Power Surge Buff Saver", "When the Power Surge buff is about to run out (or isn't up), execute the Chaos Thrust chain to use Disembowl.", DRG.JobID)]
	//DragoonFullThrustBuffSaver = 2212,

	//[ParentPreset(DragoonFullThrustCombo)]
	//[CustomComboInfo("Chaos Thrust DoT Saver", "When the Chaos Thrust DoT is about to run out on your current target (or isn't up), execute the Chaos Thrust chain.", DRG.JobID)]
	//DragoonFullThrustDotSaver = 2218,

	//[Experimental]
	//[CustomComboInfo("Total Thrust Combo", "", DRG.JobID)]
	//DragoonTotalThrustCombo = 2214,

	//[ParentPreset(DragoonTotalThrustCombo)]
	//[CustomComboInfo("Power Surge Buff Saver", "When the Power Surge buff is about to run out (or isn't up), execute the Chaos Thrust chain to use Disembowl.", DRG.JobID)]
	//DragoonTotalThrustBuffSaver = 2215,

	//[ParentPreset(DragoonTotalThrustCombo)]
	//[CustomComboInfo("Chaos Thrust DoT Saver", "When the Chaos Thrust DoT is about to run out on your current target (or isn't up), execute the Chaos Thrust chain.", DRG.JobID)]
	//DragoonTotalThrustDotSaver = 2216,

	//[ParentPreset(DragoonTotalThrustCombo)]
	//[CustomComboInfo("Full Thrust from Vorpal", "Start the Full Thrust combo chain with Vorpal Thrust instead of True Thrust.", DRG.JobID)]
	//DragoonTotalThrustVorpalSkipFirst = 2217,

	//[Conflicts(DragoonStardiverDragonfireDiveFeature)]
	//[CustomComboInfo("Stardiver to Nastrond", "Replace Stardiver with Nastrond when Nastrond is off-cooldown, and Geirskogul outside of Life of the Dragon.", DRG.JobID)]
	//DragoonStardiverNastrondFeature = 2210,

	//[Conflicts(DragoonStardiverNastrondFeature)]
	//[CustomComboInfo("Stardiver to Dragonfire Dive", "Replace Stardiver with Dragonfire Dive when the latter is off cooldown (and you have more than 7.5s of LotD left), or outside of Life of the Dragon.", DRG.JobID)]
	//DragoonStardiverDragonfireDiveFeature = 2211,

	//[Conflicts(DragoonStardiverDragonfireDiveFeature, DragoonStardiverNastrondFeature)]
	//[CustomComboInfo("Dive Dive Dive!", "Replace Spineshatter Dive, Dragonfire Dive, and Stardiver with whichever is available.", DRG.JobID)]
	//DragoonDiveFeature = 2205,

	//[CustomComboInfo("Mirage Jump", "Replace Jump and High Jump with Mirage Dive when Dive Ready.", DRG.JobID)]
	//DragoonMirageJumpFeature = 2213,

	#endregion
	// ====================================================================================
	#region DARK KNIGHT (32xx)

	[CustomComboInfo("Stun/Interrupt Feature", "Turn Low Blow and Interject into Interject when off CD and your target can be interrupted, Low Blow otherwise.", DRK.JobID)]
	DarkStunInterruptFeature = 3205,

	[CustomComboInfo("Souleater Combo", "Replace Souleater with its combo chain.", DRK.JobID)]
	DarkSouleaterCombo = 3200,

	[ParentPreset(DarkSouleaterCombo)]
	[CustomComboInfo("Souleater Overcap Feature", "Replace Souleater with Bloodspiller when the next combo action would cause the Blood Gauge to overcap.", WAR.JobID)]
	DarkSouleaterOvercapFeature = 3206,

	[CustomComboInfo("Stalwart Soul Combo", "Replace Stalwart Soul with its combo chain.", DRK.JobID)]
	DarkStalwartSoulCombo = 3201,

	[ParentPreset(DarkStalwartSoulCombo)]
	[CustomComboInfo("Stalwart Soul Overcap Feature", "Replace Stalwart Soul with Quietus when the next combo action would cause the Blood Gauge to overcap.", WAR.JobID)]
	DarkStalwartSoulOvercapFeature = 3207,

	[CustomComboInfo("Delirium Feature", "Replace Souleater and Stalwart Soul with Bloodspiller and Quietus when Delirium is active.", DRK.JobID)]
	DarkDeliriumFeature = 3202,

	[CustomComboInfo("Shadows Galore", "Replace Flood and Edge of Darkness with Shadowbringer when under Darkside with less than 6000 MP left.", DRK.JobID)]
	DarkShadowbringerFeature = 3204,

	[CustomComboInfo("Blood Weapon Feature", "Replace Carve and Spit, and Abyssal Drain with Blood Weapon when available.", DRK.JobID)]
	DarkBloodWeaponFeature = 3210,

	[CustomComboInfo("Living Shadow Feature", "Replace Quietus and Bloodspiller with Living Shadow when available.", DRK.JobID)]
	DarkLivingShadowFeature = 3211,

	[CustomComboInfo("Living Shadowbringer Feature", "Replace Living Shadow with Shadowbringer when charges are available and your Shadow is present.", DRK.JobID)]
	DarkLivingShadowbringerFeature = 3208,

	[CustomComboInfo("Missing Shadowbringer Feature", "Replace Living Shadow with Shadowbringer when charges are available and Living Shadow is on cooldown.", DRK.JobID)]
	DarkLivingShadowbringerHpFeature = 3209,

	#endregion
	// ====================================================================================
	#region GUNBREAKER (37xx)

	[CustomComboInfo("Stun/Interrupt Feature", "Turn Low Blow and Interject into Interject when off CD and your target can be interrupted, Low Blow otherwise.", GNB.JobID)]
	GunbreakerStunInterruptFeature = 3710,

	[CustomComboInfo("Solid Barrel Combo", "Replace Solid Barrel with its combo chain.", GNB.JobID)]
	GunbreakerSolidBarrelCombo = 3700,

	[ParentPreset(GunbreakerSolidBarrelCombo)]
	[CustomComboInfo("Burst Strike Feature", "Replace Solid Barrel with Burst Strike when charges are full.", GNB.JobID)]
	GunbreakerBurstStrikeFeature = 3711,

	[CustomComboInfo("Gnashing Fang Continuation", "Replace Gnashing Fang with Continuation moves when appropriate.", GNB.JobID)]
	GunbreakerGnashingFangCont = 3702,

	[CustomComboInfo("Burst Strike Continuation", "Replace Burst Strike with Continuation moves when appropriate.", GNB.JobID)]
	GunbreakerBurstStrikeCont = 3708,

	[CustomComboInfo("Demon Slaughter Combo", "Replace Demon Slaughter with its combo chain.", GNB.JobID)]
	GunbreakerDemonSlaughterCombo = 3703,

	[ParentPreset(GunbreakerDemonSlaughterCombo)]
	[CustomComboInfo("Fated Circle Feature", "In addition to the Demon Slaughter combo, add Fated Circle when charges are full.", GNB.JobID)]
	GunbreakerFatedCircleFeature = 3704,

	[CustomComboInfo("Empty Bloodfest Feature", "Replace Burst Strike and Fated Circle with Bloodfest if the powder gauge is empty.", GNB.JobID)]
	GunbreakerEmptyBloodfestFeature = 3705,

	[CustomComboInfo("No Mercy - Double Down", "Replace No Mercy with Double Down while No Mercy is active, 2 cartridges are available, and Double Down is off cooldown.\nThis takes priority over the No Mercy Bow Shock/Sonic Break Feature.", GNB.JobID)]
	GunbreakerNoMercyDoubleDownFeature = 3712,

	[CustomComboInfo("Always Double Down", "Replace No Mercy with Double Down while No Mercy is active.", GNB.JobID)]
	GunbreakerNoMercyAlwaysDoubleDownFeature = 3713,

	[CustomComboInfo("Double Down Feature", "Replace Burst Strike and Fated Circle with Double Down when available.", GNB.JobID)]
	GunbreakerDoubleDownFeature = 3709,

	[CustomComboInfo("Gnashing Strike Feature", "Replace Gnashing Fang with Burst Strike when No Mercy is active and Gnashing Fang and Double Down are on cooldown, or you are too low level to use them.", GNB.JobID)]
	GunbreakerGnashingStrikeFeature = 3714,

	[ParentPreset(GunbreakerSolidBarrelCombo)]
	[CustomComboInfo("Lighting Shot Ranged Uptime Feature", "Replace Solid Barrel with Lightning Shot when out of melee range and in combat.", GNB.JobID)]
	GunbreakerRangedUptime = 3715,

	[ParentPreset(GunbreakerSolidBarrelCombo)]
	[CustomComboInfo("No Mercy Feature", "Replace Solid Barrel with No Mercy when Gnashing Fang is ready.", GNB.JobID)]
	GunbreakerSolidNoMercy = 3716,

	[ParentPreset(GunbreakerSolidBarrelCombo)]
	[CustomComboInfo("Bloodfest Feature", "Replace Solid Barrel with Bloodfest when there is no ammo and you are under No Mercy.", GNB.JobID)]
	GunbreakerSolidBloodfest = 3717,

	[ParentPreset(GunbreakerSolidBarrelCombo)]
	[CustomComboInfo("Danger Zone/Blasting Zone Feature", "Replace Solid Barrel with Danger Zone/Blasting Zone after Gnashing Fang is used.", GNB.JobID)]
	GunbreakerSolidDangerZone = 3718,

	[ParentPreset(GunbreakerSolidBarrelCombo)]
	[CustomComboInfo("Gnashing Fang/Continuation Feature", "Replace Solid Barrel with Gnashing Fang and Continuation when Gnashing Fang is available and will hold for No Mercy when it is available.", GNB.JobID)]
	GunbreakerSolidGnashingFang = 3719,

	[ParentPreset(GunbreakerSolidBarrelCombo)]
	[CustomComboInfo("Bow Shock Feature", "Replace Solid Barrel with Bow Shock when you are under No Mercy.", GNB.JobID)]
	GunbreakerSolidBowShock = 3720,

	[ParentPreset(GunbreakerSolidBarrelCombo)]
	[CustomComboInfo("Sonic Break Feature", "Replace Solid Barrel with Sonic Break when you are under No Mercy.", GNB.JobID)]
	GunbreakerSolidSonicBreak = 3721,

	[ParentPreset(GunbreakerSolidBarrelCombo)]
	[CustomComboInfo("Double Down Feature", "Replace Solid Barrel with Double Down when you are under No Mercy and have the required ammo.", GNB.JobID)]
	GunbreakerSolidDoubleDown = 3722,

	[ParentPreset(GunbreakerGnashingFangCont)]
	[CustomComboInfo("No Mercy Feature", "Replace Gnashing Fang with No Mercy when both No Mercy and Gnashing Fang are ready to be used.", GNB.JobID)]
	GunbreakerGnashingFangNoMercy = 3724,

	[ParentPreset(GunbreakerGnashingFangCont)]
	[CustomComboInfo("Danger Zone/Blasting Zone Feature", "Replace Gnashing Fang with Danger Zone/Blasting Zone when available.", GNB.JobID)]
	GunbreakerGnashingFangDangerZone = 3725,

	[ParentPreset(GunbreakerGnashingFangCont)]
	[CustomComboInfo("Bow Shock Feature", "Replace Gnashing Fang with Bow Shock when available and when you are under No Mercy.", GNB.JobID)]
	GunbreakerGnashingFangBowShock = 3726,

	[ParentPreset(GunbreakerGnashingFangCont)]
	[CustomComboInfo("Double Down Feature", "Replace Gnashing Fang with Double Down when available and when you are under No Mercy and have the required ammo.", GNB.JobID)]
	GunbreakerGnashingFangDoubleDown = 3727,

	[ParentPreset(GunbreakerGnashingFangCont)]
	[CustomComboInfo("Sonic Break Feature", "Replace Gnashing Fang with Sonic Break when available and when you are under No Mercy.", GNB.JobID)]
	GunbreakerGnashingFangSonicBreak = 3728,

	[CustomComboInfo("Gnashing Bloodfest Feature", "Weave Bloodfest onto Gnashing Fang when out of ammo and under No Mercy.", GNB.JobID)]
	GunbreakerGnashingBloodfest = 3729,

	#endregion
	// ====================================================================================
	#region MACHINIST (31xx)

	[CustomComboInfo("(Heated) Shot Combo", "Replace either form of Clean Shot with its combo chain.", MCH.JobID)]
	MachinistMainCombo = 3100,

	[ParentPreset(MachinistMainCombo)]
	[CustomComboInfo("Reassembled override", "Replace Clean Shot combo with Excavator, Chain Saw, Drill, or Air Anchor when Reassembled.\nTries to avoid overcapping battery if possible.\nWill also become Hot Shot when you are under level for Clean Shot, which is a potency increase.", MCH.JobID)]
	MachinistMainComboReassembledOverride = 3113,

	[ParentPreset(MachinistMainCombo)]
	[CustomComboInfo("Heat Blast override", "Replace Clean Shot combo with Heat Blast while overheated.\nAlso respects the Heat Blast weaving option under the Gauss Riccochet feature.", MCH.JobID)]
	MachinistMainComboHeatBlast = 3108,

	[CustomComboInfo("Spread Shot Heat", "Replace Spread Shot / Scattergun with Auto Crossbow when overheated.", MCH.JobID)]
	MachinistSpreadShot = 3101,

	[CustomComboInfo("Hypercharged Hot Crossbow", "Replace Heat Blast and Auto Crossbow with Hypercharge when not overheated.", MCH.JobID)]
	MachinistSmartHeatup = 3102,

	[CustomComboInfo("Hypercharged Stabiliser", "Replace Hypercharge with Barrel Stabilizer if available, not overheated, and you have less than 50 heat.", MCH.JobID)]
	MachinistHyperchargeStabiliser = 3117,

	[CustomComboInfo("Hypercharged Wildfire", "Replace Hypercharge with Wildfire if available, overheated, and you have a target.", MCH.JobID)]
	MachinistHyperchargeWildfire = 3109,

	[CustomComboInfo("Overdriver", "Replace Rook Autoturret and Automaton Queen with their respective Overdrive while active.", MCH.JobID)]
	MachinistOverdrive = 3103,

	[CustomComboInfo("Gauss Ricochet", "Replace Gauss Round and Ricochet with one or the other depending on which has less recharge time left.", MCH.JobID)]
	MachinistGaussRoundRicochet = 3104,

	[ParentPreset(MachinistGaussRoundRicochet)]
	[CustomComboInfo("Overheated only", "Replace Gauss Round and Ricochet with one or the other only while overheated.", MCH.JobID)]
	MachinistGaussRoundRicochetLimiter = 3110,

	[ParentPreset(MachinistGaussRoundRicochet)]
	[CustomComboInfo("Heat Blast weaving", "Replace Heat Blast with Gauss Round or Riccochet while weaving.", MCH.JobID)]
	MachinistHeatBlastWeaveGaussRoundRicochet = 3115,

	[CustomComboInfo("Smart Hot Shot / Air Anchor / Drill", "Replace Hot Shot (Air Anchor) and Drill with whichever is available.\nTries to avoid overcapping battery, but only if that would NOT present a potency loss.", MCH.JobID)]
	MachinistDrillAirAnchor = 3105,

	[ParentPreset(MachinistDrillAirAnchor)]
	[CustomComboInfo("With Chain Saw", "Also allow the above to become Chain Saw.\nChain Saw itself will not change.", MCH.JobID)]
	MachinistDrillAirAnchorPlus = 3106,

	[CustomComboInfo("Tactical Dismantle", "Change Tactician and Dismantle into each other when one is on cooldown.\nAlso prevents wasting Tactician when under BRD's Troubadour or DNC's Shield Samba.", MCH.JobID)]
	MachinistTacticianDismantle = 3112,

	#endregion
	// ====================================================================================
	#region MONK (20xx)

	[CustomComboInfo("Second Wind / Bloodbath", "Replace Bloodbath and Second Wind with each other based on cooldown, or with only Second Wind when under level.\nIf both are available, the button will default to whichever you placed on your hotbar.", MNK.JobID)]
	MonkBloodbathReplacer = 2018,

	//[CustomComboInfo("Monk AoE Combo", "Replaces the selected actions with the AoE combo chain.", MNK.JobID)]
	//MonkAoECombo = 2000,

	//[ParentPreset(MonkAoECombo)]
	//[CustomComboInfo("On Destroyer", "Replaces (Arm/Shadow) of the Destroyer with the AoE combo chain.", MNK.JobID)]
	//MonkAoECombo_Destroyers = 2099,

	//[ParentPreset(MonkAoECombo)]
	//[CustomComboInfo("On Masterful Blitz", "Replaces Masterful Blitz with the AoE combo chain.", MNK.JobID)]
	//MonkAoECombo_MasterBlitz = 2098,

	//[ParentPreset(MonkAoECombo)]
	//[CustomComboInfo("On Rockbreaker", "Replaces Rockbreaker with the AoE combo chain.", MNK.JobID)]
	//MonkAoECombo_Rockbreaker = 2097,

	//[CustomComboInfo("Monk ST Combo", "Replace Bootshine with all single-target rotation actions", MNK.JobID)]
	//MonkSTCombo = 2017,

	//[CustomComboInfo("Dragon Kick to Bootshine Feature", "Replaces Dragon Kick with Bootshine if Leaden Fist is up.", MNK.JobID)]
	//MonkBootshineFeature = 2001,

	//[CustomComboInfo("Dragon Kick to Masterful Blitz Feature", "Replaces Dragon Kick with Masterful Blitz if you have three Beast Chakra.", MNK.JobID)]
	//MonkDragonKickBalanceFeature = 2012,

	//[CustomComboInfo("Dragon Meditation Feature", "Replace Dragon Kick with Meditation when out of combat and the Fifth Chakra is not open.", MNK.JobID)]
	//MonkDragonKickMeditationFeature = 2015,

	//[CustomComboInfo("Steel Peak / Forbidden Chakra Feature", "Replace Dragon Kick with Meditation / Steel Peak / The Forbidden Chakra when in of combat and the Fifth Chakra is open.", MNK.JobID)]
	//MonkDragonKickSteelPeakFeature = 2016,

	//[CustomComboInfo("Twin Snakes to True Strike Feature", "Replaces Twin Snakes with True Strike if Disciplined Fist is up.\nAlso applies to the ST combo feature.", MNK.JobID)]
	//MonkTwinSnakesFeature = 2010,

	//[CustomComboInfo("Demolish to Snap Punch Feature", "Replaces Demolish with Snap Punch if target is under Demolish.\nAlso applies to the ST combo feature.", MNK.JobID)]
	//MonkDemolishFeature = 2011,

	//[CustomComboInfo("Howling Fist / Meditation Feature", "Replaces Howling Fist with Meditation when the Fifth Chakra is not open.", MNK.JobID)]
	//MonkHowlingFistMeditationFeature = 2002,

	//[CustomComboInfo("Perfect Balance Feature", "Replace Perfect Balance with Masterful Blitz when you have 3 Beast Chakra, or when under Perfect Balance already.", MNK.JobID)]
	//MonkPerfectBalanceFeature = 2004,

	//[CustomComboInfo("Riddle of Brotherly Fire", "Replace Riddle of Fire with Brotherhood if the former is on CD and the latter isn't.", MNK.JobID)]
	//MonkBrotherlyFire = 2013,

	//[CustomComboInfo("Riddle of Fire and Wind", "Replace Riddle of Fire with Riddle of Wind if the former is on CD and the latter isn't.", MNK.JobID)]
	//MonkFireWind = 2014,

	#endregion
	// ====================================================================================
	#region NINJA (30xx)

	[CustomComboInfo("Second Wind / Bloodbath", "Replace Bloodbath and Second Wind with each other based on cooldown, or with only Second Wind when under level.\nIf both are available, the button will default to whichever you placed on your hotbar.", NIN.JobID)]
	NinjaBloodbathReplacer = 3037,

	[CustomComboInfo("Armor Crush Combo", "Replace Armor Crush with its combo chain.", NIN.JobID)]
	NinjaArmorCrushCombo = 3000,

	[ParentPreset(NinjaArmorCrushCombo)]
	[CustomComboInfo("Smart Weave: Bunshin", "Weave into Bunshin when available.", NIN.JobID)]
	NinjaArmorCrushBunshinFeature = 3030,

	[ParentPreset(NinjaArmorCrushCombo)]
	[CustomComboInfo("Smart Weave: Bhavacakra", "Weave into Bhavacakra when available and Bunshin is on cooldown.\nAlso applies if Smart Weave: Bunshin is not enabled.", NIN.JobID)]
	NinjaArmorCrushBhavacakraFeature = 3031,

	[ParentPreset(NinjaArmorCrushCombo)]
	[CustomComboInfo("Smart Weave: Assassinate/DWaD", "Weave into Assassinate / Dream Within a Dream when available.", NIN.JobID)]
	NinjaArmorCrushAssasinateFeature = 3032,

	[ParentPreset(NinjaArmorCrushCombo)]
	[CustomComboInfo("Phantom Kamaitachi Feature", "Replaces the combo with Phantom Kamaitachi when you have no stacks of Bunshin.", NIN.JobID)]
	NinjaArmorCrushKamaitachiFeature = 3028,

	[ParentPreset(NinjaArmorCrushCombo)]
	[Conflicts(NinjaArmorCrushForkedRaijuFeature, NinjaArmorCrushFleetingRaijuFeature)]
	[CustomComboInfo("Smart Raiju Feature", "Replaces the Armor Crush combo with Forked/Fleeting Raiju when available, depending on how far your target is.", NIN.JobID)]
	NinjaArmorCrushSmartRaijuFeature = 3021,

	[ParentPreset(NinjaArmorCrushCombo)]
	[Conflicts(NinjaArmorCrushForkedRaijuFeature)]
	[CustomComboInfo("Fleeting Raiju Feature", "Replaces the Armor Crush combo with Fleeting Raiju when available.", NIN.JobID)]
	NinjaArmorCrushFleetingRaijuFeature = 3010,

	[ParentPreset(NinjaArmorCrushCombo)]
	[Conflicts(NinjaArmorCrushFleetingRaijuFeature)]
	[CustomComboInfo("Forked Raiju Feature", "Replaces the Armor Crush combo with Forked Raiju when available.", NIN.JobID)]
	NinjaArmorCrushForkedRaijuFeature = 3017,

	[ParentPreset(NinjaArmorCrushCombo)]
	[CustomComboInfo("Distant Daggers Feature", "Replaces the Armor Crush combo with Throwing Dagger when the current target is out of melee range.\nUses Phantom Kamaitachi instead when available.", NIN.JobID)]
	NinjaArmorCrushThrowingDaggerFeature = 3018,

	[ParentPreset(NinjaArmorCrushCombo)]
	[CustomComboInfo("Fallback to Aeolian Edge", "Replaces Armor Crush with Aeolian Edge when underlevel.", NIN.JobID)]
	NinjaArmorCrushFallbackFeature = 3020,

	[CustomComboInfo("Aeolian Edge Combo", "Replace Aeolian Edge with its combo chain.", NIN.JobID)]
	NinjaAeolianEdgeCombo = 3001,

	[ParentPreset(NinjaAeolianEdgeCombo)]
	[CustomComboInfo("Smart Weave: Bunshin", "Weave into Bunshin when available.", NIN.JobID)]
	NinjaAeolianEdgeBunshinFeature = 3033,

	[ParentPreset(NinjaAeolianEdgeCombo)]
	[CustomComboInfo("Smart Weave: Bhavacakra", "Weave into Bhavacakra when available and Bunshin is on cooldown.\nAlso applies if Smart Weave: Bunshin is not enabled.", NIN.JobID)]
	NinjaAeolianEdgeBhavacakraFeature = 3034,

	[ParentPreset(NinjaAeolianEdgeCombo)]
	[CustomComboInfo("Smart Weave: Assassinate/DWaD", "Weave into Assassinate / Dream Within a Dream when available.", NIN.JobID)]
	NinjaAeolianEdgeAssasinateFeature = 3035,

	[ParentPreset(NinjaAeolianEdgeCombo)]
	[CustomComboInfo("Phantom Kamaitachi Feature", "Replaces the combo with Phantom Kamaitachi when you have no stacks of Bunshin.", NIN.JobID)]
	NinjaAeolianEdgeKamaitachiFeature = 3029,

	[ParentPreset(NinjaAeolianEdgeCombo)]
	[Conflicts(NinjaAeolianEdgeFleetingRaijuFeature, NinjaAeolianEdgeForkedRaijuFeature)]
	[CustomComboInfo("Smart Raiju Feature", "Replaces the Aeolian Edge combo with Forked/Fleeting Raiju when available, depending on how far your target is.", NIN.JobID)]
	NinjaAeolianEdgeSmartRaijuFeature = 3022,

	[ParentPreset(NinjaAeolianEdgeCombo)]
	[Conflicts(NinjaAeolianEdgeSmartRaijuFeature, NinjaAeolianEdgeForkedRaijuFeature)]
	[CustomComboInfo("Fleeting Raiju Feature", "Replaces the Aeolian Edge combo with Fleeting Raiju when available.", NIN.JobID)]
	NinjaAeolianEdgeFleetingRaijuFeature = 3011,

	[ParentPreset(NinjaAeolianEdgeCombo)]
	[Conflicts(NinjaAeolianEdgeSmartRaijuFeature, NinjaAeolianEdgeFleetingRaijuFeature)]
	[CustomComboInfo("Forked Raiju Feature", "Replaces the Aeolian Edge combo with Forked Raiju when available.", NIN.JobID)]
	NinjaAeolianEdgeForkedRaijuFeature = 3016,

	[ParentPreset(NinjaAeolianEdgeCombo)]
	[CustomComboInfo("Distant Daggers Feature", "Replaces the Aeolian Edge combo with Throwing Dagger when the current target is out of melee range.\nUses Phantom Kamaitachi instead when available.", NIN.JobID)]
	NinjaAeolianEdgeThrowingDaggerFeature = 3019,

	[CustomComboInfo("Hakke Mujinsatsu Combo", "Replace Hakke Mujinsatsu with its combo chain.", NIN.JobID)]
	NinjaHakkeMujinsatsuCombo = 3002,

	[CustomComboInfo("Smart Hide", "Replaces Hide with Trick Attack while under the effect of Suiton or Hidden AND with a target, or else Mug if in combat.", NIN.JobID)]
	NinjaSmartHideFeature = 3004,

	[CustomComboInfo("GCDs to Ninjutsu Feature", "Every GCD combo becomes Ninjutsu while Mudras are being used.", NIN.JobID)]
	NinjaGCDNinjutsuFeature = 3005,

	[CustomComboInfo("Kassatsu to Trick", "Replaces Kassatsu with Trick Attack while Suiton or Hidden is up.\nCooldown tracking plugin recommended.", NIN.JobID)]
	NinjaKassatsuTrickFeature = 3006,

	[CustomComboInfo("Ten Chi Jin to Meisui", "Replaces Ten Chi Jin (the move) with Meisui while Suiton is up.\nCooldown tracking plugin recommended.", NIN.JobID)]
	NinjaTCJMeisuiFeature = 3007,

	[CustomComboInfo("Ten Chi Jin to Tenri Jindo", "Replaces Ten Chi Jin (the move) with Tenri Jindo when available.", NIN.JobID)]
	NinjaTCJTenriJindo = 3036,

	[CustomComboInfo("Kassatsu Chi/Jin Feature", "Replaces Chi with Jin while Kassatsu is up if you have Enhanced Kassatsu.", NIN.JobID)]
	NinjaKassatsuChiJinFeature = 3008,

	[Conflicts(NinjaHuraijinFleetingRaijuFeature, NinjaHuraijinForkedRaijuFeature)]
	[CustomComboInfo("Smart Huraiju Feature", "Replaces Huraijin with Forked/Fleeting Raiju when available, depending on how far your target is.", NIN.JobID)]
	NinjaHuraijinSmartRaijuFeature = 3025,

	[Conflicts(NinjaHuraijinSmartRaijuFeature, NinjaHuraijinFleetingRaijuFeature)]
	[CustomComboInfo("Forked Huraijin Feature", "Replaces Huraijin with Forked Raiju when available.", NIN.JobID)]
	NinjaHuraijinForkedRaijuFeature = 3012,

	[Conflicts(NinjaHuraijinSmartRaijuFeature, NinjaHuraijinForkedRaijuFeature)]
	[CustomComboInfo("Fleeting Huraijin Feature", "Replaces Huraijin with Fleeting Raiju when available.", NIN.JobID)]
	NinjaHuraijinFleetingRaijuFeature = 3015,

	[CustomComboInfo("Huraijin / Crush Feature", "Replaces Huraijin with Armor Crush after Gust Slash.", NIN.JobID)]
	NinjaHuraijinCrushFeature = 3013,

	[Deprecated("This option will OVERRIDE the listed alternatives, preventing fine-grained control. If you want the existing functionality, enable all six recommended alternatives.",
		NinjaArmorCrushAssasinateFeature, NinjaAeolianEdgeAssasinateFeature,
		NinjaArmorCrushBunshinFeature, NinjaAeolianEdgeBunshinFeature,
		NinjaArmorCrushBhavacakraFeature, NinjaAeolianEdgeBhavacakraFeature
	)]
	[CustomComboInfo("Single Target Smart Weave", "Replaces both Aeolian Edge and Armor Crush combos with the following when weaving and available:\n- Assassinate or DWAD\n- Bhavacakra\n- Bunshin", NIN.JobID)]
	NinjaSingleTargetSmartWeaveFeature = 3026,

	[CustomComboInfo("AoE Smart Weave", "Replaces Death Blossom / Hakke Mujinsatsu with Hellfrog Medium when weaving and available.", NIN.JobID)]
	NinjaAOESmartWeaveFeature = 3027,

	#endregion
	// ====================================================================================
	#region PALADIN (19xx)

	[CustomComboInfo("Stun/Interrupt Feature", "Turn Low Blow and Interject into Interject when off CD and your target can be interrupted, Low Blow otherwise.", PLD.JobID)]
	PaladinStunInterruptFeature = 1907,

	[CustomComboInfo("Intervene Level Sync", "Replace Intervene with Shield Lob when under level.", PLD.JobID)]
	PaladinInterveneSyncFeature = 1906,

	[CustomComboInfo("Prominence Combo", "Replace Prominence with its combo chain.", PLD.JobID)]
	PaladinProminenceCombo = 1903,

	[ParentPreset(PaladinProminenceCombo)]
	[CustomComboInfo("Weave: Fight or Flight", "Weave in Fight or Flight on Prominence/TE when doing so will not clip your GCD window.", PLD.JobID)]
	PaladinProminenceWeaveFightOrFlight = 1921,

	[ParentPreset(PaladinProminenceCombo)]
	[CustomComboInfo("Weave: Circle of Scorn", "Weave in Circle of Scorn on Prominence/TE when doing so will not clip your GCD window.", PLD.JobID)]
	PaladinProminenceWeaveCircleOfScorn = 1920,

	[ParentPreset(PaladinProminenceCombo)]
	[CustomComboInfo("Prominent Confiteor Feature", "Replace the Prominence combo with Confiteor (and chains) when Requiescat is up.", PLD.JobID)]
	PaladinProminenceConfiteor = 1916,

	[ParentPreset(PaladinProminenceCombo)]
	[CustomComboInfo("Prominent Circle", "Change Prominence/TE into Holy Circle when under the effect of Divine Might.", PLD.JobID)]
	PaladinProminenceHolyCircle = 1924,

	[CustomComboInfo("Royal Authority Combo", "Replace Royal Authority/Rage of Halone with its combo chain.", PLD.JobID)]
	PaladinRoyalAuthorityCombo = 1901,

	[ParentPreset(PaladinRoyalAuthorityCombo)]
	[CustomComboInfo("Weave: Fight or Flight", "Weave in Fight or Flight on RA/RoH when doing so will not clip your GCD window.", PLD.JobID)]
	PaladinRoyalWeaveFightOrFlight = 1918,

	[ParentPreset(PaladinRoyalAuthorityCombo)]
	[CustomComboInfo("Weave: Spirits Within", "Weave in Spirits Within / Expiacion on RA/RoH when doing so will not clip your GCD window.", PLD.JobID)]
	PaladinRoyalWeaveSpiritsWithin = 1919,

	[ParentPreset(PaladinRoyalAuthorityCombo)]
	[CustomComboInfo("Royal Confiteor Feature", "Replace the RA/RoH combo with Confiteor (and chains) when Requiescat is up.", PLD.JobID)]
	PaladinRoyalConfiteor = 1915,

	[ParentPreset(PaladinRoyalAuthorityCombo)]
	[CustomComboInfo("Goring Authority", "Change RA/RoH into Goring Blade when available.", PLD.JobID)]
	PaladinRoyalAuthorityGoringBlade = 1922,

	[ParentPreset(PaladinRoyalAuthorityCombo)]
	[CustomComboInfo("Royal Intervention Feature", "Replace the RA/RoH combo with Intervene when NOT in the combo chain, and the current target is out of melee range.\nRespects Intervene Level Sync if enabled.", PLD.JobID)]
	PaladinRoyalAuthorityRangeSwapFeature = 1912,

	[ParentPreset(PaladinRoyalAuthorityCombo)]
	[CustomComboInfo("Holy Authority", "Change RA/RoH into Holy Spirit when under the effect of Divine Might.", PLD.JobID)]
	PaladinRoyalAuthorityHolySpirit = 1923,

	[ParentPreset(PaladinRoyalAuthorityCombo)]
	[CustomComboInfo("Atonement Feature", "Replace the RA/RoH combo with Atonement/Supplication/Sepulchre when NOT in the combo chain, and under the relevant effects.", PLD.JobID)]
	PaladinAtonementFeature = 1902,

	[CustomComboInfo("Requiescat Confiteor", "Replace Requiescat/Imperator with Confiteor (and chains) while under the effect of Requiescat.", PLD.JobID)]
	PaladinRequiescatConfiteor = 1904,

	[CustomComboInfo("Holy Confiteor", "Replace Holy Spirit/Circle with Confiteor (and chains) when Requiescat is up.", PLD.JobID)]
	PaladinHolyConfiteor = 1908,

	[CustomComboInfo("Sheltron Sentinel", "Replace Sheltron with Sentinel/Guardian when available.", PLD.JobID)]
	PaladinSheltronSentinel = 1917,

	#endregion
	// ====================================================================================
	#region PICTOMANCER (42xx)

	[CustomComboInfo("Single Target Combo Replacer", "Changes Cyan/Yellow/Magenta Single-Target combo into Single-Target Red/Green/Blue combo when not under the effect of Subtractive Palette.", PCT.JobID)]
	PictomancerSTComboFeature = 4201,

	[CustomComboInfo("AoE Target Combo Replacer", "Changes Cyan/Yellow/Magenta AoE combo into AoE Red/Green/Blue combo when not under the effect of Subtractive Palette.", PCT.JobID)]
	PictomancerAOEComboFeature = 4202,

	[CustomComboInfo("Weapon Motif Combo", "Change Weapon Motif into Striking Muse if not drawn already.", PCT.JobID)]
	PictomancerWeaponMotifCombo = 4203,

	[ParentPreset(PictomancerWeaponMotifCombo)]
	[CustomComboInfo("Hammer Combo", "When under the effects of Hammer Ready, also replace Weapon Motif/Muse combo with the hammer combo.", PCT.JobID)]
	PictomancerHammerCombo = 4204,

	[CustomComboInfo("Scenic Muse Combo", "Changes Scenic Muse into Scenic Motif when not drawn already.", PCT.JobID)]
	PictomancerScenicCombo = 4205,

	[ParentPreset(PictomancerScenicCombo)]
	[CustomComboInfo("Star Prism Combo", "When Star Prism is ready, will replace Scenic Muse with Star Prism.", PCT.JobID)]
	PictomancerStarPrismCombo = 4206,

	[CustomComboInfo("Holy Comet Combo", "When using Subtractive Palette at level 90+, turns Holy In White into Comet In Black.", PCT.JobID)]
	PictomancerHolyCometCombo = 4207,

	[CustomComboInfo("Creature Motif/Muse Combo", "Changes Living Muse into Creature Motif when nothing is currently drawn.", PCT.JobID)]
	PictomancerLivingMuseCombo = 4208,


	#endregion
	// ====================================================================================
	#region RED MAGE (35xx)

	[CustomComboInfo("Swiftcast Verraise", "Verraise turns into Swiftcast when available and reasonable.", RDM.JobID)]
	RedMageSwiftcastRaiserFeature = 3500,

	[CustomComboInfo("Smartcast Single Target", "Dynamically replaces Verstone/Verfire with the appropriate spell based on your job gauge.\nVeraero and Verthunder are replaced with one or the other accordingly, for openers.", RDM.JobID)]
	RedMageSmartcastSingleTarget = 3509,

	[ParentPreset(RedMageSmartcastSingleTarget)]
	[CustomComboInfo("Lucid Weave", "Weave into Lucid Dreaming when under a set MP threshold.", RDM.JobID)]
	RedMageSmartcastSingleTargetWeaveLucid = 3543,

	[ParentPreset(RedMageSmartcastSingleTarget)]
	[CustomComboInfo("Fleche Weave", "Turns the single-target smartcast combo into Fleche when you can weave without clipping.\nAffected by the Contre Sixte / Fleche feature.", RDM.JobID)]
	RedMageSmartcastSingleTargetWeaveAttack = 3518,

	[ParentPreset(RedMageSmartcastSingleTargetWeaveAttack)]
	[CustomComboInfo("Engagement", "If you're in melee range and Fleche (+ Contra Sixte if applicable) can't be used yet, fall back to Engagement.", RDM.JobID)]
	RedMageSmartcastSingleTargetWeaveMelee = 3523,

	[ParentPreset(RedMageSmartcastSingleTargetWeaveMelee)]
	[CustomComboInfo("Engagement Priority", "Try to use Engagement first when in melee range.\nWhile it IS a potency loss, Engagement can ONLY be used in melee range, which keeps the long-distance abilities free for when you're too far away.", RDM.JobID)]
	RedMageSmartcastSingleTargetWeaveMeleeFirst = 3525,

	[ParentPreset(RedMageSmartcastSingleTargetWeaveMelee)]
	[CustomComboInfo("Leave one charge", "Always leave one charge of Engagement unused during weaves, to allow using Displacement to backstep out of AoE markers.", RDM.JobID)]
	RedMageSmartcastSingleTargetWeaveMeleeHoldOne = 3531,

	[ParentPreset(RedMageSmartcastSingleTarget)]
	[CustomComboInfo("Walking Fleche", "Turns the single-target smartcast combo into Fleche when you're moving and can't instacast.\nAffected by the Contre Sixte / Fleche feature.", RDM.JobID)]
	RedMageSmartcastSingleTargetMovement = 3519,

	[ParentPreset(RedMageSmartcastSingleTargetMovement)]
	[CustomComboInfo("Engagement", "If you're in melee range and Fleche (+ Contra Sixte if applicable) can't be used yet, fall back to Engagement.", RDM.JobID)]
	RedMageSmartcastSingleTargetMovementMelee = 3524,

	[ParentPreset(RedMageSmartcastSingleTargetMovementMelee)]
	[CustomComboInfo("Engagement Priority", "Try to use Engagement first when in melee range.\nWhile it IS a potency loss, Engagement can ONLY be used in melee range, which keeps the long-distance abilities free for when you're too far away.", RDM.JobID)]
	RedMageSmartcastSingleTargetMovementMeleeFirst = 3526,

	[ParentPreset(RedMageSmartcastSingleTargetMovementMelee)]
	[CustomComboInfo("Leave one charge", "Always leave one charge of Engagement unused during movement, to allow using Displacement to backstep out of AoE markers.", RDM.JobID)]
	RedMageSmartcastSingleTargetMovementMeleeHoldOne = 3532,

	[ParentPreset(RedMageSmartcastSingleTarget)]
	[CustomComboInfo("Melee Combo Followthrough", "Turns the single-target smartcast combo into the rest of the melee combo once you start it, as long as you're in melee range.", RDM.JobID)]
	RedMageSmartcastSingleTargetMeleeCombo = 3521,

	[ParentPreset(RedMageSmartcastSingleTargetMeleeCombo)]
	[CustomComboInfo("Auto Start", "Turns the single-target smartcast combo into your melee combo when you're ready to execute it and your mana levels AREN'T equal.", RDM.JobID)]
	RedMageSmartcastSingleTargetMeleeComboStarter = 3522,

	[ParentPreset(RedMageSmartcastSingleTargetMeleeComboStarter)]
	[CustomComboInfo("Gap Close", "If you're ready to start your melee combo, but you aren't in range, become Corps-a-corps to gap close.", RDM.JobID)]
	RedMageSmartcastSingleTargetMeleeComboStarterCloser = 3541,

	[ParentPreset(RedMageSmartcastSingleTarget)]
	[CustomComboInfo("Acceleration", "Turns the single-target smartcast combo into Acceleration instead of Jolt, when possible.", RDM.JobID)]
	RedMageSmartcastSingleTargetAcceleration = 3527,

	[ParentPreset(RedMageSmartcastSingleTargetAcceleration)]
	[CustomComboInfo("With Swiftcast", "Acceleration falls back to Swiftcast if it's available and Acceleration is out of charges.", RDM.JobID)]
	RedMageSmartcastSingleTargetAccelerationSwiftcast = 3528,

	[ParentPreset(RedMageSmartcastSingleTargetAccelerationSwiftcast)]
	[CustomComboInfo("Swiftcast Priority", "Swiftcast is used before Acceleration if it's up.", RDM.JobID)]
	RedMageSmartcastSingleTargetAccelerationSwiftcastFirst = 3529,

	[ParentPreset(RedMageSmartcastSingleTargetAcceleration)]
	[CustomComboInfo("Combat Only", "Only become Acceleration (+ Swiftcast if applicable) when in combat.\nActs as an override - if you're not in combat, the combo will never become Acceleration/Swiftcast.", RDM.JobID)]
	RedMageSmartcastSingleTargetAccelerationCombat = 3535,

	[ParentPreset(RedMageSmartcastSingleTargetAcceleration)]
	[CustomComboInfo("When Weaving", "Change into Acceleration (+ Swiftcast if applicable) when you're weaving.\nThis will be prioritised over weaving Fleche/CS/Engagement, if applicable.", RDM.JobID)]
	RedMageSmartcastSingleTargetAccelerationWeave = 3536,

	[ParentPreset(RedMageSmartcastSingleTargetAcceleration)]
	[CustomComboInfo("When Moving", "Change into Acceleration (+ Swiftcast if applicable) when moving.\nThis will be prioritised over weaving Fleche/CS/Engagement, if applicable.", RDM.JobID)]
	RedMageSmartcastSingleTargetAccelerationMoving = 3537,

	[ParentPreset(RedMageSmartcastSingleTargetAcceleration)]
	[CustomComboInfo("Don't Override", "Don't override Jolt when you can hardcast it.\nThis will prevent GCD drift at the cost of DPS loss.", RDM.JobID)]
	RedMageSmartcastSingleTargetAccelerationNoOverride = 3538,

	[ParentPreset(RedMageSmartcastSingleTarget)]
	[CustomComboInfo("+ Grand Impact", "Become Grand Impact before becoming the verprocs, to prevent wasting it.", RDM.JobID)]
	RedMageSmartcastSingleTargetGrandImpact = 3548,

	[Conflicts(RedMageAoECombo)]
	[CustomComboInfo("Smartcast AoE", "Dynamically replaces Veraero/Verthunder 2 with the appropriate spell based on your job gauge.\nIncludes Impact/Scatter when fastcasting.\nIncludes Grand Impact when available.", RDM.JobID)]
	RedMageSmartcastAoE = 3508,

	[ParentPreset(RedMageSmartcastAoE)]
	[CustomComboInfo("Lucid Weave", "Weave into Lucid Dreaming when under a set MP threshold.", RDM.JobID)]
	RedMageSmartcastAoEWeaveLucid = 3542,

	[ParentPreset(RedMageSmartcastAoE)]
	[CustomComboInfo("Contre Sixte Weave", "Turns the AoE smartcast combo into Contre Sixte when you can weave without clipping.\nAffected by the Contre Sixte / Fleche feature.", RDM.JobID)]
	RedMageSmartcastAoEWeaveAttack = 3517,

	[ParentPreset(RedMageSmartcastAoE)]
	[CustomComboInfo("Walking Contre Sixte", "Turns the AoE smartcast combo into Contre Sixte when you're moving and can't instacast.\nAffected by the Contre Sixte / Fleche feature.", RDM.JobID)]
	RedMageSmartcastAoEMovement = 3520,

	[CustomComboInfo("Melee Combo", "Replaces Riposte with its combo chain, following enchantment rules.", RDM.JobID)]
	RedMageMeleeCombo = 3502,

	[ParentPreset(RedMageMeleeCombo)]
	[CustomComboInfo("Melee Combo+", "Replaces Riposte (and Moulinet) with Verflare/Verholy (and then Scorch and Resolution) after 3 mana stacks, whichever is more appropriate.", RDM.JobID)]
	RedMageMeleeComboPlus = 3503,

	[ParentPreset(RedMageMeleeCombo)]
	[CustomComboInfo("Gap Closer", "Replaces Riposte with Corps-a-corps when out of melee range.", RDM.JobID)]
	RedMageMeleeComboCloser = 3514,

	[Conflicts(RedMageSmartcastAoE)]
	[CustomComboInfo("Red Mage AoE Combo", "Replaces Veraero/Verthunder 2 with Impact when under a cast speeder.", RDM.JobID)]
	RedMageAoECombo = 3501,

	[CustomComboInfo("Contre Sixte / Fleche Feature", "Turns Contre Sixte and Fleche into whichever is available.", RDM.JobID)]
	RedMageContreFleche = 3510,

	[ParentPreset(RedMageContreFleche)]
	[CustomComboInfo("+ Prefulgence", "Includes Prefulgence when available.\nTakes priority over everything else.", RDM.JobID)]
	RedMageContreFlechePrefulgence = 3544,

	[ParentPreset(RedMageContreFleche)]
	[CustomComboInfo("+ Vice of Thorns", "Includes Vice of Thorns when available.\nTakes priority over everything else except Prefulgence, unless Prefulgence has more than 3 seconds and VoT does not.", RDM.JobID)]
	RedMageContreFlecheThorns = 3545,

	[CustomComboInfo("Acceleration into Swiftcast", "Replace Acceleration with Swiftcast when on cooldown or synced.", RDM.JobID)]
	RedMageAccelerationSwiftcast = 3511,

	[ParentPreset(RedMageAccelerationSwiftcast)]
	[CustomComboInfo("Acceleration with Swiftcast first", "Replace Acceleration with Swiftcast when neither are on cooldown.", RDM.JobID)]
	RedMageAccelerationSwiftcastFirst = 3512,

	[CustomComboInfo("Manafication into melee", "Replace Manafication with your melee combo when you have Magicked Swordplay up.", RDM.JobID)]
	RedMageManaficationIntoMelee = 3539,

	[ParentPreset(RedMageManaficationIntoMelee)]
	[CustomComboInfo("+from gauge", "Also change when your gauge is ready to start the combo.", RDM.JobID)]
	RedMageManaficationIntoMeleeGauge = 3546,

	[ParentPreset(RedMageManaficationIntoMelee)]
	[CustomComboInfo("Include finishers", "Also change into your finisher spells when they're ready to use.", RDM.JobID)]
	RedMageManaficationIntoMeleeFinisherFollowup = 3547,

	[CustomComboInfo("Gap Reverser: Backstep", "Replaces Corps-a-corps with Displacement when your taget is in melee range.", RDM.JobID)]
	RedMageMeleeGapReverserBackstep = 3515,

	[CustomComboInfo("Gap Reverser: Lunge", "Replaces Displacement with Corps-a-corps when your taget is NOT in melee range.", RDM.JobID)]
	RedMageMeleeGapReverserLunge = 3516,

	#endregion
	// ====================================================================================
	#region REAPER (39xx)

	[CustomComboInfo("Second Wind / Bloodbath", "Replace Bloodbath and Second Wind with each other based on cooldown, or with only Second Wind when under level.\nIf both are available, the button will default to whichever you placed on your hotbar.", RPR.JobID)]
	ReaperBloodbathReplacer = 3950,

	[CustomComboInfo("Slice Combo", "Replace Infernal Slice with its combo chain.", RPR.JobID)]
	ReaperSliceCombo = 3901,

	[CustomComboInfo("Slice Weave Assist", "Replace Infernal Slice with Blood Stalk (or variants) when available and weaving wouldn't clip your GCD.", RPR.JobID)]
	ReaperSliceWeaveAssist = 3942,

	[ParentPreset(ReaperSliceWeaveAssist)]
	[CustomComboInfo("Ignore Reaving", "Allow weaving even if you're already reaving.", RPR.JobID)]
	ReaperSliceWeaveAssistDoubleReaving = 3948,

	[CustomComboInfo("Slice of Death Feature", "Replace Infernal Slice with Shadow of Death when the target's Death's Design debuff is low.", RPR.JobID)]
	ReaperSliceShadowFeature = 3940,

	[CustomComboInfo("Soulful Slice", "Replace Infernal Slice with Soul Slice when available and Soul Gauge is no more than 50.", RPR.JobID)]
	ReaperSoulOnSliceFeature = 3946,

	[Conflicts(ReaperSliceGallowsFeature)]
	[CustomComboInfo("Slice Gibbet Feature", "Replace Infernal Slice with Gibbet while Reaving, Enshrouded, or an Executioner.", RPR.JobID)]
	ReaperSliceGibbetFeature = 3903,

	[Conflicts(ReaperSliceGibbetFeature)]
	[CustomComboInfo("Slice Gallows Feature", "Replace Infernal Slice with Gallows while Reaving, Enshrouded, or an Executioner.", RPR.JobID)]
	ReaperSliceGallowsFeature = 3904,

	[CustomComboInfo("Slice Enhanced Soul Reaver Feature", "Replace Infernal Slice with whichever of Gibbet or Gallows is currently enhanced while Reaving, Enshrouded, or an Executioner.\nNo effect if neither is enhanced - combine this with one of the above two for a default!", RPR.JobID)]
	ReaperSliceSmart = 3913,

	[CustomComboInfo("Slice Lemure's Feature", "Replace Infernal Slice with Lemure's Slice when two or more stacks of Void Shroud are active.", RPR.JobID)]
	ReaperSliceLemuresFeature = 3919,

	[CustomComboInfo("Slice Communio Feature", "Replace Infernal Slice with Communio when one stack of Shroud is left.", RPR.JobID)]
	ReaperSliceCommunioFeature = 3920,

	[CustomComboInfo("Slice Soulsow Feature", "Replace Infernal Slice with Soulsow when out of combat and not active.", RPR.JobID)]
	ReaperSliceSoulsowFeature = 3930,

	[Conflicts(ReaperShadowGibbetFeature)]
	[CustomComboInfo("Shadow Gallows Feature", "Replace Shadow of Death with Gallows while Reaving, Enshrouded, or an Executioner.", RPR.JobID)]
	ReaperShadowGallowsFeature = 3905,

	[Conflicts(ReaperShadowGallowsFeature)]
	[CustomComboInfo("Shadow Gibbet Feature", "Replace Shadow of Death with Gibbet while Reaving, Enshrouded, or an Executioner.", RPR.JobID)]
	ReaperShadowGibbetFeature = 3906,

	[CustomComboInfo("Shadow Lemure's Feature", "Replace Shadow of Death with Lemure's Slice when two or more stacks of Void Shroud are active.", RPR.JobID)]
	ReaperShadowLemuresFeature = 3923,

	[CustomComboInfo("Shadow Communio Feature", "Replace Shadow of Death with Communio when one stack of Shroud is left.", RPR.JobID)]
	ReaperShadowCommunioFeature = 3924,

	[CustomComboInfo("Shadow Soulsow Feature", "Replace Shadow of Death with Soulsow when out of combat, not active, and you have no target.", RPR.JobID)]
	ReaperShadowSoulsowFeature = 3929,

	[Conflicts(ReaperSoulGibbetFeature)]
	[CustomComboInfo("Soul Gallows Feature", "Replace Soul Slice with Gallows while Reaving, Enshrouded, or an Executioner.", RPR.JobID)]
	ReaperSoulGallowsFeature = 3925,

	[Conflicts(ReaperSoulGallowsFeature)]
	[CustomComboInfo("Soul Gibbet Feature", "Replace Soul Slice with Gibbet while Reaving, Enshrouded, or an Executioner.", RPR.JobID)]
	ReaperSoulGibbetFeature = 3926,

	[CustomComboInfo("Soul Lemure's Feature", "Replace Soul Slice with Lemure's Slice when two or more stacks of Void Shroud are active.", RPR.JobID)]
	ReaperSoulLemuresFeature = 3927,

	[CustomComboInfo("Soul Communio Feature", "Replace Soul Slice with Communio when one stack of Shroud is left.", RPR.JobID)]
	ReaperSoulCommunioFeature = 3928,

	[CustomComboInfo("Soul Slice Overcap Feature", "Replace Soul Slice with Blood Stalk when not Enshrouded and Soul Gauge is over 50.", RPR.JobID)]
	ReaperSoulOvercapFeature = 3934,

	[CustomComboInfo("Soul Scythe Overcap Feature", "Replace Soul Scythe with Grim Swathe when not Enshrouded, and Soul Gauge is over 50.", RPR.JobID)]
	ReaperSoulScytheOvercapFeature = 3935,

	[CustomComboInfo("Soul Slice Weave Assist", "Replace Soul Slice with Blood Stalk (or variants) when available and weaving wouldn't clip your GCD.", RPR.JobID)]
	ReaperSoulSliceWeaveAssist = 3944,

	[CustomComboInfo("Soul Scythe Weave Assist", "Replace Soul Scythe with Grim Swathe (or variants) when available and weaving wouldn't clip your GCD.", RPR.JobID)]
	ReaperSoulScytheWeaveAssist = 3945,

	[CustomComboInfo("Scythe Combo", "Replace Nightmare Scythe with its combo chain.", RPR.JobID)]
	ReaperScytheCombo = 3902,

	[CustomComboInfo("Scythe Weave Assist", "Replace Nightmare Scythe with Grim Swathe (or variants) when available and weaving wouldn't clip your GCD.", RPR.JobID)]
	ReaperScytheWeaveAssist = 3943,

	[ParentPreset(ReaperScytheWeaveAssist)]
	[CustomComboInfo("Ignore Reaving", "Allow weaving even if you're already reaving.", RPR.JobID)]
	ReaperScytheWeaveAssistDoubleReaving = 3949,

	[CustomComboInfo("Scythe of Death Feature", "Replace Nightmare Scythe with Whorl of Death when the target's Death's Design debuff is low.", RPR.JobID)]
	ReaperScytheWhorlFeature = 3941,

	[CustomComboInfo("Soulful Scythe", "Replace Nightmare Scythe with Soul Scythe when available and Soul Gauge is no more than 50.", RPR.JobID)]
	ReaperSoulOnScytheFeature = 3947,

	[CustomComboInfo("Scythe Guillotine Feature", "Replace Nightmare Scythe with Guillotine while Reaving, Enshrouded, or an Executioner.", RPR.JobID)]
	ReaperScytheGuillotineFeature = 3907,

	[CustomComboInfo("Scythe Lemure's Feature", "Replace Nightmare Scythe with Lemure's Scythe when two or more stacks of Void Shroud are active.", RPR.JobID)]
	ReaperScytheLemuresFeature = 3921,

	[CustomComboInfo("Scythe Communio Feature", "Replace Nightmare Scythe with Communio when one stack is left of Shroud.", RPR.JobID)]
	ReaperScytheCommunioFeature = 3922,

	[CustomComboInfo("Scythe Soulsow Feature", "Replace Nightmare Scythe with Soulsow when out of combat and not active.", RPR.JobID)]
	ReaperScytheSoulsowFeature = 3931,

	[CustomComboInfo("Scythe Harvest Moon Feature", "Replace Nightmare Scythe with Harvest Moon when Soulsow is active and you have a target.", RPR.JobID)]
	ReaperScytheHarvestMoonFeature = 3932,

	[CustomComboInfo("Enhanced Soul Reaver Feature", "Replace Gibbet and Gallows with whichever is currently enhanced while Reaving, Enshrouded, or an Executioner.", RPR.JobID)]
	ReaperEnhancedSoulReaverFeature = 3917,

	[CustomComboInfo("Lemure's Soul Reaver Feature", "Replace Gibbet, Gallows, and Guillotine with Lemure's Slice or Scythe when two or more stacks of Void Shroud are active.", RPR.JobID)]
	ReaperLemuresSoulReaverFeature = 3911,

	[CustomComboInfo("Communio Soul Reaver Feature", "Replace Gibbet, Gallows, and Guillotine with Communio when one stack is left of Shroud.", RPR.JobID)]
	ReaperCommunioSoulReaverFeature = 3912,

	[CustomComboInfo("Enshroud Communio Feature", "Replace Enshroud with Communio when Enshrouded.", RPR.JobID)]
	ReaperEnshroudCommunioFeature = 3909,

	[CustomComboInfo("Blood Stalk Gluttony Feature", "Replace Blood Stalk with Gluttony when available and Soul Gauge is at least 50.", RPR.JobID)]
	ReaperBloodStalkGluttonyFeature = 3915,

	[CustomComboInfo("Grim Swathe Gluttony Feature", "Replace Grim Swathe with Gluttony when available and Soul Gauge is at least 50.", RPR.JobID)]
	ReaperGrimSwatheGluttonyFeature = 3916,

	[CustomComboInfo("Arcane Harvest Feature", "Replace Arcane Circle with Plentiful Harvest when you have enough stacks of Immortal Sacrifice.", RPR.JobID)]
	ReaperHarvestFeature = 3908,

	[CustomComboInfo("Regress Feature", "Replace Hell's Ingress and Egress turn with Regress when Threshold is active, instead of just the opposite of the one used.", RPR.JobID)]
	ReaperRegressFeature = 3910,

	[ParentPreset(ReaperRegressFeature)]
	[CustomComboInfo("Delayed Regress Option", "Replace the action used with Regress only after a configurable delay.", RPR.JobID)]
	ReaperRegressDelayed = 3933,

	[CustomComboInfo("Harpe Soulsow Feature", "Replace Harpe with Soulsow when not active and out of combat or you have no target.", RPR.JobID)]
	ReaperHarpeHarvestSoulsowFeature = 3936,

	[CustomComboInfo("Harpe Harvest Moon Feature", "Replace Harpe with Harvest Moon when Soulsow is active and you are in combat.", RPR.JobID)]
	ReaperHarpeHarvestMoonFeature = 3937,

	[ParentPreset(ReaperHarpeHarvestMoonFeature)]
	[CustomComboInfo("Enhanced Harpe Option", "Prevent replacing Harpe with Harvest Moon when Enhanced Harpe is active.", RPR.JobID)]
	ReaperHarpeHarvestMoonEnhancedFeature = 3939,

	[ParentPreset(ReaperHarpeHarvestMoonFeature)]
	[CustomComboInfo("Combat Option", "Prevent replacing Harpe with Harvest Moon when not in combat.", RPR.JobID)]
	ReaperHarpeHarvestMoonCombatFeature = 3938,

	#endregion
	// ====================================================================================
	#region SAMURAI (34xx)
	// Working on updating SAM. Will gradually be releasing more features as they are verified working.

	[CustomComboInfo("Second Wind / Bloodbath", "Replace Bloodbath and Second Wind with each other based on cooldown, or with only Second Wind when under level.\nIf both are available, the button will default to whichever you placed on your hotbar.", SAM.JobID)]
	SamuraiBloodbathReplacer = 3419,

	[CustomComboInfo("Yukikaze Combo", "Replace Yukikaze with its combo chain.", SAM.JobID)]
	SamuraiYukikazeCombo = 3400,

	[CustomComboInfo("Gekko Combo", "Replace Gekko with its combo chain.", SAM.JobID)]
	SamuraiGekkoCombo = 3401,

	[ParentPreset(SamuraiGekkoCombo)]
	[CustomComboInfo("Gekko Combo from Jinpu", "Start the Gekko combo chain with Jinpu instead of Hakaze.", SAM.JobID)]
	SamuraiGekkoOption = 3416,

	[CustomComboInfo("Kasha Combo", "Replace Kasha with its combo chain.", SAM.JobID)]
	SamuraiKashaCombo = 3402,

	[ParentPreset(SamuraiKashaCombo)]
	[CustomComboInfo("Kasha Combo from Shifu", "Start the Kasha combo chain with Shifu instead of Hakaze.", SAM.JobID)]
	SamuraiKashaOption = 3417,

	[CustomComboInfo("Mangetsu Combo", "Replace Mangetsu with its combo chain.", SAM.JobID)]
	SamuraiMangetsuCombo = 3403,

	[CustomComboInfo("Oka Combo", "Replace Oka with its combo chain.", SAM.JobID)]
	SamuraiOkaCombo = 3404,

	[Conflicts(SamuraiIaijutsuTsubameGaeshiFeature)]
	[CustomComboInfo("Tsubame-gaeshi to Iaijutsu", "Replace Tsubame-gaeshi with Iaijutsu when Sen is not empty.", SAM.JobID)]
	SamuraiTsubameGaeshiIaijutsuFeature = 3407,

	[Conflicts(SamuraiIaijutsuShohaFeature)]
	[CustomComboInfo("Tsubame-gaeshi to Shoha", "Replace Tsubame-gaeshi with Shoha when meditation is 3.", SAM.JobID)]
	SamuraiTsubameGaeshiShohaFeature = 3409,

	[Conflicts(SamuraiTsubameGaeshiIaijutsuFeature)]
	[CustomComboInfo("Iaijutsu to Tsubame-gaeshi", "Replace Iaijutsu with Tsubame-gaeshi when Sen is empty.", SAM.JobID)]
	SamuraiIaijutsuTsubameGaeshiFeature = 3408,

	[Conflicts(SamuraiTsubameGaeshiShohaFeature)]
	[CustomComboInfo("Iaijutsu to Shoha", "Replace Iaijutsu with Shoha when meditation is 3.", SAM.JobID)]
	SamuraiIaijutsuShohaFeature = 3410,

	[CustomComboInfo("Shinten to Senei", "Replace Hissatsu: Shinten with Senei when available.", SAM.JobID)]
	SamuraiShintenSeneiFeature = 3414,

	[CustomComboInfo("Shinten to Shoha", "Replace Hissatsu: Shinten with Shoha when Meditation is full.", SAM.JobID)]
	SamuraiShintenShohaFeature = 3413,

	[CustomComboInfo("Kyuten to Guren", "Replace Hissatsu: Kyuten with Guren when available.", SAM.JobID)]
	SamuraiKyutenGurenFeature = 3415,

	[CustomComboInfo("Kyuten to Shoha", "Replace Hissatsu: Kyuten with Shoha when Meditation is full.", SAM.JobID)]
	SamuraiKyutenShohaFeature = 3412,

	[CustomComboInfo("Ikishoten Namikiri Feature", "Replace Ikishoten with Shoha, Kaeshi Namikiri, and then Ogi Namikiri when available.", SAM.JobID)]
	SamuraiIkishotenNamikiriFeature = 3411,

	[CustomComboInfo("Hissatsu Senei/Guren Sync Feature", "Replace Hissatsu Senei with Hissatsu Guren when underlevel.", SAM.JobID)]
	SamuraiGurenSeneiLevelSyncFeature = 3418,

	#endregion
	// ====================================================================================
	#region SCHOLAR (28xx)

	[CustomComboInfo("Swiftcast Resurrection", "Resurrection turns into Swiftcast when available and reasonable.", SCH.JobID)]
	ScholarSwiftcastRaiserFeature = 2800,

	[CustomComboInfo("Mobile Ruin & Broil", "Changes Ruin 1 and all variants of Broil into Ruin 2 while moving.", SCH.JobID)]
	ScholarMobileRuinBroil = 2810,

	[CustomComboInfo("Lucid Ruin & Broil", "Changes Ruin 1 and all variants of Broil into Lucid Dreaming when MP is below a certain level.", SCH.JobID)]
	ScholarLucidRuinBroil = 2811,

	[CustomComboInfo("Lucid Art of War", "Changes Art of War into Lucid Dreaming when MP is below a certain level.", SCH.JobID)]
	ScholarLucidArtOfWar = 2812,

	[CustomComboInfo("Seraph Fey Blessing/Consolation", "Change Fey Blessing into Consolation when Seraph is out.", SCH.JobID)]
	ScholarSeraphConsolationFeature = 2801,

	[CustomComboInfo("Lustrous Aetherflow", "Change Lustrate into Aetherflow when you have no more Aetherflow stacks.", SCH.JobID)]
	ScholarLustrateAetherflowFeature = 2803,

	[CustomComboInfo("Lustrate to Recitation", "Replace Lustrate with Recitation when Recitation is off cooldown.", SCH.JobID)]
	ScholarLustrateRecitationFeature = 2807,

	[CustomComboInfo("Lustrate to Excogitation", "Replace Lustrate with Excogitation when Excogitation is off cooldown.", SCH.JobID)]
	ScholarLustrateExcogitationFeature = 2808,

	[CustomComboInfo("Excog / Lustrate", "Change Excogitation into Lustrate when on CD or under level.", SCH.JobID)]
	ScholarExcogFallbackFeature = 2805,

	[CustomComboInfo("Excogitation to Recitation", "Replace Excogitation with Recitation when Recitation is off cooldown.", SCH.JobID)]
	ScholarExcogitationRecitationFeature = 2806,

	[CustomComboInfo("ED Aetherflow", "Change Energy Drain into Aetherflow when you have no more Aetherflow stacks.", SCH.JobID)]
	ScholarEnergyDrainAetherflowFeature = 2802,

	[CustomComboInfo("Indomitable Aetherflow", "Change Indomitability into Aetherflow when you have no more Aetherflow stacks.", SCH.JobID)]
	ScholarIndomAetherflowFeature = 2804,

	[CustomComboInfo("Summon Seraph Feature", "Replace Summon Eos and Selene with Summon Seraph when a summon is out.", SCH.JobID)]
	ScholarSeraphFeature = 2809,

	[CustomComboInfo("Chain Impaction", "Replace Chain Stratagem with Baneful Impaction when under Impact Imminent.", SCH.JobID)]
	ScholarChainStratagemBanefulImpaction = 2813,

	#endregion
	// ====================================================================================
	#region SAGE (40xx)
	// Current latest 4027

	[CustomComboInfo("Swiftcast Egeiro", "Egeiro turns into Swiftcast when available and reasonable.", SGE.JobID)]
	SageSwiftcastRaiserFeature = 4000,

	[CustomComboInfo("Taurochole Into Druochole Feature", "Replace Taurochole with Druochole when on cooldown", SGE.JobID)]
	SageTaurocholeDruocholeFeature = 4001,

	[CustomComboInfo("Taurochole Into Rhizomata Feature", "Replace Taurochole with Rhizomata when Addersgall is empty.", SGE.JobID)]
	SageTaurocholeRhizomataFeature = 4002,

	[CustomComboInfo("Druochole Into Rhizomata Feature", "Replace Druochole with Rhizomata when Addersgall is empty.", SGE.JobID)]
	SageDruocholeRhizomataFeature = 4003,

	[CustomComboInfo("Ixochole Into Rhizomata Feature", "Replace Ixochole with Rhizomata when Addersgall is empty.", SGE.JobID)]
	SageIxocholeRhizomataFeature = 4004,

	[CustomComboInfo("Kerachole Into Rhizomata Feature", "Replace Kerachole with Rhizomata when Addersgall is empty.", SGE.JobID)]
	SageKeracholaRhizomataFeature = 4005,

	[CustomComboInfo("Soteria Kardia Feature", "Replace Soteria with Kardia when missing Kardion.", SGE.JobID)]
	SageSoteriaKardionFeature = 4006,

	[CustomComboInfo("Flying Phlegma", "Turns Icarus into Phlegma when Phlegma is up and you're in range of your target to use it.", SGE.JobID)]
	SageIcarusPhlegma = 4019,

	[CustomComboInfo("Phlegma Gap Closer", "Replace Phlegma with Icarus when at least a configurable distance away from your target and both are off CD.\nOnly applies when Phlegma has at least one charge available.", SGE.JobID)]
	SagePhlegmaIcarus = 4009,

	[CustomComboInfo("Phlegma into Toxikon", "Replace Phlegma with Toxikon when you have a target and Addersting, and either no charges of Phlegma remain or your target is too far away.\nGap Closer takes priority if enabled and available.", SGE.JobID)]
	SagePhlegmaToxicon = 4007,

	[CustomComboInfo("Phlegma into Dosis", "Replace Phlegma with Dosis when you have a target in range and either no charges of Phlegma remain or your target is too far away.\nToxikon takes priority if enabled and available.", SGE.JobID)]
	SagePhlegmaDosis = 4016,

	[CustomComboInfo("Phlegma into Dyskrasia", "Replace Phlegma with Dyskrasia when no charges remain, you have no target, or your target is out of range.\nDosis takes priority if enabled and available.", SGE.JobID)]
	SagePhlegmaDyskrasia = 4008,

	[CustomComboInfo("Kerachole into Holos", "Turns Kerachole into Holos when your level is high enough, Kerachole is unavailable, and you can use Holos.\nSupports Kerachole into Rhizomata, prioritises being Rhizomata.", SGE.JobID)]
	SageKeracholeHolos = 4010,

	[CustomComboInfo("Holos into Kerachole", "Turns Holos into Kerachole when your level is too low, or when Kerachole is available and Holos is not.\nSupports Kerachole into Rhizomata, prioritises being Holos.", SGE.JobID)]
	SageHolosKerachole = 4011,

	[CustomComboInfo("Dosis into Phlegma", "Turns Dosis into Phlegma while moving and have a target and Phlegma is up and you're in range.\nDoes not apply if you have Eukrasia active.", SGE.JobID)]
	SageDosisPhlegma = 4020,

	[ParentPreset(SageDosisPhlegma)]
	[CustomComboInfo("Combat Only", "Only change Dosis into Phlegma when already in combat.", SGE.JobID)]
	SageDosisPhlegmaCombatOnly = 4021,

	[ParentPreset(SageDosisPhlegma)]
	[CustomComboInfo("Only when hardcasting", "Only change Dosis into Phlegma when hardcasting.", SGE.JobID)]
	SageDosisPhlegmaHardcastOnly = 4024,

	[CustomComboInfo("Dosis into Toxikon", "Turns Dosis into Toxikon while moving and have a target and Addersting.\nDoes not apply if you have Eukrasia active.", SGE.JobID)]
	SageDosisToxikon = 4017,

	[ParentPreset(SageDosisToxikon)]
	[CustomComboInfo("Combat Only", "Only change Dosis into Toxikon when already in combat.", SGE.JobID)]
	SageDosisToxikonCombatOnly = 4022,

	[ParentPreset(SageDosisToxikon)]
	[CustomComboInfo("Only when hardcasting", "Only change Dosis into Toxikon when hardcasting.", SGE.JobID)]
	SageDosisToxikonHardcastOnly = 4025,

	[CustomComboInfo("Dosis into Dyskrasia", "Turns Dosis into Dyskrasia while moving and not becoming Phlegma or Toxikon.\nDoes not apply if you have Eukrasia active.", SGE.JobID)]
	SageDosisDyskrasia = 4018,

	[ParentPreset(SageDosisDyskrasia)]
	[CustomComboInfo("Combat Only", "Only change Dosis into Dyskrasia when already in combat.", SGE.JobID)]
	SageDosisDyskrasiaCombatOnly = 4023,

	[ParentPreset(SageDosisDyskrasia)]
	[CustomComboInfo("Only when hardcasting", "Only change Dosis into Dyskrasia when hardcasting.", SGE.JobID)]
	SageDosisDyskrasiaHardcastOnly = 4026,

	[CustomComboInfo("Lucid Dosis", "Weave Dosis into Lucid Dreaming when it's available and your MP is below a threshold.\nThis also applies when Phlegma becomes Dosis.", SGE.JobID)]
	SageLucidDosis = 4012,

	[CustomComboInfo("Lucid Dyskrasia", "Weave Dyskrasia into Lucid Dreaming when it's available and your MP is below a threshold.\nThis also applies when Phlegma becomes Dyskrasia.", SGE.JobID)]
	SageLucidDyskrasia = 4013,

	[CustomComboInfo("Lucid Toxikon", "Weave Toxikon into Lucid Dreaming when it's available and your MP is below a threshold.\nThis also applies when Phlegma becomes Toxikon.", SGE.JobID)]
	SageLucidToxikon = 4014,

	[CustomComboInfo("Lucid Phlegma", "Weave Phlegma into Lucid Dreaming when it's available and your MP is below a configurable threshold.", SGE.JobID)]
	SageLucidPhlegma = 4015,

	[CustomComboInfo("Philosophia Into Zoe", "When either not at level or when Philosophica is on cooldown, change it into Zoe.", SGE.JobID)]
	SagePhilosophiaZoe = 4027,

	#endregion
	// ====================================================================================
	#region SUMMONER (27xx)

	[CustomComboInfo("Swiftcast Resurrection", "Resurrection turns into Swiftcast when available and reasonable.", SMN.JobID)]
	SummonerSwiftcastRaiserFeature = 2700,

	//[CustomComboInfo("ED Fester", "Change Fester into Energy Drain when out of Aetherflow stacks.", SMN.JobID)]
	//SummonerEDFesterCombo = 2704,

	//[CustomComboInfo("ES Painflare", "Change Painflare into Energy Syphon when out of Aetherflow stacks.", SMN.JobID)]
	//SummonerESPainflareCombo = 2705,

	//[CustomComboInfo("Ruin Feature", "Change Ruin into Gemburst when attuned.", SMN.JobID)]
	//SummonerRuinFeature = 2706,

	//[CustomComboInfo("Titan's Favor Ruin Feature", "Change Ruin into Mountain Buster (oGCD) when available.", SMN.JobID)]
	//SummonerRuinTitansFavorFeature = 2713,

	//[CustomComboInfo("Further Ruin Feature", "Change Ruin into Ruin4 when available and appropriate.", SMN.JobID)]
	//SummonerFurtherRuinFeature = 2708,

	//[CustomComboInfo("Outburst Feature", "Change Outburst into Precious Brilliance when attuned.", SMN.JobID)]
	//SummonerOutburstFeature = 2707,

	//[CustomComboInfo("Titan's Favor Outburst Feature", "Change Outburst into Mountain Buster (oGCD) when available.", SMN.JobID)]
	//SummonerOutburstTitansFavorFeature = 2714,

	//[CustomComboInfo("Further Outburst Feature", "Change Outburst into Ruin4 when available and appropriate.", SMN.JobID)]
	//SummonerFurtherOutburstFeature = 2709,

	//[CustomComboInfo("Shiny Titan's Favour", "Change Ruin into Ruin4 when available and appropriate.", SMN.JobID)]
	//SummonerShinyTitansFavorFeature = 2710,

	//[CustomComboInfo("Further Shiny Feature", "Change Outburst into Ruin4 when available and appropriate.", SMN.JobID)]
	//SummonerFurtherShinyFeature = 2711,

	//[CustomComboInfo("Shiny Enkindle Feature", "Change Gemshine and Precious Brilliance to Enkindle when Bahamut or Phoenix are summoned.", SMN.JobID)]
	//SummonerShinyEnkindleFeature = 2712,

	//[CustomComboInfo("Demi Enkindle Feature", "Change Summon Bahamut and Summon Phoenix into Enkindle when Bahamut or Phoenix are summoned.", SMN.JobID)]
	//SummonerDemiEnkindleFeature = 2715,

	//[CustomComboInfo("Radiant Carbuncle Feature", "Change Radiant Aegis into Summon Carbuncle when no pet has been summoned.", SMN.JobID)]
	//SummonerRadiantCarbuncleFeature = 2716,

	//[CustomComboInfo("Slipstream / Swiftcast Feature", "Change Slipstream into Swiftcast when Swiftcast is available.", SMN.JobID)]
	//SummonerSlipcastFeature = 2718,

	#endregion
	// ====================================================================================
	#region VIPER (41xx)

	[CustomComboInfo("Second Wind / Bloodbath", "Replace Bloodbath and Second Wind with each other based on cooldown, or with only Second Wind when under level.\nIf both are available, the button will default to whichever you placed on your hotbar.", VPR.JobID)]
	ViperBloodbathReplacer = 4100,

	#endregion
	// ====================================================================================
	#region WARRIOR (21xx)

	[CustomComboInfo("Stun/Interrupt feature", "Turn Low Blow and Interject into Interject when off CD and your target can be interrupted, Low Blow otherwise.", WAR.JobID)]
	WarriorStunInterruptFeature = 2109,

	[CustomComboInfo("Storm's Path combo", "Replace Storm's Path with its combo chain.", WAR.JobID)]
	WarriorStormsPathCombo = 2100,

	[ParentPreset(WarriorStormsPathCombo)]
	[CustomComboInfo("Smart weave", "Automatically turn into Upheaval when weaving won't drift your GCD.", WAR.JobID)]
	WarriorSmartWeaveSingleTargetPath = 2116,

	[ParentPreset(WarriorSmartWeaveSingleTargetPath)]
	[CustomComboInfo("Buffed weave", "Wait until you have Surging Tempest active.", WAR.JobID)]
	WarriorSmartWeaveSingleTargetPathOnlyBuffed = 2119,

	[ParentPreset(WarriorStormsPathCombo)]
	[CustomComboInfo("Gauge overcap saver", "Replace the Storm's Path combo with gauge spender if completing the combo would overcap you.", WAR.JobID)]
	WarriorGaugeOvercapPathFeature = 2103,

	[ParentPreset(WarriorStormsPathCombo)]
	[CustomComboInfo("Surging Tempest saver", "Replace the Storm's Path combo chain with Storm's Eye if Surging Tempest has less than 7 (default) seconds left.", WAR.JobID)]
	WarriorSmartStormCombo = 2112,

	[CustomComboInfo("Storm's Eye combo", "Replace Storm's Eye with its combo chain.", WAR.JobID)]
	WarriorStormsEyeCombo = 2101,

	[ParentPreset(WarriorStormsEyeCombo)]
	[CustomComboInfo("Smart weave", "Automatically turn into Upheaval when weaving won't drift your GCD.", WAR.JobID)]
	WarriorSmartWeaveSingleTargetEye = 2117,

	[ParentPreset(WarriorSmartWeaveSingleTargetEye)]
	[CustomComboInfo("Buffed weave", "Wait until you have Surging Tempest active.", WAR.JobID)]
	WarriorSmartWeaveSingleTargetEyeOnlyBuffed = 2120,

	[ParentPreset(WarriorStormsEyeCombo)]
	[CustomComboInfo("Gauge overcap saver", "Replace the Storm's Eye combo with gauge spender if completing the combo would overcap you.", WAR.JobID)]
	WarriorGaugeOvercapEyeFeature = 2110,

	[ParentPreset(WarriorStormsEyeCombo)]
	[CustomComboInfo("Surging Tempest overcap saver", "Replace Storm's Eye with Storm's Path when Surging Tempest buff has over 30 seconds left.", WAR.JobID)]
	WarriorStormsEyeBuffOvercapSaver = 2122,

	[CustomComboInfo("Mythril Tempest combo", "Replace Mythril Tempest with its combo chain.", WAR.JobID)]
	WarriorMythrilTempestCombo = 2102,

	[ParentPreset(WarriorMythrilTempestCombo)]
	[CustomComboInfo("Smart weave", "Automatically turn into Orogeny when weaving won't drift your GCD.", WAR.JobID)]
	WarriorSmartWeaveAOE = 2118,

	[ParentPreset(WarriorSmartWeaveAOE)]
	[CustomComboInfo("Buffed weave", "Wait until you have Surging Tempest active.", WAR.JobID)]
	WarriorSmartWeaveAOEOnlyBuffed = 2121,

	[ParentPreset(WarriorMythrilTempestCombo)]
	[CustomComboInfo("Gauge overcap saver", "Replace the Mythril Tempest combo with gauge spender if completing the combo would overcap you.", WAR.JobID)]
	WarriorGaugeOvercapTempestFeature = 2111,

	[CustomComboInfo("Inner Release feature", "Replace single-target and AoE combo with Fell Cleave/Decimate during Inner Release.", WAR.JobID)]
	WarriorInnerReleaseFeature = 2104,

	[CustomComboInfo("Nascent Flash feature", "Replace Nascent Flash with Raw Intuition when below level 76.", WAR.JobID)]
	WarriorNascentFlashFeature = 2105,

	[CustomComboInfo("Angry Beast feature", "Replace Inner Beast/Fell Cleave and Steel Cyclone/Decimate with Infuriate when less then 50 Beast Gauge is available.\nWhen you have at least 50 gauge AND the Nascent Chaos buff, they become Inner Chaos and Chaotic Cyclone, respectively.", WAR.JobID)]
	WarriorInfuriateBeastFeature = 2113,

	[ParentPreset(WarriorInfuriateBeastFeature)]
	[CustomComboInfo("Angry Beast gauge saver", "Replace the above with Infuriate when less than 60 Beast Gauge instead of 50.", WAR.JobID)]
	WarriorInfuriateBeastRaidModeFeature = 2115,

	[CustomComboInfo("Healthy balanaced diet", "Replace Bloodwhetting with Thrill of Battle, and then Equilibrium when the preceding is on cooldown.", WAR.JobID)]
	WarriorHealthyBalancedDietFeature = 2114,

	[CustomComboInfo("Primal Steel Beast", "Replace Inner Beast and Steel Cyclone with Primal Rend when available", WAR.JobID)]
	WarriorPrimalBeastFeature = 2107,

	[CustomComboInfo("Primal Release", "Replace Inner Release with Primal Rend when available", WAR.JobID)]
	WarriorPrimalReleaseFeature = 2108,

	#endregion
	// ====================================================================================
	#region WHITE MAGE (24xx)

	[CustomComboInfo("Swiftcast Raise", "Raise turns into Swiftcast when available and reasonable.", WHM.JobID)]
	WhiteMageSwiftcastRaiserFeature = 2400,

	[CustomComboInfo("Lucid Weaving", "When MP is below a set threshold, weave Lucid Dreaming onto Aero/Dia, Stone/Glare, and Holy.", WHM.JobID)]
	WhiteMageLucidWeave = 2406,

	[CustomComboInfo("Solace into Misery", "Replaces Afflatus Solace with Afflatus Misery when Misery is ready to be used.", WHM.JobID)]
	WhiteMageSolaceMiseryFeature = 2401,

	[CustomComboInfo("Rapture into Misery", "Replaces Afflatus Rapture with Afflatus Misery when Misery is ready to be used and you have a target.", WHM.JobID)]
	WhiteMageRaptureMiseryFeature = 2402,

	[CustomComboInfo("Holy into Misery", "Replace Holy/Holy 3 with Afflatus Misery when Misery is ready to be used and you have a target.", WHM.JobID)]
	WhiteMageHolyMiseryFeature = 2405,

	[CustomComboInfo("Afflatus Feature", "Changes Cure 2 into Afflatus Solace, and Medica into Afflatus Rapture, when lilies are up.", WHM.JobID)]
	WhiteMageAfflatusFeature = 2404,

	[CustomComboInfo("Cure 2 Level Sync", "Changes Cure 2 to Cure when below level 30 in synced content.", WHM.JobID)]
	WhiteMageCureFeature = 2403,

	[CustomComboInfo("DOT Refresh", "Replace Stone/Glare with level appropriate DOT when debuff is about to fall off.", WHM.JobID)]
	WhiteMageDotRefresh = 2407,

	[CustomComboInfo("Presence of Glare", "Replace Presence of Mind with Glare IV when under Sacred Sight.", WHM.JobID)]
	WhiteMagePresenceOfMindGlare4 = 2408,

	[CustomComboInfo("Divine Temperance", "Replace Temperance with Divine Caress when under Divine Grace.", WHM.JobID)]
	WhiteMageTemperanceDivineCaress = 2409,

	#endregion
	// ====================================================================================
	#region DoH (98xx)

	// [CustomComboInfo("Placeholder", "Placeholder.", DOH.JobID)]
	// DohPlaceholder = 9800,

	#endregion
	// ====================================================================================
	#region DoL (99xx)

	[CustomComboInfo("Eureka Feature", "Replace Ageless Words and Solid Reason with Wise to the World when available.", DOL.JobID)]
	GatherEurekaFeature = 9900,

	[CustomComboInfo("Job Correction", "Replace Miner/Botanist actions with the other job's version when on the opposite job.", DOL.JobID)]
	GatherJobCorrectionFeature = 9909,

	[ParentPreset(GatherJobCorrectionFeature)]
	[CustomComboInfo("Ignore node detection skills", "Do not replace skills like Triangulate / Prospect, Lay of the Land / Arbor Call, and Truth of Mountains/Forests.", DOL.JobID)]
	GatherJobCorrectionIgnoreDetectionsFeature = 9910,

	[CustomComboInfo("Hook / Cast Feature", "Replace Hook with Cast when fishing, and vice-versa when not fishing.", DOL.JobID)]
	FisherCastHookFeature = 9901,

	[CustomComboInfo("Double Cast Feature", "Replace Double Hook with Cast with when not fishing.", DOL.JobID)]
	FisherCastDoubleHookFeature = 9911,

	[CustomComboInfo("Triple Cast Feature", "Replace Triple Hook with Cast with when not fishing.", DOL.JobID)]
	FisherCastTripleHookFeature = 9912,

	[CustomComboInfo("Multi Hook Feature: 3/2", "Replace Triple Hook with Double Hook when fishing but not enough GP.", DOL.JobID)]
	FisherCastMultiHookFeature32 = 9913,

	[CustomComboInfo("Multi Hook Feature: 2/1", "Replace Double Hook with normal Hook when fishing but not enough GP.", DOL.JobID)]
	FisherCastMultiHookFeature21 = 9914,

	[CustomComboInfo("Thaliak's Chum", "Replace Chum with Thaliak's Favour when less than 100 GP and at least three stacks of Angler's Art.", DOL.JobID)]
	FisherAutoFavourChum = 9915,

	[CustomComboInfo("Thaliak's Patience", "Replace Patience with Thaliak's Favour when less than 200 GP and at least three stacks of Angler's Art.", DOL.JobID)]
	FisherAutoFavourPatience = 9916,

	[CustomComboInfo("Thaliak's Patience II", "Replace Patience II with Thaliak's Favour when less than 560 GP and at least three stacks of Angler's Art.", DOL.JobID)]
	FisherAutoFavourPatience2 = 9917,

	[CustomComboInfo("Thaliak's Eyes", "Replace Fish Eyes with Thaliak's Favour when less than 550 GP and at least three stacks of Angler's Art.", DOL.JobID)]
	FisherAutoFavourFishEyes = 9918,

	[CustomComboInfo("Thaliak's Mooch II", "Replace Mooch II with Thaliak's Favour when less than 100 GP and at least three stacks of Angler's Art.", DOL.JobID)]
	FisherAutoFavourMooch2 = 9919,

	[CustomComboInfo("Thaliak's Trade", "Replace Veteran Trade with Thaliak's Favour when less than 200 GP and at least three stacks of Angler's Art.", DOL.JobID)]
	FisherAutoFavourVeteranTrade = 9920,

	[CustomComboInfo("Thaliak's Bounty", "Replace Nature's Bounty with Thaliak's Favour when less than 100 GP and at least three stacks of Angler's Art.", DOL.JobID)]
	FisherAutoFavourNaturesBounty = 9921,

	[CustomComboInfo("Thaliak's Slap", "Replace Surface Slap with Thaliak's Favour when less than 200 GP and at least three stacks of Angler's Art.", DOL.JobID)]
	FisherAutoFavourSurfaceSlap = 9922,

	[CustomComboInfo("Thaliak's Cast", "Replace Identical Cast with Thaliak's Favour when less than 350 GP and at least three stacks of Angler's Art.", DOL.JobID)]
	FisherAutoFavourIdenticalCast = 9923,

	[CustomComboInfo("Thaliak's Breath", "Replace Baited Breath with Thaliak's Favour when less than 300 GP and at least three stacks of Angler's Art.", DOL.JobID)]
	FisherAutoFavourBaitedBreath = 9924,

	[CustomComboInfo("Thaliak's Catch", "Replace Prize Catch with Thaliak's Favour when less than 200 GP and at least three stacks of Angler's Art.", DOL.JobID)]
	FisherAutoFavourPrizeCatch = 9925,

	[CustomComboInfo("Cast / Gig Feature", "Replace Cast with Gig when swimming.", DOL.JobID)]
	FisherCastGigFeature = 9902,

	[CustomComboInfo("Surface Slap / Veteran Trade Feature", "Replace Surface Slap with Veteran Trade when swimming.", DOL.JobID)]
	FisherSurfaceTradeFeature = 9903,

	[CustomComboInfo("Prize Catch / Nature's Bounty Feature", "Replace Prize Catch with Nature's Bounty when swimming.", DOL.JobID)]
	FisherPrizeBountyFeature = 9904,

	[CustomComboInfo("Snagging / Salvage Feature", "Replace Snagging with Salvage when swimming.", DOL.JobID)]
	FisherSnaggingSalvageFeature = 9905,

	[CustomComboInfo("Identical Cast / Vital Sight Feature", "Replace Identical Cast with Vital Sight when swimming.", DOL.JobID)]
	FisherIdenticalSightFeature = 9906,

	[CustomComboInfo("Makeshift Bait / Baited Breath Feature", "Replace Makeshift Bait with Baited Breath when swimming.", DOL.JobID)]
	FisherMakeshiftBreathFeature = 9907,

	[CustomComboInfo("Chum / Electric Current Feature", "Replace Chum with Electric Current when swimming.", DOL.JobID)]
	FisherElectricChumFeature = 9908,

	[CustomComboInfo("Priming Meticulous combo", "Replace Meticulous actions with Priming Touch when Special Collector active and have more than 400GP.", DOL.JobID)]
	PrimedMetFeature = 9927,


#if DEBUG
	[CustomComboInfo("Mooch / Spareful Hand Feature", "Replace Mooch with Spareful Hand if you have space available in Swimbait box.", DOL.JobID)]
	FisherSwimbaitFeature = 9926,
#endif


	#endregion
	// ====================================================================================
	#region Common (100xx)

	#endregion
}
public static class CustomComboPresetExtensions {
	public static CustomComboPreset[] GetConflicts(this CustomComboPreset preset) => preset.GetAttribute<ConflictsAttribute>()?.Conflicts ?? [];
	public static CustomComboPreset[] GetAlternatives(this CustomComboPreset preset) => preset.GetAttribute<DeprecatedAttribute>()?.Recommended ?? [];
	public static CustomComboPreset? GetParent(this CustomComboPreset preset) => preset.GetAttribute<ParentPresetAttribute>()?.Parent;
	public static string GetDebugLabel(this CustomComboPreset preset) => $"{Enum.GetName(preset)!}#{(int)preset}";
}
