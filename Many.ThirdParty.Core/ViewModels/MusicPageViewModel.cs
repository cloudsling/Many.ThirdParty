using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Many.ThirdParty.Core.Commons;
using Many.ThirdParty.Core.Data;
using Many.ThirdParty.Core.Models.MusicModels;

namespace Many.ThirdParty.Core.ViewModels
{
    public class MusicPageViewModel : ViewModelBase
    {
        public MusicPageViewModel()
        {
            MusicModelsCollection = new ObservableCollection<MusicModel>();
        }

        public async Task RefreshMusicCollection(IEnumerable<string> idCol)
        {
            foreach (var id in idCol)
            {
                MusicModelsCollection.Add(await CommonDataLoader.GetGeneralModelAsync<MusicModel>(id));
            }
        }
         
        private ObservableCollection<MusicModel> _musicModelsCollection;
        public ObservableCollection<MusicModel> MusicModelsCollection
        {
            get { return _musicModelsCollection; }
            set
            {
                SetProperty(ref _musicModelsCollection, value);
            }
        } 
    }
}
