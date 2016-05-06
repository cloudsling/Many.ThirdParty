using Newtonsoft.Json;
using System;
using Windows.Data.Json;

namespace Many.ThirdParty.Core.Tools
{
    internal static class JsonHelper
    {
        private static readonly string DATANAME = "data";

        internal static JsonObject GetObjectFormString(string content)
        {
            JsonObject jsonObject;

            if (JsonObject.TryParse(content, out jsonObject))
            {
                return jsonObject;
            }
            return null;
        }

        internal static JsonArray GetArrayFromObject(JsonObject json, string name)
        {
            try
            {
                return json.GetNamedArray(name);
            }
            catch (Exception)
            {
                return null;
            }
        }

        internal static JsonObject GetObjectFromObject(JsonObject json, string name)
        {
            try
            {
                return json.GetNamedObject(name);
            }
            catch (Exception)
            {
                return null;
            }
        }


        internal static JsonObject GetObjectFromString(string content)
        {
            return GetObjectFormString(content);
        }

        internal static JsonObject GetObjectFromObject(JsonObject json)
        {
            return GetObjectFromObject(json, DATANAME);
        }

        internal static JsonArray GetArrayFromObject(JsonObject json)
        {
            return GetArrayFromObject(json, DATANAME);
        }

        internal static T GetTFormObject<T>(string content) where T : class, new()
        {
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
