using Many.ThirdParty.Core.Commons;
using Many.ThirdParty.Core.Tools;
using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Many.ThirdParty.AddlPages
{
    public sealed partial class UserPage : Page
    {
        public ViewModelBase ViewModel { get; set; }

        public UserPage()
        {
            ViewModel = new ViewModelBase();

            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            StatusBarModifier.Clear();
            TopImage.SetValue(MarginProperty, new Thickness(0, -StatusBarModifier.StatusBarHeight, 0, 0));

            this.RequestedTheme = ViewModel.AppSettings.NightModeEnable ? ElementTheme.Dark : ElementTheme.Light;
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            ModifyStatusBar();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            DataPackage dataPackage = new DataPackage();

            dataPackage.SetText("208664459");
            Clipboard.SetContent(dataPackage);

            await new MessageDialog("已复制到剪贴板！").ShowAsync();
        }

        private void NightMode_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.RequestedTheme == ElementTheme.Dark || this.RequestedTheme == ElementTheme.Default)
            {
                this.RequestedTheme = ElementTheme.Light;
            }
            else
            {
                this.RequestedTheme = ElementTheme.Dark;
            }
            ViewModel.ChangeThemeMode(this.RequestedTheme);
            //ModifyStatusBar();
        }

        public void ModifyStatusBar()
        {
            switch (this.RequestedTheme)
            {
                case ElementTheme.Light:
                    StatusBarModifier.SetLightStatusBar();
                    return;
                case ElementTheme.Dark:
                    StatusBarModifier.SetDarkStatusBar();
                    return;
                default:
                    break;
            }
        }
    }
}
