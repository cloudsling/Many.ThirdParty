using Many.ThirdParty.Core.Models.HomeModels;
using Many.ThirdParty.Core.Service;
using Many.ThirdParty.Core.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Web.Http;

namespace Many.ThirdParty.Core.Data
{
    class PreloadResources
    {

        private static readonly string DATANAME = "data";
        private static readonly List<string> DATALIST = new List<string>
        {
            "hpcontent_id", "hp_title", "author_id", "hp_img_url", "hp_author", "hp_content", "hp_makettime", "praisenum", "sharenum", "commentnum"
        };

        //new Uri(string.Format(ServicesUrl.MainContent, "0"))
        public async Task<HomeModel> LoadResourcesInFirstStartupAsync()
        {
            return  GetModelFormArray(await GetObjectFromObject());
        }

        private static async Task<string> GetStringAsync()
        {
            return await HttpHelper.GetStringAsync(new Uri(string.Format(ServicesUrl.MainContent, "0")));
        }

        private static async Task<JsonObject> GetObjectFromString()
        {
            return JsonHelper.GetObjectFormString(await GetStringAsync());
        }
        private static async Task<JsonObject> GetObjectFromObject()
        {
            return JsonHelper.GetObjectFromObject(await GetObjectFromString(), DATANAME);
        }

        private static HomeModel GetModelFormArray(JsonObject jsonObject)
        {
            HomeModel model = new HomeModel();

            model.ContentId = jsonObject.GetNamedString(DATALIST[0]);
            model.Title = jsonObject.GetNamedString(DATALIST[1]);
            model.AuthorId = jsonObject.GetNamedString(DATALIST[2]);
            model.ImageUrl = jsonObject.GetNamedString(DATALIST[3]);
            model.Author = jsonObject.GetNamedString(DATALIST[4]);
            model.MainContent = jsonObject.GetNamedString(DATALIST[5]);
            model.YearAndMonth = jsonObject.GetNamedString(DATALIST[6]).Substring(0, 7);
            model.Day = jsonObject.GetNamedString(DATALIST[6]).Substring(8, 10);
            model.PariseNum = jsonObject.GetNamedString(DATALIST[7]);

            return model;
        }
    }
}
