using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Background;
using Windows.Foundation;

namespace Many.ThirdParty.Background
{
    public sealed class LiveTileTask : IBackgroundTask
    {
        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            var deferral = taskInstance.GetDeferral();

            // TODO: TASK
            await GetLastHomeList();

            deferral.Complete();
        }

        private IAsyncOperation<string> GetLastHomeList()
        {
            try
            {
                return AsyncInfo.Run(token => Core.Tasks.LiveTileTask.RequestUpdate());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
