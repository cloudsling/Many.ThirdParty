using Many.ThirdParty.Core.Models.HomeModels;
using Many.ThirdParty.Core.ViewModels;
using Many.ThirdParty.SubPages;
using System;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace Many.ThirdParty
{
    public sealed partial class PreLoadPage : Page
    { 
        public HomeModel CurrentHomeModel { get; set; }

        public PreLoadPage()
        { 
            InitializeComponent();
        }

        void Grid_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            (sender as FrameworkElement).SetValue(
                MarginProperty,
                new Thickness(0, (sender as FrameworkElement).Margin.Top + e.Cumulative.Translation.Y / 2, 0, 0));
        }

        async void Grid_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            await Task.Delay(10);
            this.Frame.Navigate(typeof(MainFrameContainer), CurrentHomeModel);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DynamicImageAnimation.Begin();

            if (e.Parameter != null)
            {
                //TODO: Binding to interface
                CurrentHomeModel = e.Parameter as HomeModel;

                HomePage.CurrentHomeModle = CurrentHomeModel;
            }
        }
    }
}
