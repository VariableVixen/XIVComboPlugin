namespace XIVComboVX.Config;

using System;
using System.Collections.Generic;

using Dalamud.Configuration;
using Dalamud.Interface.Internal.Notifications;

using Newtonsoft.Json;

using XIVComboVX.Attributes;
using XIVComboVX.Combos;

[Serializable]
public class PluginConfiguration: IPluginConfiguration {
	public int Version { get; set; } = 6;

	public PluginConfiguration() { }
	public PluginConfiguration(bool firstRun) {
		this.IsFirstRun = firstRun;
	}

	#region AST settings

	// placeholder

	#endregion

	#region BLM settings

	// placeholder

	#endregion

	#region BRD settings

	// placeholder

	#endregion

	#region DNC settings

	[ComboDetailSetting(
		CustomComboPreset.DancerDanceComboCompatibility,
		"Emboite (Red) Action ID",
		"Defaults to Cascade (15989)"
	)]
	public uint DancerEmboiteRedActionID { get; set; } = DNC.Cascade;

	[ComboDetailSetting(
		CustomComboPreset.DancerDanceComboCompatibility,
		"Entrechat (Blue) Action ID",
		"Defaults to Fountain (15990)"
	)]
	public uint DancerEntrechatBlueActionID { get; set; } = DNC.Fountain;

	[ComboDetailSetting(
		CustomComboPreset.DancerDanceComboCompatibility,
		"Jete (Green) Action ID",
		"Defaults to Reverse Cascade (15991)"
	)]
	public uint DancerJeteGreenActionID { get; set; } = DNC.ReverseCascade;

	[ComboDetailSetting(
		CustomComboPreset.DancerDanceComboCompatibility,
		"Pirouette (Yellow) Action ID",
		"Defaults to Fountainfall (15992)"
	)]
	public uint DancerPirouetteYellowActionID { get; set; } = DNC.Fountainfall;

	#endregion

	#region DRG settings

	[ComboDetailSetting(
		CustomComboPreset.DragoonFullThrustBuffSaver,
		"Power Surge buff threshold",
		"When the Power Surge buff only has this many seconds left, switch to the Chaos Thrust combo chain to renew it",
		0,
		30
	)]
	public float DragoonFullThrustBuffSaverBuffTime { get; set; } = 7;

	#endregion

	#region DRK settings

	// placeholder

	#endregion

	#region GNB settings

	[ComboDetailSetting(
		CustomComboPreset.GunbreakerGnashingStrikeFeature,
		"Gnashing Fang cooldown threshold",
		"Only become Burst Strike if Gnashing Fang's cooldown has at least this long left",
		0,
		30
	)]
	public float GunbreakerGnashingStrikeCooldownGnashingFang { get; set; } = 17;

	[ComboDetailSetting(
		CustomComboPreset.GunbreakerGnashingStrikeFeature,
		"Double Down cooldown threshold",
		"Only become Burst Strike if Double Down's cooldown has at least this long left",
		0,
		60
	)]
	public float GunbreakerGnashingStrikeCooldownDoubleDown { get; set; } = 20;

	[ComboDetailSetting(
	CustomComboPreset.GunbreakerSolidRoughDivide,
	"Rough Divide charges to hold",
	"Choose how many charge of Rough Divide to hold",
	0,
	2
)]
	public uint GunbreakerRoughDivideCharge { get; set; } = 1;

	#endregion

	#region MCH settings

	// placeholder

	#endregion

	#region MNK settings

	[ComboDetailSetting(
		CustomComboPreset.MonkTwinSnakesFeature,
		"Disciplined Fist buff threshold",
		"When the Disciplined Fist buff only has this many seconds left, switch to True Strike",
		0,
		10
	)]
	public float MonkTwinSnakesBuffTime { get; set; } = 6;

	[ComboDetailSetting(
		CustomComboPreset.MonkDemolishFeature,
		"Demolish debuff threshold",
		"When your current target's Demolish debuff only has this many seconds left, switch back to Demolish",
		0,
		15
	)]
	public float MonkDemolishDebuffTime { get; set; } = 6;

	[ComboDetailSetting(
		CustomComboPreset.MonkSTCombo,
		"Monk Bloodbath health percentage threshold",
		"When your health percentage is below this threshold, weave Bloodbath into the combo",
		0,
		90
	)]
	public uint MonkBloodbathHealthPercentage { get; set; } = 75;

	[ComboDetailSetting(
		CustomComboPreset.MonkSTCombo,
		"Monk Riddle of Earth health percentage threshold",
		"When your health percentage is below this threshold, weave Riddle of Earth into the combo",
		0,
		90
	)]
	public uint MonkRiddleOfEarthHealthPercentage { get; set; } = 50;

	#endregion

	#region NIN settings

	[ComboDetailSetting(
		CustomComboPreset.NinjaAeolianEdgeHutonFeature,
		"Huton timer threshold",
		"When Huton timer is above zero but below this many seconds left, switch to Armor Crush",
		10,
		30
	)]
	public float NinjaHutonThresholdTime { get; set; } = 30;

	#endregion

	#region PLD settings

	[ComboDetailSetting(
		CustomComboPreset.PaladinRoyalAuthorityDoTSaver,
		"RA/RoH buff threshold",
		"When the Goring Blade DoT only has this many seconds left, switch to Goring Blade to renew it",
		0,
		30
	)]
	public float PaladinGoringBladeDoTSaverDebuffTime { get; set; } = 7;

	#endregion

	#region RDM settings

	// placeholder

	#endregion

	#region RPR settings

	[ComboDetailSetting(
		CustomComboPreset.ReaperRegressDelayed,
		"Threshold buff threshold",
		"When the Threshold buff only has this many seconds left, switch to Regress",
		0,
		10
	)]
	public float ReaperThresholdBuffTime { get; set; } = 8.5F;

	[ComboDetailSetting(
		CustomComboPreset.ReaperSliceShadowFeature,
		"Death's Design debuff threshold",
		"When the current target's Death's Design debuff only has this many seconds left, switch to Shadow of Death",
		0,
		30
	)]
	public float ReaperSliceDeathDebuffTime { get; set; } = 5F;

	[ComboDetailSetting(
		CustomComboPreset.ReaperScytheWhorlFeature,
		"Death's Design debuff threshold",
		"When the current target's Death's Design debuff only has this many seconds left, switch to Whorl of Death",
		0,
		30
	)]
	public float ReaperScytheDeathDebuffTime { get; set; } = 5F;

	[ComboDetailSetting(
		CustomComboPreset.ReaperHarvestFeature,
		"Minimum stacks of Immortal Sacrifice",
		"When you have at least this many stacks of Immortal Sacrifice, Arcane Circle will become Plentiful Harvest",
		1,
		8
	)]
	public uint ReaperArcaneHarvestStackThreshold { get; set; } = 1;

	#endregion

	#region SAM settings

	// placeholder

	#endregion

	#region SCH settings

	// placeholder

	#endregion

	#region SGE settings

	[ComboDetailSetting(
		CustomComboPreset.SagePhlegmaIcarus,
		"Minimum distance threshold",
		"When you are more than this many yalms away from your current target, Phlegma will become Icarus",
		6,
		25
	)]
	public float SagePhlegmaIcarusDistanceThreshold { get; set; } = 6;

	#endregion

	#region SMN settings

	// placeholder

	#endregion

	#region WAR settings

	[ComboDetailSetting(
		CustomComboPreset.WarriorSmartStormCombo,
		"Surging Tempest buff threshold",
		"When the Surging Tempest buff only has this many seconds left, switch to the Storm's Eye combo chain",
		0,
		30
	)]
	public float WarriorStormBuffSaverBuffTime { get; set; } = 7;

	#endregion

	#region WHM settings

	// placeholder

	#endregion

	#region General plugin settings

	[NonSerialized]
	[JsonIgnore]
	private bool enabled = true;
	[JsonIgnore]
	public bool Active {
		get => this.enabled;
		set {
			this.enabled = value;
			if (!value) {
				Service.Interface.UiBuilder.AddNotification("This setting will not persist through reloads.", $"{Service.Plugin.Name} temporarily disabled", NotificationType.Warning, 6000);
			}
		}
	}

	[JsonProperty("HideDisabledFeaturesChildren")]
	public bool HideDisabledFeaturesChildren { get; set; } = false;

	[JsonProperty("RegisterCommonCommandName")]
	public bool RegisterCommonCommand { get; set; } = true;

	[JsonProperty("LastLoadedVersion")]
	public Version LastVersion { get; set; } = new("3.32.5"); // The last version released before the format change

	[JsonProperty("FirstRun")]
	public bool IsFirstRun { get; set; } = false;

	[JsonProperty("CompactDisplay")]
	public bool CompactSettingsWindow { get; set; } = false;

	[JsonProperty("DisplayUpdateMessage")]
	public bool ShowUpdateMessage { get; set; } = true;

	[JsonProperty("EnabledActionsV5")]
	public HashSet<CustomComboPreset> EnabledActions = new();

	[Obsolete("Use the explicit 'Dancer*ActionID' ushorts instead")]
	public uint[] DancerDanceCompatActionIDs = Array.Empty<uint>();

	#endregion

	#region Methods

	public bool IsEnabled(CustomComboPreset preset) => this.EnabledActions.Contains(preset);

	public void Save() => Service.Interface.SavePluginConfig(this);

	public void UpgradeIfNeeded() {
#pragma warning disable CS0618 // Type or member is obsolete
		if (this.Version == 5) {
			this.DancerEmboiteRedActionID = this.DancerDanceCompatActionIDs[0];
			this.DancerEntrechatBlueActionID = this.DancerDanceCompatActionIDs[1];
			this.DancerJeteGreenActionID = this.DancerDanceCompatActionIDs[2];
			this.DancerPirouetteYellowActionID = this.DancerDanceCompatActionIDs[3];
			this.DancerDanceCompatActionIDs = Array.Empty<uint>();
			this.Version++;
		}
#pragma warning restore CS0618 // Type or member is obsolete
	}

	#endregion

}
