using Many.ThirdParty.Config;
using Many.ThirdParty.Core.Models.MovieModels;
using Many.ThirdParty.Core.Tools;
using Many.ThirdParty.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Many.ThirdParty.SubPages
{
    public sealed partial class MoviePage : Page
    {
        public static MoviePage CurrentMoviePage;
        public static readonly string movieListUri = "http://v3.wufazhuce.com:8000/api/movie/list/0?";

        public MoviePageViewModel MoviePageViewModel { get; set; }
    }

    public sealed partial class MoviePage : Page
    {
        public MoviePage()
        {
            MoviePageViewModel = new MoviePageViewModel();

            this.InitializeComponent();
            CurrentMoviePage = this;
        }

        private void movieList_ItemClick(object sender, ItemClickEventArgs e)
        {
            if ((e.ClickedItem as MovieListModel) != null)
            {
                //TODO:
                Frame.Navigate(typeof(MovieDetailPage), $"http://m.wufazhuce.com/movie/{(e.ClickedItem as MovieListModel).Id}");
            }
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            CurrentMoviePage.MoviePageViewModel.MovieListCollection = await GetList();
        }

        private static async Task<ObservableCollection<MovieListModel>> GetList()
        {
            using (var client = HttpHelper.CreateHttpClientWithUserAgent())
            {
                string response = await client.GetStringAsync(new Uri(movieListUri));
                JsonObject json;
                var movieList = new ObservableCollection<MovieListModel>();
                if (JsonObject.TryParse(response, out json))
                {
                    foreach (var item in json.GetNamedArray("data"))
                    {
                        var obj = item.GetObject();
                        //TryGetStringFromJsonObject(obj, "score");
                        movieList.Add(new MovieListModel
                        {
                            Cover = obj.GetNamedString("cover") ?? "无",
                            Id = obj.GetNamedString("id") ?? "无",
                            Title = obj.GetNamedString("title") ?? "无",
                            Score = TryGetStringFromJsonObject(obj, "score")
                        });
                    }
                }
                return movieList;
            }
        }

        static string TryGetStringFromJsonObject(JsonObject obj, string valueName)
        {
            JsonValue value = JsonValue.CreateNullValue();
            try
            {
                value = obj.GetNamedValue(valueName);
            }
            catch (Exception)
            {

                throw;
            }
            switch (value.ValueType)
            {
                case JsonValueType.String:
                    return value.GetString();
                case JsonValueType.Null:
                    return string.Empty;
                case JsonValueType.Boolean:
                    return string.Empty;
                case JsonValueType.Number:
                    return string.Empty;
                case JsonValueType.Array:
                    return string.Empty;
                case JsonValueType.Object:
                    return string.Empty;
                default:
                    return string.Empty;
            }
        }
    }
}
