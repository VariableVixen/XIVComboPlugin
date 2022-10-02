namespace XIVComboVX;

using System;

using Dalamud.Utility;

using XIVComboVX.Attributes;
using XIVComboVX.Combos;

public enum CustomComboPreset {
	// ====================================================================================
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
	#endregion
	// ====================================================================================
	#region ASTROLOGIAN (33xx)

	[CustomComboInfo("Swiftcast Ascend", "Ascend turns into Swiftcast when available and reasonable.", AST.JobID)]
	AstrologianSwiftcastRaiserFeature = 3300,

	[CustomComboInfo("Play to Draw", "Replace Play with Draw when no card is drawn and a card is available.", AST.JobID)]
	AstrologianPlayDrawFeature = 3301,

	[ParentPreset(AstrologianPlayDrawFeature)]
	[CustomComboInfo("Play to Draw to Astrodyne", "Replace Play with Astrodyne when seals are full and Draw is on Cooldown.", AST.JobID)]
	AstrologianPlayDrawAstrodyneFeature = 3307,

	[CustomComboInfo("Play to Astrodyne", "Replace Play with Astrodyne when seals are full.", AST.JobID)]
	AstrologianPlayAstrodyneFeature = 3304,

	[CustomComboInfo("Draw Lockout", "Replace Draw (not Play to Draw) with Malefic when a card is drawn.", AST.JobID)]
	AstrologianDrawLockoutFeature = 3306,

	[CustomComboInfo("Benefic 2 to Benefic Level Sync", "Changes Benefic 2 to Benefic when below level 26.", AST.JobID)]
	AstrologianBeneficFeature = 3303,

	#endregion
	// ====================================================================================
	#region BLACK MAGE (25xx)

	[CustomComboInfo("Enochian Feature", "Change Fire 4 or Blizzard 4 to whichever action you can currently use.", BLM.JobID)]
	BlackEnochianFeature = 2500,

	[ParentPreset(BlackEnochianFeature)]
	[CustomComboInfo("Enochian Despair Feature", "Change Fire 4 or Blizzard 4 to Despair when in Astral Fire with less than 2400 mana.", BLM.JobID)]
	BlackEnochianDespairFeature = 2510,

	[ParentPreset(BlackEnochianFeature)]
	[CustomComboInfo("Enochian No Sync Feature", "Fire 4 and Blizzard 4 will not sync to Fire 1 and Blizzard 1.", BLM.JobID)]
	BlackEnochianNoSyncFeature = 2518,

	[CustomComboInfo("Umbral Soul/Transpose Switcher", "Change Transpose into Umbral Soul when Umbral Soul is usable.", BLM.JobID)]
	BlackManaFeature = 2501,

	[CustomComboInfo("(Between the) Ley Lines", "Change Ley Lines into BTL when Ley Lines is active.", BLM.JobID)]
	BlackLeyLinesFeature = 2502,

	[CustomComboInfo("Fire 1/3 Astral Feature", "Fire 1 becomes Fire 3 with 1 or fewer stacks of Astral Fire.", BLM.JobID)]
	BlackFireAstralFeature = 2503,

	[CustomComboInfo("Fire 1/3 Proc Feature", "Fire 1 becomes Fire 3 when Firestarter proc is up.", BLM.JobID)]
	BlackFireProcFeature = 2509,

	[CustomComboInfo("Blizzard 1/3 Feature", "Replace Blizzard 1 with Blizzard 3 when unlocked.", BLM.JobID)]
	BlackBlizzardFeature = 2504,

	[CustomComboInfo("Freeze/Flare Feature", "Freeze and Flare become whichever action you can currently use.", BLM.JobID)]
	BlackFreezeFlareFeature = 2505,

	[CustomComboInfo("Fire 2 Feature", "(High) Fire 2 becomes Flare in Astral Fire with 1 or fewer Umbral Hearts.", BLM.JobID)]
	BlackFire2Feature = 2507,

	[CustomComboInfo("Ice 2 Feature", "(High) Blizzard 2 becomes Freeze in Umbral Ice.", BLM.JobID)]
	BlackBlizzard2Feature = 2508,

	[CustomComboInfo("Fire 2/Ice 2 Option", "Fire 2 and Blizzard 2 will not change unless you're at max Astral Fire or Umbral Ice.", BLM.JobID)]
	BlackFireBlizzard2Option = 2514,

	[CustomComboInfo("Umbral Soul Feature", "Replace your ice spells with Umbral Soul, while in Umbral Ice and having no target.", BLM.JobID)]
	BlackUmbralSoulFeature = 2517,

	[CustomComboInfo("Scathe/Xenoglossy Feature", "Scathe becomes Xenoglossy when available.", BLM.JobID)]
	BlackScatheFeature = 2506,

	#endregion
	// ====================================================================================
	#region BARD (23xx)

	[CustomComboInfo("Heavy Shot into Straight Shot", "Replaces Heavy Shot/Burst Shot with Straight Shot/Refulgent Arrow when procced.", BRD.JobID)]
	BardStraightShotUpgradeFeature = 2301,

	[CustomComboInfo("Iron Jaws Feature", "Iron Jaws is replaced with Caustic Bite/Stormbite if one or both are not up.\nAlternates between the two if Iron Jaws isn't available.", BRD.JobID)]
	BardIronJawsFeature = 2302,

	[CustomComboInfo("Apex Arrow Feature", "Replaces Heavy Shot, Burst Shot, Quick Nock, and Ladonsbit\nwith Blast Arrow when available, or Apex Arrow if gauge is full.", BRD.JobID)]
	BardApexFeature = 2303,

	[CustomComboInfo("Quick Nock / Ladonsbite into Shadowbite", "Replaces Quick Nock and Ladonsbite with Shadowbite when available.", BRD.JobID)]
	BardShadowbiteFeature = 2304,

	[CustomComboInfo("Bloodletter Feature", "Replaces Bloodletter with Empyreal Arrow and Sidewinder depending on which is available.", BRD.JobID)]
	BardBloodletterFeature = 2305,

	[Conflicts(BardBloodletterFeature)]
	[CustomComboInfo("Bloodletter to Rain of Death", "Replace Bloodletter with Rain of Death if there are no self-applied DoTs on your target.", BRD.JobID)]
	BardBloodRainFeature = 2313,

	[CustomComboInfo("Rain of Death Feature", "Replaces Rain of Death with Empyreal Arrow and Sidewinder depending on which is available.", BRD.JobID)]
	BardRainOfDeathFeature = 2306,

	[CustomComboInfo("Sidewinder Feature", "Replace Sidewinder with Empyreal Arrow depending on which is available.", BRD.JobID)]
	BardSidewinderFeature = 2309,

	[CustomComboInfo("Radiant Voice Feature", "Replace Radiant Finale with Battle Voice if Battle Voice is available.", BRD.JobID)]
	BardRadiantVoiceFeature = 2310,

	[CustomComboInfo("Radiant Strikes Feature", "Replace Radiant Finale with Raging Strikes if Raging Strikes is available.\nThis takes priority over Battle Voice if Radiant Voice is enabled.", BRD.JobID)]
	BardRadiantStrikesFeature = 2311,

	[CustomComboInfo("Barrage Feature", "Replace Barrage with Straight Shot if you have Straight Shot Ready (unless Shadowbite is ready).", BRD.JobID)]
	BardBarrageFeature = 2312,

	#endregion
	// ====================================================================================
	#region DANCER (38xx)

	[CustomComboInfo("Single Target Multibutton", "Change Cascade into procs and combos as available.", DNC.JobID)]
	DancerSingleTargetMultibutton = 3800,

	[ParentPreset(DancerSingleTargetMultibutton)]
	[CustomComboInfo("Fan Dance 1/3 Weaving", "Also change into Fan Dance 1/3 when you can weave without clipping.", DNC.JobID)]
	DancerSingleTargetFanDanceWeave = 3810,

	[ParentPreset(DancerSingleTargetFanDanceWeave)]
	[CustomComboInfo("Fan Dance 2/4 Fallback", "Also change into Fan Dance 2/4, with lower priority than 1/3.", DNC.JobID)]
	DancerSingleTargetFanDanceFallback = 3812,

	[CustomComboInfo("AoE Multibutton", "Change Windmill into procs and combos as available.", DNC.JobID)]
	DancerAoeMultibutton = 3801,

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
	[CustomComboInfo("Dance Step Feature", "Change custom actions into dance steps while dancing." +
		"\nYou can get Action IDs with Garland Tools by searching for the action and clicking the cog.", DNC.JobID)]
	DancerDanceComboCompatibility = 3806,

	#endregion
	// ====================================================================================
	#region DRAGOON (22xx)

	[CustomComboInfo("Coerthan Torment Combo", "Replace Coerthan Torment with its combo chain.", DRG.JobID)]
	DragoonCoerthanTormentCombo = 2200,

	[CustomComboInfo("Coerthan Torment Wyrmwind Feature", "Replace Coerthan Torment with Wyrmwind Thrust when you have two Firstminds' Focus.", DRG.JobID)]
	DragoonCoerthanWyrmwindFeature = 2209,

	[CustomComboInfo("Chaos Thrust Combo", "Replace Chaos Thrust with its combo chain.", DRG.JobID)]
	DragoonChaosThrustCombo = 2201,

	[ParentPreset(DragoonChaosThrustCombo)]
	[CustomComboInfo("Chaos Thrust from Disembowl", "Start the Chaos Thrust combo chain with Disembowl instead of True Thrust.", DRG.JobID)]
	DragoonChaosThrustLateOption = 2207,

	[CustomComboInfo("Full Thrust Combo", "Replace Full Thrust with its combo chain.", DRG.JobID)]
	DragoonFullThrustCombo = 2202,

	[ParentPreset(DragoonFullThrustCombo)]
	[CustomComboInfo("Full Thrust from Vorpal", "Start the Full Thrust combo chain with Vorpal Thrust instead of True Thrust.", DRG.JobID)]
	DragoonFullThrustLateOption = 2208,

	[ParentPreset(DragoonFullThrustCombo)]
	[CustomComboInfo("Power Surge Buff Saver", "When the Power Surge buff is about to run out (or isn't up), execute the Chaos Thrust chain to use Disembowl.", DRG.JobID)]
	DragoonFullThrustBuffSaver = 2212,

	[CustomComboInfo("Wheeling Thrust / Fang and Claw Option", "When you have either Enhanced Fang and Claw or Wheeling Thrust, Chaos Thrust becomes Wheeling Thrust and Full Thrust becomes Fang and Claw.", DRG.JobID)]
	DragoonFangThrustFeature = 2206,

	[Conflicts(DragoonStardiverDragonfireDiveFeature)]
	[CustomComboInfo("Stardiver to Nastrond", "Replace Stardiver with Nastrond when Nastrond is off-cooldown, and Geirskogul outside of Life of the Dragon.", DRG.JobID)]
	DragoonStardiverNastrondFeature = 2210,

	[Conflicts(DragoonStardiverNastrondFeature)]
	[CustomComboInfo("Stardiver to Dragonfire Dive", "Replace Stardiver with Dragonfire Dive when the latter is off cooldown (and you have more than 7.5s of LotD left), or outside of Life of the Dragon.", DRG.JobID)]
	DragoonStardiverDragonfireDiveFeature = 2211,

	[Conflicts(DragoonStardiverDragonfireDiveFeature, DragoonStardiverNastrondFeature)]
	[CustomComboInfo("Dive Dive Dive!", "Replace Spineshatter Dive, Dragonfire Dive, and Stardiver with whichever is available.", DRG.JobID)]
	DragoonDiveFeature = 2205,

	[CustomComboInfo("Mirage Jump", "Replace Jump and High Jump with Mirage Dive when Dive Ready.", DRG.JobID)]
	DragoonMirageJumpFeature = 2213,

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

	[CustomComboInfo("No Mercy - Bow Shock / Sonic Break", "Replace No Mercy with Bow Shock, and then Sonic Break, while No Mercy is active.", GNB.JobID)]
	GunbreakerNoMercyFeature = 3706,

	[CustomComboInfo("No Mercy - Double Down", "Replace No Mercy with Double Down while No Mercy is active, 2 cartridges are available, and Double Down is off cooldown.\nThis takes priority over the No Mercy Bow Shock/Sonic Break Feature.", GNB.JobID)]
	GunbreakerNoMercyDoubleDownFeature = 3712,

	[Conflicts(GunbreakerNoMercyFeature)]
	[CustomComboInfo("Always Double Down", "Replace No Mercy with Double Down while No Mercy is active.", GNB.JobID)]
	GunbreakerNoMercyAlwaysDoubleDownFeature = 3713,

	[CustomComboInfo("Bow Shock / Sonic Break Swap", "Replace Bow Shock and Sonic Break with one or the other, depending on which is on cooldown.", GNB.JobID)]
	GunbreakerBowShockSonicBreakFeature = 3707,

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

	[ParentPreset(GunbreakerSolidBarrelCombo)]
	[CustomComboInfo("Rough Divide Feature", "Replace Solid Barrel with Rough Divide when you are within the target's hitbox, not moving, and have the No Mercy buff.", GNB.JobID)]
	GunbreakerSolidRoughDivide = 3723,

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
	[CustomComboInfo("Hypercharge Combo", "Replace Clean Shot combo with Heat Blast while overheated.", MCH.JobID)]
	MachinistHypercombo = 3108,

	[CustomComboInfo("Spread Shot Heat", "Replace Spread Shot with Auto Crossbow when overheated.", MCH.JobID)]
	MachinistSpreadShot = 3101,

	[CustomComboInfo("Hypercharge Feature", "Replace Heat Blast and Auto Crossbow with Hypercharge when not overheated.", MCH.JobID)]
	MachinistOverheat = 3102,

	[CustomComboInfo("Hyperfire Feature", "Replace Hypercharge with Wildfire if available and you have a target.", MCH.JobID)]
	MachinistHyperfire = 3109,

	[CustomComboInfo("Overdrive Feature", "Replace Rook Autoturret and Automaton Queen with their respective Overdrive while active.", MCH.JobID)]
	MachinistOverdrive = 3103,

	[CustomComboInfo("Gauss Round / Ricochet Feature", "Replace Gauss Round and Ricochet with one or the other depending on which has less recharge time left.", MCH.JobID)]
	MachinistGaussRoundRicochet = 3104,

	[ParentPreset(MachinistGaussRoundRicochet)]
	[CustomComboInfo("Gauss Round / Ricochet Overheat Option", "Replace Gauss Round and Ricochet with one or the other only while overheated.", MCH.JobID)]
	MachinistGaussRoundRicochetLimiter = 3110,

	[CustomComboInfo("Hot Shot / Air Anchor / Drill Feature", "Replace Hot Shot (Air Anchor) and Drill with whichever is available.\nTries to avoid overcapping battery, but only if that would NOT present a potency loss.", MCH.JobID)]
	MachinistDrillAirAnchor = 3105,

	[ParentPreset(MachinistDrillAirAnchor)]
	[CustomComboInfo("HS/AA/D + Chain Saw Feature", "Also allow the above to become Chain Saw.\nChain Saw itself will not change.", MCH.JobID)]
	MachinistDrillAirAnchorPlus = 3106,

	#endregion
	// ====================================================================================
	#region MONK (20xx)

	[CustomComboInfo("Monk AoE Combo", "Replaces the selected actions with the AoE combo chain.", MNK.JobID)]
	MonkAoECombo = 2000,

	[ParentPreset(MonkAoECombo)]
	[CustomComboInfo("On Destroyer", "Replaces (Arm/Shadow) of the Destroyer with the AoE combo chain.", MNK.JobID)]
	MonkAoECombo_Destroyers = 2099,

	[ParentPreset(MonkAoECombo)]
	[CustomComboInfo("On Masterful Blitz", "Replaces Masterful Blitz with the AoE combo chain.", MNK.JobID)]
	MonkAoECombo_MasterBlitz = 2098,

	[ParentPreset(MonkAoECombo)]
	[CustomComboInfo("On Rockbreaker", "Replaces Rockbreaker with the AoE combo chain.", MNK.JobID)]
	MonkAoECombo_Rockbreaker = 2097,

	[CustomComboInfo("Monk ST Combo", "Replace Bootshine with all single-target rotation actions", MNK.JobID)]
	MonkSTCombo = 2017,

	[CustomComboInfo("Dragon Kick to Bootshine Feature", "Replaces Dragon Kick with Bootshine if Leaden Fist is up.", MNK.JobID)]
	MonkBootshineFeature = 2001,

	[CustomComboInfo("Dragon Kick to Masterful Blitz Feature", "Replaces Dragon Kick with Masterful Blitz if you have three Beast Chakra.", MNK.JobID)]
	MonkDragonKickBalanceFeature = 2012,

	[CustomComboInfo("Dragon Meditation Feature", "Replace Dragon Kick with Meditation when out of combat and the Fifth Chakra is not open.", MNK.JobID)]
	MonkDragonKickMeditationFeature = 2015,

	[CustomComboInfo("Steel Peak / Forbidden Chakra Feature", "Replace Dragon Kick with Meditation / Steel Peak / The Forbidden Chakra when in of combat and the Fifth Chakra is open.", MNK.JobID)]
	MonkDragonKickSteelPeakFeature = 2016,

	[CustomComboInfo("Twin Snakes to True Strike Feature", "Replaces Twin Snakes with True Strike if Disciplined Fist is up.\nAlso applies to the ST combo feature.", MNK.JobID)]
	MonkTwinSnakesFeature = 2010,

	[CustomComboInfo("Demolish to Snap Punch Feature", "Replaces Demolish with Snap Punch if target is under Demolish.\nAlso applies to the ST combo feature.", MNK.JobID)]
	MonkDemolishFeature = 2011,

	[CustomComboInfo("Howling Fist / Meditation Feature", "Replaces Howling Fist with Meditation when the Fifth Chakra is not open.", MNK.JobID)]
	MonkHowlingFistMeditationFeature = 2002,

	[CustomComboInfo("Perfect Balance Feature", "Replace Perfect Balance with Masterful Blitz when you have 3 Beast Chakra, or when under Perfect Balance already.", MNK.JobID)]
	MonkPerfectBalanceFeature = 2004,

	[CustomComboInfo("Riddle of Brotherly Fire", "Replace Riddle of Fire with Brotherhood if the former is on CD and the latter isn't.", MNK.JobID)]
	MonkBrotherlyFire = 2013,

	[CustomComboInfo("Riddle of Fire and Wind", "Replace Riddle of Fire with Riddle of Wind if the former is on CD and the latter isn't.", MNK.JobID)]
	MonkFireWind = 2014,

	#endregion
	// ====================================================================================
	#region NINJA (30xx)

	[CustomComboInfo("Armor Crush Combo", "Replace Armor Crush with its combo chain.", NIN.JobID)]
	NinjaArmorCrushCombo = 3000,

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
	[CustomComboInfo("Huraijin Feature", "Replaces the Armor Crush combo chain with Huraijin when Huton is missing.", NIN.JobID)]
	NinjaArmorCrushHuraijinFeature = 3023,

	[ParentPreset(NinjaArmorCrushCombo)]
	[CustomComboInfo("Fallback to Aeolian Edge", "Replaces Armor Crush with Aeolian Edge when underlevel.", NIN.JobID)]
	NinjaArmorCrushFallbackFeature = 3020,

	[CustomComboInfo("Aeolian Edge Combo", "Replace Aeolian Edge with its combo chain.", NIN.JobID)]
	NinjaAeolianEdgeCombo = 3001,

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

	[ParentPreset(NinjaAeolianEdgeCombo)]
	[CustomComboInfo("Huraijin Feature", "Replaces the Aeolian Edge combo chain with Huraijin when Huton is missing.", NIN.JobID)]
	NinjaAeolianEdgeHuraijinFeature = 3024,

	[ParentPreset(NinjaAeolianEdgeCombo)]
	[CustomComboInfo("Huton Feature", "Replaces Aeolian Edge with Armor Crush when Huton timer is below a set threshold.", NIN.JobID)]
	NinjaAeolianEdgeHutonFeature = 3014,

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

	[CustomComboInfo("Single Target Smart Weave", "Replaces both Aeolian Edge and Armor Crush combos with the following when weaving and available:\n- Assassinate or DWAD\n- Bhavacakra\n- Bunshin\n- Phantom Kamaitachi.", NIN.JobID)]
	NinjaSingleTargetSmartWeaveFeature = 3026,

	[CustomComboInfo("AoE Smart Weave", "Replaces Death Blossom / Hakke Mujinsatsu with Hellfrog Medium when weaving and available.", NIN.JobID)]
	NinjaAOESmartWeaveFeature = 3027,

	#endregion
	// ====================================================================================
	#region PALADIN (19xx)

	[CustomComboInfo("Stun/Interrupt Feature", "Turn Low Blow and Interject into Interject when off CD and your target can be interrupted, Low Blow otherwise.", PLD.JobID)]
	PaladinStunInterruptFeature = 1907,

	[CustomComboInfo("Goring Blade Combo", "Replace Goring Blade with its combo chain.", PLD.JobID)]
	PaladinGoringBladeCombo = 1900,

	[ParentPreset(PaladinGoringBladeCombo)]
	[CustomComboInfo("Intervening Blade Feature", "Replace the GB combo with Intervene when NOT in the combo chain, and the current target is out of melee range.", PLD.JobID)]
	PaladinGoringBladeRangeSwapFeature = 1910,

	[ParentPreset(PaladinGoringBladeRangeSwapFeature)]
	[CustomComboInfo("Level Sync", "Replace Intervene with Shield Lob when under level.", PLD.JobID)]
	PaladinGoringBladeRangeSwapSyncFeature = 1911,

	[CustomComboInfo("Royal Authority Combo", "Replace Royal Authority/Rage of Halone with its combo chain.", PLD.JobID)]
	PaladinRoyalAuthorityCombo = 1901,

	[ParentPreset(PaladinRoyalAuthorityCombo)]
	[CustomComboInfo("Royal Intervention Feature", "Replace the RA/RoH combo with Intervene when NOT in the combo chain, and the current target is out of melee range.", PLD.JobID)]
	PaladinRoyalAuthorityRangeSwapFeature = 1912,

	[ParentPreset(PaladinRoyalAuthorityRangeSwapFeature)]
	[CustomComboInfo("Level Sync", "Replace Intervene with Shield Lob when under level.", PLD.JobID)]
	PaladinRoyalAuthorityRangeSwapSyncFeature = 1913,

	[ParentPreset(PaladinRoyalAuthorityCombo)]
	[CustomComboInfo("Royal Authority DoT Saver", "The RA/RoH combo chain becomes Goring Blade at the end, if your current target has less than seven seconds (adjustable) on the GB DoT.\nThis includes when your target doesn't have the DoT.", PLD.JobID)]
	PaladinRoyalAuthorityDoTSaver = 1909,

	[CustomComboInfo("Atonement Feature", "Replace the Royal Authority and Goring Blade combos with Atonement when under the effect of Sword Oath.", PLD.JobID)]
	PaladinAtonementFeature = 1902,

	[CustomComboInfo("Prominence Combo", "Replace Prominence with its combo chain.", PLD.JobID)]
	PaladinProminenceCombo = 1903,

	[CustomComboInfo("Requiescat Confiteor", "Replace Requiescat with Confiteor while under the effect of Requiescat.", PLD.JobID)]
	PaladinRequiescatConfiteorCombo = 1904,

	[CustomComboInfo("Requiescat Feature", "Replace Royal Authority/Goring Blade combos with Holy Spirit, and Prominence combo with Holy Circle, while Requiescat is active.", PLD.JobID)]
	PaladinRequiescatFeature = 1905,

	[CustomComboInfo("Confiteor Feature", "Replace Holy Spirit/Circle with Confiteor when Requiescat is up and MP is under 2000 or only one stack remains.\nAlso changes the RA/GB/Prominence-into-HS/HC-combos into Confiteor.", PLD.JobID)]
	PaladinConfiteorFeature = 1908,

	[ParentPreset(PaladinConfiteorFeature)]
	[CustomComboInfo("Post-Confiteor Chain", "Include the Blade of Faith/Truth/Valor chain after Confiteor.", PLD.JobID)]
	PaladinConfiteorChainFeature = 1914,

	[CustomComboInfo("Intervene Level Sync", "Replace Intervene with Shield Lob when under level.", PLD.JobID)]
	PaladinInterveneSyncFeature = 1906,

	#endregion
	// ====================================================================================
	#region RED MAGE (35xx)

	[CustomComboInfo("Swiftcast Verraise", "Verraise turns into Swiftcast when available and reasonable.", RDM.JobID)]
	RedMageSwiftcastRaiserFeature = 3500,

	[Conflicts(RedMageVerprocCombo)]
	[CustomComboInfo("Smartcast Single Target", "Dynamically replaces Verstone/Verfire with the appropriate spell based on your job gauge.\nVeraero and Verthunder are replaced with one or the other accordingly, for openers.", RDM.JobID)]
	RedMageSmartcastSingleFeature = 3509,

	[ParentPreset(RedMageSmartcastSingleFeature)]
	[CustomComboInfo("Fleche Weave", "Turns the single-target smartcast combo into Fleche when you can weave without clipping.\nAffected by the Contre Sixte / Fleche feature.", RDM.JobID)]
	RedMageSmartcastSingleWeave = 3518,

	[ParentPreset(RedMageSmartcastSingleWeave)]
	[CustomComboInfo("Engagement", "If you're in melee range and Fleche (+ Contra Sixte if applicable) can't be used yet, fall back to Engagement.", RDM.JobID)]
	RedMageSmartcastSingleWeaveMelee = 3523,

	[ParentPreset(RedMageSmartcastSingleWeaveMelee)]
	[CustomComboInfo("Engagement Priority", "Try to use Engagement first when in melee range.\nWhile it IS a potency loss, Engagement can ONLY be used in melee range, which keeps the long-distance abilities free for when you're too far away.", RDM.JobID)]
	RedMageSmartcastSingleWeaveMeleeFirst = 3525,

	[ParentPreset(RedMageSmartcastSingleFeature)]
	[CustomComboInfo("Walking Fleche", "Turns the single-target smartcast combo into Fleche when you're moving and can't instacast.\nAffected by the Contre Sixte / Fleche feature.", RDM.JobID)]
	RedMageSmartcastSingleMovement = 3519,

	[ParentPreset(RedMageSmartcastSingleMovement)]
	[CustomComboInfo("Engagement", "If you're in melee range and Fleche (+ Contra Sixte if applicable) can't be used yet, fall back to Engagement.", RDM.JobID)]
	RedMageSmartcastSingleMovementMelee = 3524,

	[ParentPreset(RedMageSmartcastSingleMovementMelee)]
	[CustomComboInfo("Engagement Priority", "Try to use Engagement first when in melee range.\nWhile it IS a potency loss, Engagement can ONLY be used in melee range, which keeps the long-distance abilities free for when you're too far away.", RDM.JobID)]
	RedMageSmartcastSingleMovementMeleeFirst = 3526,

	[ParentPreset(RedMageSmartcastSingleFeature)]
	[CustomComboInfo("Melee Combo Followthrough", "Turns the single-target smartcast combo into the rest of the melee combo once you start it, as long as you're in melee range.", RDM.JobID)]
	RedMageSmartcastSingleMeleeCombo = 3521,

	[ParentPreset(RedMageSmartcastSingleMeleeCombo)]
	[CustomComboInfo("Auto Start", "Turns the single-target smartcast combo into your melee combo when you're ready to execute it and your mana levels AREN'T equal.", RDM.JobID)]
	RedMageSmartcastSingleMeleeComboStarter = 3522,

	[ParentPreset(RedMageSmartcastSingleFeature)]
	[CustomComboInfo("Acceleration", "Turns the single-target smartcast combo into Acceleration instead of Jolt.", RDM.JobID)]
	RedMageSmartcastSingleAcceleration = 3527,

	[ParentPreset(RedMageSmartcastSingleAcceleration)]
	[CustomComboInfo("With Swiftcast", "Acceleration falls back to Swiftcast if available and out of charges.", RDM.JobID)]
	RedMageSmartcastSingleAccelerationSwiftcast = 3528,

	[ParentPreset(RedMageSmartcastSingleAccelerationSwiftcast)]
	[CustomComboInfo("Swiftcast Priority", "Swiftcast is used before Acceleration if it's up.", RDM.JobID)]
	RedMageSmartcastSingleAccelerationSwiftcastFirst = 3529,

	[ParentPreset(RedMageSmartcastSingleAcceleration)]
	[CustomComboInfo("Combat Only", "Only become Acceleration (+ Swiftcast if applicable) when in combat.", RDM.JobID)]
	RedMageSmartcastSingleAccelerationCombat = 3530,

	[Conflicts(RedMageAoECombo)]
	[CustomComboInfo("Smartcast AoE", "Dynamically replaces Veraero/Verthunder 2 with the appropriate spell based on your job gauge.\nIncludes Impact/Scatter when fastcasting.", RDM.JobID)]
	RedMageSmartcastAoEFeature = 3508,

	[ParentPreset(RedMageSmartcastAoEFeature)]
	[CustomComboInfo("Contre Sixte Weave", "Turns the AoE smartcast combo into Contre Sixte when you can weave without clipping.\nAffected by the Contre Sixte / Fleche feature.", RDM.JobID)]
	RedMageSmartcastAoEWeave = 3517,

	[ParentPreset(RedMageSmartcastAoEFeature)]
	[CustomComboInfo("Walking Contre Sixte", "Turns the AoE smartcast combo into Contre Sixte when you're moving and can't instacast.\nAffected by the Contre Sixte / Fleche feature.", RDM.JobID)]
	RedMageSmartcastAoEMovement = 3520,

	[CustomComboInfo("Melee Combo", "Replaces Redoublement with its combo chain, following enchantment rules.", RDM.JobID)]
	RedMageMeleeCombo = 3502,

	[ParentPreset(RedMageMeleeCombo)]
	[CustomComboInfo("Melee Combo+", "Replaces Redoublement (and Moulinet) with Verflare/Verholy (and then Scorch and Resolution) after 3 mana stacks, whichever is more appropriate.", RDM.JobID)]
	RedMageMeleeComboPlus = 3503,

	[ParentPreset(RedMageMeleeCombo)]
	[CustomComboInfo("Gap Closer", "Replaces Redoublement with Corps-a-corps when out of melee range.", RDM.JobID)]
	RedMageMeleeComboCloser = 3514,

	[Conflicts(RedMageSmartcastAoEFeature)]
	[CustomComboInfo("Red Mage AoE Combo", "Replaces Veraero/Verthunder 2 with Impact when under a cast speeder.", RDM.JobID)]
	RedMageAoECombo = 3501,

	[Conflicts(RedMageSmartcastSingleFeature)]
	[CustomComboInfo("Verproc into Jolt", "Replaces Verstone/Verfire with Jolt (2) when no proc is available.", RDM.JobID)]
	RedMageVerprocCombo = 3504,

	[ParentPreset(RedMageVerprocCombo)]
	[CustomComboInfo("Verproc into Jolt Plus", "Additionally replaces Verstone/Verfire with Veraero/Verthunder if fastcasting are up.", RDM.JobID)]
	RedMageVerprocComboPlus = 3505,

	[ParentPreset(RedMageVerprocComboPlus)]
	[CustomComboInfo("Verproc into Jolt Plus Veraero Opener", "Turns Verstone into Veraero when out of combat.", RDM.JobID)]
	RedMageVeraeroOpenerFeature = 3506,

	[ParentPreset(RedMageVerprocComboPlus)]
	[CustomComboInfo("Verproc into Jolt Plus Verthunder Opener", "Turns Verfire into Verthunder when out of combat.", RDM.JobID)]
	RedMageVerthunderOpenerFeature = 3507,

	[CustomComboInfo("Contre Sixte / Fleche Feature", "Turns Contre Sixte and Fleche into whichever is available.", RDM.JobID)]
	RedMageContreFlecheFeature = 3510,

	[CustomComboInfo("Acceleration into Swiftcast", "Replace Acceleration with Swiftcast when on cooldown or synced.", RDM.JobID)]
	RedMageAccelerationSwiftcastFeature = 3511,

	[ParentPreset(RedMageAccelerationSwiftcastFeature)]
	[CustomComboInfo("Acceleration with Swiftcast first", "Replace Acceleration with Swiftcast when neither are on cooldown.", RDM.JobID)]
	RedMageAccelerationSwiftcastOption = 3512,

	[CustomComboInfo("Embolden to Manaification", "Replace Embolden with Manafication if the former is on cooldown and the latter is not.", RDM.JobID)]
	RedMageEmboldenFeature = 3513,

	[CustomComboInfo("Gap Reverser: Backstep", "Replaces Corps-a-corps with Displacement when your taget is in melee range.", RDM.JobID)]
	RedMageMeleeGapReverserBackstep = 3515,

	[CustomComboInfo("Gap Reverser: Lunge", "Replaces Displacement with Corps-a-corps when your taget is NOT in melee range.", RDM.JobID)]
	RedMageMeleeGapReverserLunge = 3516,

	#endregion
	// ====================================================================================
	#region REAPER (39xx)

	[CustomComboInfo("Slice Combo", "Replace Infernal Slice with its combo chain.", RPR.JobID)]
	ReaperSliceCombo = 3901,

	[Experimental]
	[CustomComboInfo("Slice Weave Assist", "Replace Infernal Slice with Blood Stalk (or variants) when available and weaving wouldn't clip your GCD.", RPR.JobID)]
	ReaperSliceWeaveAssist = 3942,

	[ParentPreset(ReaperSliceWeaveAssist)]
	[CustomComboInfo("Ignore Reaving", "Allow weaving even if you're already reaving.", RPR.JobID)]
	ReaperSliceWeaveAssistDoubleReaving = 3948,

	[CustomComboInfo("Slice of Death Feature", "Replace Infernal Slice with Shadow of Death when the target's Death's Design debuff is low.", RPR.JobID)]
	ReaperSliceShadowFeature = 3940,

	[Experimental]
	[CustomComboInfo("Soulful Slice", "Replace Infernal Slice with Soul Slice when available and Soul Gauge is no more than 50.", RPR.JobID)]
	ReaperSoulOnSliceFeature = 3946,

	[Conflicts(ReaperSliceGallowsFeature)]
	[CustomComboInfo("Slice Gibbet Feature", "Replace Infernal Slice with Gibbet while Reaving or Enshrouded.", RPR.JobID)]
	ReaperSliceGibbetFeature = 3903,

	[Conflicts(ReaperSliceGibbetFeature)]
	[CustomComboInfo("Slice Gallows Feature", "Replace Infernal Slice with Gallows while Reaving or Enshrouded.", RPR.JobID)]
	ReaperSliceGallowsFeature = 3904,

	[CustomComboInfo("Slice Enhanced Soul Reaver Feature", "Replace Infernal Slice with whichever of Gibbet or Gallows is currently enhanced while Reaving.", RPR.JobID)]
	ReaperSliceEnhancedSoulReaverFeature = 3913,

	[CustomComboInfo("Slice Enhanced Enshrouded Feature", "Replace Infernal Slice with whichever of Gibbet or Gallows is currently enhanced while Enshrouded.", RPR.JobID)]
	ReaperSliceEnhancedEnshroudedFeature = 3914,

	[CustomComboInfo("Slice Lemure's Feature", "Replace Infernal Slice with Lemure's Slice when two or more stacks of Void Shroud are active.", RPR.JobID)]
	ReaperSliceLemuresFeature = 3919,

	[CustomComboInfo("Slice Communio Feature", "Replace Infernal Slice with Communio when one stack of Shroud is left.", RPR.JobID)]
	ReaperSliceCommunioFeature = 3920,

	[CustomComboInfo("Slice Soulsow Feature", "Replace Infernal Slice with Soulsow when out of combat and not active.", RPR.JobID)]
	ReaperSliceSoulsowFeature = 3930,

	[Conflicts(ReaperShadowGibbetFeature)]
	[CustomComboInfo("Shadow Gallows Feature", "Replace Shadow of Death with Gallows while Reaving or Enshrouded.", RPR.JobID)]
	ReaperShadowGallowsFeature = 3905,

	[Conflicts(ReaperShadowGallowsFeature)]
	[CustomComboInfo("Shadow Gibbet Feature", "Replace Shadow of Death with Gibbet while Reaving or Enshrouded.", RPR.JobID)]
	ReaperShadowGibbetFeature = 3906,

	[CustomComboInfo("Shadow Lemure's Feature", "Replace Shadow of Death with Lemure's Slice when two or more stacks of Void Shroud are active.", RPR.JobID)]
	ReaperShadowLemuresFeature = 3923,

	[CustomComboInfo("Shadow Communio Feature", "Replace Shadow of Death with Communio when one stack of Shroud is left.", RPR.JobID)]
	ReaperShadowCommunioFeature = 3924,

	[CustomComboInfo("Shadow Soulsow Feature", "Replace Shadow of Death with Soulsow when out of combat, not active, and you have no target.", RPR.JobID)]
	ReaperShadowSoulsowFeature = 3929,

	[Conflicts(ReaperSoulGibbetFeature)]
	[CustomComboInfo("Soul Gallows Feature", "Replace Soul Slice with Gallows while Reaving or Enshrouded.", RPR.JobID)]
	ReaperSoulGallowsFeature = 3925,

	[Conflicts(ReaperSoulGallowsFeature)]
	[CustomComboInfo("Soul Gibbet Feature", "Replace Soul Slice with Gibbet while Reaving or Enshrouded.", RPR.JobID)]
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

	[Experimental]
	[CustomComboInfo("Scythe Weave Assist", "Replace Nightmare Scythe with Grim Swathe (or variants) when available and weaving wouldn't clip your GCD.", RPR.JobID)]
	ReaperScytheWeaveAssist = 3943,

	[ParentPreset(ReaperScytheWeaveAssist)]
	[CustomComboInfo("Ignore Reaving", "Allow weaving even if you're already reaving.", RPR.JobID)]
	ReaperScytheWeaveAssistDoubleReaving = 3949,

	[CustomComboInfo("Scythe of Death Feature", "Replace Nightmare Scythe with Whorl of Death when the target's Death's Design debuff is low.", RPR.JobID)]
	ReaperScytheWhorlFeature = 3941,

	[Experimental]
	[CustomComboInfo("Soulful Scythe", "Replace Nightmare Scythe with Soul Scythe when available and Soul Gauge is no more than 50.", RPR.JobID)]
	ReaperSoulOnScytheFeature = 3947,

	[CustomComboInfo("Scythe Guillotine Feature", "Replace Nightmare Scythe with Guillotine while Reaving or Enshrouded.", RPR.JobID)]
	ReaperScytheGuillotineFeature = 3907,

	[CustomComboInfo("Scythe Lemure's Feature", "Replace Nightmare Scythe with Lemure's Scythe when two or more stacks of Void Shroud are active.", RPR.JobID)]
	ReaperScytheLemuresFeature = 3921,

	[CustomComboInfo("Scythe Communio Feature", "Replace Nightmare Scythe with Communio when one stack is left of Shroud.", RPR.JobID)]
	ReaperScytheCommunioFeature = 3922,

	[CustomComboInfo("Scythe Soulsow Feature", "Replace Nightmare Scythe with Soulsow when out of combat and not active.", RPR.JobID)]
	ReaperScytheSoulsowFeature = 3931,

	[CustomComboInfo("Scythe Harvest Moon Feature", "Replace Nightmare Scythe with Harvest Moon when Soulsow is active and you have a target.", RPR.JobID)]
	ReaperScytheHarvestMoonFeature = 3932,

	[CustomComboInfo("Enhanced Soul Reaver Feature", "Replace Gibbet and Gallows with whichever is currently enhanced while Reaving.", RPR.JobID)]
	ReaperEnhancedSoulReaverFeature = 3917,

	[CustomComboInfo("Enhanced Enshrouded Feature", "Replace Gibbet and Gallows with whichever is currently enhanced while Enshrouded.", RPR.JobID)]
	ReaperEnhancedEnshroudedFeature = 3918,

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
	[CustomComboInfo("Tsubame-gaeshi to Iaijutsu", "Replace Tsubame-gaeshi with Iaijutsu when Sen is empty.", SAM.JobID)]
	SamuraiTsubameGaeshiIaijutsuFeature = 3407,

	[Conflicts(SamuraiIaijutsuShohaFeature)]
	[CustomComboInfo("Tsubame-gaeshi to Shoha", "Replace Tsubame-gaeshi with Shoha when meditation is 3.", SAM.JobID)]
	SamuraiTsubameGaeshiShohaFeature = 3409,

	[Conflicts(SamuraiTsubameGaeshiIaijutsuFeature)]
	[CustomComboInfo("Iaijutsu to Tsubame-gaeshi", "Replace Iaijutsu with Tsubame-gaeshi when Sen is not empty.", SAM.JobID)]
	SamuraiIaijutsuTsubameGaeshiFeature = 3408,

	[Conflicts(SamuraiTsubameGaeshiShohaFeature)]
	[CustomComboInfo("Iaijutsu to Shoha", "Replace Iaijutsu with Shoha when meditation is 3.", SAM.JobID)]
	SamuraiIaijutsuShohaFeature = 3410,

	[CustomComboInfo("Shinten to Senei", "Replace Hissatsu: Shinten with Senei when available.", SAM.JobID)]
	SamuraiShintenSeneiFeature = 3414,

	[CustomComboInfo("Senei to Guren Level Sync", "Replace Hissatsu: Senei with Guren when level synced below 72.", SAM.JobID)]
	SamuraiSeneiGurenFeature = 3419,

	[CustomComboInfo("Shinten to Shoha", "Replace Hissatsu: Shinten with Shoha when Meditation is full.", SAM.JobID)]
	SamuraiShintenShohaFeature = 3413,

	[CustomComboInfo("Kyuten to Guren", "Replace Hissatsu: Kyuten with Guren when available.", SAM.JobID)]
	SamuraiKyutenGurenFeature = 3415,

	[CustomComboInfo("Kyuten to Shoha 2", "Replace Hissatsu: Kyuten with Shoha 2 when Meditation is full.", SAM.JobID)]
	SamuraiKyutenShoha2Feature = 3412,

	[CustomComboInfo("Ikishoten Namikiri Feature", "Replace Ikishoten with Shoha, Kaeshi Namikiri, and then Ogi Namikiri when available.", SAM.JobID)]
	SamuraiIkishotenNamikiriFeature = 3411,

	[CustomComboInfo("Hissatsu Senei/Guren Sync Feature", "Replace Hissatsu Senei with Hissatsu Guren when underlevel.", SAM.JobID)]
	SamuraiGurenSeneiLevelSyncFeature = 3418,

	#endregion
	// ====================================================================================
	#region SCHOLAR (28xx)

	[CustomComboInfo("Swiftcast Resurrection", "Resurrection turns into Swiftcast when available and reasonable.", SCH.JobID)]
	ScholarSwiftcastRaiserFeature = 2800,

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

	#endregion
	// ====================================================================================
	#region SAGE (40xx)

	[CustomComboInfo("Swiftcast Egeiro", "Egeiro turns into Swiftcast when available and reasonable.", SGE.JobID)]
	SageSwiftcastRaiserFeature = 4000,

	[CustomComboInfo("Gap Closer Feature", "Replace Phlegma with Icarus when at least a configurable distance away and both are off CD.\nRespects the above two combos - Phlegma only becomes Icarus when NOT becoming one of the others.", SGE.JobID)]
	SagePhlegmaIcarus = 4009,

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

	[CustomComboInfo("Soteria Kardia Feature", "Replace Soteria with Kardia when off cooldown and missing Kardion.", SGE.JobID)]
	SageSoteriaKardionFeature = 4006,

	[CustomComboInfo("Phlegma into Toxikon", "Replace Phlegma with Toxikon when no charges rmemain and have Addersting.", SGE.JobID)]
	SagePhlegmaToxicon = 4007,

	[CustomComboInfo("Phlegma into Dyskrasia", "Replace Phlegma with Dyskrasia when no charges remain or have no target.", SGE.JobID)]
	SagePhlegmaDyskrasia = 4008,

	[Experimental]
	[CustomComboInfo("Kerachole into Holos", "Turns Kerachole into Holos when your level is high enough, Kerachole is unavailable, and you can use Holos.", SGE.JobID)]
	SageKeracholeHolos = 4010,

	[Experimental]
	[CustomComboInfo("Holos into Kerachole", "Turns Holos into Kerachole when your level is too low, or when Kerachole is available and Holos is not.", SGE.JobID)]
	SageHolosKerachole = 4011,

	#endregion
	// ====================================================================================
	#region SUMMONER (27xx)

	[CustomComboInfo("Swiftcast Resurrection", "Resurrection turns into Swiftcast when available and reasonable.", SMN.JobID)]
	SummonerSwiftcastRaiserFeature = 2700,

	[CustomComboInfo("ED Fester", "Change Fester into Energy Drain when out of Aetherflow stacks.", SMN.JobID)]
	SummonerEDFesterCombo = 2704,

	[CustomComboInfo("ES Painflare", "Change Painflare into Energy Syphon when out of Aetherflow stacks.", SMN.JobID)]
	SummonerESPainflareCombo = 2705,

	[CustomComboInfo("Ruin Feature", "Change Ruin into Gemburst when attuned.", SMN.JobID)]
	SummonerRuinFeature = 2706,

	[CustomComboInfo("Titan's Favor Ruin Feature", "Change Ruin into Mountain Buster (oGCD) when available.", SMN.JobID)]
	SummonerRuinTitansFavorFeature = 2713,

	[CustomComboInfo("Further Ruin Feature", "Change Ruin into Ruin4 when available and appropriate.", SMN.JobID)]
	SummonerFurtherRuinFeature = 2708,

	[CustomComboInfo("Outburst Feature", "Change Outburst into Precious Brilliance when attuned.", SMN.JobID)]
	SummonerOutburstFeature = 2707,

	[CustomComboInfo("Titan's Favor Outburst Feature", "Change Outburst into Mountain Buster (oGCD) when available.", SMN.JobID)]
	SummonerOutburstTitansFavorFeature = 2714,

	[CustomComboInfo("Further Outburst Feature", "Change Outburst into Ruin4 when available and appropriate.", SMN.JobID)]
	SummonerFurtherOutburstFeature = 2709,

	[CustomComboInfo("Shiny Titan's Favour", "Change Ruin into Ruin4 when available and appropriate.", SMN.JobID)]
	SummonerShinyTitansFavorFeature = 2710,

	[CustomComboInfo("Further Shiny Feature", "Change Outburst into Ruin4 when available and appropriate.", SMN.JobID)]
	SummonerFurtherShinyFeature = 2711,

	[CustomComboInfo("Shiny Enkindle Feature", "Change Gemshine and Precious Brilliance to Enkindle when Bahamut or Phoenix are summoned.", SMN.JobID)]
	SummonerShinyEnkindleFeature = 2712,

	[CustomComboInfo("Demi Enkindle Feature", "Change Summon Bahamut and Summon Phoenix into Enkindle when Bahamut or Phoenix are summoned.", SMN.JobID)]
	SummonerDemiEnkindleFeature = 2715,

	[CustomComboInfo("Radiant Carbuncle Feature", "Change Radiant Aegis into Summon Carbuncle when no pet has been summoned.", SMN.JobID)]
	SummonerRadiantCarbuncleFeature = 2716,

	[CustomComboInfo("Slipstream / Swiftcast Feature", "Change Slipstream into Swiftcast when Swiftcast is available.", SMN.JobID)]
	SummonerSlipcastFeature = 2718,

	#endregion
	// ====================================================================================
	#region WARRIOR (21xx)

	[CustomComboInfo("Stun/Interrupt Feature", "Turn Low Blow and Interject into Interject when off CD and your target can be interrupted, Low Blow otherwise.", WAR.JobID)]
	WarriorStunInterruptFeature = 2109,

	[CustomComboInfo("Storm's Path Combo", "Replace Storm's Path with its combo chain.", WAR.JobID)]
	WarriorStormsPathCombo = 2100,

	[ParentPreset(WarriorStormsPathCombo)]
	[CustomComboInfo("Smart Weave", "Automatically turn into Upheaval when weaving won't drift your GCD.", WAR.JobID)]
	WarriorSmartWeaveSingleTargetPath = 2116,

	[ParentPreset(WarriorStormsPathCombo)]
	[CustomComboInfo("Gauge Overcap Saver: Storm's Path", "Replace the Storm's Path combo with gauge spender if completing the combo would overcap you.", WAR.JobID)]
	WarriorGaugeOvercapPathFeature = 2103,

	[ParentPreset(WarriorStormsPathCombo)]
	[CustomComboInfo("Storm's Path Double Combo", "Replace the Storm's Path combo chain with Storm's Eye if Surging Tempest has less than 7 (default) seconds left.", WAR.JobID)]
	WarriorSmartStormCombo = 2112,

	[CustomComboInfo("Storm's Eye Combo", "Replace Storm's Eye with its combo chain.", WAR.JobID)]
	WarriorStormsEyeCombo = 2101,

	[ParentPreset(WarriorStormsEyeCombo)]
	[CustomComboInfo("Smart Weave", "Automatically turn into Upheaval when weaving won't drift your GCD.", WAR.JobID)]
	WarriorSmartWeaveSingleTargetEye = 2117,

	[ParentPreset(WarriorStormsEyeCombo)]
	[CustomComboInfo("Gauge Overcap Saver: Storm's Eye", "Replace the Storm's Eye combo with gauge spender if completing the combo would overcap you.", WAR.JobID)]
	WarriorGaugeOvercapEyeFeature = 2110,

	[CustomComboInfo("Mythril Tempest Combo", "Replace Mythril Tempest with its combo chain.", WAR.JobID)]
	WarriorMythrilTempestCombo = 2102,

	[ParentPreset(WarriorMythrilTempestCombo)]
	[CustomComboInfo("Smart Weave", "Automatically turn into Orogeny when weaving won't drift your GCD.", WAR.JobID)]
	WarriorSmartWeaveAOE = 2118,

	[ParentPreset(WarriorMythrilTempestCombo)]
	[CustomComboInfo("Gauge Overcap Saver: Mythril Tempest", "Replace the Mythril Tempest combo with gauge spender if completing the combo would overcap you.", WAR.JobID)]
	WarriorGaugeOvercapTempestFeature = 2111,

	[CustomComboInfo("Inner Release Feature", "Replace single-target and AoE combo with Fell Cleave/Decimate during Inner Release.", WAR.JobID)]
	WarriorInnerReleaseFeature = 2104,

	[CustomComboInfo("Nascent Flash Feature", "Replace Nascent Flash with Raw Intuition when below level 76.", WAR.JobID)]
	WarriorNascentFlashFeature = 2105,

	[CustomComboInfo("Angry Beast Feature", "Replace Inner Beast/Fell Cleave and Steel Cyclone/Decimate with Infuriate when less then 50 Beast Gauge is available.\nWhen you have at least 50 gauge AND the Nascent Chaos buff, they become Inner Chaos and Chaotic Cyclone, respectively.", WAR.JobID)]
	WarriorInfuriateBeastFeature = 2113,

	[ParentPreset(WarriorInfuriateBeastFeature)]
	[CustomComboInfo("Angry Beast Gauge Saver", "Replace the above with Infuriate when less than 60 Beast Gauge instead of 50.", WAR.JobID)]
	WarriorInfuriateBeastRaidModeFeature = 2115,

	[CustomComboInfo("Healthy Balanaced Diet Feature", "Replace Bloodwhetting with Thrill of Battle, and then Equilibrium when the preceding is on cooldown.", WAR.JobID)]
	WarriorHealthyBalancedDietFeature = 2114,

	[CustomComboInfo("Primal Beast Feature", "Replace Inner Beast and Steel Cyclone with Primal Rend when available", WAR.JobID)]
	WarriorPrimalBeastFeature = 2107,

	[CustomComboInfo("Primal Release Feature", "Replace Inner Release with Primal Rend when available", WAR.JobID)]
	WarriorPrimalReleaseFeature = 2108,

	#endregion
	// ====================================================================================
	#region WHITE MAGE (24xx)

	[CustomComboInfo("Swiftcast Raise", "Raise turns into Swiftcast when available and reasonable.", WHM.JobID)]
	WhiteMageSwiftcastRaiserFeature = 2400,

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

	#endregion
	// ====================================================================================
	#region DoH (98xx)

	// [CustomComboInfo("Placeholder", "Placeholder.", DOH.JobID)]
	// DohPlaceholder = 9801,

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

	[CustomComboInfo("Cast / Hook Feature", "Replace Cast with Hook when fishing.", DOL.JobID)]
	FisherCastHookFeature = 9901,

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

	#endregion
	// ====================================================================================
}
public static class CustomComboPresetExtensions {
	public static CustomComboPreset[] GetConflicts(this CustomComboPreset preset) => preset.GetAttribute<ConflictsAttribute>()?.Conflicts ?? Array.Empty<CustomComboPreset>();
	public static CustomComboPreset? GetParent(this CustomComboPreset preset) => preset.GetAttribute<ParentPresetAttribute>()?.Parent;
	public static string GetDebugLabel(this CustomComboPreset preset) => $"{Enum.GetName(preset)!}#{(int)preset}";
}
