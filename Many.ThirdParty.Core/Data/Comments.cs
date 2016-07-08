using Many.ThirdParty.Core.Models.CommonModels;
using Many.ThirdParty.Core.Tools;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Many.ThirdParty.Core.Data
{
    internal static class Comments
    {
        internal static async Task<IEnumerable<CommentModel>> GetComment(string uri)
        {
            return JsonHelper.Select<CommentModel>(await DataHelper.GetJsonArrayAsync(uri));
        }
    }
}
