using Many.ThirdParty.Config;
using Many.ThirdParty.Core.ViewModels.ReadingDetailPageViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Many.ThirdParty.SubPages.ReadingDetailPage
{
    public sealed partial class EssayDetailPage : Page
    {
        public EssayDetailPageViewModel ViewModel { get; set; }

        public EssayDetailPage()
        {
            this.InitializeComponent();
        }
        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel = e.Parameter as EssayDetailPageViewModel ?? new EssayDetailPageViewModel();

            this.RequestedTheme = ViewModel.AppSettings.NightModeEnable ? ElementTheme.Dark : ElementTheme.Light;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.GoBack(this.Frame);
        }
    }
}
