using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Many.ThirdParty.Core.Models.CommonModels;
using Many.ThirdParty.Core.Service;
using Many.ThirdParty.Core.Tools;
using Newtonsoft.Json;

namespace Many.ThirdParty.Core.ViewModels.ReadingDetailPageViewModels
{
    public class EssayDetailPageViewModel : ReadingDetailPageViewModelBase
    {  
        public string Content_Id { get; set; }

        public string Hp_Title { get; set; }

        public string Sub_Title { get; set; }

        public string Auth_It { get; set; }

        public string Hp_Author_Introduce { get; set; }

        public string Hp_MaketTime { get; set; }

        public string Guild_World { get; set; }

        public IList<Author> Author { get; set; }

        private string _hp_Content;
        public string Hp_Content
        {
            get
            {
                return new StringBuilder(_hp_Content).Replace("<br>", "").ToString();
            }
            set { _hp_Content = value; }
        }

        public static async Task<ReadingDetailPageViewModelBase> CreateViewModel(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;

            var viewModel = JsonConvert.DeserializeObject<EssayDetailPageViewModel>((await DataHelper.GetJsonObjectAsync(GetEssayUri(id))).Stringify());
            await viewModel.AddToCommentsCollection(GetCommentUri(id));
            return viewModel;
        }

        private static string GetEssayUri(string id)
        {
            return string.Format(ServicesUrl.EssayUpdate, id, "0");
        }

        private static string GetCommentUri(string id)
        {
            return string.Format(ServicesUrl.EssayComment, id, "0");
        }
    }
}
