using Many.ThirdParty.Core.Commons;
using Many.ThirdParty.Core.Models.CommonModels;
using Many.ThirdParty.Core.Models.ReadingModels;
using Many.ThirdParty.Core.Tools;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Many.ThirdParty.Core.ViewModels.ReadingDetailPageViewModels
{
    public abstract class ReadingDetailPageViewModelBase : ViewModelBase
    {
        public ReadingDetailPageViewModelBase()
        {
            HotComments = new ObservableCollection<CommentModel>();
            NormalComments = new ObservableCollection<CommentModel>();
            ContentModelCollection = new ObservableCollection<ReadingModelBase>();
        }

        // ReSharper disable once InconsistentNaming
        public string Charge_Edt { get; set; }

        public string PraiseNum { get; set; }

        public string CommentNum { get; set; }

        public string ShareNum { get; set; }

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
            foreach (var item in await DataHelper.GetCommentJsonArrayAsync(uri))
            {
                var tem = JsonConvert.DeserializeObject<CommentModel>(item.Stringify());

                if (tem.Type == "0")
                {
                    this.HotComments.Add(tem);
                }
                else
                {
                    this.NormalComments.Add(tem);
                }
#if DEBUG
                Debug.WriteLine(tem.User.Web_Url);
#endif
            }
        } 
        public ObservableCollection<CommentModel> HotComments { get; set; }

        public ObservableCollection<CommentModel> NormalComments { get; set; }
    }
}
