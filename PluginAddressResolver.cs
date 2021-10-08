using System;

using Dalamud.Game;
using Dalamud.Logging;

namespace XIVComboVeryExpandedPlugin {
	internal class PluginAddressResolver: BaseAddressResolver {
		public IntPtr ComboTimer { get; private set; }
		public IntPtr LastComboMove => this.ComboTimer + 0x4;
		public IntPtr GetIcon { get; private set; }
		public IntPtr IsIconReplaceable { get; private set; }
		public IntPtr GetActionCooldown { get; private set; }

		protected override void Setup64Bit(SigScanner scanner) {
			this.ComboTimer = scanner.GetStaticAddressFromSig("48 89 2D ?? ?? ?? ?? 85 C0 74 0F");

			this.GetIcon = scanner.ScanText("E8 ?? ?? ?? ?? 8B F8 3B DF");  // Client::Game::ActionManager.GetAdjustedActionId

			this.IsIconReplaceable = scanner.ScanText("81 F9 ?? ?? ?? ?? 7F 39 81 F9 ?? ?? ?? ??");

			this.GetActionCooldown = scanner.ScanText("E8 ?? ?? ?? ?? 0F 57 FF 48 85 C0");

			PluginLog.Verbose("===== X I V C O M B O =====");
			PluginLog.Verbose($"GetIcon address   0x{this.GetIcon.ToInt64():X}");
			PluginLog.Verbose($"IsIconReplaceable 0x{this.IsIconReplaceable.ToInt64():X}");
			PluginLog.Verbose($"ComboTimer        0x{this.ComboTimer.ToInt64():X}");
			PluginLog.Verbose($"LastComboMove     0x{this.LastComboMove.ToInt64():X}");
			PluginLog.Verbose($"GetActionCooldown 0x{this.GetActionCooldown.ToInt64():X}");
		}
	}
}
