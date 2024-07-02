using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Dalamud.Game.Command;
using Dalamud.Game.Text;
using Dalamud.Game.Text.SeStringHandling;
using Dalamud.Game.Text.SeStringHandling.Payloads;
using Dalamud.Interface.Windowing;
using Dalamud.Plugin;
using Dalamud.Utility;

using PrincessRTFM.XIVComboVX.Attributes;
using PrincessRTFM.XIVComboVX.Config;

namespace PrincessRTFM.XIVComboVX;

public sealed class Plugin: IDalamudPlugin {
	public const string Name = "XIVComboVX";

	private bool disposed = false;

	private static readonly string[] nonConflictingPluginIds = [];
	private static readonly string[] conflictingPluginNameSubstrings = [
		"combo",
	];
	private static readonly string[] conflictingPluginIdSubstrings = [
		"combo",
	];

	internal const string CommandBase = "/pcombo";
	internal const string CommandCustom = CommandBase + "vx";

	private readonly WindowSystem? windowSystem;
	private readonly ConfigWindow? configWindow;

	public static readonly Version Version = Assembly.GetExecutingAssembly().GetName().Version!;
	public const bool Debug =
#if DEBUG
		true;
#else
		false;
#endif

#pragma warning disable CA1822 // Mark members as static (some of these shouldn't be used until the plugin is initialised)
	public string PluginBuildType { get; } = $"{(Debug ? "debug" : "release")} build";
	public string PluginInstallType => $"{(Service.Interface.IsDev ? "dev" : "standard")} install";
	public string ShortPluginSignature => $"{Plugin.Name} v{Version}";
	public string FullPluginSignature => $"{this.ShortPluginSignature} ({this.PluginBuildType}, {this.PluginInstallType})";
#pragma warning restore CA1822 // Mark members as static

	public static bool AcquiredBaseCommand { get; private set; } = false;

	public Plugin(IDalamudPluginInterface pluginInterface) {

		pluginInterface.Create<Service>();

		Service.Plugin = this;
		Service.TickLogger = new();
		Service.Configuration = pluginInterface.GetPluginConfig() as PluginConfiguration ?? new(true);
		Service.Address = new();

		Service.Configuration.Active = true;
		Service.Configuration.UpgradeIfNeeded();

		Service.Address.Setup();

		if (Service.Address.LoadSuccessful) {
			Service.DataCache = new();
			Service.IconReplacer = new();
			Service.GameState = new();
			Service.ChatUtils = new();

			this.configWindow = new();
			this.windowSystem = new(this.GetType().Namespace!);
			this.windowSystem.AddWindow(this.configWindow);

			Service.Interface.UiBuilder.OpenConfigUi += this.ToggleConfigUi;
			Service.Interface.UiBuilder.Draw += this.windowSystem.Draw;
		}
		else {
			Service.Commands.ProcessCommand("/xllog");
		}

		CommandInfo handler = new(this.OnPluginCommand) {
			HelpMessage = Service.Address.LoadSuccessful ? "Open a window to edit custom combo settings." : "Do nothing, because the plugin failed to initialise.",
			ShowInHelp = true
		};

		Service.Commands.AddHandler(CommandCustom, handler);
		if (Service.Configuration.RegisterCommonCommand)
			AcquiredBaseCommand = Service.Commands.AddHandler(CommandBase, handler);

		Service.Ipc = new();

		Service.Ipc.AddTips(
			$"{Name} - better than a broken leg!", // I will not be serious and you cannot make me.
			$"It looks like {Name} is installed. Do you hate pressing buttons?",
			$"I see you're using {Name}. Have you tried being good at the game instead?"
		);

		Service.Log.Information($"{this.FullPluginSignature} initialised {(Service.Address.LoadSuccessful ? "" : "un")}successfully");
		if (Service.Configuration.IsFirstRun || !Service.Configuration.LastVersion.Equals(Version)) {
			Service.UpdateAlert = new(Version, Service.Configuration.IsFirstRun);

			Service.Configuration.LastVersion = Version;
			Service.Configuration.Save();
		}

		int deprecated = 0;
		foreach (CustomComboPreset active in Service.Configuration.EnabledActions) {
			if (active.GetAttribute<DeprecatedAttribute>() is not null)
				++deprecated;
		}
		if (deprecated > 0) {
			SeStringBuilder msg = new();

			Service.ChatUtils.AddOpenConfigLink(msg, $"[{Name}] ");
			msg.AddText("You currently have ");
			msg.AddUiForeground(ChatUtil.ColourForeWarning);
			msg.AddText($"{deprecated} deprecated combo{(deprecated == 1 ? "" : "s")}");
			msg.AddUiForegroundOff();
			msg.AddText(" enabled. It is recommended to ");
			Service.ChatUtils.AddOpenConfigLink(msg, "open the settings");
			msg.AddText($" and replace {(deprecated == 1 ? "it" : "them")} with the recommended alternatives.");

			Service.ChatGui.Print(new XivChatEntry() {
				Type = XivChatType.ErrorMessage,
				Message = msg.Build(),
			});
		}

		CheckForOtherComboPlugins();
		Service.Interface.ActivePluginsChanged += this.onActivePluginsChanged;
	}

	private void onActivePluginsChanged(PluginListInvalidationKind kind, bool affectedThisPlugin) => CheckForOtherComboPlugins();

	public static int CheckForOtherComboPlugins() {
		string[] otherComboPlugins = Service.Interface.InstalledPlugins
			// ignore unloaded plugins, they have no effect
			.Where(p => p.IsLoaded)
			// ignore us, we don't conflict with ourselves
			.Where(p => p.InternalName != Service.Interface.InternalName)
			// any false positives reported go in here to be ignored
			.Where(p => !nonConflictingPluginIds.Any(s => p.InternalName == s))
			// check the internal and display names for any (case-insensitive) substrings that look like problems
			.Where(p => conflictingPluginIdSubstrings.Any(s => p.InternalName.Contains(s, StringComparison.OrdinalIgnoreCase)))
			.Where(p => conflictingPluginNameSubstrings.Any(s => p.Name.Contains(s, StringComparison.OrdinalIgnoreCase)))
			// the list is used for user-facing display, so we only need the display name
			.Select(p => p.Name)
			.ToArray();

		if (otherComboPlugins.Length > 0) {
			// it is a Bad Idea to run more than one combo fork at the same time, but that's never stopped users before
			otherComboPluginsDetected(otherComboPlugins);
		}

		return otherComboPlugins.Length;
	}

	private static void otherComboPluginsDetected(params string[] otherComboPluginNames) {
		Service.Configuration.Active = false;
		Service.Configuration.RegisterCommonCommand = false;
		if (AcquiredBaseCommand)
			Service.Commands.RemoveHandler(CommandBase);
		AcquiredBaseCommand = false;
		Service.Configuration.Save();

		SeStringBuilder msg = new();
		string s = otherComboPluginNames.Length == 1 ? string.Empty : "s";

		msg.AddText("You appear to have installed ");
		msg.AddUiForeground(ChatUtil.ColourForeWarning);
		msg.AddText($"{otherComboPluginNames.Length} other combo plugin{s}");
		msg.AddUiForegroundOff();
		msg.AddText($" as well as {Service.Interface.InternalName}. This is generally considered a ");
		msg.AddUiForeground(ChatUtil.ColourForeError);
		msg.AddText("Very Bad Idea.");
		msg.AddUiForegroundOff();
		msg.AddText(" Running more than one combo plugin is known to cause problems with your game as they fight each other for control.");
		msg.AddText($"\nFor your safety, {Service.Interface.InternalName} has ");
		msg.AddUiForeground(ChatUtil.ColourForeWarning);
		msg.AddText("automatically disabled itself");
		msg.AddUiForegroundOff();
		msg.AddText(" and only registered its custom ");
		Service.ChatUtils.AddOpenConfigLink(msg, CommandCustom);
		msg.AddText($" command to allow the other combo plugin{s} to use ");
		msg.AddUiForeground(ChatUtil.ColourForeWarning);
		msg.AddText(CommandBase);
		msg.AddUiForegroundOff();
		msg.AddText(" instead.");
		msg.AddText("\nIf you are ");
		msg.AddItalics("determined");
		msg.AddText(" to use multiple combo plugins at once, ");
		msg.AddUiForeground(ChatUtil.ColourForeError);
		msg.AddText("no support will be provided");
		msg.AddUiForegroundOff();
		msg.AddText(" but you can ");
		Service.ChatUtils.AddOpenConfigLink(msg, $"open {Service.Interface.InternalName}'s settings");
		msg.AddText(" and re-enable it from the menu bar.");
		msg.AddText("\nHowever, you are ");
		msg.AddItalics("very strongly");
		msg.AddText(" recommended to disable the all except one of your ");
		msg.AddUiForeground(ChatUtil.ColourForeError);
		msg.AddText($"{otherComboPluginNames.Length + 1}");
		msg.AddUiForegroundOff();
		msg.AddText(" combo plugins: ");
		msg.AddUiForeground(ChatUtil.ColourForeWarning);
		msg.AddText(Service.Interface.InternalName);
		msg.AddUiForegroundOff();
		foreach (string other in otherComboPluginNames) {
			msg.AddText(", ");
			msg.AddUiForeground(ChatUtil.ColourForeWarning);
			msg.AddText(other);
			msg.AddUiForegroundOff();
		}
		msg.AddText("\nIf this is a false positive, please open a report on the ");
		Service.ChatUtils.AddOpenIssueTrackerLink(msg, "issue tracker");
		msg.AddText(" with the plugin name.");

		Service.ChatGui.Print(new XivChatEntry() {
			Type = XivChatType.ErrorMessage,
			Message = msg.Build(),
		});
	}

	#region Disposable

	public void Dispose() {
		this.dispose(true);
		GC.SuppressFinalize(this);
	}

	private void dispose(bool disposing) {
		if (this.disposed)
			return;
		this.disposed = true;

		if (disposing) {
			Service.Commands.RemoveHandler(CommandCustom);
			if (AcquiredBaseCommand)
				Service.Commands.RemoveHandler(CommandBase);

			Service.Interface.UiBuilder.OpenConfigUi -= this.ToggleConfigUi;
			if (this.windowSystem is not null)
				Service.Interface.UiBuilder.Draw -= this.windowSystem.Draw;

			Service.IconReplacer?.Dispose();
			Service.DataCache?.Dispose();
			Service.UpdateAlert?.Dispose();
			Service.ChatUtils?.Dispose();
			Service.GameState?.Dispose();
			Service.Ipc?.Dispose();
			Service.TickLogger?.Dispose();
		}
	}

	#endregion

	internal void ToggleConfigUi() {
		if (this.configWindow is not null) {
			this.configWindow.IsOpen = !this.configWindow.IsOpen;
		}
		else {
			Service.Log.Error("Cannot toggle configuration window, reference does not exist");
		}
	}

	internal void OnPluginCommand(string command, string arguments) {
		if (!Service.Address.LoadSuccessful) {
			Service.ChatGui.PrintError($"The plugin failed to initialise and cannot run:\n{Service.Address.LoadFailReason!.Message}");
			return;
		}

		string[] argumentsParts = arguments.Split();

		switch (argumentsParts[0].ToLower()) {
#if DEBUG
			case "test-conflict":
				otherComboPluginsDetected("FakeXivCombo", "ConflictMessageTest");
				break;
#endif
			case "enable": {
					Service.Configuration.Active = true;
					Service.ChatUtils.Print(XivChatType.Notice,
						new UIForegroundPayload(35),
						new TextPayload(Plugin.Name),
						new UIForegroundPayload(1),
						new TextPayload(" "),
						new UIGlowPayload(43),
						new TextPayload("enabled"),
						new UIGlowPayload(0),
						new UIForegroundPayload(0)
					);
				}
				break;
			case "disable": {
					Service.Configuration.Active = false;
					Service.ChatUtils.Print(XivChatType.Notice,
						new UIForegroundPayload(35),
						new TextPayload(Plugin.Name),
						new UIForegroundPayload(1),
						new TextPayload(" "),
						new UIGlowPayload(17),
						new TextPayload("disabled"),
						new UIGlowPayload(0),
						new UIForegroundPayload(0)
					);
				}
				break;
			case "toggle": {
					bool on = !Service.Configuration.Active;
					Service.Configuration.Active = on;
					Service.ChatUtils.Print(XivChatType.Notice,
						new UIForegroundPayload(35),
						new TextPayload(Plugin.Name),
						new UIForegroundPayload(1),
						new TextPayload(" "),
						new UIGlowPayload((ushort)(on ? 43 : 17)),
						new TextPayload($"{(on ? "en" : "dis")}abled"),
						new UIGlowPayload(0),
						new UIForegroundPayload(0)
					);
				}
				break;
			case "debug": {
					Service.TickLogger.EnableNextTick();
					Service.ChatGui.Print("Enabled debug message snapshot");
				}
				break;
			case "version": {
					Service.ChatGui.Print($"You are running {this.FullPluginSignature}");
				}
				break;
			case "reset": {
					PluginConfiguration config = new(false) {
						LastVersion = Plugin.Version
					};
					Service.Configuration = config;
					config.Save();
					List<Payload> parts = new([
						new TextPayload("Your "),
						new UIForegroundPayload(35),
						new TextPayload(Plugin.Name),
						new UIForegroundPayload(0),
						new TextPayload("configuration has been reset to the defaults.")
					]);
					if (this.configWindow is not null && !this.configWindow.IsOpen) {
						parts.AddRange([
							new TextPayload("\nYou will need to "),
							new UIForegroundPayload(ChatUtil.ColourForeOpenConfig),
							new UIGlowPayload(ChatUtil.ColourGlowOpenConfig),
							Service.ChatUtils.openConfig,
							new TextPayload($"[open the settings]"),
							RawPayload.LinkTerminator,
							new UIGlowPayload(0),
							new UIForegroundPayload(0),
							new TextPayload(" to enable your desired features.")
						]);
					}
					Service.ChatUtils.Print(XivChatType.Notice, parts.ToArray());
				}
				break;
			case "showupdate": {
					Service.UpdateAlert?.DisplayMessage();
				}
				break;
			default:
				this.ToggleConfigUi();
				break;
		}

		Service.Interface.SavePluginConfig(Service.Configuration);
	}

}
