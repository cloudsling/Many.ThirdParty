using Many.ThirdParty.Core.Data;
using Many.ThirdParty.Core.Models.ReadingModels;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Many.ThirdParty.Core.ViewModels
{
    public class CarouselDetailPageViewModel : ICarousel
    {
        public CarouselDetailPageViewModel(CarouselModel generalModel) : this()
        {
            Title = generalModel.Title;
            Cover = generalModel.Cover;
            Bottom_Text = generalModel.Bottom_Text;
            BgColor = generalModel.BgColor; 
        }
        public CarouselDetailPageViewModel()
        {
            CarouselDetailModelCollection = new ObservableCollection<CarouselDetailModel>();
        }

        public async Task RefreshCollection(string id)
        {
            foreach (var item in await CommonDataLoader.GetGeneralModelsCollectionByIdAsync<CarouselDetailModel>(id))
            {
                CarouselDetailModelCollection.Add(item);
            }
            CarouselDetailModel.ResetIndex();
        }

        public string Title { get; set; }

        public string Cover { get; set; }

        public string Bottom_Text { get; set; }

        public string BgColor { get; set; } 

        public ObservableCollection<CarouselDetailModel> CarouselDetailModelCollection { get; set; }
    }
}
