using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Data.Json; 

namespace Many.ThirdParty.Core.Tools
{
    internal static class JsonHelper
    {
        private const string Dataname = "data";

        internal static JsonObject GetObjectFormString(string content)
        {
            JsonObject jsonObject;

            return JsonObject.TryParse(content, out jsonObject) ? jsonObject : null;
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

        internal static IEnumerable<T> Select<T>(JsonArray arr)
        {
            return arr.Select(
                item => JsonConvert.DeserializeObject<T>(item.Stringify()));
        }

        internal static JsonObject GetObjectFromString(string content)
        {
            return GetObjectFormString(content);
        }

        internal static JsonObject GetObjectFromObject(JsonObject json)
        {
            return GetObjectFromObject(json, Dataname);
        }

        internal static JsonArray GetArrayFromObject(JsonObject json)
        {
            return GetArrayFromObject(json, Dataname);
        }

        internal static T GetTFormString<T>(string content) where T : class
        {
            return JsonConvert.DeserializeObject<T>(content);
        }

        internal static IEnumerable<T> GetTFormArray<T>(JsonArray array) where T : class
        {
            return array.Select(item => JsonConvert.DeserializeObject<T>(item.Stringify()));
        }
    }
}
