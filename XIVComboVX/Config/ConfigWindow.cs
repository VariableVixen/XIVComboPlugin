namespace XIVComboVX.Config;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices;

using Dalamud.Game.ClientState.Objects.SubKinds;
using Dalamud.Interface.Windowing;
using Dalamud.Utility;

using ImGuiNET;

using XIVComboVX.Attributes;

public class ConfigWindow: Window {

	private readonly Dictionary<string, List<(CustomComboPreset preset, CustomComboInfoAttribute info)>> groupedPresets;
	private readonly Dictionary<CustomComboPreset, HashSet<(CustomComboPreset Preset, CustomComboInfoAttribute Info)>> parentToChildrenPresets = new();
	private readonly Dictionary<CustomComboPreset, (CustomComboPreset Preset, CustomComboInfoAttribute Info)> childToParentPresets = new();
	private readonly Dictionary<CustomComboPreset, List<ComboDetailSetting>> detailSettings = new();

	private readonly string[] sortedJobs;

	private static readonly Vector4 shadedColour = new(0.69f, 0.69f, 0.69f, 1.0f); // NICE (x3 COMBO)
	private static readonly Vector4 warningColour = new(200f / 255f, 25f / 255f, 35f / 255f, 1f);

	private const int minWidth = 900;

	public ConfigWindow() : base($"Custom Combo Setup - {Service.Plugin.ShortPluginSignature}, {Service.Plugin.PluginBuildType}###{Service.Plugin.Name} Custom Combo Setup", ImGuiWindowFlags.MenuBar) {
		this.RespectCloseHotkey = true;

		List<(CustomComboPreset preset, CustomComboInfoAttribute info)> realPresets = Enum
			.GetValues<CustomComboPreset>()
			.Where(preset => (int)preset >= 100)
			.Select(preset => (
				preset,
				info: preset.GetAttribute<CustomComboInfoAttribute>()
			))
			.Where(preset => preset.info is not null)
			.OrderBy(preset => preset.info.Order)
			.ToList();

		this.groupedPresets = realPresets
			.GroupBy(data => data.info.JobName)
			.OrderBy(group => group.Key)
			.ToDictionary(
				group => group.Key,
				data => data
					.OrderBy(e => e.info.Order)
					.ToList()
			);

		this.detailSettings = typeof(PluginConfiguration)
			.GetProperties(BindingFlags.Instance | BindingFlags.Public)
			.Select(prop => (prop, attr: prop.GetCustomAttribute<ComboDetailSettingAttribute>()))
			.Where(pair => pair.attr is not null)
			.Select(pair => new ComboDetailSetting(pair.prop, pair.attr!))
			.GroupBy(detail => detail.Combo)
			.ToDictionary(
				group => group.Key,
				group => group
					.OrderBy(detail => detail.Label)
					.ToList()
			);

		foreach ((CustomComboPreset preset, CustomComboInfoAttribute info) in realPresets) {
			CustomComboPreset? parent = preset.GetParent();
			CustomComboInfoAttribute? parentInfo = parent?.GetAttribute<CustomComboInfoAttribute>();
			if (parent is not null && parentInfo is not null) {
				this.childToParentPresets.Add(preset, (parent.Value, parentInfo));
				if (!this.parentToChildrenPresets.ContainsKey(parent.Value)) {
					this.parentToChildrenPresets[parent.Value] = new();
				}
				this.parentToChildrenPresets[parent.Value].Add((preset, info));
			}
		}

		this.sortedJobs = this.groupedPresets.Keys
			.Where(j => !j.StartsWith("Disciple of the "))
			.Concat(
				this.groupedPresets.Keys
					.Where(j => j.StartsWith("Disciple of the "))
			)
			.ToArray();

		this.SizeCondition = ImGuiCond.FirstUseEver;
		this.Size = new(minWidth, 800);
		this.SizeConstraints = new() {
			MinimumSize = new(minWidth, 400),
			MaximumSize = new(int.MaxValue, int.MaxValue),
		};
	}

	public override void Draw() {

		bool pluginActive = Service.Configuration.Active;
		bool hideChildren = Service.Configuration.HideDisabledFeaturesChildren;
		bool registerNormalCommand = Service.Configuration.RegisterCommonCommand;
		bool showUpdateMessage = Service.Configuration.ShowUpdateMessage;
		bool compactMode = Service.Configuration.CompactSettingsWindow;

		if (ImGui.BeginMenuBar()) {

			if (ImGui.BeginMenu("Settings")) {

				bool clickEnabled = ImGui.MenuItem("Enable action replacement", "", ref pluginActive);
				if (ImGui.IsItemHovered()) {
					ImGui.BeginTooltip();
					ImGui.Text("If disabled, no actions will be replaced, regardless of configured");
					ImGui.Text("combos and features. This allows you to see what actions you actually");
					ImGui.Text("assigned on your hotbars without manually disabling everything and");
					ImGui.Text("having to turn it all back on after, one by one.");
					ImGui.Text("");
					ImGui.Text("This option does NOT persist between plugin loads.");
					ImGui.Text("It will always be reset to ON when you launch the game.");
					ImGui.EndTooltip();
				}
				if (clickEnabled) {
					Service.Configuration.Active = pluginActive;
				}

				bool clickCollapse = ImGui.MenuItem("Collapse disabled features", "", ref hideChildren);
				if (ImGui.IsItemHovered()) {
					ImGui.BeginTooltip();
					ImGui.Text("If enabled, children of disabled features will be hidden.");
					ImGui.Text("A message will be shown under any disabled feature that");
					ImGui.Text("has child features, so you can still tell that there are more");
					ImGui.Text("features available dependent on the disabled one.");
					ImGui.EndTooltip();
				}
				if (clickCollapse) {
					Service.Configuration.HideDisabledFeaturesChildren = hideChildren;
					Service.Configuration.Save();
				}

				bool clickRegister = ImGui.MenuItem($"Register {Plugin.command}", "", ref registerNormalCommand);
				if (ImGui.IsItemHovered()) {
					ImGui.BeginTooltip();
					ImGui.Text($"If enabled, {Service.Plugin.Name} will attempt to register the {Plugin.command} command.");
					ImGui.Text("This is the command generally used by all forks of XIVCombo, which");
					ImGui.Text("means it will conflict if you have multiple forks installed. This");
					ImGui.Text("isn't advised to begin with, but this option will allow for slightly");
					ImGui.Text("better compatibility than would otherwise be available, at least.");
					ImGui.Text("");
					ImGui.Text("This plugin always registers its own (separate) command to open the");
					ImGui.Text("settings window, regardless of whether the default one is also used.");
					ImGui.Text("");
					ImGui.Text("This option only takes effect after a restart.");
					ImGui.EndTooltip();
				}
				if (clickRegister) {
					Service.Configuration.RegisterCommonCommand = registerNormalCommand;
					Service.Configuration.Save();
				}

				bool clickUpdates = ImGui.MenuItem("Show update messages", "", ref showUpdateMessage);
				if (ImGui.IsItemHovered()) {
					ImGui.BeginTooltip();
					ImGui.Text("If enabled, an alert will be shown in your chatlog whenever the plugin updates.");
					ImGui.Text("The message includes the old version, the new version, and a clickable 'link' to");
					ImGui.Text("open the plugin configuration window.");
					ImGui.EndTooltip();
				}
				if (clickUpdates) {
					Service.Configuration.ShowUpdateMessage = showUpdateMessage;
					Service.Configuration.Save();
				}

				bool clickCompact = ImGui.MenuItem("Compact display", "", ref compactMode);
				if (ImGui.IsItemHovered()) {
					ImGui.BeginTooltip();
					ImGui.Text("If enabled, combo descriptions will be moved into tooltips shown on hover.");
					ImGui.Text("This makes the combo display more compact, which can be useful with the");
					ImGui.Text("new detail settings taking up extra space.");
					ImGui.EndTooltip();
				}
				if (clickCompact) {
					Service.Configuration.CompactSettingsWindow = compactMode;
					Service.Configuration.Save();
				}

				ImGui.EndMenu();
			}

			if (ImGui.BeginMenu("Utilities")) {

				bool clickReset = ImGui.MenuItem("Reset configuration");
				if (ImGui.IsItemHovered()) {
					ImGui.BeginTooltip();
					ImGui.Text("This will completely reset your entire configuration to the defaults.");
					ImGui.TextColored(warningColour, "THIS CANNOT BE UNDONE!");
					ImGui.EndTooltip();
				}
				if (clickReset) {
					Service.Plugin.onPluginCommand("", "reset");
				}

				ImGui.EndMenu();
			}

#if DEBUG
			if (ImGui.BeginMenu("Debugging")) {

				PlayerCharacter? player = Service.Client.LocalPlayer;
				if (player is null) {
					ImGui.MenuItem("Not logged in", false);
				}
				else {
					ImGui.MenuItem($"{player.Name}: {player.ClassJob.GameData!.Abbreviation.ToString().ToUpper()} ({player.ClassJob.Id})", false);
				}

				bool clickDebug = ImGui.MenuItem("Snapshot debug messages");
				if (ImGui.IsItemHovered()) {
					ImGui.BeginTooltip();
					ImGui.Text("This enables a snapshot of debug messages in the dalamud log.");
					ImGui.Text("They will appear in your log file and also in the /xllog window.");
					ImGui.EndTooltip();
				}
				if (clickDebug) {
					Service.Logger.EnableNextTick();
				}

				ImGui.EndMenu();
			}
#endif

			ImGui.EndMenuBar();
		}

		int i = 1;
		foreach (string jobName in this.sortedJobs) {
			if (ImGui.CollapsingHeader(jobName)) {

				ImGui.PushID($"settings-{jobName}");

				foreach ((CustomComboPreset preset, CustomComboInfoAttribute info) in this.groupedPresets[jobName]) {
					if (this.childToParentPresets.ContainsKey(preset))
						continue;

					this.drawPreset(preset, info, ref i);
				}

				ImGui.PopID();

			}
			else {
				i += this.groupedPresets[jobName].Count;
			}
		}

	}

	private void drawPreset(CustomComboPreset preset, CustomComboInfoAttribute info, ref int i) {

		bool compactMode = Service.Configuration.CompactSettingsWindow;
		bool enabled = Service.Configuration.IsEnabled(preset);
		CustomComboPreset[] conflicts = preset.GetConflicts();
		CustomComboPreset? parent = preset.GetParent();
		bool dangerous = preset.GetAttribute<DangerousAttribute>() is not null;
		bool experimental = preset.GetAttribute<ExperimentalAttribute>() is not null;
		bool hideChildren = Service.Configuration.HideDisabledFeaturesChildren;
		bool hasChildren = this.parentToChildrenPresets.TryGetValue(preset, out HashSet<(CustomComboPreset Preset, CustomComboInfoAttribute Info)>? children)
			&& children is not null;
		int childCount = hasChildren ? children!.Count : 0;
		bool hasDetails = this.detailSettings.TryGetValue(preset, out List<ComboDetailSetting>? details)
			&& details is not null;
#if DEBUG
		string debugInfo = preset.GetDebugLabel();
#else
		string debugInfo = ((int)preset).ToString();
#endif

		string conflictWarning = string.Empty;
		if (conflicts.Length > 0) {
			string[] conflictNames = conflicts
				.Select(p => p.GetAttribute<CustomComboInfoAttribute>().FancyName)
				.ToArray();
			conflictWarning = $"Conflicts with: {string.Join(", ", conflictNames)}";
		}

		ImGui.PushItemWidth(200);
		bool toggled = ImGui.Checkbox($"{i}: {info.FancyName}", ref enabled);
		ImGui.PopItemWidth();

		if (compactMode && ImGui.IsItemHovered()) {
			ImGui.BeginTooltip();

			ImGui.TextUnformatted(info.Description);

			if (conflictWarning.Length > 0)
				ImGui.TextColored(shadedColour, conflictWarning);

			ImGui.EndTooltip();
		}

		ImGui.SameLine();
		ImGui.TextColored(shadedColour, $"[debug: {debugInfo}]");
		if (ImGui.IsItemHovered()) {
			ImGui.SetMouseCursor(ImGuiMouseCursor.Hand);
			ImGui.SetTooltip("Click to copy the debug ID for the developer");
		}
		if (ImGui.IsItemClicked())
			ImGui.SetClipboardText(debugInfo);

		if (toggled) {
			if (enabled) {

				Service.Configuration.EnabledActions.Add(preset);
				this.enableParentPresets(preset);

				foreach (CustomComboPreset conflict in conflicts) {
					Service.Configuration.EnabledActions.Remove(conflict);
				}

			}
			else {
				Service.Configuration.EnabledActions.Remove(preset);
			}

			Service.Configuration.Save();
		}

		ImGui.PushTextWrapPos((this.Size?.Y ?? minWidth) - 20);

		if (!compactMode)
			ImGui.TextUnformatted(info.Description);
		if (dangerous) {
			ImGui.TextColored(warningColour, "UNSAFE - use at your own risk!");
			if (ImGui.IsItemHovered()) {
				ImGui.BeginTooltip();
				ImGui.TextUnformatted("Unsafe replacers use internal mechanisms that may carry a risk of crashing,"
					+ "\nespecially immediately after FFXIV or Dalamud is updated.");
				ImGui.EndTooltip();
			}
		}
		else if (experimental) {
			ImGui.TextColored(warningColour, "EXPERIMENTAL - may change without warning!");
			if (ImGui.IsItemHovered()) {
				ImGui.BeginTooltip();
				ImGui.TextUnformatted("Experimental replacers are not fully tested, may cause unwanted or unexpected behaviour,"
					+ "\nmight not be complete, and should only be used if you accept these risks.");
				ImGui.EndTooltip();
			}
		}
		if (!compactMode && conflictWarning.Length > 0)
			ImGui.TextColored(shadedColour, conflictWarning);
		if (hasChildren && hideChildren && !enabled)
			ImGui.TextColored(shadedColour, "This preset has one or more children.");
		if (hasDetails && !enabled)
			ImGui.TextColored(shadedColour, "This preset has additional configurable options.");

		ImGui.PopTextWrapPos();

		ImGui.Spacing();

		if (hasDetails && enabled) {
			const int MEM_WIDTH = 4;
			IntPtr ptrVal = Marshal.AllocHGlobal(MEM_WIDTH);
			IntPtr ptrMin = Marshal.AllocHGlobal(MEM_WIDTH);
			IntPtr ptrMax = Marshal.AllocHGlobal(MEM_WIDTH);
			IntPtr ptrStep = Marshal.AllocHGlobal(MEM_WIDTH);
			foreach (ComboDetailSetting? detail in details!) {
				if (detail is not null) {
					string fmt;
					switch (detail.ImGuiType) {
						case ImGuiDataType.Float:
							fmt = $"%.{detail.Precision}f";
							Marshal.Copy(BitConverter.GetBytes(detail.Val), 0, ptrVal, MEM_WIDTH);
							Marshal.Copy(BitConverter.GetBytes(detail.Min), 0, ptrMin, MEM_WIDTH);
							Marshal.Copy(BitConverter.GetBytes(detail.Max), 0, ptrMax, MEM_WIDTH);
							Marshal.Copy(BitConverter.GetBytes((float)1), 0, ptrStep, MEM_WIDTH);
							break;
						case ImGuiDataType.U32:
							fmt = "%u";
							Marshal.Copy(BitConverter.GetBytes((uint)detail.Val), 0, ptrVal, MEM_WIDTH);
							Marshal.Copy(BitConverter.GetBytes((uint)detail.Min), 0, ptrMin, MEM_WIDTH);
							Marshal.Copy(BitConverter.GetBytes((uint)detail.Max), 0, ptrMax, MEM_WIDTH);
							Marshal.Copy(BitConverter.GetBytes((uint)1), 0, ptrStep, MEM_WIDTH);
							break;
						case ImGuiDataType.S32:
							fmt = "%i";
							Marshal.Copy(BitConverter.GetBytes((int)detail.Val), 0, ptrVal, MEM_WIDTH);
							Marshal.Copy(BitConverter.GetBytes((int)detail.Min), 0, ptrMin, MEM_WIDTH);
							Marshal.Copy(BitConverter.GetBytes((int)detail.Max), 0, ptrMax, MEM_WIDTH);
							Marshal.Copy(BitConverter.GetBytes(1), 0, ptrStep, MEM_WIDTH);
							break;
						default:
							throw new FormatException($"Invalid detail type {detail.ImGuiType}");
					}
					Service.Logger.debug(
						$"{detail.Label} ({detail.Type.Name}/{detail.ImGuiType}) {detail.Min} <= {detail.Val} <= {detail.Max}"
					);
					bool changed = detail.Max - detail.Min > 40
						? ImGui.InputScalar(
							detail.Label + $"##{detail.Combo}",
							detail.ImGuiType,
							ptrVal,
							ptrStep,
							ptrStep,
							fmt,
							ImGuiInputTextFlags.AutoSelectAll
						)
						: ImGui.SliderScalar(
							detail.Label + $"##{detail.Combo}",
							detail.ImGuiType,
							ptrVal,
							ptrMin,
							ptrMax,
							fmt,
							ImGuiSliderFlags.AlwaysClamp
						);
					if (!string.IsNullOrEmpty(detail.Description) && ImGui.IsItemHovered()) {
						ImGui.BeginTooltip();
						ImGui.PushTextWrapPos(300);
						ImGui.TextUnformatted(detail.Description);
						ImGui.PopTextWrapPos();
						ImGui.EndTooltip();
					}
					if (changed) {
						byte[] value = new byte[MEM_WIDTH];
						Marshal.Copy(ptrVal, value, 0, MEM_WIDTH);
						float val = detail.ImGuiType switch {
							ImGuiDataType.Float => BitConverter.ToSingle(value),
							ImGuiDataType.U32 => BitConverter.ToUInt32(value),
							ImGuiDataType.S32 => BitConverter.ToInt32(value),
							_ => throw new FormatException($"Invalid detail type {detail.ImGuiType}"), // theoretically unpossible
						};
						detail.Val = (float)Math.Round(val, detail.Precision);
						Service.Configuration.Save();
					}
				}
			}
			Marshal.FreeHGlobal(ptrVal);
			Marshal.FreeHGlobal(ptrMin);
			Marshal.FreeHGlobal(ptrMax);
			Marshal.FreeHGlobal(ptrStep);
		}

		if (hasChildren) {
			if (!hideChildren || enabled) {
				++i;

				ImGui.Indent();
				if (!compactMode)
					ImGui.Indent();

				foreach ((CustomComboPreset childPreset, CustomComboInfoAttribute childInfo) in children!) {
					this.drawPreset(childPreset, childInfo, ref i);
				}

				ImGui.Unindent();
				if (!compactMode)
					ImGui.Unindent();
			}
			else {
				Queue<CustomComboPreset> queue = new();
				queue.Enqueue(preset);
				while (queue.TryDequeue(out CustomComboPreset next)) {
					++i;
					if (this.parentToChildrenPresets.TryGetValue(next, out HashSet<(CustomComboPreset Preset, CustomComboInfoAttribute Info)>? subchildren)) {
						foreach ((CustomComboPreset Preset, CustomComboInfoAttribute _) in subchildren)
							queue.Enqueue(Preset);
					}
				}
			}
		}
		else {
			++i;
		}
	}

	private void enableParentPresets(CustomComboPreset original) {
		CustomComboPreset preset = original;

		while (this.childToParentPresets.TryGetValue(preset, out (CustomComboPreset Preset, CustomComboInfoAttribute Info) parent)) {

			if (!Service.Configuration.EnabledActions.Contains(parent.Preset)) {
				Service.Configuration.EnabledActions.Add(parent.Preset);

				foreach (CustomComboPreset conflict in parent.Preset.GetConflicts()) {
					Service.Configuration.EnabledActions.Remove(conflict);
				}
			}

			preset = parent.Preset;
		}
	}

}
