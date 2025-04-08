using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

using Dalamud.Game.Text;
using Dalamud.Game.Text.SeStringHandling;
using Dalamud.Game.Text.SeStringHandling.Payloads;

namespace PrincessRTFM.XIVComboVX;

internal class ChatUtil: IDisposable {
	private bool disposed;

	private const uint
		OpenConfigId = 0,
		OpenIssueTrackerId = 1;

	internal readonly DalamudLinkPayload
		openConfig,
		openIssueTracker;

	internal const ushort
		ColourForeWarning = 32,
		ColourForeError = 17,
		ColourForeOpenConfig = 34,
		ColourGlowOpenConfig = 37;

	internal ChatUtil() {
		this.openConfig = Service.Interface.AddChatLinkHandler(OpenConfigId, this.onClickChatLink);
		this.openIssueTracker = Service.Interface.AddChatLinkHandler(OpenIssueTrackerId, this.onClickChatLink);
	}

	internal void AddOpenConfigLink(SeStringBuilder sb, string label) {
		sb.AddUiForeground(ColourForeOpenConfig);
		sb.AddUiGlow(ColourGlowOpenConfig);
		sb.Add(this.openConfig);
		sb.AddText(label);
		sb.Add(RawPayload.LinkTerminator);
		sb.AddUiGlowOff();
		sb.AddUiForegroundOff();
	}
	internal void AddOpenIssueTrackerLink(SeStringBuilder sb, string label) {
		sb.AddUiForeground(ColourForeOpenConfig);
		sb.AddUiGlow(ColourGlowOpenConfig);
		sb.Add(this.openIssueTracker);
		sb.AddText(label);
		sb.Add(RawPayload.LinkTerminator);
		sb.AddUiGlowOff();
		sb.AddUiForegroundOff();
	}

	[SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Convention")]
	internal void Print(XivChatType type, params Payload[] payloads) {
		if (payloads.Length > 0) {
			Service.ChatGui.Print(new XivChatEntry() {
				Type = type,
				Message = new SeString(payloads),
			});
		}
	}

	private void onClickChatLink(uint id, SeString source) {
		switch (id) {
			case OpenConfigId:
				Service.Plugin.OnPluginCommand("", "");
				break;
			case OpenIssueTrackerId:
				Process.Start(new ProcessStartInfo("https://github.com/VariableVixen/XIVComboPlugin/issues") { UseShellExecute = true });
				break;
			default:
				Service.ChatGui.Print(new XivChatEntry() {
					Type = XivChatType.SystemError,
					Message = new SeString(
						new TextPayload($"An internal error has occured: no handler is registered for id {id}.")
					),
				});
				break;
		}
	}

	#region Disposable

	public void Dispose() {
		if (this.disposed)
			return;
		this.disposed = true;

		Service.Interface.RemoveChatLinkHandler();
	}

	#endregion

}
