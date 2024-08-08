using System;

using Dalamud.Utility;

using PrincessRTFM.XIVComboVX.Attributes;
using PrincessRTFM.XIVComboVX.Combos;

namespace PrincessRTFM.XIVComboVX;

public enum CustomComboPreset {
	// Job ID 0 means "do not perform a class/job ID check".
	// Preset IDs below zero are NEVER enabled and are NOT shown in the config window.
	// Those that are non-negative but less than 100 are ALWAYS enabled, but are NOT shown in the config window.
	// Preset ID format is ??xxx where `??` is the job ID and `xxx` is the preset ID.
	// Always-on (universal) presets are in the `000xx` space, while job-agnostic toggle-able presets are in `001xx`.
	// DoL is given the special pseudo-ID of 99, and DoH (currently broken) is in 98, since there are multiple jobs that are
	// all close enough to each other that replacers for them should be shared.
	// Old preset IDs CANNOT be re-used, because if someone updates from a version that used them, past versions that didn't,
	// to a version that does for a new thing, they'll have an unknown new combo enabled without any idea of what happened.

	#region Universal (000xx)

	[CustomComboInfo("None", "This should not be displayed. This always returns false when used with IsEnabled.", 0)]
	None = -1,

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

	#endregion
	// ====================================================================================
	#region Common (001xx)

	#endregion
	// ====================================================================================
	#region ASTROLOGIAN (33xxx)
	// last used = 8

	[CustomComboInfo("Swiftcast Ascend", "Ascend turns into Swiftcast when available and reasonable.", AST.JobID)]
	AstrologianSwiftcastRaiserFeature = 33000,

	[CustomComboInfo("Benefic 2 to Benefic Level Sync", "Changes Benefic 2 to Benefic when below level 26.", AST.JobID)]
	AstrologianBeneficFeature = 33003,

	#endregion
	// ====================================================================================
	#region BLACK MAGE (25xxx)

	//[CustomComboInfo("Enochian Feature", "Change Fire 4 or Blizzard 4 to whichever action you can currently use.", BLM.JobID)]
	//BlackEnochianFeature = 25000,

	//[ParentPreset(BlackEnochianFeature)]
	//[CustomComboInfo("Enochian Despair Feature", "Change Fire 4 or Blizzard 4 to Despair when in Astral Fire with less than 2400 mana.", BLM.JobID)]
	//BlackEnochianDespairFeature = 25010,

	//[ParentPreset(BlackEnochianFeature)]
	//[CustomComboInfo("Enochian No Sync Feature", "Fire 4 and Blizzard 4 will not sync to Fire 1 and Blizzard 1.", BLM.JobID)]
	//BlackEnochianNoSyncFeature = 25018,

	//[CustomComboInfo("Umbral Soul/Transpose Switcher", "Change Transpose into Umbral Soul when Umbral Soul is usable.", BLM.JobID)]
	//BlackManaFeature = 25001,

	//[CustomComboInfo("(Between the) Ley Lines", "Change Ley Lines into BTL when Ley Lines is active.", BLM.JobID)]
	//BlackLeyLinesFeature = 25002,

	//[CustomComboInfo("Fire 1/3 Astral Feature", "Fire 1 becomes Fire 3 with 1 or fewer stacks of Astral Fire.", BLM.JobID)]
	//BlackFireAstralFeature = 25003,

	//[CustomComboInfo("Fire 1/3 Proc Feature", "Fire 1 becomes Fire 3 when Firestarter proc is up.", BLM.JobID)]
	//BlackFireProcFeature = 25009,

	//[CustomComboInfo("Blizzard 1/3 Feature", "Replace Blizzard 1 with Blizzard 3 when unlocked.", BLM.JobID)]
	//BlackBlizzardFeature = 25004,

	//[CustomComboInfo("Freeze/Flare Feature", "Freeze and Flare become whichever action you can currently use.", BLM.JobID)]
	//BlackFreezeFlareFeature = 25005,

	//[CustomComboInfo("Fire 2 Feature", "(High) Fire 2 becomes Flare in Astral Fire with 1 or fewer Umbral Hearts.", BLM.JobID)]
	//BlackFire2Feature = 25007,

	//[CustomComboInfo("Ice 2 Feature", "(High) Blizzard 2 becomes Freeze in Umbral Ice.", BLM.JobID)]
	//BlackBlizzard2Feature = 25008,

	//[CustomComboInfo("Fire 2/Ice 2 Option", "Fire 2 and Blizzard 2 will not change unless you're at max Astral Fire or Umbral Ice.", BLM.JobID)]
	//BlackFireBlizzard2Option = 25014,

	//[CustomComboInfo("Umbral Soul Feature", "Replace your ice spells with Umbral Soul, while in Umbral Ice and having no target.", BLM.JobID)]
	//BlackUmbralSoulFeature = 25017,

	//[CustomComboInfo("Scathe/Xenoglossy Feature", "Scathe becomes Xenoglossy when available.", BLM.JobID)]
	//BlackScatheFeature = 25006,

	//[CustomComboInfo("Fire to Ice 3 Feature", "When under 1600 MP and in Astral Fire, Blizzard will become Blizzard 3", BLM.JobID)]
	//BlackFireToIce3 = 25019,

	//[CustomComboInfo("Ice to Fire 3 Feature", "When in Umbral Ice, Fire will become Fire 3", BLM.JobID)]
	//BlackIceToFire3 = 25020,


	#endregion
	// ====================================================================================
	#region BARD (23xxx)

	[CustomComboInfo("Weave: Pitch Perfect", "Replaces Heavy Shot with Pitch Perfect when weaving and either Wanderer's Minuet is about to expire or Pitch Perfect reaches three stacks.", BRD.JobID)]
	BardWeavePitchPerfect = 23014,

	[CustomComboInfo("Weave: Battle Voice", "Replaces Heavy Shot with Battle Voice when weaving.", BRD.JobID)]
	BardWeaveBattleVoice = 23015,

	[CustomComboInfo("Weave: Raging Strikes", "Replaces Heavy Shot with Raging Strikes when weaving.", BRD.JobID)]
	BardWeaveRagingStrikes = 23016,

	[CustomComboInfo("Weave: Sidewinder", "Replaces Heavy Shot with Sidewinder when weaving.", BRD.JobID)]
	BardWeaveSidewinder = 23017,

	[CustomComboInfo("Weave: Empyreal Arrow", "Replaces Heavy Shot with Empyreal Arrow when weaving.", BRD.JobID)]
	BardWeaveEmpyrealArrow = 23018,

	[CustomComboInfo("Weave: Bloodletter", "Replaces Heavy Shot with Bloodletter when weaving.", BRD.JobID)]
	BardWeaveBloodletter = 23019,

	[CustomComboInfo("Weave: Rain of Death", "Replaces Heavy Shot with Rain of Death when weaving.", BRD.JobID)]
	BardWeaveDeathRain = 23020,

	[CustomComboInfo("Heavy Shot into Straight Shot", "Replaces Heavy Shot/Burst Shot with Straight Shot/Refulgent Arrow when procced.", BRD.JobID)]
	BardStraightShotUpgradeFeature = 23001,

	[CustomComboInfo("Heavy Jaws", "Replaces Heavy Shot/Burst Shot with Iron Jaws when your DoTs are below a configurable threshold.", BRD.JobID)]
	BardStraightShotIronJaws = 23022,

	[CustomComboInfo("Iron Bites", "Iron Jaws is replaced with Caustic Bite/Stormbite if one or both are not up.\nAlternates between the two if Iron Jaws isn't available.", BRD.JobID)]
	BardIronBites = 23002,

	[CustomComboInfo("Apex Arrow Feature", "Replaces Heavy Shot/Burst Shot, Quick Nock/Ladonsbite, and Shadowbite\nwith Blast Arrow when available, or Apex Arrow if gauge is full.", BRD.JobID)]
	BardApexFeature = 23003,

	[CustomComboInfo("Quick Nock / Ladonsbite into Shadowbite", "Replaces Quick Nock and Ladonsbite with Shadowbite when available.", BRD.JobID)]
	BardQuickNockLadonsbiteShadowbite = 23004,

	[CustomComboInfo("Rain of Shadows", "Replaces Shadowbite with Rain of Death when weaving or under level.", BRD.JobID)]
	BardShadowbiteDeathRain = 23021,

	[CustomComboInfo("Empyreal Sidewinder", "Replace Sidewinder and Empyreal Arrow with each other depending on which is available.", BRD.JobID)]
	BardEmpyrealSidewinder = 23009,

	[CustomComboInfo("Radiant Strikes Feature", "Replace Radiant Finale with Raging Strikes if Raging Strikes is available.\nThis takes priority over Battle Voice if Radiant Voice is enabled.", BRD.JobID)]
	BardRadiantStrikesFeature = 23011,

	[CustomComboInfo("Radiant Voice Feature", "Replace Radiant Finale with Battle Voice if Battle Voice is available.", BRD.JobID)]
	BardRadiantVoiceFeature = 23010,

	#endregion
	// ====================================================================================
	#region DANCER (38xxx)

	[CustomComboInfo("Single Target Multibutton", "Change Cascade into procs and combos as available.", DNC.JobID)]
	DancerSingleTargetMultibutton = 38000,

	[ParentPreset(DancerSingleTargetMultibutton)]
	[CustomComboInfo("Gauge Spender", "Also change into Saber Dance when you have at least the set amount of Esprit Gauge.", DNC.JobID)]
	DancerSingleTargetGaugeSpender = 38019,

	[ParentPreset(DancerSingleTargetMultibutton)]
	[CustomComboInfo("Starfall Saver", "Also change into Starfall Dance when your Flourishing Starfall effect has no more than a certain duration left.", DNC.JobID)]
	DancerSingleTargetStarfall = 38021,

	[ParentPreset(DancerSingleTargetMultibutton)]
	[CustomComboInfo("Flourish Weaving", "Also change into Flourish when you can weave without clipping AND have none of the effects Flourish grants.", DNC.JobID)]
	DancerSingleTargetFlourishWeave = 38017,

	[ParentPreset(DancerSingleTargetMultibutton)]
	[CustomComboInfo("Devilment Weaving", "Also change into Devilment when you can weave without clipping and Devilment is off cooldown.", DNC.JobID)]
	DancerSingleTargetDevilmentWeave = 38023,

	[ParentPreset(DancerSingleTargetMultibutton)]
	[CustomComboInfo("Fan Dance 1/3 Weaving", "Also change into Fan Dance 1/3 when you can weave without clipping.", DNC.JobID)]
	DancerSingleTargetFanDanceWeave = 38010,

	[ParentPreset(DancerSingleTargetFanDanceWeave)]
	[CustomComboInfo("Fan Dance 2/4 Fallback", "Also change into Fan Dance 2/4, with lower priority than 1/3.", DNC.JobID)]
	DancerSingleTargetFanDanceFallback = 38012,

	[CustomComboInfo("AoE Multibutton", "Change Windmill into procs and combos as available.", DNC.JobID)]
	DancerAoeMultibutton = 38001,

	[ParentPreset(DancerAoeMultibutton)]
	[CustomComboInfo("Gauge Spender", "Also change into Saber Dance when you have at least the set amount of Esprit Gauge.", DNC.JobID)]
	DancerAoeGaugeSpender = 38020,

	[ParentPreset(DancerAoeMultibutton)]
	[CustomComboInfo("Starfall Saver", "Also change into Starfall Dance when your Flourishing Starfall effect has no more than a certain duration left.", DNC.JobID)]
	DancerAoeStarfall = 38022,

	[ParentPreset(DancerAoeMultibutton)]
	[CustomComboInfo("Flourish Weaving", "Also change into Flourish when you can weave without clipping AND have none of the effects Flourish grants.", DNC.JobID)]
	DancerAoeFlourishWeave = 38018,

	[ParentPreset(DancerAoeMultibutton)]
	[CustomComboInfo("Fan Dance 2/4 Weaving", "Also change into Fan Dance 2/4 when you can weave without clipping.", DNC.JobID)]
	DancerAoeFanDanceWeave = 38011,

	[ParentPreset(DancerAoeFanDanceWeave)]
	[CustomComboInfo("Fan Dance 1/3 Fallback", "Also change into Fan Dance 1/3, with lower priority than 2/4.", DNC.JobID)]
	DancerAoeFanDanceFallback = 38013,

	[CustomComboInfo("Flourish Dance 4", "Change Flourish into Fan Dance 4 when available.", DNC.JobID)]
	DancerFlourishFeature = 38004,

	[Conflicts(DancerDanceComboCompatibility)]
	[CustomComboInfo("Dance Step Combo", "Change Standard Step and Technical Step into each dance step while dancing.", DNC.JobID)]
	DancerDanceStepCombo = 38005,

	[ParentPreset(DancerDanceStepCombo)]
	[CustomComboInfo("Alternative Dance: Standard Step", "Also change Standard Step into Technical Step when ready and Standard Step's cooldown has more than 3 seconds left.", DNC.JobID)]
	DancerDanceStepComboSmartStandard = 38024,

	[ParentPreset(DancerDanceStepCombo)]
	[CustomComboInfo("Alternative Dance: Technical Step", "Also change Technical Step into Standard Step when Technical Step is unavailable or on cooldown.", DNC.JobID)]
	DancerDanceStepComboSmartTechnical = 38025,

	[ParentPreset(DancerDanceStepCombo)]
	[CustomComboInfo("Smart Dance", "Change your normal ST/AOE combos into the next dance steps (and then the finishers) while dancing.", DNC.JobID)]
	DancerSmartDanceFeature = 38014,

	[CustomComboInfo("Devilment Feature", "Change Devilment into Starfall Dance after use.", DNC.JobID)]
	DancerDevilmentFeature = 38007,

	[CustomComboInfo("Fan Dance 1/3 Combo", "Change Fan Dance 1 into Fan Dance 3 when available.", DNC.JobID)]
	DancerFanDance13Combo = 38002,

	[CustomComboInfo("Fan Dance 1/4 Combo", "Change Fan Dance 1 into Fan Dance 4 when available.", DNC.JobID)]
	DancerFanDance14Combo = 38008,

	[CustomComboInfo("Fan Dance 2/3 Combo", "Change Fan Dance 2 into Fan Dance 3 when available.", DNC.JobID)]
	DancerFanDance23Combo = 38003,

	[CustomComboInfo("Fan Dance 2/4 Combo", "Change Fan Dance 2 into Fan Dance 4 when available.", DNC.JobID)]
	DancerFanDance24Combo = 38009,

	[CustomComboInfo("Curing Wind Level Sync", "Change Curing Waltz into Second Wind when under level.", DNC.JobID)]
	DancerCuringWaltzLevelSync = 38015,

	[CustomComboInfo("Curing Wind Cooldown Swap", "Change Curing Waltz into Second Wind when Waltz is on CD.", DNC.JobID)]
	DancerCuringWaltzCooldownSwap = 38016,

	[Conflicts(DancerDanceStepCombo)]
	[Deprecated(DancerDanceStepCombo, DancerSmartDanceFeature)]
	[CustomComboInfo("Dance Step Feature", "Change custom actions into dance steps while dancing." +
		"\nYou can get Action IDs with Garland Tools by searching for the action and clicking the cog.", DNC.JobID)]
	DancerDanceComboCompatibility = 38006,

	#endregion
	// ====================================================================================
	#region DRAGOON (22xxx)

	[CustomComboInfo("Second Wind / Bloodbath", "Replace Bloodbath and Second Wind with each other based on cooldown, or with only Second Wind when under level.\nIf both are available, the button will default to whichever you placed on your hotbar.", DRG.JobID)]
	DragoonBloodbathReplacer = 22018,

	//[CustomComboInfo("Coerthan Torment Combo", "Replace Coerthan Torment with its combo chain.", DRG.JobID)]
	//DragoonCoerthanTormentCombo = 22000,

	//[CustomComboInfo("Coerthan Torment Wyrmwind Feature", "Replace Coerthan Torment with Wyrmwind Thrust when you have two Firstminds' Focus.", DRG.JobID)]
	//DragoonCoerthanWyrmwindFeature = 22009,

	//[CustomComboInfo("Chaos Thrust Combo", "Replace Chaos Thrust with its combo chain.", DRG.JobID)]
	//DragoonChaosThrustCombo = 22001,

	//[ParentPreset(DragoonChaosThrustCombo)]
	//[CustomComboInfo("Chaos Thrust from Disembowl", "Start the Chaos Thrust combo chain with Disembowl instead of True Thrust.", DRG.JobID)]
	//DragoonChaosThrustLateOption = 22007,

	//[CustomComboInfo("Full Thrust Combo", "Replace Full Thrust with its combo chain.", DRG.JobID)]
	//DragoonFullThrustCombo = 22002,

	//[ParentPreset(DragoonFullThrustCombo)]
	//[CustomComboInfo("Full Thrust from Vorpal", "Start the Full Thrust combo chain with Vorpal Thrust instead of True Thrust.", DRG.JobID)]
	//DragoonFullThrustLateOption = 22008,

	//[ParentPreset(DragoonFullThrustCombo)]
	//[CustomComboInfo("Power Surge Buff Saver", "When the Power Surge buff is about to run out (or isn't up), execute the Chaos Thrust chain to use Disembowl.", DRG.JobID)]
	//DragoonFullThrustBuffSaver = 22012,

	//[ParentPreset(DragoonFullThrustCombo)]
	//[CustomComboInfo("Chaos Thrust DoT Saver", "When the Chaos Thrust DoT is about to run out on your current target (or isn't up), execute the Chaos Thrust chain.", DRG.JobID)]
	//DragoonFullThrustDotSaver = 22018,

	//[Experimental]
	//[CustomComboInfo("Total Thrust Combo", "", DRG.JobID)]
	//DragoonTotalThrustCombo = 22014,

	//[ParentPreset(DragoonTotalThrustCombo)]
	//[CustomComboInfo("Power Surge Buff Saver", "When the Power Surge buff is about to run out (or isn't up), execute the Chaos Thrust chain to use Disembowl.", DRG.JobID)]
	//DragoonTotalThrustBuffSaver = 22015,

	//[ParentPreset(DragoonTotalThrustCombo)]
	//[CustomComboInfo("Chaos Thrust DoT Saver", "When the Chaos Thrust DoT is about to run out on your current target (or isn't up), execute the Chaos Thrust chain.", DRG.JobID)]
	//DragoonTotalThrustDotSaver = 22016,

	//[ParentPreset(DragoonTotalThrustCombo)]
	//[CustomComboInfo("Full Thrust from Vorpal", "Start the Full Thrust combo chain with Vorpal Thrust instead of True Thrust.", DRG.JobID)]
	//DragoonTotalThrustVorpalSkipFirst = 22017,

	//[Conflicts(DragoonStardiverDragonfireDiveFeature)]
	//[CustomComboInfo("Stardiver to Nastrond", "Replace Stardiver with Nastrond when Nastrond is off-cooldown, and Geirskogul outside of Life of the Dragon.", DRG.JobID)]
	//DragoonStardiverNastrondFeature = 22010,

	//[Conflicts(DragoonStardiverNastrondFeature)]
	//[CustomComboInfo("Stardiver to Dragonfire Dive", "Replace Stardiver with Dragonfire Dive when the latter is off cooldown (and you have more than 7.5s of LotD left), or outside of Life of the Dragon.", DRG.JobID)]
	//DragoonStardiverDragonfireDiveFeature = 22011,

	//[Conflicts(DragoonStardiverDragonfireDiveFeature, DragoonStardiverNastrondFeature)]
	//[CustomComboInfo("Dive Dive Dive!", "Replace Spineshatter Dive, Dragonfire Dive, and Stardiver with whichever is available.", DRG.JobID)]
	//DragoonDiveFeature = 22005,

	//[CustomComboInfo("Mirage Jump", "Replace Jump and High Jump with Mirage Dive when Dive Ready.", DRG.JobID)]
	//DragoonMirageJumpFeature = 22013,

	#endregion
	// ====================================================================================
	#region DARK KNIGHT (32xxx)

	[CustomComboInfo("Stun/Interrupt Feature", "Turn Low Blow and Interject into Interject when off CD and your target can be interrupted, Low Blow otherwise.", DRK.JobID)]
	DarkStunInterruptFeature = 32005,

	[CustomComboInfo("Souleater Combo", "Replace Souleater with its combo chain.", DRK.JobID)]
	DarkSouleaterCombo = 32000,

	[ParentPreset(DarkSouleaterCombo)]
	[CustomComboInfo("Souleater Overcap Feature", "Replace Souleater with Bloodspiller when the next combo action would cause the Blood Gauge to overcap.", WAR.JobID)]
	DarkSouleaterOvercapFeature = 32006,

	[CustomComboInfo("Stalwart Soul Combo", "Replace Stalwart Soul with its combo chain.", DRK.JobID)]
	DarkStalwartSoulCombo = 32001,

	[ParentPreset(DarkStalwartSoulCombo)]
	[CustomComboInfo("Stalwart Soul Overcap Feature", "Replace Stalwart Soul with Quietus when the next combo action would cause the Blood Gauge to overcap.", WAR.JobID)]
	DarkStalwartSoulOvercapFeature = 32007,

	[CustomComboInfo("Delirium Feature", "Replace Souleater and Stalwart Soul with Bloodspiller and Quietus when Delirium is active.", DRK.JobID)]
	DarkDeliriumFeature = 32002,

	[CustomComboInfo("Shadows Galore", "Replace Flood and Edge of Darkness with Shadowbringer when under Darkside with less than 6000 MP left.", DRK.JobID)]
	DarkShadowbringerFeature = 32004,

	[CustomComboInfo("Blood Weapon Feature", "Replace Carve and Spit, and Abyssal Drain with Blood Weapon when available.", DRK.JobID)]
	DarkBloodWeaponFeature = 32010,

	[CustomComboInfo("Living Shadow Feature", "Replace Quietus and Bloodspiller with Living Shadow when available.", DRK.JobID)]
	DarkLivingShadowFeature = 32011,

	[CustomComboInfo("Living Shadowbringer Feature", "Replace Living Shadow with Shadowbringer when charges are available and your Shadow is present.", DRK.JobID)]
	DarkLivingShadowbringerFeature = 32008,

	[CustomComboInfo("Missing Shadowbringer Feature", "Replace Living Shadow with Shadowbringer when charges are available and Living Shadow is on cooldown.", DRK.JobID)]
	DarkLivingShadowbringerHpFeature = 32009,

	#endregion
	// ====================================================================================
	#region GUNBREAKER (37xxx)

	[CustomComboInfo("Stun/Interrupt Feature", "Turn Low Blow and Interject into Interject when off CD and your target can be interrupted, Low Blow otherwise.", GNB.JobID)]
	GunbreakerStunInterruptFeature = 37010,

	[CustomComboInfo("Solid Barrel Combo", "Replace Solid Barrel with its combo chain.", GNB.JobID)]
	GunbreakerSolidBarrelCombo = 37000,

	[ParentPreset(GunbreakerSolidBarrelCombo)]
	[CustomComboInfo("Burst Strike Feature", "Replace Solid Barrel with Burst Strike when charges are full.", GNB.JobID)]
	GunbreakerBurstStrikeFeature = 37011,

	[CustomComboInfo("Gnashing Fang Continuation", "Replace Gnashing Fang with Continuation moves when appropriate.", GNB.JobID)]
	GunbreakerGnashingFangCont = 37002,

	[CustomComboInfo("Burst Strike Continuation", "Replace Burst Strike with Continuation moves when appropriate.", GNB.JobID)]
	GunbreakerBurstStrikeCont = 37008,

	[CustomComboInfo("Demon Slaughter Combo", "Replace Demon Slaughter with its combo chain.", GNB.JobID)]
	GunbreakerDemonSlaughterCombo = 37003,

	[ParentPreset(GunbreakerDemonSlaughterCombo)]
	[CustomComboInfo("Fated Circle Feature", "In addition to the Demon Slaughter combo, add Fated Circle when charges are full.", GNB.JobID)]
	GunbreakerFatedCircleFeature = 37004,

	[CustomComboInfo("Empty Bloodfest Feature", "Replace Burst Strike and Fated Circle with Bloodfest if the powder gauge is empty.", GNB.JobID)]
	GunbreakerEmptyBloodfestFeature = 37005,

	[CustomComboInfo("No Mercy - Double Down", "Replace No Mercy with Double Down while No Mercy is active, 2 cartridges are available, and Double Down is off cooldown.\nThis takes priority over the No Mercy Bow Shock/Sonic Break Feature.", GNB.JobID)]
	GunbreakerNoMercyDoubleDownFeature = 37012,

	[CustomComboInfo("Always Double Down", "Replace No Mercy with Double Down while No Mercy is active.", GNB.JobID)]
	GunbreakerNoMercyAlwaysDoubleDownFeature = 37013,

	[CustomComboInfo("Double Down Feature", "Replace Burst Strike and Fated Circle with Double Down when available.", GNB.JobID)]
	GunbreakerDoubleDownFeature = 37009,

	[CustomComboInfo("Gnashing Strike Feature", "Replace Gnashing Fang with Burst Strike when No Mercy is active and Gnashing Fang and Double Down are on cooldown, or you are too low level to use them.", GNB.JobID)]
	GunbreakerGnashingStrikeFeature = 37014,

	[ParentPreset(GunbreakerSolidBarrelCombo)]
	[CustomComboInfo("Lighting Shot Ranged Uptime Feature", "Replace Solid Barrel with Lightning Shot when out of melee range and in combat.", GNB.JobID)]
	GunbreakerRangedUptime = 37015,

	[ParentPreset(GunbreakerSolidBarrelCombo)]
	[CustomComboInfo("No Mercy Feature", "Replace Solid Barrel with No Mercy when Gnashing Fang is ready.", GNB.JobID)]
	GunbreakerSolidNoMercy = 37016,

	[ParentPreset(GunbreakerSolidBarrelCombo)]
	[CustomComboInfo("Bloodfest Feature", "Replace Solid Barrel with Bloodfest when there is no ammo and you are under No Mercy.", GNB.JobID)]
	GunbreakerSolidBloodfest = 37017,

	[ParentPreset(GunbreakerSolidBarrelCombo)]
	[CustomComboInfo("Danger Zone/Blasting Zone Feature", "Replace Solid Barrel with Danger Zone/Blasting Zone after Gnashing Fang is used.", GNB.JobID)]
	GunbreakerSolidDangerZone = 37018,

	[ParentPreset(GunbreakerSolidBarrelCombo)]
	[CustomComboInfo("Gnashing Fang/Continuation Feature", "Replace Solid Barrel with Gnashing Fang and Continuation when Gnashing Fang is available and will hold for No Mercy when it is available.", GNB.JobID)]
	GunbreakerSolidGnashingFang = 37019,

	[ParentPreset(GunbreakerSolidBarrelCombo)]
	[CustomComboInfo("Bow Shock Feature", "Replace Solid Barrel with Bow Shock when you are under No Mercy.", GNB.JobID)]
	GunbreakerSolidBowShock = 37020,

	[ParentPreset(GunbreakerSolidBarrelCombo)]
	[CustomComboInfo("Sonic Break Feature", "Replace Solid Barrel with Sonic Break when you are under No Mercy.", GNB.JobID)]
	GunbreakerSolidSonicBreak = 37021,

	[ParentPreset(GunbreakerSolidBarrelCombo)]
	[CustomComboInfo("Double Down Feature", "Replace Solid Barrel with Double Down when you are under No Mercy and have the required ammo.", GNB.JobID)]
	GunbreakerSolidDoubleDown = 37022,

	[ParentPreset(GunbreakerGnashingFangCont)]
	[CustomComboInfo("No Mercy Feature", "Replace Gnashing Fang with No Mercy when both No Mercy and Gnashing Fang are ready to be used.", GNB.JobID)]
	GunbreakerGnashingFangNoMercy = 37024,

	[ParentPreset(GunbreakerGnashingFangCont)]
	[CustomComboInfo("Danger Zone/Blasting Zone Feature", "Replace Gnashing Fang with Danger Zone/Blasting Zone when available.", GNB.JobID)]
	GunbreakerGnashingFangDangerZone = 37025,

	[ParentPreset(GunbreakerGnashingFangCont)]
	[CustomComboInfo("Bow Shock Feature", "Replace Gnashing Fang with Bow Shock when available and when you are under No Mercy.", GNB.JobID)]
	GunbreakerGnashingFangBowShock = 37026,

	[ParentPreset(GunbreakerGnashingFangCont)]
	[CustomComboInfo("Double Down Feature", "Replace Gnashing Fang with Double Down when available and when you are under No Mercy and have the required ammo.", GNB.JobID)]
	GunbreakerGnashingFangDoubleDown = 37027,

	[ParentPreset(GunbreakerGnashingFangCont)]
	[CustomComboInfo("Sonic Break Feature", "Replace Gnashing Fang with Sonic Break when available and when you are under No Mercy.", GNB.JobID)]
	GunbreakerGnashingFangSonicBreak = 37028,

	[CustomComboInfo("Gnashing Bloodfest Feature", "Weave Bloodfest onto Gnashing Fang when out of ammo and under No Mercy.", GNB.JobID)]
	GunbreakerGnashingBloodfest = 37029,

	#endregion
	// ====================================================================================
	#region MACHINIST (31xxx)

	[CustomComboInfo("(Heated) Shot Combo", "Replace either form of Clean Shot with its combo chain.", MCH.JobID)]
	MachinistMainCombo = 31000,

	[ParentPreset(MachinistMainCombo)]
	[CustomComboInfo("Reassembled override", "Replace Clean Shot combo with Excavator, Chain Saw, Drill, or Air Anchor when Reassembled.\nTries to avoid overcapping battery if possible.\nWill also become Hot Shot when you are under level for Clean Shot, which is a potency increase.", MCH.JobID)]
	MachinistMainComboReassembledOverride = 31013,

	[ParentPreset(MachinistMainCombo)]
	[CustomComboInfo("Heat Blast override", "Replace Clean Shot combo with Heat Blast while overheated.\nAlso respects the Heat Blast weaving option under the Gauss Riccochet feature.", MCH.JobID)]
	MachinistMainComboHeatBlast = 31008,

	[CustomComboInfo("Spread Shot Heat", "Replace Spread Shot / Scattergun with Auto Crossbow when overheated.", MCH.JobID)]
	MachinistSpreadShot = 31001,

	[CustomComboInfo("Hypercharged Hot Crossbow", "Replace Heat Blast and Auto Crossbow with Hypercharge when not overheated.", MCH.JobID)]
	MachinistSmartHeatup = 31002,

	[CustomComboInfo("Hypercharged Stabiliser", "Replace Hypercharge with Barrel Stabilizer if available, not overheated, and you have less than 50 heat.", MCH.JobID)]
	MachinistHyperchargeStabiliser = 31017,

	[CustomComboInfo("Hypercharged Wildfire", "Replace Hypercharge with Wildfire if available, overheated, and you have a target.", MCH.JobID)]
	MachinistHyperchargeWildfire = 31009,

	[CustomComboInfo("Overdriver", "Replace Rook Autoturret and Automaton Queen with their respective Overdrive while active.", MCH.JobID)]
	MachinistOverdrive = 31003,

	[CustomComboInfo("Gauss Ricochet", "Replace Gauss Round and Ricochet with one or the other depending on which has less recharge time left.", MCH.JobID)]
	MachinistGaussRoundRicochet = 31004,

	[ParentPreset(MachinistGaussRoundRicochet)]
	[CustomComboInfo("Overheated only", "Replace Gauss Round and Ricochet with one or the other only while overheated.", MCH.JobID)]
	MachinistGaussRoundRicochetLimiter = 31010,

	[ParentPreset(MachinistGaussRoundRicochet)]
	[CustomComboInfo("Heat Blast weaving", "Replace Heat Blast with Gauss Round or Riccochet while weaving.", MCH.JobID)]
	MachinistHeatBlastWeaveGaussRoundRicochet = 31015,

	[CustomComboInfo("Smart Hot Shot / Air Anchor / Drill", "Replace Hot Shot (Air Anchor) and Drill with whichever is available.\nTries to avoid overcapping battery, but only if that would NOT present a potency loss.", MCH.JobID)]
	MachinistDrillAirAnchor = 31005,

	[ParentPreset(MachinistDrillAirAnchor)]
	[CustomComboInfo("With Chain Saw", "Also allow the above to become Chain Saw.\nChain Saw itself will not change.", MCH.JobID)]
	MachinistDrillAirAnchorPlus = 31006,

	[CustomComboInfo("Tactical Dismantle", "Change Tactician and Dismantle into each other when one is on cooldown.\nAlso prevents wasting Tactician when under BRD's Troubadour or DNC's Shield Samba.", MCH.JobID)]
	MachinistTacticianDismantle = 31012,

	#endregion
	// ====================================================================================
	#region MONK (20xxx)

	[CustomComboInfo("Second Wind / Bloodbath", "Replace Bloodbath and Second Wind with each other based on cooldown, or with only Second Wind when under level.\nIf both are available, the button will default to whichever you placed on your hotbar.", MNK.JobID)]
	MonkBloodbathReplacer = 20018,

	//[CustomComboInfo("Monk AoE Combo", "Replaces the selected actions with the AoE combo chain.", MNK.JobID)]
	//MonkAoECombo = 20000,

	//[ParentPreset(MonkAoECombo)]
	//[CustomComboInfo("On Destroyer", "Replaces (Arm/Shadow) of the Destroyer with the AoE combo chain.", MNK.JobID)]
	//MonkAoECombo_Destroyers = 20099,

	//[ParentPreset(MonkAoECombo)]
	//[CustomComboInfo("On Masterful Blitz", "Replaces Masterful Blitz with the AoE combo chain.", MNK.JobID)]
	//MonkAoECombo_MasterBlitz = 20098,

	//[ParentPreset(MonkAoECombo)]
	//[CustomComboInfo("On Rockbreaker", "Replaces Rockbreaker with the AoE combo chain.", MNK.JobID)]
	//MonkAoECombo_Rockbreaker = 20097,

	//[CustomComboInfo("Monk ST Combo", "Replace Bootshine with all single-target rotation actions", MNK.JobID)]
	//MonkSTCombo = 20017,

	//[CustomComboInfo("Dragon Kick to Bootshine Feature", "Replaces Dragon Kick with Bootshine if Leaden Fist is up.", MNK.JobID)]
	//MonkBootshineFeature = 20001,

	//[CustomComboInfo("Dragon Kick to Masterful Blitz Feature", "Replaces Dragon Kick with Masterful Blitz if you have three Beast Chakra.", MNK.JobID)]
	//MonkDragonKickBalanceFeature = 20012,

	//[CustomComboInfo("Dragon Meditation Feature", "Replace Dragon Kick with Meditation when out of combat and the Fifth Chakra is not open.", MNK.JobID)]
	//MonkDragonKickMeditationFeature = 20015,

	//[CustomComboInfo("Steel Peak / Forbidden Chakra Feature", "Replace Dragon Kick with Meditation / Steel Peak / The Forbidden Chakra when in of combat and the Fifth Chakra is open.", MNK.JobID)]
	//MonkDragonKickSteelPeakFeature = 20016,

	//[CustomComboInfo("Twin Snakes to True Strike Feature", "Replaces Twin Snakes with True Strike if Disciplined Fist is up.\nAlso applies to the ST combo feature.", MNK.JobID)]
	//MonkTwinSnakesFeature = 20010,

	//[CustomComboInfo("Demolish to Snap Punch Feature", "Replaces Demolish with Snap Punch if target is under Demolish.\nAlso applies to the ST combo feature.", MNK.JobID)]
	//MonkDemolishFeature = 20011,

	//[CustomComboInfo("Howling Fist / Meditation Feature", "Replaces Howling Fist with Meditation when the Fifth Chakra is not open.", MNK.JobID)]
	//MonkHowlingFistMeditationFeature = 20002,

	//[CustomComboInfo("Perfect Balance Feature", "Replace Perfect Balance with Masterful Blitz when you have 3 Beast Chakra, or when under Perfect Balance already.", MNK.JobID)]
	//MonkPerfectBalanceFeature = 20004,

	//[CustomComboInfo("Riddle of Brotherly Fire", "Replace Riddle of Fire with Brotherhood if the former is on CD and the latter isn't.", MNK.JobID)]
	//MonkBrotherlyFire = 20013,

	//[CustomComboInfo("Riddle of Fire and Wind", "Replace Riddle of Fire with Riddle of Wind if the former is on CD and the latter isn't.", MNK.JobID)]
	//MonkFireWind = 20014,

	#endregion
	// ====================================================================================
	#region NINJA (30xxx)

	[CustomComboInfo("Second Wind / Bloodbath", "Replace Bloodbath and Second Wind with each other based on cooldown, or with only Second Wind when under level.\nIf both are available, the button will default to whichever you placed on your hotbar.", NIN.JobID)]
	NinjaBloodbathReplacer = 30037,

	[CustomComboInfo("Armor Crush Combo", "Replace Armor Crush with its combo chain.", NIN.JobID)]
	NinjaArmorCrushCombo = 30000,

	[ParentPreset(NinjaArmorCrushCombo)]
	[CustomComboInfo("Smart Weave: Bunshin", "Weave into Bunshin when available.", NIN.JobID)]
	NinjaArmorCrushBunshinFeature = 30030,

	[ParentPreset(NinjaArmorCrushCombo)]
	[CustomComboInfo("Smart Weave: Bhavacakra", "Weave into Bhavacakra when available and Bunshin is on cooldown.\nAlso applies if Smart Weave: Bunshin is not enabled.", NIN.JobID)]
	NinjaArmorCrushBhavacakraFeature = 30031,

	[ParentPreset(NinjaArmorCrushCombo)]
	[CustomComboInfo("Smart Weave: Assassinate/DWaD", "Weave into Assassinate / Dream Within a Dream when available.", NIN.JobID)]
	NinjaArmorCrushAssasinateFeature = 30032,

	[ParentPreset(NinjaArmorCrushCombo)]
	[CustomComboInfo("Gauge Saver", "Replaces Armor Crush with Aeolian Edge when at 4 or 5 stacks of Kazematoi.", NIN.JobID)]
	NinjaArmorCrushGaugeSaver = 30038,

	[ParentPreset(NinjaArmorCrushCombo)]
	[CustomComboInfo("Phantom Kamaitachi Feature", "Replaces the combo with Phantom Kamaitachi when you have no stacks of Bunshin.", NIN.JobID)]
	NinjaArmorCrushKamaitachiFeature = 30028,

	[ParentPreset(NinjaArmorCrushCombo)]
	[Conflicts(NinjaArmorCrushForkedRaijuFeature, NinjaArmorCrushFleetingRaijuFeature)]
	[CustomComboInfo("Smart Raiju Feature", "Replaces the Armor Crush combo with Forked/Fleeting Raiju when available, depending on how far your target is.", NIN.JobID)]
	NinjaArmorCrushSmartRaijuFeature = 30021,

	[ParentPreset(NinjaArmorCrushCombo)]
	[Conflicts(NinjaArmorCrushForkedRaijuFeature)]
	[CustomComboInfo("Fleeting Raiju Feature", "Replaces the Armor Crush combo with Fleeting Raiju when available.", NIN.JobID)]
	NinjaArmorCrushFleetingRaijuFeature = 30010,

	[ParentPreset(NinjaArmorCrushCombo)]
	[Conflicts(NinjaArmorCrushFleetingRaijuFeature)]
	[CustomComboInfo("Forked Raiju Feature", "Replaces the Armor Crush combo with Forked Raiju when available.", NIN.JobID)]
	NinjaArmorCrushForkedRaijuFeature = 30017,

	[ParentPreset(NinjaArmorCrushCombo)]
	[CustomComboInfo("Distant Daggers Feature", "Replaces the Armor Crush combo with Throwing Dagger when the current target is out of melee range.\nUses Phantom Kamaitachi instead when available.", NIN.JobID)]
	NinjaArmorCrushThrowingDaggerFeature = 30018,

	[ParentPreset(NinjaArmorCrushCombo)]
	[CustomComboInfo("Fallback to Aeolian Edge", "Replaces Armor Crush with Aeolian Edge when underlevel.", NIN.JobID)]
	NinjaArmorCrushFallbackFeature = 30020,

	[CustomComboInfo("Aeolian Edge Combo", "Replace Aeolian Edge with its combo chain.", NIN.JobID)]
	NinjaAeolianEdgeCombo = 30001,

	[ParentPreset(NinjaAeolianEdgeCombo)]
	[CustomComboInfo("Smart Weave: Bunshin", "Weave into Bunshin when available.", NIN.JobID)]
	NinjaAeolianEdgeBunshinFeature = 30033,

	[ParentPreset(NinjaAeolianEdgeCombo)]
	[CustomComboInfo("Smart Weave: Bhavacakra", "Weave into Bhavacakra when available and Bunshin is on cooldown.\nAlso applies if Smart Weave: Bunshin is not enabled.", NIN.JobID)]
	NinjaAeolianEdgeBhavacakraFeature = 30034,

	[ParentPreset(NinjaAeolianEdgeCombo)]
	[CustomComboInfo("Smart Weave: Assassinate/DWaD", "Weave into Assassinate / Dream Within a Dream when available.", NIN.JobID)]
	NinjaAeolianEdgeAssasinateFeature = 30035,

	[ParentPreset(NinjaAeolianEdgeCombo)]
	[CustomComboInfo("Gauge Saver", "Replaces Aeolian Edge with Armor Crush when at 0 stacks of Kazematoi.", NIN.JobID)]
	NinjaAeolianEdgeGaugeSaver = 30039,

	[ParentPreset(NinjaAeolianEdgeCombo)]
	[CustomComboInfo("Phantom Kamaitachi Feature", "Replaces the combo with Phantom Kamaitachi when you have no stacks of Bunshin.", NIN.JobID)]
	NinjaAeolianEdgeKamaitachiFeature = 30029,

	[ParentPreset(NinjaAeolianEdgeCombo)]
	[Conflicts(NinjaAeolianEdgeFleetingRaijuFeature, NinjaAeolianEdgeForkedRaijuFeature)]
	[CustomComboInfo("Smart Raiju Feature", "Replaces the Aeolian Edge combo with Forked/Fleeting Raiju when available, depending on how far your target is.", NIN.JobID)]
	NinjaAeolianEdgeSmartRaijuFeature = 30022,

	[ParentPreset(NinjaAeolianEdgeCombo)]
	[Conflicts(NinjaAeolianEdgeSmartRaijuFeature, NinjaAeolianEdgeForkedRaijuFeature)]
	[CustomComboInfo("Fleeting Raiju Feature", "Replaces the Aeolian Edge combo with Fleeting Raiju when available.", NIN.JobID)]
	NinjaAeolianEdgeFleetingRaijuFeature = 30011,

	[ParentPreset(NinjaAeolianEdgeCombo)]
	[Conflicts(NinjaAeolianEdgeSmartRaijuFeature, NinjaAeolianEdgeFleetingRaijuFeature)]
	[CustomComboInfo("Forked Raiju Feature", "Replaces the Aeolian Edge combo with Forked Raiju when available.", NIN.JobID)]
	NinjaAeolianEdgeForkedRaijuFeature = 30016,

	[ParentPreset(NinjaAeolianEdgeCombo)]
	[CustomComboInfo("Distant Daggers Feature", "Replaces the Aeolian Edge combo with Throwing Dagger when the current target is out of melee range.\nUses Phantom Kamaitachi instead when available.", NIN.JobID)]
	NinjaAeolianEdgeThrowingDaggerFeature = 30019,

	[CustomComboInfo("Hakke Mujinsatsu Combo", "Replace Hakke Mujinsatsu with its combo chain.", NIN.JobID)]
	NinjaHakkeMujinsatsuCombo = 30002,

	[CustomComboInfo("Smart Hide", "Replaces Hide with Trick Attack while under the effect of Suiton or Hidden AND with a target, or else Mug if in combat.", NIN.JobID)]
	NinjaSmartHideFeature = 30004,

	[CustomComboInfo("GCDs to Ninjutsu Feature", "Every GCD combo becomes Ninjutsu while Mudras are being used.", NIN.JobID)]
	NinjaGCDNinjutsuFeature = 30005,

	[CustomComboInfo("Kassatsu to Trick", "Replaces Kassatsu with Trick Attack while Suiton or Hidden is up.\nCooldown tracking plugin recommended.", NIN.JobID)]
	NinjaKassatsuTrickFeature = 30006,

	[CustomComboInfo("Ten Chi Jin to Meisui", "Replaces Ten Chi Jin (the move) with Meisui while Suiton is up.\nCooldown tracking plugin recommended.", NIN.JobID)]
	NinjaTCJMeisuiFeature = 30007,

	[CustomComboInfo("Ten Chi Jin to Tenri Jindo", "Replaces Ten Chi Jin (the move) with Tenri Jindo when available.", NIN.JobID)]
	NinjaTCJTenriJindo = 30036,

	[CustomComboInfo("Kassatsu Chi/Jin Feature", "Replaces Chi with Jin while Kassatsu is up if you have Enhanced Kassatsu.", NIN.JobID)]
	NinjaKassatsuChiJinFeature = 30008,

	[Conflicts(NinjaHuraijinFleetingRaijuFeature, NinjaHuraijinForkedRaijuFeature)]
	[CustomComboInfo("Smart Huraiju Feature", "Replaces Huraijin with Forked/Fleeting Raiju when available, depending on how far your target is.", NIN.JobID)]
	NinjaHuraijinSmartRaijuFeature = 30025,

	[Conflicts(NinjaHuraijinSmartRaijuFeature, NinjaHuraijinFleetingRaijuFeature)]
	[CustomComboInfo("Forked Huraijin Feature", "Replaces Huraijin with Forked Raiju when available.", NIN.JobID)]
	NinjaHuraijinForkedRaijuFeature = 30012,

	[Conflicts(NinjaHuraijinSmartRaijuFeature, NinjaHuraijinForkedRaijuFeature)]
	[CustomComboInfo("Fleeting Huraijin Feature", "Replaces Huraijin with Fleeting Raiju when available.", NIN.JobID)]
	NinjaHuraijinFleetingRaijuFeature = 30015,

	[CustomComboInfo("Huraijin / Crush Feature", "Replaces Huraijin with Armor Crush after Gust Slash.", NIN.JobID)]
	NinjaHuraijinCrushFeature = 30013,

	[Deprecated("This option will OVERRIDE the listed alternatives, preventing fine-grained control. If you want the existing functionality, enable all six recommended alternatives.",
		NinjaArmorCrushAssasinateFeature, NinjaAeolianEdgeAssasinateFeature,
		NinjaArmorCrushBunshinFeature, NinjaAeolianEdgeBunshinFeature,
		NinjaArmorCrushBhavacakraFeature, NinjaAeolianEdgeBhavacakraFeature
	)]
	[CustomComboInfo("Single Target Smart Weave", "Replaces both Aeolian Edge and Armor Crush combos with the following when weaving and available:\n- Assassinate or DWAD\n- Bhavacakra\n- Bunshin", NIN.JobID)]
	NinjaSingleTargetSmartWeaveFeature = 30026,

	[CustomComboInfo("AoE Smart Weave", "Replaces Death Blossom / Hakke Mujinsatsu with Hellfrog Medium when weaving and available.", NIN.JobID)]
	NinjaAOESmartWeaveFeature = 30027,

	#endregion
	// ====================================================================================
	#region PALADIN (19xxx)

	[CustomComboInfo("Stun/Interrupt Feature", "Turn Low Blow and Interject into Interject when off CD and your target can be interrupted, Low Blow otherwise.", PLD.JobID)]
	PaladinStunInterruptFeature = 19007,

	[CustomComboInfo("Intervene Level Sync", "Replace Intervene with Shield Lob when under level.", PLD.JobID)]
	PaladinInterveneSyncFeature = 19006,

	[CustomComboInfo("Prominence Combo", "Replace Prominence with its combo chain.", PLD.JobID)]
	PaladinProminenceCombo = 19003,

	[ParentPreset(PaladinProminenceCombo)]
	[CustomComboInfo("Weave: Fight or Flight", "Weave in Fight or Flight on Prominence/TE when doing so will not clip your GCD window.", PLD.JobID)]
	PaladinProminenceWeaveFightOrFlight = 19021,

	[ParentPreset(PaladinProminenceCombo)]
	[CustomComboInfo("Weave: Circle of Scorn", "Weave in Circle of Scorn on Prominence/TE when doing so will not clip your GCD window.", PLD.JobID)]
	PaladinProminenceWeaveCircleOfScorn = 19020,

	[ParentPreset(PaladinProminenceCombo)]
	[CustomComboInfo("Prominent Confiteor Feature", "Replace the Prominence combo with Confiteor (and chains) when Requiescat is up.", PLD.JobID)]
	PaladinProminenceConfiteor = 19016,

	[ParentPreset(PaladinProminenceCombo)]
	[CustomComboInfo("Prominent Circle", "Change Prominence/TE into Holy Circle when under the effect of Divine Might.", PLD.JobID)]
	PaladinProminenceHolyCircle = 19024,

	[CustomComboInfo("Royal Authority Combo", "Replace Royal Authority/Rage of Halone with its combo chain.", PLD.JobID)]
	PaladinRoyalAuthorityCombo = 19001,

	[ParentPreset(PaladinRoyalAuthorityCombo)]
	[CustomComboInfo("Weave: Fight or Flight", "Weave in Fight or Flight on RA/RoH when doing so will not clip your GCD window.", PLD.JobID)]
	PaladinRoyalWeaveFightOrFlight = 19018,

	[ParentPreset(PaladinRoyalAuthorityCombo)]
	[CustomComboInfo("Weave: Spirits Within", "Weave in Spirits Within / Expiacion on RA/RoH when doing so will not clip your GCD window.", PLD.JobID)]
	PaladinRoyalWeaveSpiritsWithin = 19019,

	[ParentPreset(PaladinRoyalAuthorityCombo)]
	[CustomComboInfo("Royal Confiteor Feature", "Replace the RA/RoH combo with Confiteor (and chains) when Requiescat is up.", PLD.JobID)]
	PaladinRoyalConfiteor = 19015,

	[ParentPreset(PaladinRoyalAuthorityCombo)]
	[CustomComboInfo("Goring Authority", "Change RA/RoH into Goring Blade when available.", PLD.JobID)]
	PaladinRoyalAuthorityGoringBlade = 19022,

	[ParentPreset(PaladinRoyalAuthorityCombo)]
	[CustomComboInfo("Royal Intervention Feature", "Replace the RA/RoH combo with Intervene when NOT in the combo chain, and the current target is out of melee range.\nRespects Intervene Level Sync if enabled.", PLD.JobID)]
	PaladinRoyalAuthorityRangeSwapFeature = 19012,

	[ParentPreset(PaladinRoyalAuthorityCombo)]
	[CustomComboInfo("Holy Authority", "Change RA/RoH into Holy Spirit when under the effect of Divine Might.", PLD.JobID)]
	PaladinRoyalAuthorityHolySpirit = 19023,

	[ParentPreset(PaladinRoyalAuthorityCombo)]
	[CustomComboInfo("Atonement Feature", "Replace the RA/RoH combo with Atonement/Supplication/Sepulchre when NOT in the combo chain, and under the relevant effects.", PLD.JobID)]
	PaladinAtonementFeature = 19002,

	[CustomComboInfo("Requiescat Confiteor", "Replace Requiescat/Imperator with Confiteor (and chains) while under the effect of Requiescat.", PLD.JobID)]
	PaladinRequiescatConfiteor = 19004,

	[CustomComboInfo("Holy Confiteor", "Replace Holy Spirit/Circle with Confiteor (and chains) when Requiescat is up.", PLD.JobID)]
	PaladinHolyConfiteor = 19008,

	[CustomComboInfo("Sheltron Sentinel", "Replace Sheltron with Sentinel/Guardian when available.", PLD.JobID)]
	PaladinSheltronSentinel = 19017,

	#endregion
	// ====================================================================================
	#region PICTOMANCER (42xxx)

	[CustomComboInfo("Single Target Combo Replacer", "Changes Cyan/Yellow/Magenta Single-Target combo into Single-Target Red/Green/Blue combo when not under the effect of Subtractive Palette.", PCT.JobID)]
	PictomancerSTComboFeature = 42001,

	[CustomComboInfo("AoE Target Combo Replacer", "Changes Cyan/Yellow/Magenta AoE combo into AoE Red/Green/Blue combo when not under the effect of Subtractive Palette.", PCT.JobID)]
	PictomancerAOEComboFeature = 42002,

	[CustomComboInfo("Weapon Motif Combo", "Change Weapon Motif into Striking Muse if not drawn already.", PCT.JobID)]
	PictomancerWeaponMotifCombo = 42003,

	[ParentPreset(PictomancerWeaponMotifCombo)]
	[CustomComboInfo("Hammer Combo", "When under the effects of Hammer Ready, also replace Weapon Motif/Muse combo with the hammer combo.", PCT.JobID)]
	PictomancerHammerCombo = 42004,

	[CustomComboInfo("Scenic Muse Combo", "Changes Scenic Muse into Scenic Motif when not drawn already.", PCT.JobID)]
	PictomancerScenicCombo = 42005,

	[ParentPreset(PictomancerScenicCombo)]
	[CustomComboInfo("Star Prism Combo", "When Star Prism is ready, will replace Scenic Muse with Star Prism.", PCT.JobID)]
	PictomancerStarPrismCombo = 42006,

	[CustomComboInfo("Holy Comet Combo", "When using Subtractive Palette at level 90+, turns Holy In White into Comet In Black.", PCT.JobID)]
	PictomancerHolyCometCombo = 42007,

	[CustomComboInfo("Creature Motif/Muse Combo", "Changes Living Muse into Creature Motif when nothing is currently drawn.", PCT.JobID)]
	PictomancerLivingMuseCombo = 42008,

	#endregion
	// ====================================================================================
	#region RED MAGE (35xxx)

	[CustomComboInfo("Swiftcast Verraise", "Verraise turns into Swiftcast when available and reasonable.", RDM.JobID)]
	RedMageSwiftcastRaiserFeature = 35000,

	[CustomComboInfo("Smartcast Single Target", "Dynamically replaces Verstone/Verfire with the appropriate spell based on your job gauge.\nVeraero and Verthunder are replaced with one or the other accordingly, for openers.", RDM.JobID)]
	RedMageSmartcastSingleTarget = 35009,

	[ParentPreset(RedMageSmartcastSingleTarget)]
	[CustomComboInfo("Lucid Weave", "Weave into Lucid Dreaming when under a set MP threshold.", RDM.JobID)]
	RedMageSmartcastSingleTargetWeaveLucid = 35043,

	[ParentPreset(RedMageSmartcastSingleTarget)]
	[CustomComboInfo("Fleche Weave", "Turns the single-target smartcast combo into Fleche when you can weave without clipping.\nAffected by the Contre Sixte / Fleche feature.", RDM.JobID)]
	RedMageSmartcastSingleTargetWeaveAttack = 35018,

	[ParentPreset(RedMageSmartcastSingleTargetWeaveAttack)]
	[CustomComboInfo("Engagement", "If you're in melee range and Fleche (+ Contra Sixte if applicable) can't be used yet, fall back to Engagement.", RDM.JobID)]
	RedMageSmartcastSingleTargetWeaveMelee = 35023,

	[ParentPreset(RedMageSmartcastSingleTargetWeaveMelee)]
	[CustomComboInfo("Engagement Priority", "Try to use Engagement first when in melee range.\nWhile it IS a potency loss, Engagement can ONLY be used in melee range, which keeps the long-distance abilities free for when you're too far away.", RDM.JobID)]
	RedMageSmartcastSingleTargetWeaveMeleeFirst = 35025,

	[ParentPreset(RedMageSmartcastSingleTargetWeaveMelee)]
	[CustomComboInfo("Leave one charge", "Always leave one charge of Engagement unused during weaves, to allow using Displacement to backstep out of AoE markers.", RDM.JobID)]
	RedMageSmartcastSingleTargetWeaveMeleeHoldOne = 35031,

	[ParentPreset(RedMageSmartcastSingleTarget)]
	[CustomComboInfo("Walking Fleche", "Turns the single-target smartcast combo into Fleche when you're moving and can't instacast.\nAffected by the Contre Sixte / Fleche feature.", RDM.JobID)]
	RedMageSmartcastSingleTargetMovement = 35019,

	[ParentPreset(RedMageSmartcastSingleTargetMovement)]
	[CustomComboInfo("Engagement", "If you're in melee range and Fleche (+ Contra Sixte if applicable) can't be used yet, fall back to Engagement.", RDM.JobID)]
	RedMageSmartcastSingleTargetMovementMelee = 35024,

	[ParentPreset(RedMageSmartcastSingleTargetMovementMelee)]
	[CustomComboInfo("Engagement Priority", "Try to use Engagement first when in melee range.\nWhile it IS a potency loss, Engagement can ONLY be used in melee range, which keeps the long-distance abilities free for when you're too far away.", RDM.JobID)]
	RedMageSmartcastSingleTargetMovementMeleeFirst = 35026,

	[ParentPreset(RedMageSmartcastSingleTargetMovementMelee)]
	[CustomComboInfo("Leave one charge", "Always leave one charge of Engagement unused during movement, to allow using Displacement to backstep out of AoE markers.", RDM.JobID)]
	RedMageSmartcastSingleTargetMovementMeleeHoldOne = 35032,

	[ParentPreset(RedMageSmartcastSingleTarget)]
	[CustomComboInfo("Melee Combo Followthrough", "Turns the single-target smartcast combo into the rest of the melee combo once you start it, as long as you're in melee range.", RDM.JobID)]
	RedMageSmartcastSingleTargetMeleeCombo = 35021,

	[ParentPreset(RedMageSmartcastSingleTargetMeleeCombo)]
	[CustomComboInfo("Auto Start", "Turns the single-target smartcast combo into your melee combo when you're ready to execute it and your mana levels AREN'T equal.", RDM.JobID)]
	RedMageSmartcastSingleTargetMeleeComboStarter = 35022,

	[ParentPreset(RedMageSmartcastSingleTargetMeleeComboStarter)]
	[CustomComboInfo("Gap Close", "If you're ready to start your melee combo, but you aren't in range, become Corps-a-corps to gap close.", RDM.JobID)]
	RedMageSmartcastSingleTargetMeleeComboStarterCloser = 35041,

	[ParentPreset(RedMageSmartcastSingleTarget)]
	[CustomComboInfo("Acceleration", "Turns the single-target smartcast combo into Acceleration instead of Jolt, when possible.", RDM.JobID)]
	RedMageSmartcastSingleTargetAcceleration = 35027,

	[ParentPreset(RedMageSmartcastSingleTargetAcceleration)]
	[CustomComboInfo("With Swiftcast", "Acceleration falls back to Swiftcast if it's available and Acceleration is out of charges.", RDM.JobID)]
	RedMageSmartcastSingleTargetAccelerationSwiftcast = 35028,

	[ParentPreset(RedMageSmartcastSingleTargetAccelerationSwiftcast)]
	[CustomComboInfo("Swiftcast Priority", "Swiftcast is used before Acceleration if it's up.", RDM.JobID)]
	RedMageSmartcastSingleTargetAccelerationSwiftcastFirst = 35029,

	[ParentPreset(RedMageSmartcastSingleTargetAcceleration)]
	[CustomComboInfo("Combat Only", "Only become Acceleration (+ Swiftcast if applicable) when in combat.\nActs as an override - if you're not in combat, the combo will never become Acceleration/Swiftcast.", RDM.JobID)]
	RedMageSmartcastSingleTargetAccelerationCombat = 35035,

	[ParentPreset(RedMageSmartcastSingleTargetAcceleration)]
	[CustomComboInfo("When Weaving", "Change into Acceleration (+ Swiftcast if applicable) when you're weaving.\nThis will be prioritised over weaving Fleche/CS/Engagement, if applicable.", RDM.JobID)]
	RedMageSmartcastSingleTargetAccelerationWeave = 35036,

	[ParentPreset(RedMageSmartcastSingleTargetAcceleration)]
	[CustomComboInfo("When Moving", "Change into Acceleration (+ Swiftcast if applicable) when moving.\nThis will be prioritised over weaving Fleche/CS/Engagement, if applicable.", RDM.JobID)]
	RedMageSmartcastSingleTargetAccelerationMoving = 35037,

	[ParentPreset(RedMageSmartcastSingleTargetAcceleration)]
	[CustomComboInfo("Don't Override", "Don't override Jolt when you can hardcast it.\nThis will prevent GCD drift at the cost of DPS loss.", RDM.JobID)]
	RedMageSmartcastSingleTargetAccelerationNoOverride = 35038,

	[ParentPreset(RedMageSmartcastSingleTarget)]
	[CustomComboInfo("+ Grand Impact", "Become Grand Impact before becoming the verprocs, to prevent wasting it.", RDM.JobID)]
	RedMageSmartcastSingleTargetGrandImpact = 35048,

	[Conflicts(RedMageAoECombo)]
	[CustomComboInfo("Smartcast AoE", "Dynamically replaces Veraero/Verthunder 2 with the appropriate spell based on your job gauge.\nIncludes Impact/Scatter when fastcasting.\nIncludes Grand Impact when available.", RDM.JobID)]
	RedMageSmartcastAoE = 35008,

	[ParentPreset(RedMageSmartcastAoE)]
	[CustomComboInfo("Lucid Weave", "Weave into Lucid Dreaming when under a set MP threshold.", RDM.JobID)]
	RedMageSmartcastAoEWeaveLucid = 35042,

	[ParentPreset(RedMageSmartcastAoE)]
	[CustomComboInfo("Contre Sixte Weave", "Turns the AoE smartcast combo into Contre Sixte when you can weave without clipping.\nAffected by the Contre Sixte / Fleche feature.", RDM.JobID)]
	RedMageSmartcastAoEWeaveAttack = 35017,

	[ParentPreset(RedMageSmartcastAoE)]
	[CustomComboInfo("Walking Contre Sixte", "Turns the AoE smartcast combo into Contre Sixte when you're moving and can't instacast.\nAffected by the Contre Sixte / Fleche feature.", RDM.JobID)]
	RedMageSmartcastAoEMovement = 35020,

	[CustomComboInfo("Melee Combo", "Replaces Riposte with its combo chain, following enchantment rules.", RDM.JobID)]
	RedMageMeleeCombo = 35002,

	[ParentPreset(RedMageMeleeCombo)]
	[CustomComboInfo("Melee Combo+", "Replaces Riposte (and Moulinet) with Verflare/Verholy (and then Scorch and Resolution) after 3 mana stacks, whichever is more appropriate.", RDM.JobID)]
	RedMageMeleeComboPlus = 35003,

	[ParentPreset(RedMageMeleeCombo)]
	[CustomComboInfo("Gap Closer", "Replaces Riposte with Corps-a-corps when out of melee range.", RDM.JobID)]
	RedMageMeleeComboCloser = 35014,

	[Conflicts(RedMageSmartcastAoE)]
	[CustomComboInfo("Red Mage AoE Combo", "Replaces Veraero/Verthunder 2 with Impact when under a cast speeder.", RDM.JobID)]
	RedMageAoECombo = 35001,

	[CustomComboInfo("Contre Sixte / Fleche Feature", "Turns Contre Sixte and Fleche into whichever is available.", RDM.JobID)]
	RedMageContreFleche = 35010,

	[ParentPreset(RedMageContreFleche)]
	[CustomComboInfo("+ Prefulgence", "Includes Prefulgence when available.\nTakes priority over everything else.", RDM.JobID)]
	RedMageContreFlechePrefulgence = 35044,

	[ParentPreset(RedMageContreFleche)]
	[CustomComboInfo("+ Vice of Thorns", "Includes Vice of Thorns when available.\nTakes priority over everything else except Prefulgence, unless Prefulgence has more than 3 seconds and VoT does not.", RDM.JobID)]
	RedMageContreFlecheThorns = 35045,

	[CustomComboInfo("Acceleration into Swiftcast", "Replace Acceleration with Swiftcast when on cooldown or synced.", RDM.JobID)]
	RedMageAccelerationSwiftcast = 35011,

	[ParentPreset(RedMageAccelerationSwiftcast)]
	[CustomComboInfo("Acceleration with Swiftcast first", "Replace Acceleration with Swiftcast when neither are on cooldown.", RDM.JobID)]
	RedMageAccelerationSwiftcastFirst = 35012,

	[CustomComboInfo("Manafication into melee", "Replace Manafication with your melee combo when you have Magicked Swordplay up.", RDM.JobID)]
	RedMageManaficationIntoMelee = 35039,

	[ParentPreset(RedMageManaficationIntoMelee)]
	[CustomComboInfo("+from gauge", "Also change when your gauge is ready to start the combo.", RDM.JobID)]
	RedMageManaficationIntoMeleeGauge = 35046,

	[ParentPreset(RedMageManaficationIntoMelee)]
	[CustomComboInfo("Include finishers", "Also change into your finisher spells when they're ready to use.", RDM.JobID)]
	RedMageManaficationIntoMeleeFinisherFollowup = 35047,

	[CustomComboInfo("Gap Reverser: Backstep", "Replaces Corps-a-corps with Displacement when your taget is in melee range.", RDM.JobID)]
	RedMageMeleeGapReverserBackstep = 35015,

	[CustomComboInfo("Gap Reverser: Lunge", "Replaces Displacement with Corps-a-corps when your taget is NOT in melee range.", RDM.JobID)]
	RedMageMeleeGapReverserLunge = 35016,

	#endregion
	// ====================================================================================
	#region REAPER (39xxx)

	[CustomComboInfo("Second Wind / Bloodbath", "Replace Bloodbath and Second Wind with each other based on cooldown, or with only Second Wind when under level.\nIf both are available, the button will default to whichever you placed on your hotbar.", RPR.JobID)]
	ReaperBloodbathReplacer = 39050,

	[CustomComboInfo("Slice Combo", "Replace Infernal Slice with its combo chain.", RPR.JobID)]
	ReaperSliceCombo = 39001,

	[CustomComboInfo("Slice Weave Assist", "Replace Infernal Slice with Blood Stalk (or variants) when available and weaving wouldn't clip your GCD.", RPR.JobID)]
	ReaperSliceWeaveAssist = 39042,

	[ParentPreset(ReaperSliceWeaveAssist)]
	[CustomComboInfo("Ignore Reaving", "Allow weaving even if you're already reaving.", RPR.JobID)]
	ReaperSliceWeaveAssistDoubleReaving = 39048,

	[CustomComboInfo("Slice of Death Feature", "Replace Infernal Slice with Shadow of Death when the target's Death's Design debuff is low.", RPR.JobID)]
	ReaperSliceShadowFeature = 39040,

	[CustomComboInfo("Soulful Slice", "Replace Infernal Slice with Soul Slice when available and Soul Gauge is no more than 50.", RPR.JobID)]
	ReaperSoulOnSliceFeature = 39046,

	[Conflicts(ReaperSliceGallowsFeature)]
	[CustomComboInfo("Slice Gibbet Feature", "Replace Infernal Slice with Gibbet while Reaving, Enshrouded, or an Executioner.", RPR.JobID)]
	ReaperSliceGibbetFeature = 39003,

	[Conflicts(ReaperSliceGibbetFeature)]
	[CustomComboInfo("Slice Gallows Feature", "Replace Infernal Slice with Gallows while Reaving, Enshrouded, or an Executioner.", RPR.JobID)]
	ReaperSliceGallowsFeature = 39004,

	[CustomComboInfo("Slice Enhanced Soul Reaver Feature", "Replace Infernal Slice with whichever of Gibbet or Gallows is currently enhanced while Reaving, Enshrouded, or an Executioner.\nNo effect if neither is enhanced - combine this with one of the above two for a default!", RPR.JobID)]
	ReaperSliceSmart = 39013,

	[CustomComboInfo("Slice Lemure's Feature", "Replace Infernal Slice with Lemure's Slice when two or more stacks of Void Shroud are active.", RPR.JobID)]
	ReaperSliceLemuresFeature = 39019,

	[CustomComboInfo("Slice Communio Feature", "Replace Infernal Slice with Communio when one stack of Shroud is left.", RPR.JobID)]
	ReaperSliceCommunioFeature = 39020,

	[CustomComboInfo("Slice Soulsow Feature", "Replace Infernal Slice with Soulsow when out of combat and not active.", RPR.JobID)]
	ReaperSliceSoulsowFeature = 39030,

	[Conflicts(ReaperShadowGibbetFeature)]
	[CustomComboInfo("Shadow Gallows Feature", "Replace Shadow of Death with Gallows while Reaving, Enshrouded, or an Executioner.", RPR.JobID)]
	ReaperShadowGallowsFeature = 39005,

	[Conflicts(ReaperShadowGallowsFeature)]
	[CustomComboInfo("Shadow Gibbet Feature", "Replace Shadow of Death with Gibbet while Reaving, Enshrouded, or an Executioner.", RPR.JobID)]
	ReaperShadowGibbetFeature = 39006,

	[CustomComboInfo("Shadow Lemure's Feature", "Replace Shadow of Death with Lemure's Slice when two or more stacks of Void Shroud are active.", RPR.JobID)]
	ReaperShadowLemuresFeature = 39023,

	[CustomComboInfo("Shadow Communio Feature", "Replace Shadow of Death with Communio when one stack of Shroud is left.", RPR.JobID)]
	ReaperShadowCommunioFeature = 39024,

	[CustomComboInfo("Shadow Soulsow Feature", "Replace Shadow of Death with Soulsow when out of combat, not active, and you have no target.", RPR.JobID)]
	ReaperShadowSoulsowFeature = 39029,

	[Conflicts(ReaperSoulGibbetFeature)]
	[CustomComboInfo("Soul Gallows Feature", "Replace Soul Slice with Gallows while Reaving, Enshrouded, or an Executioner.", RPR.JobID)]
	ReaperSoulGallowsFeature = 39025,

	[Conflicts(ReaperSoulGallowsFeature)]
	[CustomComboInfo("Soul Gibbet Feature", "Replace Soul Slice with Gibbet while Reaving, Enshrouded, or an Executioner.", RPR.JobID)]
	ReaperSoulGibbetFeature = 39026,

	[CustomComboInfo("Soul Lemure's Feature", "Replace Soul Slice with Lemure's Slice when two or more stacks of Void Shroud are active.", RPR.JobID)]
	ReaperSoulLemuresFeature = 39027,

	[CustomComboInfo("Soul Communio Feature", "Replace Soul Slice with Communio when one stack of Shroud is left.", RPR.JobID)]
	ReaperSoulCommunioFeature = 39028,

	[CustomComboInfo("Soul Slice Overcap Feature", "Replace Soul Slice with Blood Stalk when not Enshrouded and Soul Gauge is over 50.", RPR.JobID)]
	ReaperSoulOvercapFeature = 39034,

	[CustomComboInfo("Soul Scythe Overcap Feature", "Replace Soul Scythe with Grim Swathe when not Enshrouded, and Soul Gauge is over 50.", RPR.JobID)]
	ReaperSoulScytheOvercapFeature = 39035,

	[CustomComboInfo("Soul Slice Weave Assist", "Replace Soul Slice with Blood Stalk (or variants) when available and weaving wouldn't clip your GCD.", RPR.JobID)]
	ReaperSoulSliceWeaveAssist = 39044,

	[CustomComboInfo("Soul Scythe Weave Assist", "Replace Soul Scythe with Grim Swathe (or variants) when available and weaving wouldn't clip your GCD.", RPR.JobID)]
	ReaperSoulScytheWeaveAssist = 39045,

	[CustomComboInfo("Scythe Combo", "Replace Nightmare Scythe with its combo chain.", RPR.JobID)]
	ReaperScytheCombo = 39002,

	[CustomComboInfo("Scythe Weave Assist", "Replace Nightmare Scythe with Grim Swathe (or variants) when available and weaving wouldn't clip your GCD.", RPR.JobID)]
	ReaperScytheWeaveAssist = 39043,

	[ParentPreset(ReaperScytheWeaveAssist)]
	[CustomComboInfo("Ignore Reaving", "Allow weaving even if you're already reaving.", RPR.JobID)]
	ReaperScytheWeaveAssistDoubleReaving = 39049,

	[CustomComboInfo("Scythe of Death Feature", "Replace Nightmare Scythe with Whorl of Death when the target's Death's Design debuff is low.", RPR.JobID)]
	ReaperScytheWhorlFeature = 39041,

	[CustomComboInfo("Soulful Scythe", "Replace Nightmare Scythe with Soul Scythe when available and Soul Gauge is no more than 50.", RPR.JobID)]
	ReaperSoulOnScytheFeature = 39047,

	[CustomComboInfo("Scythe Guillotine Feature", "Replace Nightmare Scythe with Guillotine while Reaving, Enshrouded, or an Executioner.", RPR.JobID)]
	ReaperScytheGuillotineFeature = 39007,

	[CustomComboInfo("Scythe Lemure's Feature", "Replace Nightmare Scythe with Lemure's Scythe when two or more stacks of Void Shroud are active.", RPR.JobID)]
	ReaperScytheLemuresFeature = 39021,

	[CustomComboInfo("Scythe Communio Feature", "Replace Nightmare Scythe with Communio when one stack is left of Shroud.", RPR.JobID)]
	ReaperScytheCommunioFeature = 39022,

	[CustomComboInfo("Scythe Soulsow Feature", "Replace Nightmare Scythe with Soulsow when out of combat and not active.", RPR.JobID)]
	ReaperScytheSoulsowFeature = 39031,

	[CustomComboInfo("Scythe Harvest Moon Feature", "Replace Nightmare Scythe with Harvest Moon when Soulsow is active and you have a target.", RPR.JobID)]
	ReaperScytheHarvestMoonFeature = 39032,

	[CustomComboInfo("Enhanced Soul Reaver Feature", "Replace Gibbet and Gallows with whichever is currently enhanced while Reaving, Enshrouded, or an Executioner.", RPR.JobID)]
	ReaperEnhancedSoulReaverFeature = 39017,

	[CustomComboInfo("Lemure's Soul Reaver Feature", "Replace Gibbet, Gallows, and Guillotine with Lemure's Slice or Scythe when two or more stacks of Void Shroud are active.", RPR.JobID)]
	ReaperLemuresSoulReaverFeature = 39011,

	[CustomComboInfo("Communio Soul Reaver Feature", "Replace Gibbet, Gallows, and Guillotine with Communio when one stack is left of Shroud.", RPR.JobID)]
	ReaperCommunioSoulReaverFeature = 39012,

	[CustomComboInfo("Enshroud Communio Feature", "Replace Enshroud with Communio when Enshrouded.", RPR.JobID)]
	ReaperEnshroudCommunioFeature = 39009,

	[CustomComboInfo("Blood Stalk Gluttony Feature", "Replace Blood Stalk with Gluttony when available and Soul Gauge is at least 50.", RPR.JobID)]
	ReaperBloodStalkGluttonyFeature = 39015,

	[CustomComboInfo("Grim Swathe Gluttony Feature", "Replace Grim Swathe with Gluttony when available and Soul Gauge is at least 50.", RPR.JobID)]
	ReaperGrimSwatheGluttonyFeature = 39016,

	[CustomComboInfo("Arcane Harvest Feature", "Replace Arcane Circle with Plentiful Harvest when you have enough stacks of Immortal Sacrifice.", RPR.JobID)]
	ReaperHarvestFeature = 39008,

	[CustomComboInfo("Regress Feature", "Replace Hell's Ingress and Egress turn with Regress when Threshold is active, instead of just the opposite of the one used.", RPR.JobID)]
	ReaperRegressFeature = 39010,

	[ParentPreset(ReaperRegressFeature)]
	[CustomComboInfo("Delayed Regress Option", "Replace the action used with Regress only after a configurable delay.", RPR.JobID)]
	ReaperRegressDelayed = 39033,

	[CustomComboInfo("Harpe Soulsow Feature", "Replace Harpe with Soulsow when not active and out of combat or you have no target.", RPR.JobID)]
	ReaperHarpeHarvestSoulsowFeature = 39036,

	[CustomComboInfo("Harpe Harvest Moon Feature", "Replace Harpe with Harvest Moon when Soulsow is active and you are in combat.", RPR.JobID)]
	ReaperHarpeHarvestMoonFeature = 39037,

	[ParentPreset(ReaperHarpeHarvestMoonFeature)]
	[CustomComboInfo("Enhanced Harpe Option", "Prevent replacing Harpe with Harvest Moon when Enhanced Harpe is active.", RPR.JobID)]
	ReaperHarpeHarvestMoonEnhancedFeature = 39039,

	[ParentPreset(ReaperHarpeHarvestMoonFeature)]
	[CustomComboInfo("Combat Option", "Prevent replacing Harpe with Harvest Moon when not in combat.", RPR.JobID)]
	ReaperHarpeHarvestMoonCombatFeature = 39038,

	#endregion
	// ====================================================================================
	#region SAMURAI (34xxx)
	// Working on updating SAM. Will gradually be releasing more features as they are verified working.

	[CustomComboInfo("Second Wind / Bloodbath", "Replace Bloodbath and Second Wind with each other based on cooldown, or with only Second Wind when under level.\nIf both are available, the button will default to whichever you placed on your hotbar.", SAM.JobID)]
	SamuraiBloodbathReplacer = 34019,

	[CustomComboInfo("Yukikaze Combo", "Replace Yukikaze with its combo chain.", SAM.JobID)]
	SamuraiYukikazeCombo = 34000,

	[CustomComboInfo("Gekko Combo", "Replace Gekko with its combo chain.", SAM.JobID)]
	SamuraiGekkoCombo = 34001,

	[ParentPreset(SamuraiGekkoCombo)]
	[CustomComboInfo("Gekko Combo from Jinpu", "Start the Gekko combo chain with Jinpu instead of Hakaze.", SAM.JobID)]
	SamuraiGekkoOption = 34016,

	[CustomComboInfo("Kasha Combo", "Replace Kasha with its combo chain.", SAM.JobID)]
	SamuraiKashaCombo = 34002,

	[ParentPreset(SamuraiKashaCombo)]
	[CustomComboInfo("Kasha Combo from Shifu", "Start the Kasha combo chain with Shifu instead of Hakaze.", SAM.JobID)]
	SamuraiKashaOption = 34017,

	[CustomComboInfo("Mangetsu Combo", "Replace Mangetsu with its combo chain.", SAM.JobID)]
	SamuraiMangetsuCombo = 34003,

	[CustomComboInfo("Oka Combo", "Replace Oka with its combo chain.", SAM.JobID)]
	SamuraiOkaCombo = 34004,

	[Conflicts(SamuraiIaijutsuTsubameGaeshiFeature)]
	[CustomComboInfo("Tsubame-gaeshi to Iaijutsu", "Replace Tsubame-gaeshi with Iaijutsu when Sen is not empty.", SAM.JobID)]
	SamuraiTsubameGaeshiIaijutsuFeature = 34007,

	[Conflicts(SamuraiIaijutsuShohaFeature)]
	[CustomComboInfo("Tsubame-gaeshi to Shoha", "Replace Tsubame-gaeshi with Shoha when meditation is 3.", SAM.JobID)]
	SamuraiTsubameGaeshiShohaFeature = 34009,

	[Conflicts(SamuraiTsubameGaeshiIaijutsuFeature)]
	[CustomComboInfo("Iaijutsu to Tsubame-gaeshi", "Replace Iaijutsu with Tsubame-gaeshi when Sen is empty.", SAM.JobID)]
	SamuraiIaijutsuTsubameGaeshiFeature = 34008,

	[Conflicts(SamuraiTsubameGaeshiShohaFeature)]
	[CustomComboInfo("Iaijutsu to Shoha", "Replace Iaijutsu with Shoha when meditation is 3.", SAM.JobID)]
	SamuraiIaijutsuShohaFeature = 34010,

	[CustomComboInfo("Shinten to Senei", "Replace Hissatsu: Shinten with Senei when available.", SAM.JobID)]
	SamuraiShintenSeneiFeature = 34014,

	[CustomComboInfo("Shinten to Shoha", "Replace Hissatsu: Shinten with Shoha when Meditation is full.", SAM.JobID)]
	SamuraiShintenShohaFeature = 34013,

	[CustomComboInfo("Kyuten to Guren", "Replace Hissatsu: Kyuten with Guren when available.", SAM.JobID)]
	SamuraiKyutenGurenFeature = 34015,

	[CustomComboInfo("Kyuten to Shoha", "Replace Hissatsu: Kyuten with Shoha when Meditation is full.", SAM.JobID)]
	SamuraiKyutenShohaFeature = 34012,

	[CustomComboInfo("Ikishoten Namikiri Feature", "Replace Ikishoten with Shoha, Kaeshi Namikiri, and then Ogi Namikiri when available.", SAM.JobID)]
	SamuraiIkishotenNamikiriFeature = 34011,

	[CustomComboInfo("Hissatsu Senei/Guren Sync Feature", "Replace Hissatsu Senei with Hissatsu Guren when underlevel.", SAM.JobID)]
	SamuraiGurenSeneiLevelSyncFeature = 34018,

	#endregion
	// ====================================================================================
	#region SCHOLAR (28xxx)

	[CustomComboInfo("Swiftcast Resurrection", "Resurrection turns into Swiftcast when available and reasonable.", SCH.JobID)]
	ScholarSwiftcastRaiserFeature = 28000,

	[CustomComboInfo("Mobile Ruin & Broil", "Changes Ruin 1 and all variants of Broil into Ruin 2 while moving.", SCH.JobID)]
	ScholarMobileRuinBroil = 28010,

	[CustomComboInfo("Lucid Ruin & Broil", "Changes Ruin 1 and all variants of Broil into Lucid Dreaming when MP is below a certain level.", SCH.JobID)]
	ScholarLucidRuinBroil = 28011,

	[CustomComboInfo("Lucid Art of War", "Changes Art of War into Lucid Dreaming when MP is below a certain level.", SCH.JobID)]
	ScholarLucidArtOfWar = 28012,

	[CustomComboInfo("Seraph Fey Blessing/Consolation", "Change Fey Blessing into Consolation when Seraph is out.", SCH.JobID)]
	ScholarSeraphConsolationFeature = 28001,

	[CustomComboInfo("Lustrous Aetherflow", "Change Lustrate into Aetherflow when you have no more Aetherflow stacks.", SCH.JobID)]
	ScholarLustrateAetherflowFeature = 28003,

	[CustomComboInfo("Lustrate to Recitation", "Replace Lustrate with Recitation when Recitation is off cooldown.", SCH.JobID)]
	ScholarLustrateRecitationFeature = 28007,

	[CustomComboInfo("Lustrate to Excogitation", "Replace Lustrate with Excogitation when Excogitation is off cooldown.", SCH.JobID)]
	ScholarLustrateExcogitationFeature = 28008,

	[CustomComboInfo("Excog / Lustrate", "Change Excogitation into Lustrate when on CD or under level.", SCH.JobID)]
	ScholarExcogFallbackFeature = 28005,

	[CustomComboInfo("Excogitation to Recitation", "Replace Excogitation with Recitation when Recitation is off cooldown.", SCH.JobID)]
	ScholarExcogitationRecitationFeature = 28006,

	[CustomComboInfo("ED Aetherflow", "Change Energy Drain into Aetherflow when you have no more Aetherflow stacks.", SCH.JobID)]
	ScholarEnergyDrainAetherflowFeature = 28002,

	[CustomComboInfo("Indomitable Aetherflow", "Change Indomitability into Aetherflow when you have no more Aetherflow stacks.", SCH.JobID)]
	ScholarIndomAetherflowFeature = 28004,

	[CustomComboInfo("Summon Seraph Feature", "Replace Summon Eos and Selene with Summon Seraph when a summon is out.", SCH.JobID)]
	ScholarSeraphFeature = 28009,

	[CustomComboInfo("Chain Impaction", "Replace Chain Stratagem with Baneful Impaction when under Impact Imminent.", SCH.JobID)]
	ScholarChainStratagemBanefulImpaction = 28013,

	#endregion
	// ====================================================================================
	#region SAGE (40xxx)
	// Current latest 4027

	[CustomComboInfo("Swiftcast Egeiro", "Egeiro turns into Swiftcast when available and reasonable.", SGE.JobID)]
	SageSwiftcastRaiserFeature = 40000,

	[CustomComboInfo("Taurochole Into Druochole Feature", "Replace Taurochole with Druochole when on cooldown", SGE.JobID)]
	SageTaurocholeDruocholeFeature = 40001,

	[CustomComboInfo("Taurochole Into Rhizomata Feature", "Replace Taurochole with Rhizomata when Addersgall is empty.", SGE.JobID)]
	SageTaurocholeRhizomataFeature = 40002,

	[CustomComboInfo("Druochole Into Rhizomata Feature", "Replace Druochole with Rhizomata when Addersgall is empty.", SGE.JobID)]
	SageDruocholeRhizomataFeature = 40003,

	[CustomComboInfo("Ixochole Into Rhizomata Feature", "Replace Ixochole with Rhizomata when Addersgall is empty.", SGE.JobID)]
	SageIxocholeRhizomataFeature = 40004,

	[CustomComboInfo("Kerachole Into Rhizomata Feature", "Replace Kerachole with Rhizomata when Addersgall is empty.", SGE.JobID)]
	SageKeracholaRhizomataFeature = 40005,

	[CustomComboInfo("Soteria Kardia Feature", "Replace Soteria with Kardia when missing Kardion.", SGE.JobID)]
	SageSoteriaKardionFeature = 40006,

	[CustomComboInfo("Flying Phlegma", "Turns Icarus into Phlegma when Phlegma is up and you're in range of your target to use it.", SGE.JobID)]
	SageIcarusPhlegma = 40019,

	[CustomComboInfo("Phlegma Gap Closer", "Replace Phlegma with Icarus when at least a configurable distance away from your target and both are off CD.\nOnly applies when Phlegma has at least one charge available.", SGE.JobID)]
	SagePhlegmaIcarus = 40009,

	[CustomComboInfo("Phlegma into Toxikon", "Replace Phlegma with Toxikon when you have a target and Addersting, and either no charges of Phlegma remain or your target is too far away.\nGap Closer takes priority if enabled and available.", SGE.JobID)]
	SagePhlegmaToxicon = 40007,

	[CustomComboInfo("Phlegma into Dosis", "Replace Phlegma with Dosis when you have a target in range and either no charges of Phlegma remain or your target is too far away.\nToxikon takes priority if enabled and available.", SGE.JobID)]
	SagePhlegmaDosis = 40016,

	[CustomComboInfo("Phlegma into Dyskrasia", "Replace Phlegma with Dyskrasia when no charges remain, you have no target, or your target is out of range.\nDosis takes priority if enabled and available.", SGE.JobID)]
	SagePhlegmaDyskrasia = 40008,

	[CustomComboInfo("Kerachole into Holos", "Turns Kerachole into Holos when your level is high enough, Kerachole is unavailable, and you can use Holos.\nSupports Kerachole into Rhizomata, prioritises being Rhizomata.", SGE.JobID)]
	SageKeracholeHolos = 40010,

	[CustomComboInfo("Holos into Kerachole", "Turns Holos into Kerachole when your level is too low, or when Kerachole is available and Holos is not.\nSupports Kerachole into Rhizomata, prioritises being Holos.", SGE.JobID)]
	SageHolosKerachole = 40011,

	[CustomComboInfo("Dosis into Phlegma", "Turns Dosis into Phlegma while moving and have a target and Phlegma is up and you're in range.\nDoes not apply if you have Eukrasia active.", SGE.JobID)]
	SageDosisPhlegma = 40020,

	[ParentPreset(SageDosisPhlegma)]
	[CustomComboInfo("Combat Only", "Only change Dosis into Phlegma when already in combat.", SGE.JobID)]
	SageDosisPhlegmaCombatOnly = 40021,

	[ParentPreset(SageDosisPhlegma)]
	[CustomComboInfo("Only when hardcasting", "Only change Dosis into Phlegma when hardcasting.", SGE.JobID)]
	SageDosisPhlegmaHardcastOnly = 40024,

	[CustomComboInfo("Dosis into Toxikon", "Turns Dosis into Toxikon while moving and have a target and Addersting.\nDoes not apply if you have Eukrasia active.", SGE.JobID)]
	SageDosisToxikon = 40017,

	[ParentPreset(SageDosisToxikon)]
	[CustomComboInfo("Combat Only", "Only change Dosis into Toxikon when already in combat.", SGE.JobID)]
	SageDosisToxikonCombatOnly = 40022,

	[ParentPreset(SageDosisToxikon)]
	[CustomComboInfo("Only when hardcasting", "Only change Dosis into Toxikon when hardcasting.", SGE.JobID)]
	SageDosisToxikonHardcastOnly = 40025,

	[CustomComboInfo("Dosis into Dyskrasia", "Turns Dosis into Dyskrasia while moving and not becoming Phlegma or Toxikon.\nDoes not apply if you have Eukrasia active.", SGE.JobID)]
	SageDosisDyskrasia = 40018,

	[ParentPreset(SageDosisDyskrasia)]
	[CustomComboInfo("Combat Only", "Only change Dosis into Dyskrasia when already in combat.", SGE.JobID)]
	SageDosisDyskrasiaCombatOnly = 40023,

	[ParentPreset(SageDosisDyskrasia)]
	[CustomComboInfo("Only when hardcasting", "Only change Dosis into Dyskrasia when hardcasting.", SGE.JobID)]
	SageDosisDyskrasiaHardcastOnly = 40026,

	[CustomComboInfo("Lucid Dosis", "Weave Dosis into Lucid Dreaming when it's available and your MP is below a threshold.\nThis also applies when Phlegma becomes Dosis.", SGE.JobID)]
	SageLucidDosis = 40012,

	[CustomComboInfo("Lucid Dyskrasia", "Weave Dyskrasia into Lucid Dreaming when it's available and your MP is below a threshold.\nThis also applies when Phlegma becomes Dyskrasia.", SGE.JobID)]
	SageLucidDyskrasia = 40013,

	[CustomComboInfo("Lucid Toxikon", "Weave Toxikon into Lucid Dreaming when it's available and your MP is below a threshold.\nThis also applies when Phlegma becomes Toxikon.", SGE.JobID)]
	SageLucidToxikon = 40014,

	[CustomComboInfo("Lucid Phlegma", "Weave Phlegma into Lucid Dreaming when it's available and your MP is below a configurable threshold.", SGE.JobID)]
	SageLucidPhlegma = 40015,

	[CustomComboInfo("Philosophia Into Zoe", "When either not at level or when Philosophica is on cooldown, change it into Zoe.", SGE.JobID)]
	SagePhilosophiaZoe = 40027,

	#endregion
	// ====================================================================================
	#region SUMMONER (27xxx)

	[CustomComboInfo("Swiftcast Resurrection", "Resurrection turns into Swiftcast when available and reasonable.", SMN.JobID)]
	SummonerSwiftcastRaiserFeature = 27000,

	//[CustomComboInfo("ED Fester", "Change Fester into Energy Drain when out of Aetherflow stacks.", SMN.JobID)]
	//SummonerEDFesterCombo = 27004,

	//[CustomComboInfo("ES Painflare", "Change Painflare into Energy Syphon when out of Aetherflow stacks.", SMN.JobID)]
	//SummonerESPainflareCombo = 27005,

	//[CustomComboInfo("Ruin Feature", "Change Ruin into Gemburst when attuned.", SMN.JobID)]
	//SummonerRuinFeature = 27006,

	//[CustomComboInfo("Titan's Favor Ruin Feature", "Change Ruin into Mountain Buster (oGCD) when available.", SMN.JobID)]
	//SummonerRuinTitansFavorFeature = 27013,

	//[CustomComboInfo("Further Ruin Feature", "Change Ruin into Ruin4 when available and appropriate.", SMN.JobID)]
	//SummonerFurtherRuinFeature = 27008,

	//[CustomComboInfo("Outburst Feature", "Change Outburst into Precious Brilliance when attuned.", SMN.JobID)]
	//SummonerOutburstFeature = 27007,

	//[CustomComboInfo("Titan's Favor Outburst Feature", "Change Outburst into Mountain Buster (oGCD) when available.", SMN.JobID)]
	//SummonerOutburstTitansFavorFeature = 27014,

	//[CustomComboInfo("Further Outburst Feature", "Change Outburst into Ruin4 when available and appropriate.", SMN.JobID)]
	//SummonerFurtherOutburstFeature = 27009,

	//[CustomComboInfo("Shiny Titan's Favour", "Change Ruin into Ruin4 when available and appropriate.", SMN.JobID)]
	//SummonerShinyTitansFavorFeature = 27010,

	//[CustomComboInfo("Further Shiny Feature", "Change Outburst into Ruin4 when available and appropriate.", SMN.JobID)]
	//SummonerFurtherShinyFeature = 27011,

	//[CustomComboInfo("Shiny Enkindle Feature", "Change Gemshine and Precious Brilliance to Enkindle when Bahamut or Phoenix are summoned.", SMN.JobID)]
	//SummonerShinyEnkindleFeature = 27012,

	//[CustomComboInfo("Demi Enkindle Feature", "Change Summon Bahamut and Summon Phoenix into Enkindle when Bahamut or Phoenix are summoned.", SMN.JobID)]
	//SummonerDemiEnkindleFeature = 27015,

	//[CustomComboInfo("Radiant Carbuncle Feature", "Change Radiant Aegis into Summon Carbuncle when no pet has been summoned.", SMN.JobID)]
	//SummonerRadiantCarbuncleFeature = 27016,

	//[CustomComboInfo("Slipstream / Swiftcast Feature", "Change Slipstream into Swiftcast when Swiftcast is available.", SMN.JobID)]
	//SummonerSlipcastFeature = 27018,

	#endregion
	// ====================================================================================
	#region VIPER (41xxx)

	[CustomComboInfo("Second Wind / Bloodbath", "Replace Bloodbath and Second Wind with each other based on cooldown, or with only Second Wind when under level.\nIf both are available, the button will default to whichever you placed on your hotbar.", VPR.JobID)]
	ViperBloodbathReplacer = 41000,

	#endregion
	// ====================================================================================
	#region WARRIOR (21xxx)

	[CustomComboInfo("Stun/Interrupt feature", "Turn Low Blow and Interject into Interject when off CD and your target can be interrupted, Low Blow otherwise.", WAR.JobID)]
	WarriorStunInterruptFeature = 21009,

	[CustomComboInfo("Storm's Path combo", "Replace Storm's Path with its combo chain.", WAR.JobID)]
	WarriorStormsPathCombo = 21000,

	[ParentPreset(WarriorStormsPathCombo)]
	[CustomComboInfo("Smart weave", "Automatically turn into Upheaval when weaving won't drift your GCD.", WAR.JobID)]
	WarriorSmartWeaveSingleTargetPath = 21016,

	[ParentPreset(WarriorSmartWeaveSingleTargetPath)]
	[CustomComboInfo("Buffed weave", "Wait until you have Surging Tempest active.", WAR.JobID)]
	WarriorSmartWeaveSingleTargetPathOnlyBuffed = 21019,

	[ParentPreset(WarriorStormsPathCombo)]
	[CustomComboInfo("Gauge overcap saver", "Replace the Storm's Path combo with gauge spender if completing the combo would overcap you.", WAR.JobID)]
	WarriorGaugeOvercapPathFeature = 21003,

	[ParentPreset(WarriorStormsPathCombo)]
	[CustomComboInfo("Surging Tempest saver", "Replace the Storm's Path combo chain with Storm's Eye if Surging Tempest has less than 7 (default) seconds left.", WAR.JobID)]
	WarriorSmartStormCombo = 21012,

	[CustomComboInfo("Storm's Eye combo", "Replace Storm's Eye with its combo chain.", WAR.JobID)]
	WarriorStormsEyeCombo = 21001,

	[ParentPreset(WarriorStormsEyeCombo)]
	[CustomComboInfo("Smart weave", "Automatically turn into Upheaval when weaving won't drift your GCD.", WAR.JobID)]
	WarriorSmartWeaveSingleTargetEye = 21017,

	[ParentPreset(WarriorSmartWeaveSingleTargetEye)]
	[CustomComboInfo("Buffed weave", "Wait until you have Surging Tempest active.", WAR.JobID)]
	WarriorSmartWeaveSingleTargetEyeOnlyBuffed = 21020,

	[ParentPreset(WarriorStormsEyeCombo)]
	[CustomComboInfo("Gauge overcap saver", "Replace the Storm's Eye combo with gauge spender if completing the combo would overcap you.", WAR.JobID)]
	WarriorGaugeOvercapEyeFeature = 21010,

	[ParentPreset(WarriorStormsEyeCombo)]
	[CustomComboInfo("Surging Tempest overcap saver", "Replace Storm's Eye with Storm's Path when Surging Tempest buff has over 30 seconds left.", WAR.JobID)]
	WarriorStormsEyeBuffOvercapSaver = 21022,

	[CustomComboInfo("Mythril Tempest combo", "Replace Mythril Tempest with its combo chain.", WAR.JobID)]
	WarriorMythrilTempestCombo = 21002,

	[ParentPreset(WarriorMythrilTempestCombo)]
	[CustomComboInfo("Smart weave", "Automatically turn into Orogeny when weaving won't drift your GCD.", WAR.JobID)]
	WarriorSmartWeaveAOE = 21018,

	[ParentPreset(WarriorSmartWeaveAOE)]
	[CustomComboInfo("Buffed weave", "Wait until you have Surging Tempest active.", WAR.JobID)]
	WarriorSmartWeaveAOEOnlyBuffed = 21021,

	[ParentPreset(WarriorMythrilTempestCombo)]
	[CustomComboInfo("Gauge overcap saver", "Replace the Mythril Tempest combo with gauge spender if completing the combo would overcap you.", WAR.JobID)]
	WarriorGaugeOvercapTempestFeature = 21011,

	[CustomComboInfo("Inner Release feature", "Replace single-target and AoE combo with Fell Cleave/Decimate during Inner Release.", WAR.JobID)]
	WarriorInnerReleaseFeature = 21004,

	[CustomComboInfo("Nascent Flash feature", "Replace Nascent Flash with Raw Intuition when below level 76.", WAR.JobID)]
	WarriorNascentFlashFeature = 21005,

	[CustomComboInfo("Angry Beast feature", "Replace Inner Beast/Fell Cleave and Steel Cyclone/Decimate with Infuriate when less then 50 Beast Gauge is available.\nWhen you have at least 50 gauge AND the Nascent Chaos buff, they become Inner Chaos and Chaotic Cyclone, respectively.", WAR.JobID)]
	WarriorInfuriateBeastFeature = 21013,

	[ParentPreset(WarriorInfuriateBeastFeature)]
	[CustomComboInfo("Angry Beast gauge saver", "Replace the above with Infuriate when less than 60 Beast Gauge instead of 50.", WAR.JobID)]
	WarriorInfuriateBeastRaidModeFeature = 21015,

	[CustomComboInfo("Healthy balanaced diet", "Replace Bloodwhetting with Thrill of Battle, and then Equilibrium when the preceding is on cooldown.", WAR.JobID)]
	WarriorHealthyBalancedDietFeature = 21014,

	[CustomComboInfo("Primal Steel Beast", "Replace Inner Beast and Steel Cyclone with Primal Rend when available", WAR.JobID)]
	WarriorPrimalBeastFeature = 21007,

	[CustomComboInfo("Primal Release", "Replace Inner Release with Primal Rend when available", WAR.JobID)]
	WarriorPrimalReleaseFeature = 21008,

	#endregion
	// ====================================================================================
	#region WHITE MAGE (24xxx)

	[CustomComboInfo("Swiftcast Raise", "Raise turns into Swiftcast when available and reasonable.", WHM.JobID)]
	WhiteMageSwiftcastRaiserFeature = 24000,

	[CustomComboInfo("Lucid Weaving", "When MP is below a set threshold, weave Lucid Dreaming onto Aero/Dia, Stone/Glare, and Holy.", WHM.JobID)]
	WhiteMageLucidWeave = 24006,

	[CustomComboInfo("Solace into Misery", "Replaces Afflatus Solace with Afflatus Misery when Misery is ready to be used.", WHM.JobID)]
	WhiteMageSolaceMiseryFeature = 24001,

	[CustomComboInfo("Rapture into Misery", "Replaces Afflatus Rapture with Afflatus Misery when Misery is ready to be used and you have a target.", WHM.JobID)]
	WhiteMageRaptureMiseryFeature = 24002,

	[CustomComboInfo("Holy into Misery", "Replace Holy/Holy 3 with Afflatus Misery when Misery is ready to be used and you have a target.", WHM.JobID)]
	WhiteMageHolyMiseryFeature = 24005,

	[CustomComboInfo("Afflatus Feature", "Changes Cure 2 into Afflatus Solace, and Medica into Afflatus Rapture, when lilies are up.", WHM.JobID)]
	WhiteMageAfflatusFeature = 24004,

	[CustomComboInfo("Cure 2 Level Sync", "Changes Cure 2 to Cure when below level 30 in synced content.", WHM.JobID)]
	WhiteMageCureFeature = 24003,

	[CustomComboInfo("DOT Refresh", "Replace Stone/Glare with level appropriate DOT when debuff is about to fall off.", WHM.JobID)]
	WhiteMageDotRefresh = 24007,

	[CustomComboInfo("Presence of Glare", "Replace Presence of Mind with Glare IV when under Sacred Sight.", WHM.JobID)]
	WhiteMagePresenceOfMindGlare4 = 24008,

	[CustomComboInfo("Divine Temperance", "Replace Temperance with Divine Caress when under Divine Grace.", WHM.JobID)]
	WhiteMageTemperanceDivineCaress = 24009,

	[CustomComboInfo("Glare IV Combo", "Replace Glare with Glare IV when under Sacred Sight.", WHM.JobID)]
	WhiteMageGlareIVCombo = 24010,

	[CustomComboInfo("Glare of Mind", "Replace Glare with Presence of Mind when off cooldown", WHM.JobID)]
	WhiteMageGlareOfMind = 24011,

	#endregion
	// ====================================================================================
	#region DoH (98xxx)

	// [CustomComboInfo("Placeholder", "Placeholder.", DOH.JobID)]
	// DohPlaceholder = 98000,

	#endregion
	// ====================================================================================
	#region DoL (99xxx)

	[CustomComboInfo("Eureka Feature", "Replace Ageless Words and Solid Reason with Wise to the World when available.", DOL.JobID)]
	GatherEurekaFeature = 99000,

	[CustomComboInfo("Job Correction", "Replace Miner/Botanist actions with the other job's version when on the opposite job.", DOL.JobID)]
	GatherJobCorrectionFeature = 99009,

	[ParentPreset(GatherJobCorrectionFeature)]
	[CustomComboInfo("Ignore node detection skills", "Do not replace skills like Triangulate / Prospect, Lay of the Land / Arbor Call, and Truth of Mountains/Forests.", DOL.JobID)]
	GatherJobCorrectionIgnoreDetectionsFeature = 99010,

	[CustomComboInfo("Hook / Cast Feature", "Replace Hook with Cast when fishing, and vice-versa when not fishing.", DOL.JobID)]
	FisherCastHookFeature = 99001,

	[CustomComboInfo("Double Cast Feature", "Replace Double Hook with Cast with when not fishing.", DOL.JobID)]
	FisherCastDoubleHookFeature = 99011,

	[CustomComboInfo("Triple Cast Feature", "Replace Triple Hook with Cast with when not fishing.", DOL.JobID)]
	FisherCastTripleHookFeature = 99012,

	[CustomComboInfo("Multi Hook Feature: 3/2", "Replace Triple Hook with Double Hook when fishing but not enough GP.", DOL.JobID)]
	FisherCastMultiHookFeature32 = 99013,

	[CustomComboInfo("Multi Hook Feature: 2/1", "Replace Double Hook with normal Hook when fishing but not enough GP.", DOL.JobID)]
	FisherCastMultiHookFeature21 = 99014,

	[CustomComboInfo("Thaliak's Chum", "Replace Chum with Thaliak's Favour when less than 100 GP and at least three stacks of Angler's Art.", DOL.JobID)]
	FisherAutoFavourChum = 99015,

	[CustomComboInfo("Thaliak's Patience", "Replace Patience with Thaliak's Favour when less than 200 GP and at least three stacks of Angler's Art.", DOL.JobID)]
	FisherAutoFavourPatience = 99016,

	[CustomComboInfo("Thaliak's Patience II", "Replace Patience II with Thaliak's Favour when less than 560 GP and at least three stacks of Angler's Art.", DOL.JobID)]
	FisherAutoFavourPatience2 = 99017,

	[CustomComboInfo("Thaliak's Eyes", "Replace Fish Eyes with Thaliak's Favour when less than 550 GP and at least three stacks of Angler's Art.", DOL.JobID)]
	FisherAutoFavourFishEyes = 99018,

	[CustomComboInfo("Thaliak's Mooch II", "Replace Mooch II with Thaliak's Favour when less than 100 GP and at least three stacks of Angler's Art.", DOL.JobID)]
	FisherAutoFavourMooch2 = 99019,

	[CustomComboInfo("Thaliak's Trade", "Replace Veteran Trade with Thaliak's Favour when less than 200 GP and at least three stacks of Angler's Art.", DOL.JobID)]
	FisherAutoFavourVeteranTrade = 99020,

	[CustomComboInfo("Thaliak's Bounty", "Replace Nature's Bounty with Thaliak's Favour when less than 100 GP and at least three stacks of Angler's Art.", DOL.JobID)]
	FisherAutoFavourNaturesBounty = 99021,

	[CustomComboInfo("Thaliak's Slap", "Replace Surface Slap with Thaliak's Favour when less than 200 GP and at least three stacks of Angler's Art.", DOL.JobID)]
	FisherAutoFavourSurfaceSlap = 99022,

	[CustomComboInfo("Thaliak's Cast", "Replace Identical Cast with Thaliak's Favour when less than 350 GP and at least three stacks of Angler's Art.", DOL.JobID)]
	FisherAutoFavourIdenticalCast = 99023,

	[CustomComboInfo("Thaliak's Breath", "Replace Baited Breath with Thaliak's Favour when less than 300 GP and at least three stacks of Angler's Art.", DOL.JobID)]
	FisherAutoFavourBaitedBreath = 99024,

	[CustomComboInfo("Thaliak's Catch", "Replace Prize Catch with Thaliak's Favour when less than 200 GP and at least three stacks of Angler's Art.", DOL.JobID)]
	FisherAutoFavourPrizeCatch = 99025,

	[CustomComboInfo("Cast / Gig Feature", "Replace Cast with Gig when swimming.", DOL.JobID)]
	FisherCastGigFeature = 99002,

	[CustomComboInfo("Surface Slap / Veteran Trade Feature", "Replace Surface Slap with Veteran Trade when swimming.", DOL.JobID)]
	FisherSurfaceTradeFeature = 99003,

	[CustomComboInfo("Prize Catch / Nature's Bounty Feature", "Replace Prize Catch with Nature's Bounty when swimming.", DOL.JobID)]
	FisherPrizeBountyFeature = 99004,

	[CustomComboInfo("Snagging / Salvage Feature", "Replace Snagging with Salvage when swimming.", DOL.JobID)]
	FisherSnaggingSalvageFeature = 99005,

	[CustomComboInfo("Identical Cast / Vital Sight Feature", "Replace Identical Cast with Vital Sight when swimming.", DOL.JobID)]
	FisherIdenticalSightFeature = 99006,

	[CustomComboInfo("Makeshift Bait / Baited Breath Feature", "Replace Makeshift Bait with Baited Breath when swimming.", DOL.JobID)]
	FisherMakeshiftBreathFeature = 99007,

	[CustomComboInfo("Chum / Electric Current Feature", "Replace Chum with Electric Current when swimming.", DOL.JobID)]
	FisherElectricChumFeature = 99008,

	[CustomComboInfo("Priming Meticulous combo", "Replace Meticulous actions with Priming Touch when Special Collector active and have more than 400GP.", DOL.JobID)]
	PrimedMetFeature = 99027,

	[CustomComboInfo("Mooch / Spareful Hand Feature", "Replace Mooch with Spareful Hand if you have space available in Swimbait box.", DOL.JobID)]
	FisherSwimbaitFeature = -99026, // negative ID means force-disabled, but the enum entry still exists to compile - remove the negative sign to enable

	#endregion
}
public static class CustomComboPresetExtensions {
	public static CustomComboPreset[] GetConflicts(this CustomComboPreset preset) => preset.GetAttribute<ConflictsAttribute>()?.Conflicts ?? [];
	public static CustomComboPreset[] GetAlternatives(this CustomComboPreset preset) => preset.GetAttribute<DeprecatedAttribute>()?.Recommended ?? [];
	public static CustomComboPreset? GetParent(this CustomComboPreset preset) => preset.GetAttribute<ParentPresetAttribute>()?.Parent;
	public static string GetDebugLabel(this CustomComboPreset preset) => $"{Enum.GetName(preset)!}#{(int)preset}";
}
