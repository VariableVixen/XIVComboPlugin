using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;

using Dalamud.Data;
using Dalamud.Game;
using Dalamud.Game.ClientState;
using Dalamud.Game.ClientState.Conditions;
using Dalamud.Game.ClientState.JobGauge;
using Dalamud.Game.ClientState.Objects;
using Dalamud.Game.Command;
using Dalamud.Game.Gui;
using Dalamud.IoC;
using Dalamud.Plugin;
using Dalamud.Utility;

using ImGuiNET;

namespace XIVComboVeryExpandedPlugin {
	public sealed class XIVComboVeryExpandedPlugin: IDalamudPlugin {
		public string Name => "XIV Combo Very Expanded Plugin";

		private const string command = "/pcombo";
		internal XIVComboVeryExpandedConfiguration configuration;
		[SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
		internal const int CURRENT_CONFIG_VERSION = 4;

		[PluginService] internal static DalamudPluginInterface pluginInterface { get; private set; } = null!;
		[PluginService] internal static CommandManager cmdManager { get; private set; } = null!;
		[PluginService] internal static ChatGui chat { get; private set; } = null!;
		[PluginService] internal static SigScanner scanner { get; private set; } = null!;
		[PluginService] internal static ClientState client { get; private set; } = null!;
		[PluginService] internal static Condition conditions { get; private set; } = null!;
		[PluginService] internal static TargetManager targets { get; private set; } = null!;
		[PluginService] internal static JobGauges jobGauge { get; private set; } = null!;
		[PluginService] internal static DataManager data { get; private set; } = null!;

		private readonly IconReplacer iconReplacer;

		private readonly Dictionary<string, List<(CustomComboPreset preset, CustomComboInfoAttribute info)>> groupedPresets;

		public XIVComboVeryExpandedPlugin() {
			cmdManager.AddHandler(command, new CommandInfo(this.onCommandDebugCombo) {
				HelpMessage = "Open a window to edit custom combo settings.",
				ShowInHelp = true
			});

			this.configuration = pluginInterface.GetPluginConfig() as XIVComboVeryExpandedConfiguration ?? new XIVComboVeryExpandedConfiguration();
			if (this.configuration.Version < CURRENT_CONFIG_VERSION) {
				this.configuration.Upgrade();
				this.saveConfiguration();
			}

			this.iconReplacer = new IconReplacer(this.configuration);

			pluginInterface.UiBuilder.OpenConfigUi += () => this.isImguiComboSetupOpen = true;
			pluginInterface.UiBuilder.Draw += this.buildUi;

			this.groupedPresets = Enum
				.GetValues(typeof(CustomComboPreset))
				.Cast<CustomComboPreset>()
				.Select(preset => (preset, info: preset.GetAttribute<CustomComboInfoAttribute>()))
				.Where(presetWithInfo => presetWithInfo.info != null)
				.OrderBy(presetWithInfo => presetWithInfo.info.JobName)
				.GroupBy(presetWithInfo => presetWithInfo.info.JobName)
				.ToDictionary(presetWithInfos => presetWithInfos.Key,
							  presetWithInfos => presetWithInfos.ToList());
		}

		private bool isImguiComboSetupOpen = false;

		private void saveConfiguration() => pluginInterface.SavePluginConfig(this.configuration);

		private void buildUi() {
			if (!this.isImguiComboSetupOpen)
				return;

			ImGui.SetNextWindowSize(new Vector2(740, 490), ImGuiCond.FirstUseEver);

			ImGui.Begin("Custom Combo Setup", ref this.isImguiComboSetupOpen);

			ImGui.Text("This window allows you to enable and disable custom combos to your liking.");

			ImGui.BeginChild("scrolling", new Vector2(0, -1), true);

			ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new Vector2(0, 5));

			int i = 1;
			foreach (string jobName in this.groupedPresets.Keys) {
				if (ImGui.CollapsingHeader(jobName)) {
					foreach ((CustomComboPreset preset, CustomComboInfoAttribute info) in this.groupedPresets[jobName]) {
						bool enabled = this.configuration.IsEnabled(preset);

						ImGui.PushItemWidth(200);

						if (ImGui.Checkbox(info.FancyName, ref enabled)) {
							if (enabled)
								this.configuration.EnabledActions.Add(preset);
							else
								this.configuration.EnabledActions.Remove(preset);
							this.iconReplacer.UpdateEnabledActionIDs();
							this.saveConfiguration();
						}

						ImGui.PopItemWidth();

						ImGui.TextColored(new Vector4(0.68f, 0.68f, 0.68f, 1.0f), $"#{i}: {info.Description}");
						ImGui.Spacing();

						if (preset == CustomComboPreset.DancerDanceComboCompatibility && enabled) {
							int[] actions = this.configuration.DancerDanceCompatActionIDs.Select(i => (int)i).ToArray();
							if (ImGui.InputInt("Emboite (Red) ActionID", ref actions[0], 0) ||
								ImGui.InputInt("Entrechat (Blue) ActionID", ref actions[1], 0) ||
								ImGui.InputInt("Jete (Green) ActionID", ref actions[2], 0) ||
								ImGui.InputInt("Pirouette (Yellow) ActionID", ref actions[3], 0)) {
								this.configuration.DancerDanceCompatActionIDs = actions.Select(i => (uint)i).ToArray();
								this.iconReplacer.UpdateEnabledActionIDs();
								this.saveConfiguration();
							}
							ImGui.Spacing();
						}

						i++;
					}
				}
				else {
					i += this.groupedPresets[jobName].Count;
				}
			}

			ImGui.PopStyleVar();

			ImGui.EndChild();

			ImGui.End();
		}

		public void Dispose() {
			this.iconReplacer.Dispose();

			cmdManager.RemoveHandler(command);

			pluginInterface.Dispose();
		}

		private void onCommandDebugCombo(string command, string arguments) {
			string[] argumentsParts = arguments.Split();

			switch (argumentsParts[0]) {
				case "setall": {
					foreach (CustomComboPreset preset in Enum.GetValues(typeof(CustomComboPreset)).Cast<CustomComboPreset>())
						this.configuration.EnabledActions.Add(preset);

					chat.Print("All SET");
				}
				break;
				case "unsetall": {
					foreach (CustomComboPreset preset in Enum.GetValues(typeof(CustomComboPreset)).Cast<CustomComboPreset>())
						this.configuration.EnabledActions.Remove(preset);

					chat.Print("All UNSET");
				}
				break;
				case "set": {
					string targetPreset = argumentsParts[1].ToLower();
					foreach (CustomComboPreset preset in Enum.GetValues(typeof(CustomComboPreset)).Cast<CustomComboPreset>()) {
						if (preset.ToString().ToLower() != targetPreset)
							continue;

						this.configuration.EnabledActions.Add(preset);
						chat.Print($"{preset} SET");
					}
				}
				break;
				case "secrets":
					chat.Print("Secret combos have been removed in VX; all combos are always available.");
					break;
				case "toggle": {
					string targetPreset = argumentsParts[1].ToLower();
					foreach (CustomComboPreset preset in Enum.GetValues(typeof(CustomComboPreset)).Cast<CustomComboPreset>()) {
						if (preset.ToString().ToLower() != targetPreset)
							continue;

						if (this.configuration.EnabledActions.Contains(preset)) {
							this.configuration.EnabledActions.Remove(preset);
							chat.Print($"{preset} UNSET");
						}
						else {
							this.configuration.EnabledActions.Add(preset);
							chat.Print($"{preset} SET");
						}
					}
				}
				break;
				case "unset": {
					string targetPreset = argumentsParts[1].ToLower();
					foreach (CustomComboPreset preset in Enum.GetValues(typeof(CustomComboPreset)).Cast<CustomComboPreset>()) {
						if (preset.ToString().ToLower() != targetPreset)
							continue;

						this.configuration.EnabledActions.Remove(preset);
						chat.Print($"{preset} UNSET");
					}
				}
				break;
				case "list": {
					string filter = argumentsParts.Length == 1 ? "all" : argumentsParts[1].ToLower();

					foreach (CustomComboPreset preset in Enum.GetValues(typeof(CustomComboPreset)).Cast<CustomComboPreset>()) {
						if (filter == "set") {
							if (this.configuration.EnabledActions.Contains(preset))
								chat.Print(preset.ToString());
						}
						else if (filter == "unset") {
							if (!this.configuration.EnabledActions.Contains(preset))
								chat.Print(preset.ToString());
						}
						else if (filter == "all") {
							chat.Print(preset.ToString());
						}
					}
				}
				break;
				default:
					this.isImguiComboSetupOpen = true;
					break;
			}

			pluginInterface.SavePluginConfig(this.configuration);
		}
	}
}
