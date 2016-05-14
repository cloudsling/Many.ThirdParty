using Many.ThirdParty.Core.Models.CommonModels;
using Many.ThirdParty.Core.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Many.ThirdParty.Core.Data
{
    internal static class Comments
    {
        internal async static Task<ObservableCollection<CommentModel>> GetComment(string uri)
        {
            ObservableCollection<CommentModel> collection = new ObservableCollection<CommentModel>();

            foreach (var item in await DataHelper.GetJsonArrayAsync(uri))
            {
                collection.Add(JsonConvert.DeserializeObject<CommentModel>(item.Stringify()));
            }
            return collection;
        }
    }
}
