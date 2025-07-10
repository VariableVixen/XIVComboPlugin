using System;
using System.Linq;

using VariableVixen.XIVComboVX;

namespace VariableVixen.XIVComboVX.Attributes;

[AttributeUsage(AttributeTargets.Field)]
internal class DeprecatedAttribute: Attribute {
	public const string Explanation = "Deprecated replacers are no longer being actively updated, and should be considered outdated. They may be removed in future versions.";

	public CustomComboPreset[] Recommended { get; }
	public string Information { get; }
	internal DeprecatedAttribute(string label, params CustomComboPreset[] suggestions) {
		this.Information = label;
		this.Recommended = suggestions.OrderBy(p => (uint)p).ToArray();
	}
	internal DeprecatedAttribute(params CustomComboPreset[] suggestions) : this(string.Empty, suggestions) { }
	internal DeprecatedAttribute(string label) : this(label, []) { }
}
