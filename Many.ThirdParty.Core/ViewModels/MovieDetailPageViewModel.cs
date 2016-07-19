using Many.ThirdParty.Core.Commons;
using Many.ThirdParty.Core.Models.MovieModels;

namespace Many.ThirdParty.Core.ViewModels
{
    public class MovieDetailPageViewModel: ViewModelBase
    {
        public MovieDetailPageViewModel()
        {
            _movieModel = new MovieModel();
        }

        public void RefreshModel(string uri)
        {
            
        }


        private MovieModel _movieModel;
        public MovieModel MovieModel
        {
            get { return _movieModel; }
            set
            {
                SetProperty(ref _movieModel, value);
            }
        }
    }
}
