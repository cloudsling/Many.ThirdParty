using System;
using Many.ThirdParty.Core.Models.HomeModels;
using Many.ThirdParty.Core.Service;
using Many.ThirdParty.Core.Tools;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Data.Json;
using Many.ThirdParty.Core.Models.ReadingModels;
using System.Collections.ObjectModel;
using Many.ThirdParty.Core.Factories;
using Many.ThirdParty.Core.Models.MusicModels;
using Many.ThirdParty.Core.Enum;
using Many.ThirdParty.Core.Models.MovieModels;
using static Many.ThirdParty.Core.Tools.JsonHelper;

namespace Many.ThirdParty.Core.Data
{ 
    public static class CommonDataLoader
    {
        public static async Task<List<string>> GetGeneralList(string listId, ListType type)
        {
            return GetTFormString<List<string>>(await GetMainListGeneric(GetUriByModelType(type, listId)));
        }

        public static async Task<IEnumerable<HomeModel>> LoadHomeModelsAsync(IEnumerable<string> homeList)
        {
            IList<HomeModel> home = new List<HomeModel>();
            foreach (var item in homeList)
            {
                home.Add(await GetGeneralModelByIdAsync<HomeModel>(item));
            }
            return home;
        }

        #region private method
        private static async Task<string> GetMainListGeneric(string uri)
        {
            return GetJsonArrayFromObject(await GetMainJsonObjectAsync(uri)).Stringify();
        }

        public static async Task<JsonArray> GetMainJsonArrayGeneric(string uri)
        {
            return GetJsonArrayFromObject(await GetMainJsonObjectAsync(uri));
        }

        public static async Task<string> GetMainContentGeneric(string uri)
        {
            return GetObjectFromObject(await GetMainJsonObjectAsync(uri)).Stringify();
        }

        private static async Task<JsonObject> GetMainJsonObjectAsync(string uri)
        {
            return GetObjectFromString(await HttpHelper.GetStringAsync(uri));
        }

        private static string GetUriByModelType(Type type, string id)
        {
            switch (type.Name)
            {
                case nameof(CarouselModel):
                    return string.Format(ServicesUrl.ReadingCarousel, id);
                case nameof(MusicModel):
                    return string.Format(ServicesUrl.MusicContent, id);
                case nameof(HomeModel):
                    return string.Format(ServicesUrl.MainContent, id);
                case nameof(CarouselDetailModel):
                    return string.Format(ServicesUrl.ReadingCarousel, id);
                case nameof(MovieModel):
                    return string.Format(ServicesUrl.MovieDetail, id);
                default:
                    return string.Empty;
            }
        }

        private static string GetUriByModelType(ListType type, string id)
        {
            switch (type)
            {
                case ListType.HomeList:
                    return string.Format(ServicesUrl.MainId, id);
                case ListType.MusicList:
                    return string.Format(ServicesUrl.MusicId, id);
                default:
                    return string.Empty;
            }
        }
        #endregion

        public static async Task<ObservableCollection<T>> GetGeneralModelsCollectionByIdAsync<T>(string id)
        {
            return GetTFormString<ObservableCollection<T>>(
                await GetMainListGeneric(
                    GetUriByModelType(typeof(T), id)));
        }

        //返回从请求到的Json数据中的data下的JsonArray集合
        public static async Task<ObservableCollection<T>> GetGeneralModelsCollectionByUriAsync<T>(string uri)
        {
            return GetTFormString<ObservableCollection<T>>(
                await GetMainListGeneric(uri));
        }

        public static async Task<T> GetGeneralModelByIdAsync<T>(string id) where T : class
        {
            return GetTFormString<T>(
                await GetMainContentGeneric(
                    GetUriByModelType(typeof(T), id)));
        }


        public static async Task<T> GetGeneralModelByUriAsync<T>(string uri) where T : class
        {
            return GetTFormString<T>(await GetMainContentGeneric(uri));
        }
        
        private static Dictionary<uint, string> MoviePair { get; } = new Dictionary<uint, string> { { 0, "0" } };

        public static async Task<ObservableCollection<MovieListModel>> GetMovieListModel(uint key)
        {
            if (!MoviePair.ContainsKey(key)) return null;

            var arr = await GetGeneralModelsCollectionByUriAsync<MovieListModel>(string.Format(ServicesUrl.MovieList, MoviePair[key]));

            if (arr == null || arr.Count < 1) return null;

            if (!MoviePair.ContainsKey(key + 1))
                MoviePair.Add(key + 1, arr[arr.Count - 1].Id);
            return arr;
        }

        public static async Task<ObservableCollection<ReadingModel>> GetReadingModel(uint listId)
        {
            var array = await GetMainJsonArrayGeneric(string.Format(ServicesUrl.ReadingContent, listId - 1));

            var collection = new ObservableCollection<ReadingModel>();

            foreach (var item in array)
            {
                var json = item.GetObject();
                var model = new ReadingModel { MaketTime = json.GetNamedString("date") };

                var innerArray = json.GetNamedArray("items");

                foreach (var innerItem in innerArray)
                {
                    var obj = innerItem.GetObject();

                    var type = (int)obj.GetNamedNumber("type");

                    var itemModel = ReadingModelFactory.CreateReadingModel(type, obj.GetNamedObject("content"));

                    itemModel.Time = obj.GetNamedString("time");

                    model.AddToCollection(itemModel);
                }

                collection.Add(model);
            }
            return collection;
        }
    }
}
