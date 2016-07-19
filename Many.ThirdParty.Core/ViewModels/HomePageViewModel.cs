using Many.ThirdParty.Core.Commons;
using Many.ThirdParty.Core.Data;
using Many.ThirdParty.Core.Models.HomeModels;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Many.ThirdParty.Core.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        public HomePageViewModel()
        {
            HomeModelCollection = new ObservableCollection<HomeModel>();
        }

        internal static async Task SavePic(object obj)
        {
            var model = obj as HomeModel;
            if (await Saver.SavePic(model.Hp_Title + ".png", model.Hp_Img_Url))
                HomeModel.EndOfMenuFlyoutCommand?.Invoke();
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

        public async Task AddHomeModels(List<string> listId)
        {
            for (int index = 1; index < listId.Count; index++)
            {
                await AddHomeModel(listId[index]);
            }
        }

        public async Task AddHomeModel(string contentId)
        {
            _homeModelCollection.Add(await CommonDataLoader.GetGeneralModelByIdAsync<HomeModel>(contentId));
        }

        public void InsertHomeModel(HomeModel model)
        {
            _homeModelCollection.Insert(0, model);
        }
    }
}
