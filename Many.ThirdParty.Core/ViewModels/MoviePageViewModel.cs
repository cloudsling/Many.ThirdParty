using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Many.ThirdParty.Core.Models.MovieModels;
using Windows.ApplicationModel;
using Windows.Data.Json;
using Many.ThirdParty.Core.Commons;
using Many.ThirdParty.Core.Data;
using Many.ThirdParty.Core.Interface;
using Many.ThirdParty.Core.Tools;

namespace Many.ThirdParty.Core.ViewModels
{
    public class MoviePageViewModel : BindableBase
    {
        public MoviePageViewModel()
        {
            MovieListCollection = new IncrementalLoadingCollection<MovieListModel>(index => CommonDataLoader.GetMovieListModel((int)index));
#if DEBUG
            if (DesignMode.DesignModeEnabled)
            {
                MovieListCollection.Add(new MovieListModel
                {
                    Cover = "ms-appx:///Resources/Test/cover.png",
                    Id = "34",
                    Title = "卧虎藏龙2：青冥宝剑",
                    Score = "39"
                });
                MovieListCollection.Add(new MovieListModel
                {
                    Cover = "ms-appx:///Resources/Test/cover.png",
                    Id = "34",
                    Title = "卧虎藏龙2：青冥宝剑",
                    Score = "39"
                });
            }
#endif
        }

        private static async Task<ObservableCollection<MovieListModel>> GetList(string id)
        {
            //var ite = await CommonDataLoader.GetGeneralModelsCollectionAsync<MovieListModel>(id);

            

            var response = await HttpHelper.GetStringAsync(string.Format(MovieListUri, id));

            JsonObject json;
            var movieList = new ObservableCollection<MovieListModel>();

            if (!JsonObject.TryParse(response, out json)) return null;

            foreach (var model in GetList(json.GetNamedArray("data")))
            {
                movieList.Add(model); 
            }

            return movieList; 
        }

        private static IEnumerable<MovieListModel> GetList(JsonArray arr)
        {
            return arr.Select(item => item.GetObject()).Select(obj => new MovieListModel
            {
                Cover = obj.GetNamedString("cover"),
                Id = obj.GetNamedString("id"),
                Title = obj.GetNamedString("title"),
                Score = TryGetStringFromJsonObject(obj, "score")
            });

        }

        private const string MovieListUri = "http://v3.wufazhuce.com:8000/api/movie/list/{0}?";

        private static string TryGetStringFromJsonObject(JsonObject obj, string valueName)
        {
            var value = obj.GetNamedValue(valueName);
            return value.ValueType == JsonValueType.String ? value.GetString() : string.Empty;
        }

        IncrementalLoadingCollection<MovieListModel> _movieListCollection;
        public IncrementalLoadingCollection<MovieListModel> MovieListCollection
        {
            get { return _movieListCollection; }
            set
            {
                SetProperty(ref _movieListCollection, value);
            }
        }
    }
}
