using System.Collections.Generic;
using Many.ThirdParty.Core.Commons;
using Many.ThirdParty.Core.Models.CommonModels;
using Many.ThirdParty.Core.Models.ReadingModels;
using Many.ThirdParty.Core.Tools;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Many.ThirdParty.Core.Data;
using Many.ThirdParty.Core.Interface;
using static Many.ThirdParty.Core.Tools.UriHelper;

namespace Many.ThirdParty.Core.ViewModels.ReadingDetailPageViewModels
{
    public abstract class ReadingDetailPageViewModelBase : ViewModelBase, IComments
    {
        protected ReadingDetailPageViewModelBase()
        {
            HotComments = new ObservableCollection<CommentModel>();
            NormalComments = new ObservableCollection<CommentModel>();
            RelatedCollection = new ObservableCollection<ReadingModelBase>();
        }

        public string Charge_Edt { get; set; }

        public string PraiseNum { get; set; }

        public string CommentNum { get; set; }

        public string ShareNum { get; set; }

        private ObservableCollection<ReadingModelBase> _relatedCollection;
        public ObservableCollection<ReadingModelBase> RelatedCollection
        {
            get { return _relatedCollection; }
            set
            {
                SetProperty(ref _relatedCollection, value);
            }
        }

        public void AddToCommentsCollection(CommentModel model)
        {
            HotComments.Add(model);
        }

        protected async Task AddToRelatedCollection<T>(string id)
        {
            var uri = GetRelatedUri<T>(id);

            switch (typeof(T).Name)
            {
                case nameof(QuestionDetailPageViewModel):
                    AddToRelatedCollection<QuestionContent, QuestionModel>(
                        await CommonDataLoader.GetGeneralModelsCollectionAsync<QuestionContent>(id, uri));
                    return;
                case nameof(EssayDetailPageViewModel):
                    AddToRelatedCollection<EssayContent, EssayModel>(
                        await CommonDataLoader.GetGeneralModelsCollectionAsync<EssayContent>(id, uri));
                    return;
                case nameof(SerialDetailPageViewModel):
                    AddToRelatedCollection<SerialContent, SerialModel>(
                        await CommonDataLoader.GetGeneralModelsCollectionAsync<SerialContent>(id, uri)
                        );
                    return;
            }
        }

        private void AddToRelatedCollection<T, TM>(IEnumerable<T> col) where T : ReadingContent where TM : ReadingModelBase, new()
        {
            foreach (var content in col)
            {
                ReadingModelBase temp = new TM();
                temp.Content = content;
                RelatedCollection.Add(temp);
            }
        }


        public static async Task<T> CreateViewModel<T>(string id) where T : ReadingDetailPageViewModelBase
        {
            if (string.IsNullOrEmpty(id)) return null;

            var viewModel = JsonConvert.DeserializeObject<T>((await DataHelper.GetJsonObjectAsync(GetUri<T>(id))).Stringify());
            await viewModel.RefreshCommentsCollection(GetCommentUri<T>(id));
            await viewModel.AddToRelatedCollection<T>(id);

            return viewModel;
        }


        public async Task RefreshCommentsCollection(string uri)
        {
            foreach (var item in await DataHelper.GetCommentJsonArrayAsync(uri))
            {
                var tem = JsonConvert.DeserializeObject<CommentModel>(item.Stringify());

                if (tem.Type == "0")
                {
                    HotComments.Add(tem);
                }
                else
                {
                    NormalComments.Add(tem);
                }
            }
        }


        public ObservableCollection<CommentModel> HotComments { get; set; }

        public ObservableCollection<CommentModel> NormalComments { get; set; }
    }
}
