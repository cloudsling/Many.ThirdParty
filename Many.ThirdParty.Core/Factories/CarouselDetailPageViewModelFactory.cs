using Many.ThirdParty.Core.Models.ReadingModels;
using Many.ThirdParty.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Many.ThirdParty.Core.Factories
{
    public class CarouselDetailPageViewModelFactory
    {
        public static async Task<CarouselDetailPageViewModel> CreateViewModel(CarouselModel model)
        {
            CarouselDetailPageViewModel viewModel = new CarouselDetailPageViewModel();

            viewModel.GeneralModel = model;

            await viewModel.RefreshCollection(model.Id);
            
            return viewModel;
        }
    }
}
