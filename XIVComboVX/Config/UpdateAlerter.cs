using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Dalamud.Game.Text;
using Dalamud.Game.Text.SeStringHandling;
using Dalamud.Game.Text.SeStringHandling.Payloads;

namespace PrincessRTFM.XIVComboVX.Config;

internal class UpdateAlerter: IDisposable {
	private const int
		MessageDelayMs = 500,
		LoginDelayMs = 500;

	private bool disposed;

	private bool seenUpdateMessage = false;
	private readonly bool isFreshInstall = false;
	private readonly Version current;

	private CancellationTokenSource? realAborter;
	private CancellationTokenSource? aborter {
		get {
			lock (this) {
				return this.realAborter;
			}
		}
		set {
			lock (this) {
				this.realAborter?.Cancel();
				this.realAborter = value;
			}
		}
	}

	internal UpdateAlerter(Version to, bool isFresh) {
		this.current = to;
		this.isFreshInstall = isFresh;
		if (Service.Configuration.ShowUpdateMessage) {
			this.Register();
			this.CheckMessage();
		}
	}

	internal void CheckMessage() {
		Service.Log.Information("Checking whether to display update message");
		if (this.disposed) {
			this.Unregister();
			Service.Log.Information("Update alerter already disposed");
			return;
		}
		if (this.seenUpdateMessage) {
			this.Unregister();
			Service.Log.Information("Message already displayed, unregistering");
			return;
		}

		Service.Log.Information($"Checks passed, delaying message by {MessageDelayMs}ms - may be reset if message is triggered again within that time");

		this.aborter = new();

		Task.Delay(MessageDelayMs, this.aborter.Token).ContinueWith(waiter => {
			if (waiter.Status is TaskStatus.RanToCompletion)
				this.DisplayMessage();
		});
	}

	internal void DisplayMessage() {

		this.aborter?.Cancel();
		this.seenUpdateMessage = true;
		this.Unregister();

		Service.Log.Information("Displaying update alert in game chat");

		List<Payload> parts = [];
		if (!(Plugin.Debug && Service.Interface.IsDev)) {
			parts.Add(new TextPayload(
				this.isFreshInstall
					? $"{Service.Plugin.ShortPluginSignature} has been installed. By default, all features are disabled.\n"
					: $"{Plugin.Name} has been updated to {this.current}. Features may have been added or changed.\n"
			));
		}
		parts.AddRange([
			new UIForegroundPayload(ChatUtil.ColourForeOpenConfig),
			new UIGlowPayload(ChatUtil.ColourGlowOpenConfig),
			Service.ChatUtils.openConfig,
			new TextPayload($"[Open {Plugin.Name} Settings]"),
			RawPayload.LinkTerminator,
			new UIGlowPayload(0),
			new UIForegroundPayload(0),
		]);

		Service.ChatUtils.Print(XivChatType.Notice, parts.ToArray());

	}

	internal void Register() {
		Service.Log.Information("Registering update alerter");
		Service.ChatGui.ChatMessage += this.onChatMessage;
		Service.Client.Login += this.onLogin;
	}

	internal void Unregister() {
		Service.Log.Information("Unregistering update alerter");
		Service.ChatGui.ChatMessage -= this.onChatMessage;
		Service.Client.Login -= this.onLogin;
	}

	private void onChatMessage(XivChatType type, int timestamp, ref SeString sender, ref SeString message, ref bool isHandled) {
		if (type is XivChatType.Urgent or XivChatType.Notice or XivChatType.SystemMessage)
			this.CheckMessage();
	}
	private async void onLogin() {
		do {
			await Task.Delay(LoginDelayMs);
		} while (!Service.Client.IsLoggedIn || Service.Client.LocalContentId == 0 || Service.Client.LocalPlayer is null);
		this.CheckMessage();
	}


	#region Disposing

	public void Dispose() {
		if (this.disposed)
			return;
		this.disposed = true;

		this.Unregister();
	}

	#endregion

}
