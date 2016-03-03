using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Many.ThirdParty
{
    /// <summary>
    /// some field
    /// </summary>
    public sealed partial class ExtendedSplash
    {
        internal Frame rootFrame;
    }

    /// <summary>
    /// entry and method
    /// </summary>
    public sealed partial class ExtendedSplash
    {
        public ExtendedSplash(bool loadState)
        {
            //TODO: load status before app suspend
            //if (loadState)
            //{

            //}
            InitializeComponent();

            // ScaleFactor = (double)DisplayInformation.GetForCurrentView().ResolutionScale;

            rootFrame = new Frame();
            rootFrame.NavigationFailed += OnNavigationFailed;
            rootFrame.Navigated += RootFrame_Navigated;

            Window.Current.Content = rootFrame;
            //TODO: something needed to do as app launch
            Do();

            if (rootFrame.Content == null)
            {
                rootFrame.Navigate(typeof(PreLoadPage));
            }
        }

        void Do()
        {

        }

        private void RootFrame_Navigated(object sender, NavigationEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                (Window.Current.Content as Frame).BackStack.Any() ?
                 AppViewBackButtonVisibility.Visible : AppViewBackButtonVisibility.Collapsed;
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }
    }
}
