using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Many.ThirdParty.Core.Models.MovieModels;

namespace Many.ThirdParty.SubPages
{
    public sealed partial class MovieDetailPage : Page
    {
        public MovieDetailPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var temp = e.Parameter as MovieListModel;
            if (temp != null)
            {

            }
        }
    }
}
