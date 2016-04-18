using Many.ThirdParty.Core.Data;
using Many.ThirdParty.Core.Models.ReadingModels;
using Many.ThirdParty.Core.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;

namespace Many.ThirdParty.Core.ViewModels
{
    public partial class ReadingPageViewModel
    {
        public ReadingPageViewModel()
        {
            CarouselModelCollection = new ObservableCollection<CarouselModel>();
        }

        public void AddToCollection(CarouselModel model)
        {
            CarouselModelCollection.Add(model);
        }

        public async Task RefreshCollection()
        {
            foreach (var item in await LoadResources.GetCarouselModel())
            {
                AddToCollection(item);
            }
        }
    }

    public partial class ReadingPageViewModel
    {
        //ObservableCollection<CarouselModel> _carouselModelCollection;
        //public ObservableCollection<CarouselModel> CarouselModelCollection
        //{
        //    get { return _carouselModelCollection; }
        //    set
        //    {
        //        SetProperty(ref _carouselModelCollection, value);
        //    }
        //}

        public ObservableCollection<CarouselModel> CarouselModelCollection { get; set; }

    }
}
