using Many.ThirdParty.Config;
using Many.ThirdParty.Core.Models.MovieModels;
using Many.ThirdParty.Core.Tools;
using Many.ThirdParty.Core.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Many.ThirdParty.Core.Data;
using Many.ThirdParty.Core.Service;

namespace Many.ThirdParty.SubPages
{
    public sealed partial class MoviePage : Page
    {
        public static MoviePage CurrentMoviePage;

        public MoviePageViewModel MoviePageViewModel { get; set; }
    }

    public sealed partial class MoviePage : Page
    {
        public MoviePage()
        {
            MoviePageViewModel = new MoviePageViewModel();

            InitializeComponent();
            CurrentMoviePage = this;
        }

        private async void movieList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = e.ClickedItem as MovieListModel;
            if (item != null)
            {
                //TODO:
                NavigationManager.GeneralNavigate(
                    typeof(MovieDetailPage), 
                    await CommonDataLoader.GetGeneralModelByIdAsync<MovieModel>(string.Format(ServicesUrl.MovieDetail, item.Id)));
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // CurrentMoviePage.MoviePageViewModel.MovieListCollection = await GetList();
        }

    }
}
