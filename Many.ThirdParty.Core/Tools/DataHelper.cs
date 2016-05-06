using System.Threading.Tasks;

namespace Many.ThirdParty.Core.Tools
{
    internal static class DataHelper
    {
        internal async static Task<Windows.Data.Json.JsonObject> GetJsonObjectAsync(string uri)
        {
           return JsonHelper.GetObjectFormString(await HttpHelper.GetStringAsync(uri));
        }
    }
}
