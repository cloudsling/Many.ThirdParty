using Many.ThirdParty.Core.Data;
using Many.ThirdParty.Core.Models.ReadingModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Many.ThirdParty.Core.ViewModels
{
    public class CarouselDetailPageViewModel
    {
        public CarouselDetailPageViewModel()
        {
            CarouselDetailModelCollection = new ObservableCollection<CarouselDetailModel>();
        }

        public async Task RefreshCollection(string id)
        {
            foreach (var item in await CommonDataLoader.GetCarouselModel<CarouselDetailModel>(id))
            {
                CarouselDetailModelCollection.Add(item);
            }
        }

        public CarouselModel GeneralModel { get; set; }

        public ObservableCollection<CarouselDetailModel> CarouselDetailModelCollection { get; set; }
    }
}
