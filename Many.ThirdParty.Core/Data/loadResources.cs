using Many.ThirdParty.Core.Models.HomeModels;
using Many.ThirdParty.Core.Service;
using Many.ThirdParty.Core.Tools;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public static async Task<List<string>> GetMainList(string listId)
        {
            return JsonHelper.GetTFormObject<List<string>>(await GetMainListGeneric(GetListContentAsync, listId));
        }

        public static async Task<HomeModel> LoadHomeModelResourcesAsync(string contentId)
        {
            return JsonHelper.GetTFormObject<HomeModel>(await GetMainContentGeneric(GetMainContentAsync, contentId));
        }

        #region private method
        private static async Task<string> GetMainListGeneric(Func<string, Task<string>> func, string param)
        {
            return JsonHelper.GetArrayFromObject(JsonHelper.GetObjectFromString(await func(param))).Stringify();
        }

        private static async Task<string> GetMainContentGeneric(Func<string, Task<string>> func, string param)
        {
            return JsonHelper.GetObjectFromObject(JsonHelper.GetObjectFromString(await func(param))).Stringify();
        }


        private static async Task<string> GetListContentAsync(string listId)
        {
            return await HttpHelper.GetStringAsync(string.Format(ServicesUrl.MainId, listId));
        }

        private static async Task<string> GetMainContentAsync(string contentId)
        {
            return await HttpHelper.GetStringAsync(string.Format(ServicesUrl.MainContent, contentId));
        }
        #endregion
    }
}
