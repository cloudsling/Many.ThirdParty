using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace Many.ThirdParty.Core.Tools
{
    class JsonHelper
    {
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
            return json.GetNamedArray(name) ?? null;
        }
        internal static JsonObject GetObjectFromObject(JsonObject json, string name)
        {
            return json.GetNamedObject(name) ?? null;
        }
    }
}
