using Many.ThirdParty.Core.Commons;
using Many.ThirdParty.Core.Data;
using Many.ThirdParty.Core.Models.HomeModels;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Many.ThirdParty.Core.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        public HomePageViewModel()
        {
            HomeModelCollection = new ObservableCollection<HomeModel>();
        }

        ObservableCollection<HomeModel> _homeModelCollection;
        public ObservableCollection<HomeModel> HomeModelCollection
        {
            get { return _homeModelCollection; }
            set
            {
                SetProperty(ref _homeModelCollection, value);
            }
        }

        public void AddHomeModel(HomeModel model)
        {
            _homeModelCollection.Add(model);
        }
        public async Task AddHomeModel(string contentId)
        {
            _homeModelCollection.Add(await CommonDataLoader.LoadHomeModelAsync(contentId));
        }

        public void InsertHomeModel(HomeModel model)
        {
            _homeModelCollection.Insert(0, model);
        }
    }
}
