using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
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
            //Get cumulate length
            var cumulatedLength = e.Cumulative.Translation.Y;
            var frmElmt = sender as FrameworkElement;
            //Set new margin top
            frmElmt.SetValue(MarginProperty, new Thickness(0, frmElmt.Margin.Top + cumulatedLength / 2, 0, 0));
        }

        void Grid_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(OneMainPage));
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
            dynamicImageAnimation.Begin();

            if (e.Parameter != null)
            {
                //TODO: Binding to interface
            }
        }
    }
}
