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
using System.Collections;

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
                home.Add(await GetGeneralModelAsync<HomeModel>(item));
                //home.Add(await LoadHomeModelAsync(item));
            }
            return home;
        }

        //public static async Task<HomeModel> LoadHomeModelAsync(string contentId)
        //{
        //    return GetTFormString<HomeModel>(
        //        await GetMainContentGeneric(
        //            string.Format(ServicesUrl.MainContent, contentId)));
        //}

        #region private method
        private static async Task<string> GetMainListGeneric(string uri)
        {
            return GetJsonArrayFromObject(await GetMainJsonObjectAsync(uri)).Stringify();
        }

        internal static async Task<JsonArray> GetMainJsonArrayGeneric(string uri)
        {
            return GetJsonArrayFromObject(await GetMainJsonObjectAsync(uri));
        }

        private static async Task<string> GetMainContentGeneric(string uri)
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

        public static async Task<ObservableCollection<T>> GetGeneralModelsCollectionByUriAsync<T>(string uri)
        {
            return GetTFormString<ObservableCollection<T>>(
                await GetMainListGeneric(uri));
        }

        public static async Task<T> GetGeneralModelAsync<T>(string id) where T : class
        {
            return GetTFormString<T>(
                await GetMainContentGeneric(
                    GetUriByModelType(typeof(T), id)));
        }

        private static List<string> MoviePair { get; set; } = new List<string> { "0" };

        public static async Task<ObservableCollection<MovieListModel>> GetMovieListModel(int key)
        {
            if (key == 0) return null;

            ++key;

            var arr = await GetGeneralModelsCollectionByUriAsync<MovieListModel>(string.Format(ServicesUrl.MovieList, MoviePair[key - 1]));

            MoviePair.Add(arr[arr.Count - 1].Id);

            return arr;
        }

        public static async Task<ObservableCollection<ReadingModel>> GetReadingModel(string listId)
        {
            var array = await GetMainJsonArrayGeneric(string.Format(ServicesUrl.ReadingContent, listId));

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
