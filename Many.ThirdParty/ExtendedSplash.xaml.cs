using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    /// <summary>
    /// some field
    /// </summary>
    public sealed partial class ExtendedSplash
    {
        internal Rect splashImageRect;
        internal bool dismissed = false;
        internal Frame rootFrame;
        SplashScreen splash;
        double ScaleFactor;
    }

    public sealed partial class ExtendedSplash
    {
        public ExtendedSplash(SplashScreen splashscreen, bool loadState)
        {
            InitializeComponent();

            Window.Current.SizeChanged += Current_SizeChanged;
        }

        private void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
