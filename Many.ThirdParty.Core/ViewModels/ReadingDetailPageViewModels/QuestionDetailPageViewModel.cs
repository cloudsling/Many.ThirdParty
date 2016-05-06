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

namespace Many.ThirdParty.Core.ViewModels.ReadingDetailPageViewModels
{
    public class QuestionDetailPageViewModel : BindableBase
    {

        public string Question_Title { get; set; }

        public string Question_Content { get; set; }

        public string Answer_Title { get; set; }

        public string Answer_Content { get; set; }

        public string Charge_Edt { get; set; }

        public string Test { get; set; } = "test!!!!!!!!!!!!!!";

        //  private string _praiseNum;
        public string PraiseNum { get; set; }
        //{
        //    get { return _praiseNum; }
        //    set
        //    {
        //        SetProperty(ref _praiseNum, value);
        //    }
        //}

        // private string _commentNum;
        public string CommentNum { get; set; }
        //{
        //    get { return _commentNum; }
        //    set
        //    {
        //        SetProperty(ref _commentNum, value);
        //    }
        //}

        // private string _shareNum;
        public string ShareNum { get; set; }
        //{
        //    get { return _shareNum; }
        //    set
        //    {
        //        SetProperty(ref _shareNum, value);
        //    }
        //}

        private static string GetQuestionUri(string id)
        {
            return string.Format(ServicesUrl.QuestionContent, id, DateTime.Now.ToString("d").Replace('/', '-'));
        }

        private static async Task<JsonObject> GetQuestionJsonObject(string id)
        {
            return await DataHelper.GetJsonObjectAsync(GetQuestionUri(id));
        }

        public static async Task<QuestionDetailPageViewModel> CreateQuestionDetailPageViewModel(string id)
        {

            if (string.IsNullOrEmpty(id)) return null;

            return JsonConvert.DeserializeObject<QuestionDetailPageViewModel>(JsonHelper.GetObjectFromObject(await GetQuestionJsonObject(id)).ToString());

        }

        public async Task AcquireContent(string id)
        {
            if (string.IsNullOrEmpty(id)) return;

            QuestionDetailPageViewModel obj = JsonConvert.DeserializeObject<QuestionDetailPageViewModel>(JsonHelper.GetObjectFromObject(await GetQuestionJsonObject(id)).ToString());

            Question_Title = obj.Question_Title;
            Question_Content = obj.Question_Content;
            Answer_Title = obj.Answer_Title;
            Answer_Content = obj.Answer_Content;
            Charge_Edt = obj.Charge_Edt;
            PraiseNum = obj.PraiseNum;
            CommentNum = obj.CommentNum;
            ShareNum = obj.ShareNum;

        }
    }
}
