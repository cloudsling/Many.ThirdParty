using Many.ThirdParty.Core.Commons;
using Many.ThirdParty.Core.Tools;

namespace Many.ThirdParty.Core.Models.CommonModels
{
    public class CommentModel : BindableBase
    { 
        private string _content;
        public string Content
        {
            get { return _content; }
            set
            {
                SetProperty(ref _content, value);
            }
        } 

        public string Id { get; set; }

        public string Input_Date { get; set; }

        public string Quote { get; set; }

        public string PraiseNum { get; set; }

        public string Type { get; set; }

        public User ToUser { get; set; }

        public User User { get; set; }
    }
}
