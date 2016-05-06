using Many.ThirdParty.Core.Models.CommonModels;
using System.Collections.ObjectModel;

namespace Many.ThirdParty.Core.ViewModels.ReadingDetailPageViewModels
{
    public abstract class ReadingDetailPageViewModelBase
    {
        public string Question_Title { get; set; }

        public string Question_Content { get; set; }

        public string Answer_Title { get; set; }

        public string Answer_Content { get; set; }

        public string Charge_Edt { get; set; }

        public string PraiseNum { get; set; }

        public string CommentNum { get; set; }

        public string ShareNum { get; set; }

        public ObservableCollection<CommentModel> HotComments { get; set; }

        public ObservableCollection<CommentModel> NormalComments { get; set; }
    }
}
