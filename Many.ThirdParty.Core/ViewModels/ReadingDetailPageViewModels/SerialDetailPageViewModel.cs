using Many.ThirdParty.Core.Models.CommonModels;
using Many.ThirdParty.Core.Service;
using Many.ThirdParty.Core.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Many.ThirdParty.Core.ViewModels.ReadingDetailPageViewModels
{
    public class SerialDetailPageViewModel : ReadingDetailPageViewModelBase
    {
        public string Id { get; set; }

        // ReSharper disable once InconsistentNaming
        public string Serial_Id { get; set; }

        public string Number { get; set; }

        public string Title { get; set; }

        public string Excerpt { get; set; }

        private string _makeTime;
        public string MakeTime
        {
            get { return _makeTime.Split(' ')[0]; }
            set { _makeTime = value; }
        }
        public Author Author { get; set; }

        private string _content;
        public string Content
        {
            get
            {
                return new StringBuilder(_content).Replace("<br>", "").ToString();
            }
            set { _content = value; }
        }

        public static async Task<ReadingDetailPageViewModelBase> CreateViewModel(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;

            var viewModel = JsonConvert.DeserializeObject<SerialDetailPageViewModel>(
                (await DataHelper.GetJsonObjectAsync(
                    GetEssayUri(id))).Stringify());
            await viewModel.AddToCommentsCollection(GetCommentUri(id));
            return viewModel;
        }

        private static string GetEssayUri(string id)
        {
            return string.Format(ServicesUrl.SerialContent, id);
        }

        private static string GetCommentUri(string id)
        {
            return string.Format(ServicesUrl.SerialComment, id, "0");
        }
    }
}
