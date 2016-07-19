using Many.ThirdParty.Config;
using Many.ThirdParty.Core.Models.MovieModels;
using Many.ThirdParty.Core.Tools;
using Many.ThirdParty.Core.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Many.ThirdParty.SubPages
{
    public sealed partial class MoviePage : Page
    {
        public static MoviePage CurrentMoviePage;
        private const string MovieListUri = "http://v3.wufazhuce.com:8000/api/movie/list/0?";

        public MoviePageViewModel MoviePageViewModel { get; set; }
    }

    public sealed partial class MoviePage : Page
    {
        public MoviePage()
        {
            MoviePageViewModel = new MoviePageViewModel();

            InitializeComponent();
            CurrentMoviePage = this;
        }

        private void movieList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = e.ClickedItem as MovieListModel;
            if (item != null)
            {
                //TODO:
                NavigationManager.GeneralNavigate(typeof(MovieDetailPage), $"http://m.wufazhuce.com/movie/{item.Id}");
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           // CurrentMoviePage.MoviePageViewModel.MovieListCollection = await GetList();
        }

        private static async Task<ObservableCollection<MovieListModel>> GetList()
        {
            using (var client = HttpHelper.CreateHttpClientWithUserAgent())
            {
                string response = await client.GetStringAsync(new Uri(MovieListUri));
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
                            Cover = obj.GetNamedString("cover"),
                            Id = obj.GetNamedString("id"),
                            Title = obj.GetNamedString("title"),
                            Score = TryGetStringFromJsonObject(obj, "score")
                        });
                    }
                }
                return movieList;
            }
        }

        private static string TryGetStringFromJsonObject(JsonObject obj, string valueName)
        {
            var value = obj.GetNamedValue(valueName);
            return value.ValueType == JsonValueType.String ? value.GetString() : string.Empty;
        }
    }
}
