using System.Text;

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
                return new StringBuilder(_answer_Content).Replace("<br><br>", "\r\n").Replace("<br>", "\r\n").Replace("<strong>", "").Replace("</strong>", "").ToString();
            }
            set { _answer_Content = value; }
        } 
    }
}
