using Many.ThirdParty.Core.Commons;
using Many.ThirdParty.Core.Data;
using Many.ThirdParty.Core.Models.ReadingModels;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Many.ThirdParty.Core.ViewModels
{
    public partial class ReadingPageViewModel : BindableBase
    {
        public ReadingPageViewModel()
        {
            CarouselModelCollection = new ObservableCollection<CarouselModel>();

            ReadingModelCollection = new IncrementalLoadingCollection<ReadingModel>(index => CommonDataLoader.GetReadingModel(index.ToString()));
        }

        public void AddToCollection(CarouselModel model)
        {
            CarouselModelCollection.Add(model);
        }

        public async Task RefreshCollection()
        {
            foreach (var item in await CommonDataLoader.GetCarouselModel<CarouselModel>(""))
            {
                AddToCollection(item);
            }
        }

        public int GetCarouselModelCollectionCount() => _readingModelCollection.Count;

        public async Task RefreshListView()
        {
            foreach (var item in await CommonDataLoader.GetReadingModel("0"))
            {
                ReadingModelCollection.Add(item);
            }
        }
    }

    public partial class ReadingPageViewModel : BindableBase
    {
        public ObservableCollection<CarouselModel> CarouselModelCollection { get; set; }

        IncrementalLoadingCollection<ReadingModel> _readingModelCollection;

        public IncrementalLoadingCollection<ReadingModel> ReadingModelCollection
        {
            get { return _readingModelCollection; }
            set
            {
                SetProperty(ref _readingModelCollection, value);
            }
        }
    }
}
