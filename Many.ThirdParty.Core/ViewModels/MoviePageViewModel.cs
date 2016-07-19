using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Many.ThirdParty.Core.Models.MovieModels;
using Windows.ApplicationModel;
using Windows.Data.Json;
using Many.ThirdParty.Core.Commons;
using Many.ThirdParty.Core.Data;
using Many.ThirdParty.Core.Interface;

namespace Many.ThirdParty.Core.ViewModels
{
    public class MoviePageViewModel : BindableBase
    {
        public MoviePageViewModel()
        {
            MovieListCollection = new IncrementalLoadingCollection<MovieListModel>(CommonDataLoader.GetMovieListModel);
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

        IncrementalLoadingCollection<MovieListModel> _movieListCollection;
        public IncrementalLoadingCollection<MovieListModel> MovieListCollection
        {
            get { return _movieListCollection; }
            set
            {
                SetProperty(ref _movieListCollection, value);
            }
        }
    }
}
