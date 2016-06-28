using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Many.ThirdParty.Core.Models.CommonModels;

namespace Many.ThirdParty.Core.Interface
{
    internal interface IComments
    {
        ObservableCollection<CommentModel> HotComments { get; set; }

        ObservableCollection<CommentModel> NormalComments { get; set; }
    }
}
