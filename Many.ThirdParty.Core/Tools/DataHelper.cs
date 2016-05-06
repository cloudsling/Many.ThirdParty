using System.Threading.Tasks;
using Windows.Data.Json;
using static Many.ThirdParty.Core.Tools.JsonHelper;

namespace Many.ThirdParty.Core.Tools
{
    internal static class DataHelper
    {

        internal async static Task<JsonArray> GetJsonArrayAsync(string uri)
        {
            return GetArrayFromObject(GetObjectFormString(await HttpHelper.GetStringAsync(uri)));
        }

        internal async static Task<JsonObject> GetJsonObjectAsync(string uri)
        {
            return GetObjectFromObject(GetObjectFormString(await HttpHelper.GetStringAsync(uri)));
        }

        internal async static Task<JsonArray> GetCommentJsonArrayAsync(string uri)
        {
            return GetArrayFromObject(await GetJsonObjectAsync(uri));
        }
    }
}
