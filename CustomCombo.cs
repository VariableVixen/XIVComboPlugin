using System.Linq;

using Dalamud.Game.ClientState;
using Dalamud.Game.ClientState.Actors.Types;

using Structs = Dalamud.Game.ClientState.Structs;

namespace XIVComboVeryExpandedPlugin.Combos {
	internal abstract class CustomCombo {
		#region static 

		private static IconReplacer IconReplacer;
		protected static XIVComboVeryExpandedConfiguration Configuration;

		public static void Initialize(IconReplacer iconReplacer, XIVComboVeryExpandedConfiguration configuration) {
			IconReplacer = iconReplacer;
			Configuration = configuration;
		}

		#endregion

		protected abstract CustomComboPreset Preset { get; }

		protected byte JobID { get; set; }
		public byte ClassID => this.JobID switch {
			>= 19 and <= 25 => (byte)(this.JobID - 18),
			27 or 28 => 26,
			30 => 29,
			_ => this.JobID,
		};

		protected virtual uint[] ActionIDs { get; set; }

		protected CustomCombo() {
			CustomComboInfoAttribute presetInfo = this.Preset.GetInfo();
			this.JobID = presetInfo.JobID;
			this.ActionIDs = presetInfo.ActionIDs;
		}

		public bool TryInvoke(uint actionID, uint lastComboMove, float comboTime, byte level, out uint newActionID) {
			newActionID = 0;

			if (!IsEnabled(this.Preset))
				return false;

			if ((this.JobID != LocalPlayer.ClassJob.Id && this.ClassID != LocalPlayer.ClassJob.Id) || !this.ActionIDs.Contains(actionID))
				return false;

			uint resultingActionID = this.Invoke(actionID, lastComboMove, comboTime, level);
			if (resultingActionID == 0 || actionID == resultingActionID)
				return false;

			newActionID = resultingActionID;
			return true;
		}

		protected abstract uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level);

		#region Passthru

		protected static uint OriginalHook(uint actionID) => IconReplacer.OriginalHook(actionID);

		protected static PlayerCharacter LocalPlayer => IconReplacer.LocalPlayer;

		protected static Actor CurrentTarget => IconReplacer.CurrentTarget;

		protected static bool IsEnabled(CustomComboPreset preset) => Configuration.IsEnabled(preset);

		protected static bool HasCondition(ConditionFlag flag) => IconReplacer.HasCondition(flag);

		protected static bool HasEffect(short effectID) => IconReplacer.HasEffect(effectID);

		protected static bool TargetHasEffect(short effectID) => IconReplacer.TargetHasEffect(effectID);

		protected static Structs.StatusEffect? FindEffect(short effectId) => IconReplacer.FindEffect(effectId);

		protected static float EffectDuration(short effectId) => IconReplacer.EffectDuration(effectId);

		protected static float EffectStacks(short effectId) => IconReplacer.EffectStacks(effectId);

		protected static Structs.StatusEffect? FindTargetEffect(short effectId) => IconReplacer.FindTargetEffect(effectId);

		protected static float TargetEffectDuration(short effectId) => IconReplacer.TargetEffectDuration(effectId);

		protected static float TargetEffectStacks(short effectId) => IconReplacer.TargetEffectStacks(effectId);

		protected static CooldownData GetCooldown(uint actionID) => IconReplacer.GetCooldown(actionID);

		protected static T GetJobGauge<T>() => IconReplacer.GetJobGauge<T>();

		#endregion
	}
}