using Many.ThirdParty.Core.Data;
using Many.ThirdParty.Core.Tools;
using Many.ThirdParty.SubPages;
using System;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Many.ThirdParty.Core.Commons;
using Windows.UI.Core;
using Windows.UI.Xaml.Media.Animation;
using Many.ThirdParty.Config;
using Many.ThirdParty.Core.Enum;
using Many.ThirdParty.Core.Models.HomeModels;

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
            if (!await HttpHelper.CheckInternet())
            {
                Progress.Text = "加载资源失败";
                await new MessageDialog("请连接互联网后重试！").ShowAsync();
                Windows.UI.Xaml.Application.Current.Exit();
            }

            HomePage.TodaysListId = await CommonDataLoader.GetGeneralList(HomePage.CumulateListIndex.ToString(), ListType.HomeList);
            HomePage.CumulateListIndex += 1;
            Progress.Text = "加载资源成功!正在初始化";

            Frame.ContentTransitions = new TransitionCollection {new NavigationThemeTransition()};

            NavigationManager.GeneralFrame = Frame;
            Frame.Navigate(
                ViewModelBase.CurrentSettings.SkipPreLoadPage ? typeof(MainFrameContainer) : typeof(PreLoadPage),
                HomePage.CurrentHomeModle = await CommonDataLoader.GetGeneralModelAsync<HomeModel>(HomePage.TodaysListId[0]), 
                new DrillInNavigationTransitionInfo());

            SystemNavigationManager.GetForCurrentView().BackRequested += PreLoadPage_BackRequested;
        }

        private void PreLoadPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.SourcePageType == typeof(MainFrameContainer)) return;

            if (Frame.CanGoBack)
            {
                Frame.GoBack();
                e.Handled = true;
            }
        }
    }
}
