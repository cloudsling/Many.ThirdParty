using Many.ThirdParty.Core.Models.ReadingModels;
using Many.ThirdParty.Core.ViewModels;
using System.Threading.Tasks;

namespace Many.ThirdParty.Core.Factories
{
    public class CarouselDetailPageViewModelFactory
    {
        public static async Task<CarouselDetailPageViewModel> CreateViewModel(CarouselModel model)
        {
            var viewModel = new CarouselDetailPageViewModel(model);

            await viewModel.RefreshCollection(model.Id);

            return viewModel;
        }
    }
}
