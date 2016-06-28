using Many.ThirdParty.Core.Models.MusicModels;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;
using Many.ThirdParty.Core.Data;
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
            if (ViewModel.MusicModelsCollection.Count <= 0)
            {
                await ViewModel.RefreshMusicCollection(await CommonDataLoader.GetGeneralList("0", ListType.MusicList));

            }
        }
    }
}
