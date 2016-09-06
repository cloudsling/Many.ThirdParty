using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Many.ThirdParty.Core.Models.MovieModels;
using Many.ThirdParty.Core.Service;
using Many.ThirdParty.Core.ViewModels;
using static Many.ThirdParty.Core.Tools.JsonHelper;

namespace Many.ThirdParty.Core.Data
{
    public class MovieStoryData
    {
        public static async Task<MovieDetailPageViewModel> CreateViewModel(string uri)
        {
            var model = await CommonDataLoader.GetGeneralModelByUriAsync<MovieDetailPageViewModel>(uri);

            await model.LoadMovieStory();
            await model.RefreshCommentsCollection(model.Id);

            return model;

        }
        internal static async Task<MovieStoryModel> LoadModel(string uri)
        {
            var tem = await CommonDataLoader.GetMainContentGeneric(uri);

            JsonArray obj = GetArrayFromObject(GetObjectFromString(tem),"data");
           
            return obj == null ? null : GetTFormString<MovieStoryModel>(obj[0].Stringify());
            ;
        }

    }
}
