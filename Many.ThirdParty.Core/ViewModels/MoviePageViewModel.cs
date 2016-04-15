using System;
using Many.ThirdParty.Core.Models.MovieModels;
using System.Collections.ObjectModel;
using Windows.ApplicationModel;
using Many.ThirdParty.Core.Tools;

namespace Many.ThirdParty.Core.ViewModels
{
    public class MoviePageViewModel : BindableBase
    {
        public MoviePageViewModel()
        {
            MovieListCollection = new ObservableCollection<MovieListModel>();
#if DEBUG
            if (DesignMode.DesignModeEnabled)
            {
                MovieListCollection.Add(new MovieListModel
                {
                    Cover = "ms-appx:///Resources/Test/cover.png",
                    Id = "34",
                    Title = "卧虎藏龙2：青冥宝剑",
                    Score = "39"
                });
                MovieListCollection.Add(new MovieListModel
                {
                    Cover = "ms-appx:///Resources/Test/cover.png",
                    Id = "34",
                    Title = "卧虎藏龙2：青冥宝剑",
                    Score = "39"
                });
            }
#endif
        }
        
        ObservableCollection<MovieListModel> _movieListCollection;
        public ObservableCollection<MovieListModel> MovieListCollection
        {
            get { return _movieListCollection; }
            set
            {
                SetProperty(ref _movieListCollection, value);
            }
        }
    }
}
