using Many.ThirdParty.Core.Service;
using Many.ThirdParty.Core.Tools;
using Newtonsoft.Json;
using System.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Many.ThirdParty.Core.Models.CommonModels;
using System.Collections.ObjectModel;

namespace Many.ThirdParty.Core.ViewModels.ReadingDetailPageViewModels
{
    public class QuestionDetailPageViewModel : ReadingDetailPageViewModelBase
    {
        public string Question_Id { get; set; }

        private string _question_MaketTime;
        public string Question_MaketTime
        {
            get { return _question_MaketTime.Split(' ')[0]; }
            set { _question_MaketTime = value; }
        }

        public string Question_Title { get; set; }

        public string Question_Content { get; set; }

        public string Answer_Title { get; set; }

        private string _answer_Content;
        public string Answer_Content
        {
            get
            {
                return new StringBuilder(_answer_Content).Replace("<br>", "\r\n").ToString();
            }
            set { _answer_Content = value; }
        }

        public override string Charge_Edt { get; set; }

        public override string PraiseNum { get; set; }

        public override string CommentNum { get; set; }

        public override string ShareNum { get; set; }

        public override ObservableCollection<CommentModel> HotComments { get; set; }

        public override ObservableCollection<CommentModel> NormalComments { get; set; }

        private static string GetQuestionUri(string id)
        {
            return string.Format(ServicesUrl.QuestionContent, id, DateTime.Now.ToString("d").Replace('/', '-'));
        }

        private static string GetCommentString(string id)
        {
            return string.Format(ServicesUrl.QuestionComment, id, "0");
        }

        public static async Task AddToCollection(QuestionDetailPageViewModel viewModel, string uri)
        {
            foreach (var item in await DataHelper.GetCommentJsonArrayAsync(uri))
            {
                viewModel.HotComments.Add(JsonConvert.DeserializeObject<CommentModel>(item.Stringify()));
            }
        }

        public static async Task<QuestionDetailPageViewModel> CreateQuestionDetailPageViewModel(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;

            var viewModel = JsonConvert.DeserializeObject<QuestionDetailPageViewModel>((await DataHelper.GetJsonObjectAsync(GetQuestionUri(id))).Stringify());
            await viewModel.AddToCommentsCollection(GetCommentString(id));
            return viewModel;
        }
    }
}
