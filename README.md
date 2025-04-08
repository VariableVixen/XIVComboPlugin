# XIVComboVX
_Finally, hotbar space..._

![GitHub build status](https://img.shields.io/github/actions/workflow/status/VariableVixen/XIVComboPlugin/build.yml?logo=github)
![GitHub tag (latest by date)](https://img.shields.io/github/v/tag/VariableVixen/XIVComboPlugin?label=version&color=informational)
![GitHub last commit (branch)](https://img.shields.io/github/last-commit/VariableVixen/XIVComboPlugin/master?label=updated)
[![GitHub issues](https://img.shields.io/github/issues-raw/VariableVixen/XIVComboPlugin?label=known%20issues)](https://github.com/VariableVixen/XIVComboPlugin/issues?q=is%3Aissue+is%3Aopen+sort%3Aupdated-desc)

[![Support me!](https://ko-fi.com/img/githubbutton_sm.svg)](https://ko-fi.com/V7V7IK9UU)

## About
[![License](https://img.shields.io/github/license/VariableVixen/XIVComboPlugin?logo=github&color=informational&cacheSeconds=86400)](https://github.com/VariableVixen/XIVComboPlugin/blob/master/LICENSE)

XIVCombo is a plugin to allow for "one-button" combo chains, as well as implementing various other mutually-exclusive button consolidation and quality of life replacements. Thanks to Meli for the initial start, attick and daemitus for continuing, and obviously goat for making any of this possible.

For some jobs, this frees a massive amount of hotbar space (looking at you, DRG). For most, it removes a lot of mindless tedium associated with having to press various buttons that have little logical reason to be separate.

## Installation
Type `/xlplugins` in-game to access the plugin installer and updater. Note that you will need to add [my custom plugin repository](https://github.com/VariableVixen/MyDalamudPlugins) (full instructions included at that link) in order to find this plugin.

## In-game usage
* Type `/pcombo` to pull up a GUI for editing active combo replacements.
* Drag the named ability from your ability list onto your hotbar to use.
  * For example, to use DRK's Souleater combo, first check the box, then place Souleater on your bar. It should automatically turn into Hard Slash.
  * The description associated with each combo should be enough to tell you which ability needs to be placed on the hotbar.

### Examples
![DRK Souleater combo](https://github.com/VariableVixen/XIVComboPlugin/raw/master/res/souleater_combo.gif)

![MCH Hypercharge/Heat Blast combo](https://github.com/VariableVixen/XIVComboPlugin/raw/master/res/hypercharge_heat_blast.gif)

![BLM Enochian switcher (outdated)](https://github.com/VariableVixen/XIVComboPlugin/raw/master/res/eno_swap.gif)

## Why Another Fork?
Because the original fork developer (daemitus) has a different philosophy regarding how much the plugin should be allowed to do. They want to avoid "intelligent" decisions in the plugin, because they feel it's too close to botting. While I respect their decision and their reasoning, I also personally disagree with it, and additionally believe that since this plugin _only_ operates in PvE, there's no real harm or reason to restrict it like that. You aren't gaining an advantage over another player unless you're comparing parses, and even then nobody "wins" or "loses" anything. <!-- Although it could be said that everyone comparing parses like that loses, in a way :P -->

Furthermore, I've seen _so_ many people who want to play this game, but have some disability or another - carpal tunnel, for instance - that makes it hard for them to do so. It is my hope that my fork will make the game more accessible to people like that, thereby bringing in more players to enjoy it.

## Full list of supported combos
This has been removed (it was a long time coming) because the list is both _so_ extensive and also tree-shaped with parent/child combos that it really can't be well represented in a flat list.

If you have any requests, including combos existing in other forks but not in this one, please [open a feature request](https://github.com/VariableVixen/XIVComboPlugin/issues/new/choose) here on the repo's issue tracker.

