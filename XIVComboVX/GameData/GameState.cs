using System;

using Dalamud.Game.NativeWrapper;

using FFXIVClientStructs.FFXIV.Component.GUI;

namespace VariableVixen.XIVComboVX.GameData;

internal unsafe class GameState: IDisposable {
	private bool disposed;

	private AtkUnitBasePtr chatLogPointer;

	internal AtkUnitBasePtr ChatLog {
		get {
			if (Service.Client.LocalPlayer is null)
				return null;
			if (this.chatLogPointer.IsNull)
				this.chatLogPointer = Service.GameGui.GetAddonByName("ChatLog", 1);
			return this.chatLogPointer;
		}
	}

	internal bool IsChatVisible => this.ChatLog.IsVisible;

	#region Registration and cleanup

	internal GameState() => Service.Client.Logout += this.clearCacheOnLogout;

	private void clearCacheOnLogout(int type, int code) => this.chatLogPointer = null;

	public void Dispose() {
		if (this.disposed)
			return;
		this.disposed = true;

		Service.Client.Logout -= this.clearCacheOnLogout;
		this.chatLogPointer = null;
	}

	#endregion

}
