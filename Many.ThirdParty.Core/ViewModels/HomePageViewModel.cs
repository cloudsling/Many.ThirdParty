using Many.ThirdParty.Core.Data;
using Many.ThirdParty.Core.Models.HomeModels;
using Many.ThirdParty.Core.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Many.ThirdParty.Core.ViewModels
{
    public class HomePageViewModel : BindableBase
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
            HomeModelCollection.Add(model);
        }
        public async Task AddHomeModel(string contentId)
        {
            AddHomeModel(await ResourcesLoader.LoadHomeModelResourcesAsync(contentId));
        }
    }
}
