using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Many.ThirdParty.Core.Data;
using Many.ThirdParty.Core.Enum;
using Many.ThirdParty.Core.Models.MusicModels;
using Many.ThirdParty.Core.ViewModels;

namespace Many.ThirdParty.SubPages
{
    public sealed partial class MusicPage : Page
    {
        public static MusicPage MusicCurrent { get; private set; }

        public MusicPageViewModel ViewModel { get; set; }

    }

    public sealed partial class MusicPage : Page
    {
        public MusicPage()
        {
            ViewModel = new MusicPageViewModel();
            InitializeComponent();

            MusicCurrent = this;
            NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter == null)
            {
                await ViewModel.RefreshMusicCollection(await CommonDataLoader.GetGeneralList("0", ListType.MusicList));
                //await ViewModel.AddTo 
            }
            else if(e.Parameter is MusicModel)
            {
                await ViewModel.RefreshAMusicCollection(((MusicModel)e.Parameter).Id);
            }
        }
    }
}
