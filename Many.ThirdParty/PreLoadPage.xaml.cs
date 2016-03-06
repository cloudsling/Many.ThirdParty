using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    /// auto enevt
    /// </summary>
    public sealed partial class PreLoadPage : Page
    {
        void Grid_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {

        }

        void Grid_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {

        }
    }

    /// <summary>
    /// entry and method
    /// </summary>
    public sealed partial class PreLoadPage : Page
    {
        public PreLoadPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            //this.Frame.Navigate(typeof(OneMainPage));
        }

    }
}
