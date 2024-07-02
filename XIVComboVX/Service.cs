using Dalamud.Game;
using Dalamud.Game.ClientState.Objects;
using Dalamud.IoC;
using Dalamud.Plugin;
using Dalamud.Plugin.Services;

using PrincessRTFM.XIVComboVX.Config;
using PrincessRTFM.XIVComboVX.GameData;

namespace PrincessRTFM.XIVComboVX;

internal class Service {
	public static Plugin Plugin { get; set; } = null!;

	public static PluginConfiguration Configuration { get; set; } = null!;

	public static IconReplacer IconReplacer { get; set; } = null!;

	public static PluginAddressResolver Address { get; set; } = null!;

	public static ComboDataCache DataCache { get; set; } = null!;

	public static LogUtil TickLogger { get; set; } = null!;

	public static GameState GameState { get; set; } = null!;

	public static UpdateAlerter? UpdateAlert { get; set; } = null;

	public static ChatUtil ChatUtils { get; set; } = null!;

	public static Ipc Ipc { get; set; } = null!;

	[PluginService] public static IPluginLog Log { get; private set; } = null!;
	[PluginService] public static IDalamudPluginInterface Interface { get; private set; } = null!;
	[PluginService] public static ISigScanner SigScanner { get; private set; } = null!;
	[PluginService] public static IBuddyList BuddyList { get; private set; } = null!;
	[PluginService] public static IChatGui ChatGui { get; private set; } = null!;
	[PluginService] public static IClientState Client { get; private set; } = null!;
	[PluginService] public static ICommandManager Commands { get; private set; } = null!;
	[PluginService] public static ICondition Conditions { get; private set; } = null!;
	[PluginService] public static IDataManager GameData { get; private set; } = null!;
	[PluginService] public static IFramework Framework { get; private set; } = null!;
	[PluginService] public static IJobGauges JobGauge { get; private set; } = null!;
	[PluginService] public static ITargetManager Targets { get; private set; } = null!;
	[PluginService] public static IGameGui GameGui { get; private set; } = null!;
	[PluginService] public static IGameInteropProvider Interop { get; private set; } = null!;
	[PluginService] public static INotificationManager Notifications { get; private set; } = null!;

}
