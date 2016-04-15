using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class MusicPage : Page
    {
        private static readonly string musicId = "http://v3.wufazhuce.com:8000/api/music/idlist/0?";
        private static readonly string musicUri = "http://m.wufazhuce.com/music/";
        HttpClient client;
        static MusicPage MusicCurrent;
        int CurrentCount = 0;
    }

    public sealed partial class MusicPage : Page
    {
        public MusicPage()
        {
            this.InitializeComponent();
            MusicCurrent = this;
            NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter == null)
            {
                if (CurrentCount == 0)
                {
                    await Do();
                }
            }
            else
            {
                //var music = e.Parameter as MusicModel;
                // musicWebView.Navigate(new Uri(musicUri + music.Id.ToString()));
            }
            CurrentCount += 1;
        }

        private async Task Do()
        {
            string uri = await GetMusicUri();
            musicWebView.Navigate(new Uri(uri));
            bar.IsIndeterminate = false;
            ring.IsActive = false;
        }

        async Task<string> GetMusicUri()
        {
            using (client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("UserAgent", "android-async-http/2.0 (http://loopj.com/android-async-http)");
                string response = await client.GetStringAsync(new Uri(musicId));
                JsonObject json;
                if (JsonObject.TryParse(response, out json))
                {
                    JsonArray array = json.GetNamedArray("data");
                    return $"{musicUri}{ array[0].GetString()}";
                }
                return $"{musicUri}0";
            }
        }
    }
}
