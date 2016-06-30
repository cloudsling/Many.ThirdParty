using System.Threading.Tasks;
using Windows.Data.Json;
using static Many.ThirdParty.Core.Tools.JsonHelper;

namespace Many.ThirdParty.Core.Tools
{
    internal static class DataHelper
    {
        internal static async Task<JsonArray> GetJsonArrayAsync(string uri)
        {
            return GetArrayFromObject(GetObjectFormString(await HttpHelper.GetStringAsync(uri)));
        }

        internal static async Task<JsonObject> GetJsonObjectAsync(string uri)
        {
            return GetObjectFromObject(GetObjectFormString(await HttpHelper.GetStringAsync(uri)));
        }

        internal static async Task<JsonArray> GetCommentJsonArrayAsync(string uri)
        {
            return GetArrayFromObject(await GetJsonObjectAsync(uri));
        }
    }
}
