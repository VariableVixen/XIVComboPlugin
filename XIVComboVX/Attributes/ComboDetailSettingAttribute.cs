using System;

using VariableVixen.XIVComboVX;

namespace VariableVixen.XIVComboVX.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
internal class ComboDetailSettingAttribute: Attribute {
	public CustomComboPreset Combo { get; }
	public double Min { get; } = float.MinValue;
	public double Max { get; } = float.MaxValue;
	public int Precision { get; } = 0;

	public string Label { get; }
	public string? Description { get; }

	public ComboDetailSettingAttribute(CustomComboPreset combo, string lbl, string? tooltip, double minimum, double maximum, int decimals) {
		this.Combo = combo;
		this.Label = lbl;
		this.Description = tooltip;
		if (decimals >= 0)
			this.Precision = decimals;
		if (!double.IsNaN(minimum) && double.IsFinite(minimum))
			this.Min = minimum;
		if (!double.IsNaN(maximum) && double.IsFinite(maximum))
			this.Max = maximum;
	}
	public ComboDetailSettingAttribute(CustomComboPreset combo, string lbl, string? tooltip, double minimum, double maximum) : this(combo, lbl, tooltip, minimum, maximum, 2) { }
	public ComboDetailSettingAttribute(CustomComboPreset combo, string lbl, string? tooltip) : this(combo, lbl, tooltip, double.NaN, double.NaN) { }
	public ComboDetailSettingAttribute(CustomComboPreset combo, string lbl) : this(combo, lbl, null) { }
}
