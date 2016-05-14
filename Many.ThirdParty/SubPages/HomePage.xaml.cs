using Many.ThirdParty.Core.Models.HomeModels;
using Many.ThirdParty.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;

namespace Many.ThirdParty.SubPages
{
    public sealed partial class HomePage : Page
    {
        public static int CumulateListIndex { get; set; } = 0;

        public static List<string> TodaysListId { get; set; }

        internal static HomeModel CurrentHomeModle;

        public HomePageViewModel HomePageViewModel { get; set; }
    }

    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            HomePageViewModel = new HomePageViewModel();
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            HomePageViewModel.AddHomeModel(CurrentHomeModle ?? new HomeModel());

            await LoadRemainingHomeModel();
        }

        private async Task LoadRemainingHomeModel()
        {
            for (int index = 1; index < TodaysListId.Count; index++)
            {
                await HomePageViewModel.AddHomeModel(TodaysListId[index]);
            }
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
