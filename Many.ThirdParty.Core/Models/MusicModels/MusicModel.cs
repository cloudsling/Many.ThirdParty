using System.Collections.ObjectModel;
using Many.ThirdParty.Core.Interface;
using Many.ThirdParty.Core.Models.CommonModels;

namespace Many.ThirdParty.Core.Models.MusicModels
{
    public class MusicModel : IComments
    {
        public MusicModel()
        {
            HotComments = new ObservableCollection<CommentModel>();

            NormalComments = new ObservableCollection<CommentModel>();
        }

        public string Id { get; set; }

        public string Cover { get; set; }

        public string Title { get; set; }

        public string Platform { get; set; }

        public string Story_Title { get; set; }

        public string Story { get; set; }

        public string Lyric { get; set; }

        public string Info { get; set; }

        public string IsFirst { get; set; }
        
        public string Music_Id { get; set; }

        public string Charge_Edt { get; set; }

        public string RelatedTo { get; set; }

        public string PraiseNum { get; set; }

        public string ShareNum { get; set; }

        public string CommentNum { get; set; }

        public string MakeTile { get; set; }

        public string Read_Num { get; set; }

        public Author Story_Author { get; set; }
         
        public Author Author { get; set; }
         
        public ObservableCollection<CommentModel> HotComments { get; set; }

        public ObservableCollection<CommentModel> NormalComments { get; set; }
    }
}
