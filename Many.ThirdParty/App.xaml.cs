using System;
using System.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Background;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Many.ThirdParty.Background;
using Many.ThirdParty.Config;
using System.Diagnostics;

namespace Many.ThirdParty
{
    sealed partial class App : Application
    {
        public App()
        {
            Microsoft.HockeyApp.HockeyClient.Current.Configure("2f514decca45422a84708df6ca4886a5");

            InitializeComponent();
            Suspending += OnSuspending;
        }

        private async Task RegisterBackgroundTask()
        {
            var task = await TaskConfiguration.RegisterBackgroundTask(
                typeof(LiveTileTask),
                "LiveTile",
                new TimeTrigger(60 * 12, false),
                new SystemCondition(SystemConditionType.InternetAvailable));

            task.Completed += Task_Completed;
        }

        private void Task_Completed(BackgroundTaskRegistration sender, BackgroundTaskCompletedEventArgs args)
        {
#if DEBUG
            Debug.WriteLine($"Task_Completed............................");
#endif 
        }

        protected override async void OnLaunched(LaunchActivatedEventArgs e)
        {
#if DEBUG
            if (DebugSettings != null) DebugSettings.EnableFrameRateCounter |= Debugger.IsAttached;
#endif
            Frame rootFrame = Window.Current.Content as Frame;

            if (rootFrame == null)
            {
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;
                rootFrame.Navigated += RootFrame_Navigated;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: 从之前挂起的应用程序加载状态
                }

                Window.Current.Content = rootFrame;

                await RegisterBackgroundTask();
            }

            if (rootFrame.Content == null)
            {
                rootFrame.Navigate(typeof(ExtendedSplash), e.Arguments);
            }

            Window.Current.Activate();
        }

        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }

        void RootFrame_Navigated(object sender, NavigationEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                (Window.Current.Content as Frame).BackStack.Any() ?
                AppViewBackButtonVisibility.Visible : AppViewBackButtonVisibility.Collapsed;
        }

        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception($"Failed to load Page { e.SourcePageType.FullName}|{e.Exception.Message }|");
        }
    }
}
