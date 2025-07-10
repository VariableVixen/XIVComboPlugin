using System;

namespace VariableVixen.XIVComboVX.Attributes;

[AttributeUsage(AttributeTargets.Property)]
internal class LucidWeavingSettingAttribute(CustomComboPreset combo): ComboDetailSettingAttribute(combo, LucidWeaveName, LucidWeaveDesc, LucidWeaveManaMin, LucidWeaveManaMax) {
	internal const int
		LucidWeaveManaMin = 1000,
		LucidWeaveManaMax = 8000;
	internal const string
		LucidWeaveName = "MP threshold",
		LucidWeaveDesc = "When your MP is below this limit, change this button into Lucid Dreaming while weaving\n(LD restores about one third of maximum MP, for reference)";
}
