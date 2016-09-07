using Many.ThirdParty.Config;
using Many.ThirdParty.Core.Models.MovieModels;
using Many.ThirdParty.Core.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Many.ThirdParty.Core.Data;
using Many.ThirdParty.Core.Service;

namespace Many.ThirdParty.SubPages
{
    public sealed partial class MoviePage
    {
        public static MoviePage CurrentMoviePage;

        public MoviePageViewModel MoviePageViewModel { get; set; }
    }

    public sealed partial class MoviePage
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
                //TODO://MovieStoryData
                NavigationManager.GeneralNavigate(
                    typeof(MovieDetailPage),
                    await MovieStoryData.CreateViewModel(string.Format(ServicesUrl.MovieDetail, item.Id)));
                //NavigationManager.GeneralNavigate(
                //    typeof(MovieDetailPage),
                //    await CommonDataLoader.GetGeneralModelByUriAsync<MovieDetailPageViewModel>(string.Format(ServicesUrl.MovieDetail, item.Id)));
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // CurrentMoviePage.MoviePageViewModel.MovieListCollection = await GetList();
        }

    }
}
