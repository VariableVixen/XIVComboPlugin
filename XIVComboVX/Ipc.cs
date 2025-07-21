using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Dalamud.Plugin.Ipc;
using Dalamud.Plugin.Ipc.Exceptions;

namespace VariableVixen.XIVComboVX;

internal class Ipc: IDisposable {
	private const int LoopDelaySec = 300;
	private const int InitialDelaySec = 5;

	private const string TippyPluginId = "Tippy";
	private const string TippyRegisterTipId = "Tippy.RegisterTip";
	private const string TippyRegisterMessageId = "Tippy.RegisterMessage";

	private readonly CancellationTokenSource stop = new();
	private readonly Task registrationWorker;
	private bool disposed;

	internal static bool TippyLoaded => Service.Interface.InstalledPlugins.Where(state => state.InternalName == TippyPluginId).Any();

	private readonly ICallGateSubscriber<string, bool> tippyRegisterTip;
	private readonly ICallGateSubscriber<string, bool> tippyRegisterMessage;

	private readonly ConcurrentQueue<string> tippyRegistrationQueue = new();

	internal Ipc() {
		this.tippyRegisterTip = Service.Interface.GetIpcSubscriber<string, bool>(TippyRegisterTipId);
		this.tippyRegisterMessage = Service.Interface.GetIpcSubscriber<string, bool>(TippyRegisterMessageId);
		this.registrationWorker = Task.Run(this.registrationLoop, this.stop.Token);
	}

	private async void registrationLoop() {
		await Task.Delay(InitialDelaySec * 1000, this.stop.Token);
		while (!this.stop.IsCancellationRequested) {
			try { // catches cancellation so the task shows as completed, once it's actually gotten started

				if (TippyLoaded) {
					if (!this.tippyRegistrationQueue.IsEmpty) {
						string tippyTip = null!;
						try {
							while (this.tippyRegistrationQueue.TryDequeue(out tippyTip!)) {
								if (!string.IsNullOrWhiteSpace(tippyTip))
									this.tippyRegisterTip.InvokeFunc(tippyTip); // ignore the return value cause if Tippy just says "no" then what are WE gonna do about it?
							}
						}
						catch (IpcNotReadyError) {
							// We already got the value out of the queue, but registering it failed, so put it back in
							this.AddTips(tippyTip);
						}
						catch (IpcError ex) {
							Service.Log.Error("Failed to register tip for Tippy's pool", ex);
							this.tippyRegistrationQueue.Clear();
						}
					}
				}

				// Only try to do things every so often
				await Task.Delay(LoopDelaySec * 1000, this.stop.Token);
			}
			catch (TaskCanceledException) { // if cancellation is requested once we get started, it's considered completion cause this is infinite
				return;
			}
		}
	}

	#region Tippy API
	internal void AddTips(params string[] tips) {
		if (this.disposed)
			return;

		foreach (string tip in tips) {
			if (!string.IsNullOrWhiteSpace(tip))
				this.tippyRegistrationQueue.Enqueue(tip);
		}
	}

	internal bool ShowTippyMessage(string message) {
		if (this.disposed)
			return false;

		try {
			return this.tippyRegisterMessage.InvokeFunc(message);
		}
		catch (IpcNotReadyError) {
			return false;
		}
		catch (IpcError ex) {
			Service.Log.Error("Failed to register priority message for Tippy", ex);
			return false;
		}
	}
	#endregion

	#region Disposable
	protected virtual void Dispose(bool disposing) {
		if (this.disposed)
			return;
		this.disposed = true;

		if (disposing) {
			this.stop.Cancel();
			this.registrationWorker.Wait();
			this.registrationWorker.Dispose();
			this.stop.Dispose();
			this.tippyRegistrationQueue.Clear();
		}

	}

	public void Dispose() {
		this.Dispose(true);
		GC.SuppressFinalize(this);
	}
	#endregion

}
