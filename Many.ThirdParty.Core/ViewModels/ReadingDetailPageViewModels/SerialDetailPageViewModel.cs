using Many.ThirdParty.Core.Models.CommonModels;
using System.Text;

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
    }
}
