using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Many.ThirdParty.Core.ViewModels;

namespace Many.ThirdParty.SubPages
{
    public sealed partial class MovieDetailPage : Page
    {
        public MovieDetailPageViewModel ViewModel { get; set; }

        public MovieDetailPage()
        {
           // ViewModel = new MovieDetailPageViewModel();

            InitializeComponent();
        }

        protected override   void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel = e.Parameter as MovieDetailPageViewModel;
            //if (model != null)
            //{
            //    await model.LoadMovieStory();
            //    await model.RefreshCommentsCollection(model.Id);
            //}
            //ViewModel = model;
        }
    }
}
