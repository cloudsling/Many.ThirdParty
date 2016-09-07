using Many.ThirdParty.Config;
using Many.ThirdParty.Core.Models.HomeModels;
using Many.ThirdParty.SubPages;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace Many.ThirdParty
{
    public sealed partial class PreLoadPage
    {
        public HomeModel CurrentHomeModel { get; set; }

        public PreLoadPage()
        {
            InitializeComponent();
        }

        private void Grid_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            var fe = sender as FrameworkElement;
            fe?.SetValue(
                MarginProperty,
                new Thickness(0, fe.Margin.Top + e.Cumulative.Translation.Y / 2, 0, 0));
        }

        private async void Grid_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            await Task.Delay(10);

            NavigationManager.GeneralFrame = Frame;
            Frame.Navigate(typeof(MainFrameContainer), CurrentHomeModel);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DynamicImageAnimation.Begin();

            if (e.Parameter == null) return;
            //TODO: Binding to interface
            CurrentHomeModel = e.Parameter as HomeModel;

            HomePage.CurrentHomeModle = CurrentHomeModel;
        }
    }
}
