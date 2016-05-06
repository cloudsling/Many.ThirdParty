using Many.ThirdParty.Core.Data;
using Many.ThirdParty.SubPages;
using System;
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
            HomePage.TodaysListId = await ResourcesLoader.GetHomeList(HomePage.CumulateListIndex.ToString());

            //TODO: load resource from internet
            Frame.Navigate(typeof(PreLoadPage), await ResourcesLoader.LoadHomeModelResourcesAsync(HomePage.TodaysListId[0]));
        }
    }

}
