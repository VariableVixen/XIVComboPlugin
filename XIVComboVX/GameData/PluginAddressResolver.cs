using System;
using System.Text;

using FFXIVClientStructs.FFXIV.Client.Game;

namespace PrincessRTFM.XIVComboVX.GameData;

internal class PluginAddressResolver {
	private const string AddrFmtSpec = "X16";

	public Exception? LoadFailReason { get; private set; }
	public bool LoadSuccessful => this.LoadFailReason is null;

	public IntPtr ComboTimer { get; private set; } = IntPtr.Zero;
	public string ComboTimerAddr => this.ComboTimer.ToInt64().ToString(AddrFmtSpec);

	public IntPtr LastComboMove => this.ComboTimer + 0x4;
	public string LastComboMoveAddr => this.LastComboMove.ToInt64().ToString(AddrFmtSpec);

	public IntPtr IsActionIdReplaceable { get; private set; } = IntPtr.Zero;
	public string IsActionIdReplaceableAddr => this.IsActionIdReplaceable.ToInt64().ToString(AddrFmtSpec);


	internal unsafe void Setup() {
		try {
			Service.Log.Information("Scanning for ComboTimer signature");
			this.ComboTimer = new IntPtr(&ActionManager.Instance()->Combo.Timer);

			Service.Log.Information("Scanning for IsActionIdReplaceable signature");
			this.IsActionIdReplaceable = Service.SigScanner.ScanText("40 53 48 83 EC 20 8B D9 48 8B 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 85 C0 74 1B");
		}
		catch (Exception ex) {
			this.LoadFailReason = ex;
			StringBuilder msg = new();
			msg.AppendLine("Address scanning failed, plugin cannot load.");
			msg.AppendLine("Please present this error message to the developer.");
			msg.AppendLine();
			msg.Append("Signature scan failed for ");
			if (this.ComboTimer == IntPtr.Zero)
				msg.Append("ComboTimer");
			else if (this.IsActionIdReplaceable == IntPtr.Zero)
				msg.Append("IsActionIdReplaceable");
			msg.AppendLine(":");
			msg.Append(ex.ToString());
			Service.Log.Fatal(msg.ToString());
			return;
		}

		Service.Log.Information("Address resolution successful");

		Service.Log.Information($"IsIconReplaceable   0x{this.IsActionIdReplaceableAddr}");
		Service.Log.Information($"ComboTimer          0x{this.ComboTimerAddr}");
		Service.Log.Information($"LastComboMove       0x{this.LastComboMoveAddr}");
	}
}
