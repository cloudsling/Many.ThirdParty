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
            ViewModel = new MovieDetailPageViewModel();

            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                var model = e.Parameter as MovieDetailPageViewModel;
                if (model != null)
                {
                    Wv.Navigate(new System.Uri("http://m.wufazhuce.com/movie/" + model.Id));
                    // ViewModel = model;
                }


            }



        }
    }
}
