using Many.ThirdParty.Core.Commons;
using Many.ThirdParty.Core.Data;
using Many.ThirdParty.Core.Models.HomeModels;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using Many.ThirdParty.Core.Commands;

namespace Many.ThirdParty.Core.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        public HomePageViewModel()
        {
            HomeModelCollection = new ObservableCollection<HomeModel>();
            SavePicCommand = new AsyncCommand(SavePic);
        }

       internal static async Task SavePic(object obj)
        {
            var model = obj as HomeModel;
            await Saver.SavePic(model.Hpcontent_Id, model.Hp_Img_Url);
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
            _homeModelCollection.Add(await CommonDataLoader.LoadHomeModelAsync(contentId));
        }

        public void InsertHomeModel(HomeModel model)
        {
            _homeModelCollection.Insert(0, model);
        }

        public CommandBase SavePicCommand { get; set; }
    }
}
