using System.Collections.Generic;
using System.Diagnostics;

using Lumina.Excel;

using GameAction = Lumina.Excel.Sheets.Action;
using GameStatus = Lumina.Excel.Sheets.Status;

namespace VariableVixen.XIVComboVX.GameData;

internal static class Labels {
	private static readonly Dictionary<uint, string> actions = [];
	private static readonly Dictionary<uint, string> effects = [];

	internal static string Action(uint actionID) {
		if (actionID is 0)
			return "(no action)#0";
		if (!actions.TryGetValue(actionID, out string? label) || string.IsNullOrWhiteSpace(label))
			return $"(unknown action)#{actionID}";
		return $"(action {label})#{actionID}";
	}
	internal static string Status(uint statusID) {
		if (statusID is 0)
			return "(no status)#0";
		if (!effects.TryGetValue(statusID, out string? label) || string.IsNullOrWhiteSpace(label))
			return $"(unknown status)#{statusID}";
		return $"(status {label})#{statusID}";
	}

	internal static void Load() {
		Stopwatch timer = new();

		Service.Log.Info($"{LogTag.CoreSetup} Indexing player action names");
		timer.Restart();
		ExcelSheet<GameAction> actionSheet = Service.DataManager.GetExcelSheet<GameAction>();
		foreach (GameAction row in actionSheet) {
			actions[row.RowId] = row.Name.ExtractText();
		}
		timer.Stop();
		Service.Log.Info($"{LogTag.CoreSetup} Indexed {actions.Count} player actions in {timer.ElapsedMilliseconds}ms");

		Service.Log.Info($"{LogTag.CoreSetup} Indexing status effect names");
		timer.Restart();
		ExcelSheet<GameStatus> effectSheet = Service.DataManager.GetExcelSheet<GameStatus>();
		foreach (GameStatus row in effectSheet) {
			effects[row.RowId] = row.Name.ExtractText();
		}
		timer.Stop();
		Service.Log.Info($"{LogTag.CoreSetup} Indexed {effects.Count} status effects in {timer.ElapsedMilliseconds}ms");
	}
}
