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
                    return await QuestionDetailPageViewModel.CreateQuestionDetailPageViewModel(modelBase.Id);
                case 1:
                    return await EssayDetailPageViewModel.CreateQuestionDetailPageViewModel(modelBase.Id);
                case 2:
                    return await SerialDetailPageViewModel.CreateQuestionDetailPageViewModel(modelBase.Id);//连载
                default:
                    return null;
            }
        }

    }
}
