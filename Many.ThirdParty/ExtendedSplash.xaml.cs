using Many.ThirdParty.Core.Data;
using Many.ThirdParty.Core.Tools;
using Many.ThirdParty.SubPages;
using System;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

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
            //TODO: Delay 2s in debug mode
#if DEBUG
            //await Task.Delay(1000);
#endif
            if (!await HttpHelper.CheckInternet())
            {
                await new MessageDialog("请连接互联网后重试！").ShowAsync();
                Windows.UI.Xaml.Application.Current.Exit();
            }
            HomePage.TodaysListId = await ResourcesLoader.GetHomeList(HomePage.CumulateListIndex.ToString());

            //TODO: load resource from internet
            Frame.Navigate(typeof(PreLoadPage), await ResourcesLoader.LoadHomeModelResourcesAsync(HomePage.TodaysListId[0]));
        }
    }

}
