using System;
using Many.ThirdParty.Core.Models.HomeModels;
using Many.ThirdParty.Core.Service;
using Many.ThirdParty.Core.Tools;
using static Many.ThirdParty.Core.Tools.JsonHelper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Data.Json;
using Many.ThirdParty.Core.Models.ReadingModels;
using System.Collections.ObjectModel;
using Many.ThirdParty.Core.Factories;
using Many.ThirdParty.Core.Models.MusicModels;

namespace Many.ThirdParty.Core.Data
{
    public enum ListType
    {
        HomeList,
        MusicList,
    }

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
            return GetArrayFromObject(await GetMainJsonObjectAsync(uri)).Stringify();
        }

        internal static async Task<JsonArray> GetMainArrayGeneric(string uri)
        {
            return GetArrayFromObject(await GetMainJsonObjectAsync(uri));
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

        public static async Task<ObservableCollection<T>> GetGeneralModelsCollectionAsync<T>(string id)
        {
            return GetTFormString<ObservableCollection<T>>(
                await GetMainListGeneric(
                    GetUriByModelType(typeof(T), id)));
        }

        public static async Task<T> GetGeneralModelAsync<T>(string id) where T : class
        {
            return GetTFormString<T>(
                await GetMainContentGeneric(
                    GetUriByModelType(typeof(T), id)));
        }

        public static async Task<ObservableCollection<ReadingModel>> GetReadingModel(string listId)
        {
            JsonArray array = await GetMainArrayGeneric(string.Format(ServicesUrl.ReadingContent, listId));

            ObservableCollection<ReadingModel> collection = new ObservableCollection<ReadingModel>();
            foreach (var item in array)
            {
                JsonObject json = item.GetObject();

                ReadingModel model = new ReadingModel { MaketTime = json.GetNamedString("date") };

                JsonArray innerArray = json.GetNamedArray("items");

                foreach (var innerItem in innerArray)
                {
                    JsonObject obj = innerItem.GetObject();

                    int type = (int)obj.GetNamedNumber("type");

                    ReadingModelBase itemModel = ReadingModelFactory.CreateReadingModel(type, obj.GetNamedObject("content"));

                    itemModel.Time = obj.GetNamedString("time");

                    model.AddToCollection(itemModel);
                }

                collection.Add(model);
            }
            return collection;
        }
    }
}
