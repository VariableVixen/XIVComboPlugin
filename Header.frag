# XIVComboPlugin
This plugin condenses combos and mutually exclusive abilities onto a single button. Thanks to Meli for the initial start, and obviously goat for making any of this possible.

## About
XIVCombo is a plugin to allow for "one-button" combo chains, as well as implementing various other mutually-exclusive button consolidation and quality of life replacements.

For some jobs, this frees a massive amount of hotbar space (looking at you, DRG). For most, it removes a lot of mindless tedium associated with having to press various buttons that have little logical reason to be separate.

## Installation
Type `/xlplugins` in-game to access the plugin installer and updater. Note that you will need to add [my custom plugin repository](https://github.com/PrincessRTFM/MyDalamudPlugins) (instructions included at that link) in order to find this plugin.

## In-game usage
* Type `/pcombo` to pull up a GUI for editing active combo replacements.
* Drag the named ability from your ability list onto your hotbar to use.
  * For example, to use DRK's Souleater combo, first check the box, then place Souleater on your bar. It should automatically turn into Hard Slash.
  * The description associated with each combo should be enough to tell you which ability needs to be placed on the hotbar.

### Examples
![](https://github.com/daemitus/xivcomboplugin/raw/master/res/souleater_combo.gif)
![](https://github.com/daemitus/xivcomboplugin/raw/master/res/hypercharge_heat_blast.gif)
![](https://github.com/daemitus/xivcomboplugin/raw/master/res/eno_swap.gif)

## Known Issues
* None, for now!

## Why Another Fork?
Because the original fork developer (daemitus) has a different philosophy regarding how much the plugin should be allowed to do. They want to avoid "intelligent" decisions in the plugin, because they feel it's too close to botting. While I respect their decision and their reasoning, I also personally disagree with it, and additionally believe that since this plugin _only_ operates in PvE, there's no real harm or reason to restrict it like that. You aren't gaining an advantage over another player unless you're comparing parses, and even then nobody "wins" or "loses" anything.

Furthermore, I've seen _so_ many people who want to play this game, but have some disability or another - carpal tunnel, for instance - that makes it hard for them to do so. It is my hope that my fork will make the game more accessible to people like that, thereby bringing in more players to enjoy it.

## Full list of supported combos
**Please note**: in the original fork, you _had_ to be on the listed job for replacements to function. You couldn't be on the base class, which means that the plugin wouldn't help until you reached level 30. This should now be fixed, so that applicable skills will update even on the base pre-job classes.

Now sorted by job and combo name!

