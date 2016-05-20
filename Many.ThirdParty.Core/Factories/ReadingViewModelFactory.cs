using Many.ThirdParty.Core.Models.AddlModels;
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
                    return await QuestionDetailPageViewModel.CreateViewModel(modelBase.Id);
                case 1:
                    return await EssayDetailPageViewModel.CreateViewModel(modelBase.Id);
                case 2:
                    return await SerialDetailPageViewModel.CreateViewModel(modelBase.Id);//连载
                default:
                    return null;
            }
        }

        public static async Task<ReadingDetailPageViewModelBase> CreateReadingDetailPageViewModel(CarouselDetailModel model)
        {
            switch (model.Type)
            {
                case "3":
                    return await QuestionDetailPageViewModel.CreateViewModel(model.Item_Id);
                case "1":
                    return await EssayDetailPageViewModel.CreateViewModel(model.Item_Id);
                case "2":
                    return await SerialDetailPageViewModel.CreateViewModel(model.Item_Id);//连载
                default:
                    return null;
            }
        }
    }
}
