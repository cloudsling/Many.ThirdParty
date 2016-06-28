using Many.ThirdParty.Core.Data;
using Many.ThirdParty.Core.Tools;
using Many.ThirdParty.SubPages;
using System;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Many.ThirdParty.Core.Commons;
using Windows.UI.Core;
using Many.ThirdParty.Config;

namespace Many.ThirdParty
{
    public sealed partial class ExtendedSplash : Page
    {
        public ExtendedSplash()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
#if DEBUG
            //await Task.Delay(1000);
#endif
            if (!await HttpHelper.CheckInternet())
            {
                Progress.Text = "加载资源失败";
                await new MessageDialog("请连接互联网后重试！").ShowAsync();
                Windows.UI.Xaml.Application.Current.Exit();
            }
            HomePage.TodaysListId = await CommonDataLoader.GetHomeList(HomePage.CumulateListIndex.ToString());
            HomePage.CumulateListIndex += 1;
            Progress.Text = "加载资源成功!正在初始化";

            NavigationManager.GeneralFrame = this.Frame;
            Frame.Navigate(
                ViewModelBase.CurrentSettings.SkipPreLoadPage ? typeof(MainFrameContainer) : typeof(PreLoadPage),
                HomePage.CurrentHomeModle = await CommonDataLoader.LoadHomeModelAsync(HomePage.TodaysListId[0]));

            SystemNavigationManager.GetForCurrentView().BackRequested += PreLoadPage_BackRequested;
        }

        private void PreLoadPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (this.Frame.SourcePageType == typeof(MainFrameContainer)) return;

            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
                e.Handled = true;
            }
        }
    }
}
