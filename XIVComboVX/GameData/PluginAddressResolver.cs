using System;
using System.Text;

using FFXIVClientStructs.FFXIV.Client.Game;

using VariableVixen.XIVComboVX;

namespace VariableVixen.XIVComboVX.GameData;

internal class PluginAddressResolver {
	private const string AddrFmtSpec = "X16";

	public Exception? LoadFailReason { get; private set; }
	public bool LoadSuccessful => this.LoadFailReason is null;

	public nint ComboTimer { get; private set; } = nint.Zero;
	public string ComboTimerAddr => this.ComboTimer.ToInt64().ToString(AddrFmtSpec);

	public nint LastComboMove => this.ComboTimer + 0x4;
	public string LastComboMoveAddr => this.LastComboMove.ToInt64().ToString(AddrFmtSpec);

	public nint IsActionIdReplaceable { get; private set; } = nint.Zero;
	public string IsActionIdReplaceableAddr => this.IsActionIdReplaceable.ToInt64().ToString(AddrFmtSpec);


	internal unsafe void Setup() {
		try {
			Service.Log.Information($"{LogTag.SignatureScan} Scanning for ComboTimer signature");
			this.ComboTimer = new nint(&ActionManager.Instance()->Combo.Timer);

			Service.Log.Information($"{LogTag.SignatureScan} Scanning for IsActionIdReplaceable signature");
			this.IsActionIdReplaceable = Service.SigScanner.ScanText("40 53 48 83 EC 20 8B D9 48 8B 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 85 C0 74 1F");
		}
		catch (Exception ex) {
			this.LoadFailReason = ex;
			StringBuilder msg = new($"{LogTag.SignatureScan} ");
			msg.AppendLine("Address scanning failed, plugin cannot load.");
			msg.AppendLine("Please present this error message to the developer.");
			msg.AppendLine();
			msg.Append("Signature scan failed for ");
			if (this.ComboTimer == nint.Zero)
				msg.Append("ComboTimer");
			else if (this.IsActionIdReplaceable == nint.Zero)
				msg.Append("IsActionIdReplaceable");
			msg.AppendLine(":");
			msg.Append(ex.ToString());
			Service.Log.Fatal(msg.ToString());
			return;
		}

		Service.Log.Information($"{LogTag.SignatureScan} Address resolution successful");

		Service.Log.Information($"{LogTag.SignatureScan} IsIconReplaceable   0x{this.IsActionIdReplaceableAddr}");
		Service.Log.Information($"{LogTag.SignatureScan} ComboTimer          0x{this.ComboTimerAddr}");
		Service.Log.Information($"{LogTag.SignatureScan} LastComboMove       0x{this.LastComboMoveAddr}");
	}
}
