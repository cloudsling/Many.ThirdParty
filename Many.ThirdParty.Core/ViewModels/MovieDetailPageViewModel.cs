using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
using System.Threading.Tasks;
using Many.ThirdParty.Core.Commons;
using Many.ThirdParty.Core.Data;
using Many.ThirdParty.Core.Interface;
using Many.ThirdParty.Core.Models.CommonModels;
using Many.ThirdParty.Core.Service;

namespace Many.ThirdParty.Core.ViewModels
{
    public class MovieDetailPageViewModel : ViewModelBase, IComments
    {
        public MovieDetailPageViewModel()
        {
            HotComments = new ObservableCollection<CommentModel>();

            NormalComments = new ObservableCollection<CommentModel>();
        }

        public string Id { get; set; }

        public string Title { get; set; }

        public string IndexCover { get; set; }

        public string DetailCover { get; set; }

        public string Video { get; set; }

        public string Verse { get; set; }

        public string Verse_En { get; set; }

        public string RevisedScore { get; set; }

        public string KeyWords { get; set; }

        public List<string> Photo { get; set; }

        public string Movie_Id { get; set; }

        public string Info { get; set; }

        public string OffcialStory { get; set; }

        public string Charge_Edt { get; set; }

        public string PraiseNum { get; set; }

        public string Sort { get; set; }

        public string Read_Num { get; set; }

        public string ShareNum { get; set; }

        public string CommentNum { get; set; }

        public string ServerTime { get; set; }

        public ObservableCollection<CommentModel> HotComments { get; set; }

        public ObservableCollection<CommentModel> NormalComments { get; set; }

        public async Task RefreshCommentsCollection(string id)
        {
            foreach (var model in await CommonDataLoader.GetGeneralModelsCollectionByUriAsync<CommentModel>(string.Format(ServicesUrl.MovieComment, Id)))
            {
                if (model.Type == "0")
                {
                    HotComments.Add(model);
                }
                else
                {
                    NormalComments.Add(model);
                }
            }
        }
    }
}
