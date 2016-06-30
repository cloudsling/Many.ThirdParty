using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Many.ThirdParty.Core.Models.CommonModels;

namespace Many.ThirdParty.Core.Interface
{
    internal interface IComments
    {
        ObservableCollection<CommentModel> HotComments { get; set; }

        ObservableCollection<CommentModel> NormalComments { get; set; }

        Task RefreshCommentsCollection(string id);
    }
}
