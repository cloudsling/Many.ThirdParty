using Many.ThirdParty.Core.Models.HomeModels;
using Many.ThirdParty.Core.ViewModels;
using System;
using System.Collections.Generic;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;
using Windows.UI.Xaml.Controls.Primitives;

namespace Many.ThirdParty.SubPages
{
    public sealed partial class HomePage : Page
    {
        public static int CumulateListIndex { get; set; } = 0;

        public static List<string> TodaysListId { get; set; }

        internal static HomeModel CurrentHomeModle;
        internal static HomePage CurrentHomePage;

        public HomePageViewModel ViewModel { get; set; }

        private void MainFlipView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void MainContent_Holding(object sender, Windows.UI.Xaml.Input.HoldingRoutedEventArgs e)
        {
            ShowFlyOut(sender as FrameworkElement);
        }

        private void MainContent_RightTapped(object sender, Windows.UI.Xaml.Input.RightTappedRoutedEventArgs e)
        {
            ShowFlyOut(sender as FrameworkElement);
        }

        void ShowFlyOut(FrameworkElement element)
        {
            if (element != null)
            {
                FlyoutBase.ShowAttachedFlyout(element);
            }
        }

        public delegate void EndOfMenuFlyoutCommand();

        void SavePicSuccessed()
        {
            MainFrameContainer.NotifyUser("成功保存到 Pictueres/一个 目录下");
        }

        private void CopyContent_Click(object sender, RoutedEventArgs e)
        {
            MainFrameContainer.NotifyUser("已复制到剪贴板");
        }

        private void SavePic_Click(object sender, RoutedEventArgs e)
        {
            HomeModel.EndOfMenuFlyoutCommand = SavePicSuccessed;
        }
    }

    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            ViewModel = new HomePageViewModel();
            this.InitializeComponent();
            CurrentHomePage = this;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                ViewModel.InsertHomeModel(e.Parameter as HomeModel);
            }
            else
            {
                ViewModel.AddHomeModel(CurrentHomeModle ?? new HomeModel());
            }
            await ViewModel.AddHomeModels(TodaysListId);
        }

        Dictionary<string, bool> isClickDic = new Dictionary<string, bool>();

        /// <summary>
        /// expired code
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Love_Click(object sender, RoutedEventArgs e)
        {
            if (isClickDic.ContainsKey(CurrentHomeModle.Hpcontent_Id))
            {
                int result;
                if (int.TryParse(CurrentHomeModle.PraiseNum, out result))
                {
                    CurrentHomeModle.PraiseNum = (result -= 1).ToString();
                    await new MessageDialog("取消喜欢!!").ShowAsync();
                }
                isClickDic.Remove(CurrentHomeModle.Hpcontent_Id);
                return;
            }

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("UserAgent", "android-async-http/2.0 (http://loopj.com/android-async-http)");
                client.DefaultRequestHeaders.Add("ContentType", "application/x-www-form-urlencoded");
                Dictionary<string, string> dic = new Dictionary<string, string>
                {
                    {"itemid", CurrentHomeModle.Hpcontent_Id},
                    {"type","hpcontent" },
                    {"deviceid","00000000-0565-4187-0033-c5870033c587" },
                    {"devicetype","android"}
                };
                var response = await client.PostAsync(new Uri("http://v3.wufazhuce.com:8000/api/praise/add"), new HttpFormUrlEncodedContent(dic));

                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    isClickDic.Add(CurrentHomeModle.Hpcontent_Id, true);
                    //Main.NotifyUserMethod("喜欢成功", 150);
                    int result;
                    if (int.TryParse(CurrentHomeModle.PraiseNum, out result))
                    {
                        CurrentHomeModle.PraiseNum = (result += 1).ToString();
#if DEBUG
                        await new MessageDialog("Success!").ShowAsync();
#endif
                    }
                }
            }
        }
    }
}
