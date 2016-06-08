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
            HomePage.TodaysListId = await CommonDataLoader.GetHomeList(HomePage.CumulateListIndex.ToString());
            HomePage.CumulateListIndex += 1;

            //TODO: load resource from internet
            Frame.Navigate(typeof(PreLoadPage), await CommonDataLoader.LoadHomeModelAsync(HomePage.TodaysListId[0]));
        }
    }
}
