using Many.ThirdParty.Core.Models.AddlModels;
using Many.ThirdParty.Core.Models.CommonModels;
using Many.ThirdParty.Core.Models.HomeModels;
using Many.ThirdParty.Core.Models.MovieModels;
using Many.ThirdParty.Core.Models.MusicModels;
using Many.ThirdParty.Core.Service;
using static Many.ThirdParty.Core.Tools.JsonHelper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Many.ThirdParty.Core.Data
{
    public static class Searcher<T> where T : class, new()
    {
        private static string GetSearchUri(string searchContent)
        {
            switch (typeof(T).Name)
            {
                case nameof(HomeModel):
                    return string.Format(ServicesUrl.SearchMain, searchContent);
                case nameof(SearchReadingModel):
                    return string.Format(ServicesUrl.SearchReading, searchContent);
                case nameof(MusicModel):
                    return string.Format(ServicesUrl.SearchMusic, searchContent);
                case nameof(MovieListModel):
                    return string.Format(ServicesUrl.SearchMovie, searchContent);
                case nameof(Author):
                    return string.Format(ServicesUrl.SearchAuthor, searchContent);
                default:
                    return null;
            }
        }

        public static async Task<IEnumerable<T>> Search(string searchContent)
        {
            return GetTFormString<IEnumerable<T>>(
                  (await CommonDataLoader.GetMainJsonArrayGeneric(
                      GetSearchUri(searchContent))
                  ).Stringify());
        }

        public static async Task<IEnumerable<T>> SearchWithLargeContent(string searchContent)
        {
            return GetTFormArray<T>((
                await CommonDataLoader.GetMainJsonArrayGeneric(
                      GetSearchUri(searchContent))));
        }
    }
}
