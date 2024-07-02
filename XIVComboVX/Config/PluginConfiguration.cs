using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

using Dalamud.Configuration;
using Dalamud.Interface.ImGuiNotification;

using Newtonsoft.Json;

using PrincessRTFM.XIVComboVX.Attributes;
using PrincessRTFM.XIVComboVX.Combos;

namespace PrincessRTFM.XIVComboVX.Config;

[Serializable]
[SuppressMessage("Maintainability", "CA1507:Use nameof to express symbol names", Justification = "Serialisation names must remain constant even if member names change")]
public class PluginConfiguration: IPluginConfiguration {
	private static readonly Notification disableWillNotPersist = new() {
		Title = $"{Plugin.Name} temporarily disabled",
		Content = "This setting will not persist through reloads.",
		Type = NotificationType.Warning,
		InitialDuration = TimeSpan.FromSeconds(6),
		Minimized = false,
		MinimizedText = "XCVX paused",
		UserDismissable = true,
	};

	public int Version { get; set; } = 6;

	public PluginConfiguration() { }
	public PluginConfiguration(bool firstRun) => this.IsFirstRun = firstRun;

	/* HOW IT WORKS:
	 *
	 *      The key words "MUST", "MUST NOT", "REQUIRED", "SHALL", "SHALL
	 *      NOT", "SHOULD", "SHOULD NOT", "RECOMMENDED",  "MAY", and
	 *      "OPTIONAL" are to be interpreted as described in RFC 2119.
	 *
	 *      Yeah, I'm going there. I'm autistic, sue me.
	 *
	 * Detail settings MUST be one of three numeric types: float, int, or uint. Using any other type for a tagged property will crash the plugin.
	 * Each detail MUST have a getter and a setter, which MAY perform validation or transformation, but remember that the getter's returned value will be displayed to the user in the config window.
	 * Each detail MUST be linked to ONE AND ONLY ONE preset, and will be displayed below that preset IFF it is enabled.
	 * Values are persisted and accessible even when the linked preset is disabled, but SHOULD NOT be used in any code that does not depend on the linked preset being enabled.
	 * Details MAY be given a minimum and maximum value, which are both inclusive. If no range is given, it defaults to the minimum and maximum representable values of the detail's type.
	 * If the range of a detail's acceptable values is not greater than 40, it will be represented as a slider. Otherwise, it will be a "spinner"-type writable input.
	 * Details MAY be given a precision level, which is the number of decimal places that will be displayed for float values. There is no effect on int and uint values.
	 */

	#region AST settings

	// placeholder

	#endregion

	#region BLM settings

	// placeholder

	#endregion

	#region BRD settings

	[ComboDetailSetting(
		CustomComboPreset.BardWeavePitchPerfect,
		"Minimum song time left",
		"When the Wanderer's Minuet has no more than this much time left, weave into Pitch Perfect",
		3,
		45
	)]
	public float BardWanderersMinuetBuffThreshold { get; set; } = 5;

	[ComboDetailSetting(
		CustomComboPreset.BardStraightShotIronJaws,
		"Debuff time threshold",
		"When your bite DoTs have less than this much time left, Heavy/Burst shot becomes Iron Jaws",
		3,
		45
	)]
	public float BardBiteDebuffThreshold { get; set; } = 10;

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

	[ComboDetailSetting(
		CustomComboPreset.DancerSingleTargetGaugeSpender,
		"Minimum Espirit",
		"When you have AT LEAST this much Esprit, the single-target multibutton combo will become Saber Dance",
		50,
		100
	)]
	public uint DancerSingleTargetGaugeThreshold { get; set; } = 80;

	[ComboDetailSetting(
		CustomComboPreset.DancerAoeGaugeSpender,
		"Minimum Espirit",
		"When you have AT LEAST this much Esprit, the AoE multibutton combo will become Saber Dance",
		50,
		100
	)]
	public uint DancerAoeGaugeThreshold { get; set; } = 80;

	[ComboDetailSetting(
		CustomComboPreset.DancerSingleTargetStarfall,
		"Maximum buff time",
		"When you have NO MORE than this much time left on Flourishing Starfall, the single-target multibutton will become Starfall Dance",
		3,
		20
	)]
	public float DancerSingleTargetStarfallBuffThreshold { get; set; } = 10;

	[ComboDetailSetting(
		CustomComboPreset.DancerAoeStarfall,
		"Maximum buff time",
		"When you have NO MORE than this much time left on Flourishing Starfall, the AoE multibutton will become Starfall Dance",
		3,
		20
	)]
	public float DancerAoeStarfallBuffThreshold { get; set; } = 10;

	#endregion

	#region DRG settings

	[ComboDetailSetting(
		CustomComboPreset.DragoonFullThrustBuffSaver,
		"Power Surge buff threshold",
		"When the Power Surge buff only has this many seconds left, switch to the Chaos Thrust skill chain to renew it",
		0,
		30
	)]
	[ComboDetailSetting(
		CustomComboPreset.DragoonTotalThrustBuffSaver,
		"Power Surge buff threshold",
		"When the Power Surge buff only has this many seconds left, switch to the Chaos Thrust skill chain to renew it",
		0,
		30
	)]
	public float DragoonPowerSurgeBuffSaverBuffTime { get; set; } = 7;

	[ComboDetailSetting(
		CustomComboPreset.DragoonTotalThrustDotSaver,
		"Chaos Thrust DoT threshold",
		"When the Chaos Thrust DoT only has this many seconds left on your current target, switch to the Chaos Thrust skill chain to renew it",
		0,
		30
	)]
	[ComboDetailSetting(
		CustomComboPreset.DragoonFullThrustDotSaver,
		"Chaos Thrust DoT threshold",
		"When the Chaos Thrust DoT only has this many seconds left on your current target, switch to the Chaos Thrust skill chain to renew it",
		0,
		30
	)]
	public float DragoonChaosDotSaverDebuffTime { get; set; } = 7;

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

	// placeholder

	#endregion

	#region RDM settings

	[LucidWeavingSetting(CustomComboPreset.RedMageSmartcastAoEWeaveLucid)]
	public uint RedMageSmartcastAoEWeaveLucidManaThreshold { get; set; } = 7000;

	[LucidWeavingSetting(CustomComboPreset.RedMageSmartcastSingleTargetWeaveLucid)]
	public uint RedMageSmartcastSingleWeaveLucidManaThreshold { get; set; } = 7000;

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

	[LucidWeavingSetting(CustomComboPreset.ScholarLucidRuinBroil)]
	public uint ScholarLucidRuinBroilManaThreshold { get; set; } = 7000;

	[LucidWeavingSetting(CustomComboPreset.ScholarLucidArtOfWar)]
	public uint ScholarLucidArtOfWarManaThreshold { get; set; } = 7000;

	#endregion

	#region SGE settings

	[ComboDetailSetting(
		CustomComboPreset.SagePhlegmaIcarus,
		"Minimum ENEMY distance threshold",
		"When you are more than this many yalms away from your HOSTILE current target, Phlegma will become Icarus",
		6,
		25
	)]
	public float SagePhlegmaIcarusDistanceThresholdEnemy { get; set; } = 6;


	[ComboDetailSetting(
		CustomComboPreset.SagePhlegmaIcarus,
		"Minimum ALLY distance threshold",
		"When you are more than this many yalms away from your FRIENDLY current target, Phlegma will become Icarus",
		6,
		25
	)]
	public float SagePhlegmaIcarusDistanceThresholdAlly { get; set; } = 6;

	[LucidWeavingSetting(CustomComboPreset.SageLucidDosis)]
	public uint SageLucidDosisManaThreshold { get; set; } = 7000;

	[LucidWeavingSetting(CustomComboPreset.SageLucidDyskrasia)]
	public uint SageLucidDyskrasiaManaThreshold { get; set; } = 7000;

	[LucidWeavingSetting(CustomComboPreset.SageLucidPhlegma)]
	public uint SageLucidPhlegmaManaThreshold { get; set; } = 7000;

	[LucidWeavingSetting(CustomComboPreset.SageLucidToxikon)]
	public uint SageLucidToxikonManaThreshold { get; set; } = 7000;

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

	[LucidWeavingSetting(CustomComboPreset.WhiteMageLucidWeave)]
	public uint WhiteMageLucidWeaveManaThreshold { get; set; } = 7000;
	
	[ComboDetailSetting(
		CustomComboPreset.WhiteMageDotRefresh,
		"Debuff time threshold",
		"When your current target's Aero/Aero2/Dia debuff only has this many seconds left, switch back to DOT",
		0,
		30
	)]
	public float WhiteMageDotRefreshDuration { get; set; } = 3F;

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
				Service.Notifications.AddNotification(disableWillNotPersist);
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
	public HashSet<CustomComboPreset> EnabledActions { get; set; } = [];

	[Obsolete("Use the explicit 'Dancer*ActionID' ushorts instead")]
	public uint[] DancerDanceCompatActionIDs { get; set; } = [];

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
			this.DancerDanceCompatActionIDs = [];
			this.Version++;
		}
#pragma warning restore CS0618 // Type or member is obsolete
	}

	#endregion

}
