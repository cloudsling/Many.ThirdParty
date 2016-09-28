using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Many.ThirdParty.Config;
using Many.ThirdParty.Core.ViewModels;

namespace Many.ThirdParty.SubPages
{
    public sealed partial class MovieDetailPage : Page
    {
        public MovieDetailPageViewModel ViewModel { get; set; }

        public MovieDetailPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel = e.Parameter as MovieDetailPageViewModel ?? new MovieDetailPageViewModel();

            RequestedTheme = ViewModel.AppSettings.NightModeEnable ? ElementTheme.Dark : ElementTheme.Light;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.GoBack(Frame);
        }
    }
}
