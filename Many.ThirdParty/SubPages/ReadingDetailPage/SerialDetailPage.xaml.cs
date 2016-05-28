using Many.ThirdParty.Config;
using Many.ThirdParty.Core.ViewModels.ReadingDetailPageViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Many.ThirdParty.SubPages.ReadingDetailPage
{
    public sealed partial class SerialDetailPage : Page
    {
        public SerialDetailPageViewModel ViewModel { get; set; }

        public SerialDetailPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel = e.Parameter as SerialDetailPageViewModel ?? new SerialDetailPageViewModel();
            
            this.RequestedTheme = ViewModel.AppSettings.NightModeEnable ? ElementTheme.Dark : ElementTheme.Light;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.GoBack(this.Frame);
        }
    }
}
