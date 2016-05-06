using Many.ThirdParty.Core.Models.CommonModels;
using Many.ThirdParty.Core.Models.ReadingModels;
using Many.ThirdParty.Core.Tools;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Many.ThirdParty.Core.ViewModels.ReadingDetailPageViewModels
{
    public abstract class ReadingDetailPageViewModelBase : BindableBase
    {
        public ReadingDetailPageViewModelBase()
        {
            HotComments = new ObservableCollection<CommentModel>();
            NormalComments = new ObservableCollection<CommentModel>();
        }

        public abstract string Charge_Edt { get; set; }

        public abstract string PraiseNum { get; set; }

        public abstract string CommentNum { get; set; }

        public abstract string ShareNum { get; set; }

        ObservableCollection<ReadingModelBase> _contentModelCollection;
        public ObservableCollection<ReadingModelBase> ContentModelCollection
        {
            get { return _contentModelCollection; }
            set
            {
                SetProperty(ref _contentModelCollection, value);
            }
        }

        public void AddToCommentsCollection(CommentModel model)
        {
            this.HotComments.Add(model);
        }

        public async Task AddToCommentsCollection(string uri)
        {
            CommentModel tem;
            foreach (var item in await DataHelper.GetCommentJsonArrayAsync(uri))
            {
                tem = JsonConvert.DeserializeObject<CommentModel>(item.Stringify());

                if (tem.Type == "0")
                {
                    this.HotComments.Add(tem);
                }
                else
                {
                    this.NormalComments.Add(tem);
                }
            }
        }

        public abstract ObservableCollection<CommentModel> HotComments { get; set; }

        public abstract ObservableCollection<CommentModel> NormalComments { get; set; }
    }
}
