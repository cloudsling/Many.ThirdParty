using Many.ThirdParty.Core.Models.HomeModels;
using Many.ThirdParty.Core.Service;
using Many.ThirdParty.Core.Tools;
using static Many.ThirdParty.Core.Tools.JsonHelper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Data.Json;
using Many.ThirdParty.Core.Models.ReadingModels;
using System.Collections.ObjectModel;

namespace Many.ThirdParty.Core.Data
{
    //public class PreloadResourcesTest
    //{
    //    public static async void Test()
    //    {
    //       // var model = await PreloadResources.LoadResourcesInFirstStartupAsync();

    //        string response = await HttpHelper.GetStringAsync(new Uri(string.Format(ServicesUrl.MainContent, "1313")));

    //        JsonObject json;

    //        if (JsonObject.TryParse(response, out json))
    //        {
    //           JsonObject jsonObject = json.GetNamedObject("data");

    //            HomeModel gen = JsonConvert.DeserializeObject<HomeModel>(jsonObject.Stringify());
    //        }

    //    }
    //}

    public static class LoadResources
    {
        public static async Task<List<string>> GetHomeList(string listId)
        {
            return GetTFormObject<List<string>>(await GetMainListGeneric(string.Format(ServicesUrl.MainId, listId)));
        }

        public static async Task<HomeModel> LoadHomeModelResourcesAsync(string contentId)
        {
            return GetTFormObject<HomeModel>(await GetMainContentGeneric(string.Format(ServicesUrl.MainContent, contentId)));
        }

        #region private method
        private static async Task<string> GetMainListGeneric(string uri)
        {
            return GetArrayFromObject(await GetMainJsonObjectAsync(uri)).Stringify();
        }

        private static async Task<JsonArray> GetMainArrayGeneric(string uri)
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
        #endregion

        public static async Task<ObservableCollection<CarouselModel>> GetCarouselModel()
        {
            return GetTFormObject<ObservableCollection<CarouselModel>>(await GetMainListGeneric(ServicesUrl.ReadingCarousel));
        }
        public static async Task<ObservableCollection<ReadingModel>> GetReadingModel(string listId)
        {
            JsonArray array = await GetMainArrayGeneric(string.Format(ServicesUrl.ReadingContent, listId));

            foreach (var item in array)
            {
                JsonObject json = item.GetObject();

                ReadingModel model = new ReadingModel();

                model.MaketTime = json.GetNamedString("date");

                JsonArray innerArray = json.GetNamedArray("items");

                foreach (var innerItem in innerArray)
                {
                    JsonObject obj = innerItem.GetObject();

                   double type = obj.GetNamedNumber("type");
                }

            }

            return null;
        }
    }
}
