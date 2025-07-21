using System;
using System.Reflection;

using ImGuiNET;

using VariableVixen.XIVComboVX.Attributes;

namespace VariableVixen.XIVComboVX.Config;

internal class ComboDetailSetting {
	public PropertyInfo Property { get; }
	public CustomComboPreset Combo { get; }
	public Type Type { get; }
	public ImGuiDataType ImGuiType { get; }

	public int Precision { get; }
	public double Max { get; }
	public double Min { get; }
	public double Val {
		get => Convert.ToDouble(this.Property.GetValue(Service.Configuration) ?? default(double));
		set {
			if (double.IsNaN(value) || double.IsInfinity(value))
				return;
			if (value > this.Max)
				value = this.Max;
			if (value < this.Min)
				value = this.Min;
			// Apparently these can't be switch/case'd, because the `typeof(type)` expression isn't a constant
			if (this.Type == typeof(int))
				this.Property.SetValue(Service.Configuration, (int)value);
			else if (this.Type == typeof(uint))
				this.Property.SetValue(Service.Configuration, (uint)value);
			else if (this.Type == typeof(float))
				this.Property.SetValue(Service.Configuration, (float)value);
			else
				throw new ArgumentException($"Cannot assign value ({value.GetType().Name} {value}) to property ({this.Type.Name} {this.Property.Name})");
		}
	}

	public string Label { get; }
	public string? Description { get; }

	internal ComboDetailSetting(PropertyInfo prop, ComboDetailSettingAttribute attr) {
		this.Combo = attr.Combo;
		this.Label = attr.Label;
		this.Description = attr.Description;
		this.Property = prop;
		this.Type = prop.PropertyType;
		this.ImGuiType = this.Type == typeof(int)
			? ImGuiDataType.S64
			: this.Type == typeof(uint)
			? ImGuiDataType.U64
			: ImGuiDataType.Double;
		this.Precision = this.ImGuiType == ImGuiDataType.Float ? attr.Precision : 0;

		double typeMin = this.ImGuiType switch {
			ImGuiDataType.S64 => int.MinValue,
			ImGuiDataType.U64 => uint.MinValue,
			ImGuiDataType.Double => (double)float.MinValue,
			_ => 0,
		};
		double typeMax = this.ImGuiType switch {
			ImGuiDataType.S64 => int.MaxValue,
			ImGuiDataType.U64 => uint.MaxValue,
			ImGuiDataType.Double => (double)float.MaxValue,
			_ => 0,
		};
		if (attr.Min < typeMin) {
			Service.Log.Warning($"{LogTag.ConfigWindow} {this.Combo}:{this.Property.Name} has minimum value {attr.Min} below {this.Type.Name}.MinValue, bounding to {typeMin}");
			this.Min = typeMin;
		}
		else if (attr.Min > typeMax) {
			Service.Log.Warning($"{LogTag.ConfigWindow} {this.Combo}:{this.Property.Name} has minimum value {attr.Min} above {this.Type.Name}.MaxValue, bounding to {typeMax}");
			this.Min = typeMax;
		}
		else {
			this.Min = attr.Min;
		}
		if (attr.Max > typeMax) {
			Service.Log.Warning($"{LogTag.ConfigWindow} {this.Combo}:{this.Property.Name} has maximum value {attr.Max} above {this.Type.Name}.MaxValue, bounding to {typeMax}");
			this.Max = typeMax;
		}
		else if (attr.Max < typeMin) {
			Service.Log.Warning($"{LogTag.ConfigWindow} {this.Combo}:{this.Property.Name} has maximum value {attr.Max} below {this.Type.Name}.MinValue, bounding to {typeMin}");
			this.Max = typeMin;
		}
		else {
			this.Max = attr.Max;
		}
	}
}
