using Many.ThirdParty.Core.Models.ReadingModels;
using Many.ThirdParty.Core.ViewModels.ReadingDetailPageViewModels;
using System.Threading.Tasks;

namespace Many.ThirdParty.Core.Factories
{
    public static class ReadingViewModelFactory
    {
        public static async Task<ReadingDetailPageViewModelBase> CreateReadingDetailPageViewModel(ReadingModelBase modelBase)
        {
            return await CreateReadingDetailPageViewModel(modelBase.Type.ToString(), modelBase.Id);
        }

        public static async Task<ReadingDetailPageViewModelBase> CreateReadingDetailPageViewModel(CarouselDetailModel model)
        {
            return await CreateReadingDetailPageViewModel(model.Type, model.Item_Id);
        }

        private static async Task<ReadingDetailPageViewModelBase> CreateReadingDetailPageViewModel(string type, string id)
        {
            switch (type)
            {
                case "3":
                    return await ReadingDetailPageViewModelBase.CreateViewModel<QuestionDetailPageViewModel>(id);
                case "1":
                    return await ReadingDetailPageViewModelBase.CreateViewModel<EssayDetailPageViewModel>(id);
                case "2":
                    return await ReadingDetailPageViewModelBase.CreateViewModel<SerialDetailPageViewModel>(id);
                default:
                    return null;
            }
        }
    }
}
