using System;

using Dalamud.Plugin.Services;

namespace VariableVixen.XIVComboVX;

internal abstract class ManagedCache: IDisposable {
	#region IDisposable

	public bool Disposed { get; protected set; }
	public void Dispose() {
		this.Dispose(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing) {
		if (this.Disposed)
			return;
		this.Disposed = true;

		Service.Framework.Update -= this.InvalidateCache;
	}

	#endregion

	protected ManagedCache() => Service.Framework.Update += this.InvalidateCache;

	protected abstract void InvalidateCache(IFramework framework);
}
