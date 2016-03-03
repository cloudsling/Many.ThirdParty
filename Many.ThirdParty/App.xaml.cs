using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Many.ThirdParty
{
    sealed partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }
        
        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
#if DEBUG
            this.DebugSettings.EnableFrameRateCounter |= System.Diagnostics.Debugger.IsAttached;
#endif
            if (args.PreviousExecutionState != ApplicationExecutionState.Running)
            {
                bool loadState = (args.PreviousExecutionState == ApplicationExecutionState.Terminated);
                var extendedSplash = new ExtendedSplash(loadState);
                Window.Current.Content = extendedSplash;
            }
            Window.Current.Activate();
        }
       
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}
