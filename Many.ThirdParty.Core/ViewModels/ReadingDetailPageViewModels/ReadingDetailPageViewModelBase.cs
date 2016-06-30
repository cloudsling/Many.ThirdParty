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

        // ReSharper disable once InconsistentNaming
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
                    AddToRelatedCollection(
                        await CommonDataLoader.GetGeneralModelsCollectionAsync<QuestionContent>(id, uri),
                        new QuestionModel(3));
                    return;
                case nameof(EssayDetailPageViewModel):
                    AddToRelatedCollection(
                        await CommonDataLoader.GetGeneralModelsCollectionAsync<EssayContent>(id, uri),
                        new EssayModel(1));
                    return;
                case nameof(SerialDetailPageViewModel):
                    AddToRelatedCollection(
                        await CommonDataLoader.GetGeneralModelsCollectionAsync<SerialContent>(id, uri),
                        new SerialModel(2));
                    return;
            }
        }

        private void AddToRelatedCollection<T>(IEnumerable<T> col, ReadingModelBase modelBase) where T : ReadingContent
        {
            foreach (var content in col)
            {
                modelBase.Content = content;
                RelatedCollection.Add(modelBase);
            }
        }


        public static async Task<T> CreateViewModel<T>(string id) where T : ReadingDetailPageViewModelBase
        {
            if (string.IsNullOrEmpty(id)) return null;

            var viewModel = JsonConvert.DeserializeObject<T>((await DataHelper.GetJsonObjectAsync(GetUri<T>(id))).Stringify());
            await viewModel.AddToCommentsCollection(GetCommentUri<T>(id));
            await viewModel.AddToRelatedCollection<T>(id);

            return viewModel;
        }


        public async Task AddToCommentsCollection(string uri)
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
