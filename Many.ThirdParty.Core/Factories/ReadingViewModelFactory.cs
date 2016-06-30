using Many.ThirdParty.Core.Models.ReadingModels;
using Many.ThirdParty.Core.ViewModels.ReadingDetailPageViewModels;
using System.Threading.Tasks;

namespace Many.ThirdParty.Core.Factories
{
    public static class ReadingViewModelFactory
    {
        public static async Task<ReadingDetailPageViewModelBase> CreateReadingDetailPageViewModel(ReadingModelBase modelBase)
        {
            switch (modelBase.Type)
            {
                case 3:
                    return await ReadingDetailPageViewModelBase.CreateViewModel<QuestionDetailPageViewModel>(modelBase.Id);
                case 1:
                    return await ReadingDetailPageViewModelBase.CreateViewModel<EssayDetailPageViewModel>(modelBase.Id);
                case 2:
                    return await ReadingDetailPageViewModelBase.CreateViewModel<SerialDetailPageViewModel>(modelBase.Id);
                default:
                    return null;
            }
        }

        public static async Task<ReadingDetailPageViewModelBase> CreateReadingDetailPageViewModel(CarouselDetailModel model)
        {
            switch (model.Type)
            {
                case "3":
                    return await ReadingDetailPageViewModelBase.CreateViewModel<QuestionDetailPageViewModel>(model.Item_Id);
                case "1":
                    return await ReadingDetailPageViewModelBase.CreateViewModel<EssayDetailPageViewModel>(model.Item_Id);
                case "2":
                    return await ReadingDetailPageViewModelBase.CreateViewModel<SerialDetailPageViewModel>(model.Item_Id);
                default:
                    return null;
            }
        }
    }
}
