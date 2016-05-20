using Many.ThirdParty.Core.Commons;
using Many.ThirdParty.Core.ViewModels.AddlPageViewModels;
using System;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            DataPackage dataPackage = new DataPackage();

            dataPackage.SetText("208664459");
            Clipboard.SetContent(dataPackage);

            await new MessageDialog("已复制到剪贴板！").ShowAsync();
        }

        private void NightMode_ItemClick(object sender, ItemClickEventArgs e)
        {
            ViewModel.ChangeThemeMode();
        }
    }
}
