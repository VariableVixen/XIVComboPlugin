# XIVComboPlugin
This plugin condenses combos and mutually exclusive abilities onto a single button. Thanks to Meli for the initial start, attick and daemitus for continuing, and obviously goat for making any of this possible.

![GitHub build status](https://img.shields.io/github/workflow/status/PrincessRTFM/XIVComboPlugin/Build?logo=github)
![GitHub tag (latest by date)](https://img.shields.io/github/v/tag/PrincessRTFM/XIVComboPlugin?label=version&color=informational)
![GitHub last commit (branch)](https://img.shields.io/github/last-commit/PrincessRTFM/XIVComboPlugin/master?label=updated)
[![GitHub issues](https://img.shields.io/github/issues-raw/PrincessRTFM/XIVComboPlugin?label=known%20issues)](https://github.com/PrincessRTFM/XIVComboPlugin/issues?q=is%3Aissue+is%3Aopen+sort%3Aupdated-desc)

## About
[![License](https://img.shields.io/github/license/PrincessRTFM/XIVComboPlugin?logo=github&color=informational&cacheSeconds=86400)](https://github.com/PrincessRTFM/XIVComboPlugin/blob/master/LICENSE)

XIVCombo is a plugin to allow for "one-button" combo chains, as well as implementing various other mutually-exclusive button consolidation and quality of life replacements.

For some jobs, this frees a massive amount of hotbar space (looking at you, DRG). For most, it removes a lot of mindless tedium associated with having to press various buttons that have little logical reason to be separate.

## Installation
Type `/xlplugins` in-game to access the plugin installer and updater. Note that you will need to add [my custom plugin repository](https://github.com/PrincessRTFM/MyDalamudPlugins) (full instructions included at that link) in order to find this plugin.

## In-game usage
* Type `/pcombo` to pull up a GUI for editing active combo replacements.
* Drag the named ability from your ability list onto your hotbar to use.
  * For example, to use DRK's Souleater combo, first check the box, then place Souleater on your bar. It should automatically turn into Hard Slash.
  * The description associated with each combo should be enough to tell you which ability needs to be placed on the hotbar.

### Examples
![DRK Souleater combo](https://github.com/PrincessRTFM/XIVComboPlugin/raw/master/res/souleater_combo.gif)

![MCH Hypercharge/Heat Blast combo](https://github.com/PrincessRTFM/XIVComboPlugin/raw/master/res/hypercharge_heat_blast.gif)

![BLM Enochian switcher (outdated)](https://github.com/PrincessRTFM/XIVComboPlugin/raw/master/res/eno_swap.gif)

## Why Another Fork?
Because the original fork developer (daemitus) has a different philosophy regarding how much the plugin should be allowed to do. They want to avoid "intelligent" decisions in the plugin, because they feel it's too close to botting. While I respect their decision and their reasoning, I also personally disagree with it, and additionally believe that since this plugin _only_ operates in PvE, there's no real harm or reason to restrict it like that. You aren't gaining an advantage over another player unless you're comparing parses, and even then nobody "wins" or "loses" anything. <!-- Although it could be said that everyone comparing parses like that loses, in a way :P -->

Furthermore, I've seen _so_ many people who want to play this game, but have some disability or another - carpal tunnel, for instance - that makes it hard for them to do so. It is my hope that my fork will make the game more accessible to people like that, thereby bringing in more players to enjoy it.

## Full list of supported combos
**Please note**: in the original fork, you _had_ to be on the listed job for replacements to function. You couldn't be on the base class, which means that the plugin wouldn't help until you reached level 30. This should now be fixed, so that applicable skills will update even on the base pre-job classes.

Now sorted by job and combo name!

| Job | Name | Description |
|-----|------|-------------|
| AST | Benefic 2 to Benefic Level Sync | Changes Benefic 2 to Benefic when below level 26. |
| AST | Draw Lockout | Replace Draw (not Play to Draw) with Malefic when a card is drawn. |
| AST | Play to Astrodyne | Replace Play with Astrodyne when seals are full. |
| AST | Play to Draw | Replace Play with Draw when no card is drawn and a card is available. |
| AST | Play to Draw to Astrodyne | Replace Play with Astrodyne when seals are full and Draw is on Cooldown. |
| AST | Swiftcast Ascend | Ascend turns into Swiftcast when available and reasonable. |
| BLM | (Between the) Ley Lines | Change Ley Lines into BTL when Ley Lines is active. |
| BLM | Blizzard 1/3 Feature | Replace Blizzard 1 with Blizzard 3 when unlocked. |
| BLM | Enochian Despair Feature | Change Fire 4 or Blizzard 4 to Despair when in Astral Fire with less than 2400 mana. |
| BLM | Enochian Feature | Change Fire 4 or Blizzard 4 to whichever action you can currently use. |
| BLM | Enochian No Sync Feature | Fire 4 and Blizzard 4 will not sync to Fire 1 and Blizzard 1. |
| BLM | Fire 1/3 Astral Feature | Fire 1 becomes Fire 3 with 1 or fewer stacks of Astral Fire. |
| BLM | Fire 1/3 Proc Feature | Fire 1 becomes Fire 3 when Firestarter proc is up. |
| BLM | Fire 2 Feature | (High) Fire 2 becomes Flare in Astral Fire with 1 or fewer Umbral Hearts. |
| BLM | Fire 2/Ice 2 Option | Fire 2 and Blizzard 2 will not change unless you're at max Astral Fire or Umbral Ice. |
| BLM | Freeze/Flare Feature | Freeze and Flare become whichever action you can currently use. |
| BLM | Ice 2 Feature | (High) Blizzard 2 becomes Freeze in Umbral Ice. |
| BLM | Scathe/Xenoglossy Feature | Scathe becomes Xenoglossy when available. |
| BLM | Umbral Soul Feature | Replace your ice spells with Umbral Soul, while in Umbral Ice and having no target. |
| BLM | Umbral Soul/Transpose Switcher | Change Transpose into Umbral Soul when Umbral Soul is usable. |
| BRD | Apex Arrow Feature | Replaces Heavy Shot, Burst Shot, Quick Nock, and Ladonsbit |
| BRD | Barrage Feature | Replace Barrage with Straight Shot if you have Straight Shot Ready (unless Shadowbite is ready). |
| BRD | Bloodletter Feature | Replaces Bloodletter with Empyreal Arrow and Sidewinder depending on which is available. |
| BRD | Bloodletter to Rain of Death | Replace Bloodletter with Rain of Death if there are no self-applied DoTs on your target. |
| BRD | Heavy Shot into Straight Shot | Replaces Heavy Shot/Burst Shot with Straight Shot/Refulgent Arrow when procced. |
| BRD | Iron Jaws Feature | Iron Jaws is replaced with Caustic Bite/Stormbite if one or both are not up. |
| BRD | Quick Nock / Ladonsbite into Shadowbite | Replaces Quick Nock and Ladonsbite with Shadowbite when available. |
| BRD | Radiant Strikes Feature | Replace Radiant Finale with Raging Strikes if Raging Strikes is available. |
| BRD | Radiant Voice Feature | Replace Radiant Finale with Battle Voice if Battle Voice is available. |
| BRD | Rain of Death Feature | Replaces Rain of Death with Empyreal Arrow and Sidewinder depending on which is available. |
| BRD | Sidewinder Feature | Replace Sidewinder with Empyreal Arrow depending on which is available. |
| DNC | AoE Multibutton | Change Windmill into procs and combos as available. |
| DNC | Curing Wind Cooldown Swap | Change Curing Waltz into Second Wind when Waltz is on CD. |
| DNC | Curing Wind Level Sync | Change Curing Waltz into Second Wind when under level. |
| DNC | Dance Step Combo | Change Standard Step and Technical Step into each dance step while dancing. |
| DNC | Dance Step Feature | Change custom actions into dance steps while dancing. |
| DNC | Devilment Feature | Change Devilment into Starfall Dance after use. |
| DNC | Fan Dance 1/3 Combo | Change Fan Dance 1 into Fan Dance 3 when available. |
| DNC | Fan Dance 1/3 Fallback | Also change into Fan Dance 1/3, with lower priority than 2/4. |
| DNC | Fan Dance 1/3 Weaving | Also change into Fan Dance 1/3 when you can weave without clipping. |
| DNC | Fan Dance 1/4 Combo | Change Fan Dance 1 into Fan Dance 4 when available. |
| DNC | Fan Dance 2/3 Combo | Change Fan Dance 2 into Fan Dance 3 when available. |
| DNC | Fan Dance 2/4 Combo | Change Fan Dance 2 into Fan Dance 4 when available. |
| DNC | Fan Dance 2/4 Fallback | Also change into Fan Dance 2/4, with lower priority than 1/3. |
| DNC | Fan Dance 2/4 Weaving | Also change into Fan Dance 2/4 when you can weave without clipping. |
| DNC | Flourish Dance 4 | Change Flourish into Fan Dance 4 when available. |
| DNC | Single Target Multibutton | Change Cascade into procs and combos as available. |
| DNC | Smart Dance | Change your normal ST/AOE combos into the next dance steps (and then the finishers) while dancing. |
| DOL | Cast / Gig Feature | Replace Cast with Gig when swimming. |
| DOL | Cast / Hook Feature | Replace Cast with Hook when fishing. |
| DOL | Chum / Electric Current Feature | Replace Chum with Electric Current when swimming. |
| DOL | Eureka Feature | Replace Ageless Words and Solid Reason with Wise to the World when available. |
| DOL | Identical Cast / Vital Sight Feature | Replace Identical Cast with Vital Sight when swimming. |
| DOL | Ignore node detection skills | Do not replace skills like Triangulate / Prospect, Lay of the Land / Arbor Call, and Truth of Mountains/Forests. |
| DOL | Job Correction | Replace Miner/Botanist actions with the other job's version when on the opposite job. |
| DOL | Makeshift Bait / Baited Breath Feature | Replace Makeshift Bait with Baited Breath when swimming. |
| DOL | Prize Catch / Nature's Bounty Feature | Replace Prize Catch with Nature's Bounty when swimming. |
| DOL | Snagging / Salvage Feature | Replace Snagging with Salvage when swimming. |
| DOL | Surface Slap / Veteran Trade Feature | Replace Surface Slap with Veteran Trade when swimming. |
| DRG | Chaos Thrust Combo | Replace Chaos Thrust with its combo chain. |
| DRG | Chaos Thrust from Disembowl | Start the Chaos Thrust combo chain with Disembowl instead of True Thrust. |
| DRG | Coerthan Torment Combo | Replace Coerthan Torment with its combo chain. |
| DRG | Coerthan Torment Wyrmwind Feature | Replace Coerthan Torment with Wyrmwind Thrust when you have two Firstminds' Focus. |
| DRG | Dive Dive Dive! | Replace Spineshatter Dive, Dragonfire Dive, and Stardiver with whichever is available. |
| DRG | Full Thrust Combo | Replace Full Thrust with its combo chain. |
| DRG | Full Thrust from Vorpal | Start the Full Thrust combo chain with Vorpal Thrust instead of True Thrust. |
| DRG | Mirage Jump | Replace Jump and High Jump with Mirage Dive when Dive Ready. |
| DRG | Power Surge Buff Saver | When the Power Surge buff is about to run out (or isn't up), execute the Chaos Thrust chain to use Disembowl. |
| DRG | Stardiver to Dragonfire Dive | Replace Stardiver with Dragonfire Dive when the latter is off cooldown (and you have more than 7.5s of LotD left), or outside of Life of the Dragon. |
| DRG | Stardiver to Nastrond | Replace Stardiver with Nastrond when Nastrond is off-cooldown, and Geirskogul outside of Life of the Dragon. |
| DRG | Wheeling Thrust / Fang and Claw Option | When you have either Enhanced Fang and Claw or Wheeling Thrust, Chaos Thrust becomes Wheeling Thrust and Full Thrust becomes Fang and Claw. |
| DRK | Blood Weapon Feature | Replace Carve and Spit, and Abyssal Drain with Blood Weapon when available. |
| DRK | Delirium Feature | Replace Souleater and Stalwart Soul with Bloodspiller and Quietus when Delirium is active. |
| DRK | Living Shadow Feature | Replace Quietus and Bloodspiller with Living Shadow when available. |
| DRK | Living Shadowbringer Feature | Replace Living Shadow with Shadowbringer when charges are available and your Shadow is present. |
| DRK | Missing Shadowbringer Feature | Replace Living Shadow with Shadowbringer when charges are available and Living Shadow is on cooldown. |
| DRK | Shadows Galore | Replace Flood and Edge of Darkness with Shadowbringer when under Darkside with less than 6000 MP left. |
| DRK | Souleater Combo | Replace Souleater with its combo chain. |
| DRK | Stalwart Soul Combo | Replace Stalwart Soul with its combo chain. |
| DRK | Stun/Interrupt Feature | Turn Low Blow and Interject into Interject when off CD and your target can be interrupted, Low Blow otherwise. |
| GNB | Always Double Down | Replace No Mercy with Double Down while No Mercy is active. |
| GNB | Bloodfest Feature | Replace Solid Barrel with Bloodfest when there is no ammo and you are under No Mercy. |
| GNB | Bow Shock / Sonic Break Swap | Replace Bow Shock and Sonic Break with one or the other, depending on which is on cooldown. |
| GNB | Bow Shock Feature | Replace Solid Barrel with Bow Shock when you are under No Mercy. |
| GNB | Bow Shock Feature | Replace Gnashing Fang with Bow Shock when available and when you are under No Mercy. |
| GNB | Burst Strike Continuation | Replace Burst Strike with Continuation moves when appropriate. |
| GNB | Burst Strike Feature | Replace Solid Barrel with Burst Strike when charges are full. |
| GNB | Danger Zone/Blasting Zone Feature | Replace Solid Barrel with Danger Zone/Blasting Zone after Gnashing Fang is used. |
| GNB | Danger Zone/Blasting Zone Feature | Replace Gnashing Fang with Danger Zone/Blasting Zone when available. |
| GNB | Demon Slaughter Combo | Replace Demon Slaughter with its combo chain. |
| GNB | Double Down Feature | Replace Burst Strike and Fated Circle with Double Down when available. |
| GNB | Double Down Feature | Replace Solid Barrel with Double Down when you are under No Mercy and have the required ammo. |
| GNB | Double Down Feature | Replace Gnashing Fang with Double Down when available and when you are under No Mercy and have the required ammo. |
| GNB | Empty Bloodfest Feature | Replace Burst Strike and Fated Circle with Bloodfest if the powder gauge is empty. |
| GNB | Fated Circle Feature | In addition to the Demon Slaughter combo, add Fated Circle when charges are full. |
| GNB | Gnashing Bloodfest Feature | Weave Bloodfest onto Gnashing Fang when out of ammo and under No Mercy. |
| GNB | Gnashing Fang Continuation | Replace Gnashing Fang with Continuation moves when appropriate. |
| GNB | Gnashing Fang/Continuation Feature | Replace Solid Barrel with Gnashing Fang and Continuation when Gnashing Fang is available and will hold for No Mercy when it is available. |
| GNB | Gnashing Strike Feature | Replace Gnashing Fang with Burst Strike when No Mercy is active and Gnashing Fang and Double Down are on cooldown, or you are too low level to use them. |
| GNB | Lighting Shot Ranged Uptime Feature | Replace Solid Barrel with Lightning Shot when out of melee range and in combat. |
| GNB | No Mercy - Bow Shock / Sonic Break | Replace No Mercy with Bow Shock, and then Sonic Break, while No Mercy is active. |
| GNB | No Mercy - Double Down | Replace No Mercy with Double Down while No Mercy is active, 2 cartridges are available, and Double Down is off cooldown. |
| GNB | No Mercy Feature | Replace Solid Barrel with No Mercy when Gnashing Fang is ready. |
| GNB | No Mercy Feature | Replace Gnashing Fang with No Mercy when both No Mercy and Gnashing Fang are ready to be used. |
| GNB | Rough Divide Feature | Replace Solid Barrel with Rough Divide when you are within the target's hitbox, not moving, and have the No Mercy buff. |
| GNB | Solid Barrel Combo | Replace Solid Barrel with its combo chain. |
| GNB | Sonic Break Feature | Replace Solid Barrel with Sonic Break when you are under No Mercy. |
| GNB | Sonic Break Feature | Replace Gnashing Fang with Sonic Break when available and when you are under No Mercy. |
| GNB | Stun/Interrupt Feature | Turn Low Blow and Interject into Interject when off CD and your target can be interrupted, Low Blow otherwise. |
| MCH | (Heated) Shot Combo | Replace either form of Clean Shot with its combo chain. |
| MCH | Gauss Round / Ricochet Feature | Replace Gauss Round and Ricochet with one or the other depending on which has less recharge time left. |
| MCH | Gauss Round / Ricochet Overheat Option | Replace Gauss Round and Ricochet with one or the other only while overheated. |
| MCH | HS/AA/D + Chain Saw Feature | Also allow the above to become Chain Saw. |
| MCH | Hot Shot / Air Anchor / Drill Feature | Replace Hot Shot (Air Anchor) and Drill with whichever is available. |
| MCH | Hypercharge Combo | Replace Clean Shot combo with Heat Blast while overheated. |
| MCH | Hypercharge Feature | Replace Heat Blast and Auto Crossbow with Hypercharge when not overheated. |
| MCH | Hyperfire Feature | Replace Hypercharge with Wildfire if available and you have a target. |
| MCH | Overdrive Feature | Replace Rook Autoturret and Automaton Queen with their respective Overdrive while active. |
| MCH | Spread Shot Heat | Replace Spread Shot with Auto Crossbow when overheated. |
| MNK | Demolish to Snap Punch Feature | Replaces Demolish with Snap Punch if target is under Demolish. |
| MNK | Dragon Kick to Bootshine Feature | Replaces Dragon Kick with Bootshine if Leaden Fist is up. |
| MNK | Dragon Kick to Masterful Blitz Feature | Replaces Dragon Kick with Masterful Blitz if you have three Beast Chakra. |
| MNK | Dragon Meditation Feature | Replace Dragon Kick with Meditation when out of combat and the Fifth Chakra is not open. |
| MNK | Howling Fist / Meditation Feature | Replaces Howling Fist with Meditation when the Fifth Chakra is not open. |
| MNK | Monk AoE Combo | Replaces the selected actions with the AoE combo chain. |
| MNK | Monk ST Combo | Replace Bootshine with all single-target rotation actions |
| MNK | On Destroyer | Replaces (Arm/Shadow) of the Destroyer with the AoE combo chain. |
| MNK | On Masterful Blitz | Replaces Masterful Blitz with the AoE combo chain. |
| MNK | On Rockbreaker | Replaces Rockbreaker with the AoE combo chain. |
| MNK | Perfect Balance Feature | Replace Perfect Balance with Masterful Blitz when you have 3 Beast Chakra, or when under Perfect Balance already. |
| MNK | Riddle of Brotherly Fire | Replace Riddle of Fire with Brotherhood if the former is on CD and the latter isn't. |
| MNK | Riddle of Fire and Wind | Replace Riddle of Fire with Riddle of Wind if the former is on CD and the latter isn't. |
| MNK | Steel Peak / Forbidden Chakra Feature | Replace Dragon Kick with Meditation / Steel Peak / The Forbidden Chakra when in of combat and the Fifth Chakra is open. |
| MNK | Twin Snakes to True Strike Feature | Replaces Twin Snakes with True Strike if Disciplined Fist is up. |
| NIN | Aeolian Edge Combo | Replace Aeolian Edge with its combo chain. |
| NIN | AoE Smart Weave | Replaces Death Blossom / Hakke Mujinsatsu with Hellfrog Medium when weaving and available. |
| NIN | Armor Crush Combo | Replace Armor Crush with its combo chain. |
| NIN | Distant Daggers Feature | Replaces the Armor Crush combo with Throwing Dagger when the current target is out of melee range. |
| NIN | Distant Daggers Feature | Replaces the Aeolian Edge combo with Throwing Dagger when the current target is out of melee range. |
| NIN | Fallback to Aeolian Edge | Replaces Armor Crush with Aeolian Edge when underlevel. |
| NIN | Fleeting Huraijin Feature | Replaces Huraijin with Fleeting Raiju when available. |
| NIN | Fleeting Raiju Feature | Replaces the Armor Crush combo with Fleeting Raiju when available. |
| NIN | Fleeting Raiju Feature | Replaces the Aeolian Edge combo with Fleeting Raiju when available. |
| NIN | Forked Huraijin Feature | Replaces Huraijin with Forked Raiju when available. |
| NIN | Forked Raiju Feature | Replaces the Armor Crush combo with Forked Raiju when available. |
| NIN | Forked Raiju Feature | Replaces the Aeolian Edge combo with Forked Raiju when available. |
| NIN | GCDs to Ninjutsu Feature | Every GCD combo becomes Ninjutsu while Mudras are being used. |
| NIN | Hakke Mujinsatsu Combo | Replace Hakke Mujinsatsu with its combo chain. |
| NIN | Huraijin / Crush Feature | Replaces Huraijin with Armor Crush after Gust Slash. |
| NIN | Huraijin Feature | Replaces the Armor Crush combo chain with Huraijin when Huton is missing. |
| NIN | Huraijin Feature | Replaces the Aeolian Edge combo chain with Huraijin when Huton is missing. |
| NIN | Huton Feature | Replaces Aeolian Edge with Armor Crush when Huton timer is below a set threshold. |
| NIN | Kassatsu Chi/Jin Feature | Replaces Chi with Jin while Kassatsu is up if you have Enhanced Kassatsu. |
| NIN | Kassatsu to Trick | Replaces Kassatsu with Trick Attack while Suiton or Hidden is up. |
| NIN | Phantom Kamaitachi Feature | Replaces the combo with Phantom Kamaitachi when you have no stacks of Bunshin. |
| NIN | Phantom Kamaitachi Feature | Replaces the combo with Phantom Kamaitachi when you have no stacks of Bunshin. |
| NIN | Single Target Smart Weave | Replaces both Aeolian Edge and Armor Crush combos with the following when weaving and available: |
| NIN | Smart Hide | Replaces Hide with Trick Attack while under the effect of Suiton or Hidden AND with a target, or else Mug if in combat. |
| NIN | Smart Huraiju Feature | Replaces Huraijin with Forked/Fleeting Raiju when available, depending on how far your target is. |
| NIN | Smart Raiju Feature | Replaces the Armor Crush combo with Forked/Fleeting Raiju when available, depending on how far your target is. |
| NIN | Smart Raiju Feature | Replaces the Aeolian Edge combo with Forked/Fleeting Raiju when available, depending on how far your target is. |
| NIN | Ten Chi Jin to Meisui | Replaces Ten Chi Jin (the move) with Meisui while Suiton is up. |
| PLD | Atonement Feature | Replace the Royal Authority and Goring Blade combos with Atonement when under the effect of Sword Oath. |
| PLD | Confiteor Feature | Replace Holy Spirit/Circle with Confiteor when Requiescat is up and MP is under 2000 or only one stack remains. |
| PLD | Goring Blade Combo | Replace Goring Blade with its combo chain. |
| PLD | Intervene Level Sync | Replace Intervene with Shield Lob when under level. |
| PLD | Intervening Blade Feature | Replace the GB combo with Intervene when NOT in the combo chain, and the current target is out of melee range. |
| PLD | Level Sync | Replace Intervene with Shield Lob when under level. |
| PLD | Level Sync | Replace Intervene with Shield Lob when under level. |
| PLD | Post-Confiteor Chain | Include the Blade of Faith/Truth/Valor chain after Confiteor. |
| PLD | Prominence Combo | Replace Prominence with its combo chain. |
| PLD | Requiescat Confiteor | Replace Requiescat with Confiteor while under the effect of Requiescat. |
| PLD | Requiescat Feature | Replace Royal Authority/Goring Blade combos with Holy Spirit, and Prominence combo with Holy Circle, while Requiescat is active. |
| PLD | Royal Authority Combo | Replace Royal Authority/Rage of Halone with its combo chain. |
| PLD | Royal Authority DoT Saver | The RA/RoH combo chain becomes Goring Blade at the end, if your current target has less than seven seconds (adjustable) on the GB DoT. |
| PLD | Royal Intervention Feature | Replace the RA/RoH combo with Intervene when NOT in the combo chain, and the current target is out of melee range. |
| PLD | Stun/Interrupt Feature | Turn Low Blow and Interject into Interject when off CD and your target can be interrupted, Low Blow otherwise. |
| RDM | Acceleration | Turns the single-target smartcast combo into Acceleration instead of Jolt. |
| RDM | Acceleration into Swiftcast | Replace Acceleration with Swiftcast when on cooldown or synced. |
| RDM | Acceleration with Swiftcast first | Replace Acceleration with Swiftcast when neither are on cooldown. |
| RDM | Auto Start | Turns the single-target smartcast combo into your melee combo when you're ready to execute it and your mana levels AREN'T equal. |
| RDM | Combat Only | Only become Acceleration (+ Swiftcast if applicable) when in combat. |
| RDM | Contre Sixte / Fleche Feature | Turns Contre Sixte and Fleche into whichever is available. |
| RDM | Contre Sixte Weave | Turns the AoE smartcast combo into Contre Sixte when you can weave without clipping. |
| RDM | Embolden to Manaification | Replace Embolden with Manafication if the former is on cooldown and the latter is not. |
| RDM | Engagement | If you're in melee range and Fleche (+ Contra Sixte if applicable) can't be used yet, fall back to Engagement. |
| RDM | Engagement | If you're in melee range and Fleche (+ Contra Sixte if applicable) can't be used yet, fall back to Engagement. |
| RDM | Engagement Priority | Try to use Engagement first when in melee range. |
| RDM | Engagement Priority | Try to use Engagement first when in melee range. |
| RDM | Fleche Weave | Turns the single-target smartcast combo into Fleche when you can weave without clipping. |
| RDM | Gap Closer | Replaces Redoublement with Corps-a-corps when out of melee range. |
| RDM | Gap Reverser: Backstep | Replaces Corps-a-corps with Displacement when your taget is in melee range. |
| RDM | Gap Reverser: Lunge | Replaces Displacement with Corps-a-corps when your taget is NOT in melee range. |
| RDM | Melee Combo | Replaces Redoublement with its combo chain, following enchantment rules. |
| RDM | Melee Combo Followthrough | Turns the single-target smartcast combo into the rest of the melee combo once you start it, as long as you're in melee range. |
| RDM | Melee Combo+ | Replaces Redoublement (and Moulinet) with Verflare/Verholy (and then Scorch and Resolution) after 3 mana stacks, whichever is more appropriate. |
| RDM | Red Mage AoE Combo | Replaces Veraero/Verthunder 2 with Impact when under a cast speeder. |
| RDM | Smartcast AoE | Dynamically replaces Veraero/Verthunder 2 with the appropriate spell based on your job gauge. |
| RDM | Smartcast Single Target | Dynamically replaces Verstone/Verfire with the appropriate spell based on your job gauge. |
| RDM | Swiftcast Priority | Swiftcast is used before Acceleration if it's up. |
| RDM | Swiftcast Verraise | Verraise turns into Swiftcast when available and reasonable. |
| RDM | Verproc into Jolt | Replaces Verstone/Verfire with Jolt (2) when no proc is available. |
| RDM | Verproc into Jolt Plus | Additionally replaces Verstone/Verfire with Veraero/Verthunder if fastcasting are up. |
| RDM | Verproc into Jolt Plus Veraero Opener | Turns Verstone into Veraero when out of combat. |
| RDM | Verproc into Jolt Plus Verthunder Opener | Turns Verfire into Verthunder when out of combat. |
| RDM | Walking Contre Sixte | Turns the AoE smartcast combo into Contre Sixte when you're moving and can't instacast. |
| RDM | Walking Fleche | Turns the single-target smartcast combo into Fleche when you're moving and can't instacast. |
| RDM | With Swiftcast | Acceleration falls back to Swiftcast if available and out of charges. |
| RPR | Arcane Harvest Feature | Replace Arcane Circle with Plentiful Harvest when you have enough stacks of Immortal Sacrifice. |
| RPR | Blood Stalk Gluttony Feature | Replace Blood Stalk with Gluttony when available and Soul Gauge is at least 50. |
| RPR | Combat Option | Prevent replacing Harpe with Harvest Moon when not in combat. |
| RPR | Communio Soul Reaver Feature | Replace Gibbet, Gallows, and Guillotine with Communio when one stack is left of Shroud. |
| RPR | Delayed Regress Option | Replace the action used with Regress only after a configurable delay. |
| RPR | Enhanced Enshrouded Feature | Replace Gibbet and Gallows with whichever is currently enhanced while Enshrouded. |
| RPR | Enhanced Harpe Option | Prevent replacing Harpe with Harvest Moon when Enhanced Harpe is active. |
| RPR | Enhanced Soul Reaver Feature | Replace Gibbet and Gallows with whichever is currently enhanced while Reaving. |
| RPR | Enshroud Communio Feature | Replace Enshroud with Communio when Enshrouded. |
| RPR | Grim Swathe Gluttony Feature | Replace Grim Swathe with Gluttony when available and Soul Gauge is at least 50. |
| RPR | Harpe Harvest Moon Feature | Replace Harpe with Harvest Moon when Soulsow is active and you are in combat. |
| RPR | Harpe Soulsow Feature | Replace Harpe with Soulsow when not active and out of combat or you have no target. |
| RPR | Ignore Reaving | Allow weaving even if you're already reaving. |
| RPR | Ignore Reaving | Allow weaving even if you're already reaving. |
| RPR | Lemure's Soul Reaver Feature | Replace Gibbet, Gallows, and Guillotine with Lemure's Slice or Scythe when two or more stacks of Void Shroud are active. |
| RPR | Regress Feature | Replace Hell's Ingress and Egress turn with Regress when Threshold is active, instead of just the opposite of the one used. |
| RPR | Scythe Combo | Replace Nightmare Scythe with its combo chain. |
| RPR | Scythe Communio Feature | Replace Nightmare Scythe with Communio when one stack is left of Shroud. |
| RPR | Scythe Guillotine Feature | Replace Nightmare Scythe with Guillotine while Reaving or Enshrouded. |
| RPR | Scythe Harvest Moon Feature | Replace Nightmare Scythe with Harvest Moon when Soulsow is active and you have a target. |
| RPR | Scythe Lemure's Feature | Replace Nightmare Scythe with Lemure's Scythe when two or more stacks of Void Shroud are active. |
| RPR | Scythe Soulsow Feature | Replace Nightmare Scythe with Soulsow when out of combat and not active. |
| RPR | Scythe Weave Assist | Replace Nightmare Scythe with Grim Swathe (or variants) when available and weaving wouldn't clip your GCD. |
| RPR | Scythe of Death Feature | Replace Nightmare Scythe with Whorl of Death when the target's Death's Design debuff is low. |
| RPR | Shadow Communio Feature | Replace Shadow of Death with Communio when one stack of Shroud is left. |
| RPR | Shadow Gallows Feature | Replace Shadow of Death with Gallows while Reaving or Enshrouded. |
| RPR | Shadow Gibbet Feature | Replace Shadow of Death with Gibbet while Reaving or Enshrouded. |
| RPR | Shadow Lemure's Feature | Replace Shadow of Death with Lemure's Slice when two or more stacks of Void Shroud are active. |
| RPR | Shadow Soulsow Feature | Replace Shadow of Death with Soulsow when out of combat, not active, and you have no target. |
| RPR | Slice Combo | Replace Infernal Slice with its combo chain. |
| RPR | Slice Communio Feature | Replace Infernal Slice with Communio when one stack of Shroud is left. |
| RPR | Slice Enhanced Enshrouded Feature | Replace Infernal Slice with whichever of Gibbet or Gallows is currently enhanced while Enshrouded. |
| RPR | Slice Enhanced Soul Reaver Feature | Replace Infernal Slice with whichever of Gibbet or Gallows is currently enhanced while Reaving. |
| RPR | Slice Gallows Feature | Replace Infernal Slice with Gallows while Reaving or Enshrouded. |
| RPR | Slice Gibbet Feature | Replace Infernal Slice with Gibbet while Reaving or Enshrouded. |
| RPR | Slice Lemure's Feature | Replace Infernal Slice with Lemure's Slice when two or more stacks of Void Shroud are active. |
| RPR | Slice Soulsow Feature | Replace Infernal Slice with Soulsow when out of combat and not active. |
| RPR | Slice Weave Assist | Replace Infernal Slice with Blood Stalk (or variants) when available and weaving wouldn't clip your GCD. |
| RPR | Slice of Death Feature | Replace Infernal Slice with Shadow of Death when the target's Death's Design debuff is low. |
| RPR | Soul Communio Feature | Replace Soul Slice with Communio when one stack of Shroud is left. |
| RPR | Soul Gallows Feature | Replace Soul Slice with Gallows while Reaving or Enshrouded. |
| RPR | Soul Gibbet Feature | Replace Soul Slice with Gibbet while Reaving or Enshrouded. |
| RPR | Soul Lemure's Feature | Replace Soul Slice with Lemure's Slice when two or more stacks of Void Shroud are active. |
| RPR | Soul Scythe Overcap Feature | Replace Soul Scythe with Grim Swathe when not Enshrouded, and Soul Gauge is over 50. |
| RPR | Soul Scythe Weave Assist | Replace Soul Scythe with Grim Swathe (or variants) when available and weaving wouldn't clip your GCD. |
| RPR | Soul Slice Overcap Feature | Replace Soul Slice with Blood Stalk when not Enshrouded and Soul Gauge is over 50. |
| RPR | Soul Slice Weave Assist | Replace Soul Slice with Blood Stalk (or variants) when available and weaving wouldn't clip your GCD. |
| RPR | Soulful Scythe | Replace Nightmare Scythe with Soul Scythe when available and Soul Gauge is no more than 50. |
| RPR | Soulful Slice | Replace Infernal Slice with Soul Slice when available and Soul Gauge is no more than 50. |
| SAM | Gekko Combo | Replace Gekko with its combo chain. |
| SAM | Gekko Combo from Jinpu | Start the Gekko combo chain with Jinpu instead of Hakaze. |
| SAM | Hissatsu Senei/Guren Sync Feature | Replace Hissatsu Senei with Hissatsu Guren when underlevel. |
| SAM | Iaijutsu to Shoha | Replace Iaijutsu with Shoha when meditation is 3. |
| SAM | Iaijutsu to Tsubame-gaeshi | Replace Iaijutsu with Tsubame-gaeshi when Sen is not empty. |
| SAM | Ikishoten Namikiri Feature | Replace Ikishoten with Shoha, Kaeshi Namikiri, and then Ogi Namikiri when available. |
| SAM | Kasha Combo | Replace Kasha with its combo chain. |
| SAM | Kasha Combo from Shifu | Start the Kasha combo chain with Shifu instead of Hakaze. |
| SAM | Kyuten to Guren | Replace Hissatsu: Kyuten with Guren when available. |
| SAM | Kyuten to Shoha 2 | Replace Hissatsu: Kyuten with Shoha 2 when Meditation is full. |
| SAM | Mangetsu Combo | Replace Mangetsu with its combo chain. |
| SAM | Oka Combo | Replace Oka with its combo chain. |
| SAM | Senei to Guren Level Sync | Replace Hissatsu: Senei with Guren when level synced below 72. |
| SAM | Shinten to Senei | Replace Hissatsu: Shinten with Senei when available. |
| SAM | Shinten to Shoha | Replace Hissatsu: Shinten with Shoha when Meditation is full. |
| SAM | Tsubame-gaeshi to Iaijutsu | Replace Tsubame-gaeshi with Iaijutsu when Sen is empty. |
| SAM | Tsubame-gaeshi to Shoha | Replace Tsubame-gaeshi with Shoha when meditation is 3. |
| SAM | Yukikaze Combo | Replace Yukikaze with its combo chain. |
| SCH | ED Aetherflow | Change Energy Drain into Aetherflow when you have no more Aetherflow stacks. |
| SCH | Excog / Lustrate | Change Excogitation into Lustrate when on CD or under level. |
| SCH | Excogitation to Recitation | Replace Excogitation with Recitation when Recitation is off cooldown. |
| SCH | Indomitable Aetherflow | Change Indomitability into Aetherflow when you have no more Aetherflow stacks. |
| SCH | Lustrate to Excogitation | Replace Lustrate with Excogitation when Excogitation is off cooldown. |
| SCH | Lustrate to Recitation | Replace Lustrate with Recitation when Recitation is off cooldown. |
| SCH | Lustrous Aetherflow | Change Lustrate into Aetherflow when you have no more Aetherflow stacks. |
| SCH | Seraph Fey Blessing/Consolation | Change Fey Blessing into Consolation when Seraph is out. |
| SCH | Summon Seraph Feature | Replace Summon Eos and Selene with Summon Seraph when a summon is out. |
| SCH | Swiftcast Resurrection | Resurrection turns into Swiftcast when available and reasonable. |
| SGE | Druochole Into Rhizomata Feature | Replace Druochole with Rhizomata when Addersgall is empty. |
| SGE | Gap Closer Feature | Replace Phlegma with Icarus when at least a configurable distance away and both are off CD. |
| SGE | Holos into Kerachole | Turns Holos into Kerachole when your level is too low, or when Kerachole is available and Holos is not. |
| SGE | Ixochole Into Rhizomata Feature | Replace Ixochole with Rhizomata when Addersgall is empty. |
| SGE | Kerachole Into Rhizomata Feature | Replace Kerachole with Rhizomata when Addersgall is empty. |
| SGE | Kerachole into Holos | Turns Kerachole into Holos when your level is high enough, Kerachole is unavailable, and you can use Holos. |
| SGE | Phlegma into Dyskrasia | Replace Phlegma with Dyskrasia when no charges remain or have no target. |
| SGE | Phlegma into Toxikon | Replace Phlegma with Toxikon when no charges rmemain and have Addersting. |
| SGE | Soteria Kardia Feature | Replace Soteria with Kardia when off cooldown and missing Kardion. |
| SGE | Swiftcast Egeiro | Egeiro turns into Swiftcast when available and reasonable. |
| SGE | Taurochole Into Druochole Feature | Replace Taurochole with Druochole when on cooldown |
| SGE | Taurochole Into Rhizomata Feature | Replace Taurochole with Rhizomata when Addersgall is empty. |
| SMN | Demi Enkindle Feature | Change Summon Bahamut and Summon Phoenix into Enkindle when Bahamut or Phoenix are summoned. |
| SMN | ED Fester | Change Fester into Energy Drain when out of Aetherflow stacks. |
| SMN | ES Painflare | Change Painflare into Energy Syphon when out of Aetherflow stacks. |
| SMN | Further Outburst Feature | Change Outburst into Ruin4 when available and appropriate. |
| SMN | Further Ruin Feature | Change Ruin into Ruin4 when available and appropriate. |
| SMN | Further Shiny Feature | Change Outburst into Ruin4 when available and appropriate. |
| SMN | Outburst Feature | Change Outburst into Precious Brilliance when attuned. |
| SMN | Radiant Carbuncle Feature | Change Radiant Aegis into Summon Carbuncle when no pet has been summoned. |
| SMN | Ruin Feature | Change Ruin into Gemburst when attuned. |
| SMN | Shiny Enkindle Feature | Change Gemshine and Precious Brilliance to Enkindle when Bahamut or Phoenix are summoned. |
| SMN | Shiny Titan's Favour | Change Ruin into Ruin4 when available and appropriate. |
| SMN | Slipstream / Swiftcast Feature | Change Slipstream into Swiftcast when Swiftcast is available. |
| SMN | Swiftcast Resurrection | Resurrection turns into Swiftcast when available and reasonable. |
| SMN | Titan's Favor Outburst Feature | Change Outburst into Mountain Buster (oGCD) when available. |
| SMN | Titan's Favor Ruin Feature | Change Ruin into Mountain Buster (oGCD) when available. |
| WAR | Angry Beast Feature | Replace Inner Beast/Fell Cleave and Steel Cyclone/Decimate with Infuriate when less then 50 Beast Gauge is available. |
| WAR | Angry Beast Gauge Saver | Replace the above with Infuriate when less than 60 Beast Gauge instead of 50. |
| WAR | Gauge Overcap Saver: Mythril Tempest | Replace the Mythril Tempest combo with gauge spender if completing the combo would overcap you. |
| WAR | Gauge Overcap Saver: Storm's Eye | Replace the Storm's Eye combo with gauge spender if completing the combo would overcap you. |
| WAR | Gauge Overcap Saver: Storm's Path | Replace the Storm's Path combo with gauge spender if completing the combo would overcap you. |
| WAR | Healthy Balanaced Diet Feature | Replace Bloodwhetting with Thrill of Battle, and then Equilibrium when the preceding is on cooldown. |
| WAR | Inner Release Feature | Replace single-target and AoE combo with Fell Cleave/Decimate during Inner Release. |
| WAR | Mythril Tempest Combo | Replace Mythril Tempest with its combo chain. |
| WAR | Nascent Flash Feature | Replace Nascent Flash with Raw Intuition when below level 76. |
| WAR | Primal Beast Feature | Replace Inner Beast and Steel Cyclone with Primal Rend when available |
| WAR | Primal Release Feature | Replace Inner Release with Primal Rend when available |
| WAR | Smart Weave | Automatically turn into Upheaval when weaving won't drift your GCD. |
| WAR | Smart Weave | Automatically turn into Upheaval when weaving won't drift your GCD. |
| WAR | Smart Weave | Automatically turn into Orogeny when weaving won't drift your GCD. |
| WAR | Souleater Overcap Feature | Replace Souleater with Bloodspiller when the next combo action would cause the Blood Gauge to overcap. |
| WAR | Stalwart Soul Overcap Feature | Replace Stalwart Soul with Quietus when the next combo action would cause the Blood Gauge to overcap. |
| WAR | Storm's Eye Combo | Replace Storm's Eye with its combo chain. |
| WAR | Storm's Path Combo | Replace Storm's Path with its combo chain. |
| WAR | Storm's Path Double Combo | Replace the Storm's Path combo chain with Storm's Eye if Surging Tempest has less than 7 (default) seconds left. |
| WAR | Stun/Interrupt Feature | Turn Low Blow and Interject into Interject when off CD and your target can be interrupted, Low Blow otherwise. |
| WHM | Afflatus Feature | Changes Cure 2 into Afflatus Solace, and Medica into Afflatus Rapture, when lilies are up. |
| WHM | Cure 2 Level Sync | Changes Cure 2 to Cure when below level 30 in synced content. |
| WHM | Holy into Misery | Replace Holy/Holy 3 with Afflatus Misery when Misery is ready to be used and you have a target. |
| WHM | Rapture into Misery | Replaces Afflatus Rapture with Afflatus Misery when Misery is ready to be used and you have a target. |
| WHM | Solace into Misery | Replaces Afflatus Solace with Afflatus Misery when Misery is ready to be used. |
| WHM | Swiftcast Raise | Raise turns into Swiftcast when available and reasonable. |
