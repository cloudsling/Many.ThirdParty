using Many.ThirdParty.Config;
using Many.ThirdParty.Core.ViewModels.ReadingDetailPageViewModels;
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Many.ThirdParty.SubPages.ReadingDetailPage
{
    public sealed partial class QuestionDetailPage : Page
    {
        public QuestionDetailPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel = e.Parameter as QuestionDetailPageViewModel ?? new QuestionDetailPageViewModel(); 

            this.RequestedTheme = ViewModel.AppSettings.NightModeEnable ? ElementTheme.Dark : ElementTheme.Light;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.GoBack(this.Frame);
        }
    }

    public sealed partial class QuestionDetailPage : Page
    { 
        public QuestionDetailPageViewModel ViewModel { get; set; }
    }
}
