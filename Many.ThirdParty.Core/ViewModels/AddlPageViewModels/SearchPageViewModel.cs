using Many.ThirdParty.Core.Models.AddlModels;
using Many.ThirdParty.Core.Models.HomeModels;
using Many.ThirdParty.Core.Models.MovieModels;
using Many.ThirdParty.Core.Models.MusicModels;
using Many.ThirdParty.Core.Commands;
using Many.ThirdParty.Core.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Many.ThirdParty.Core.ViewModels.AddlPageViewModels
{
    public partial class SearchPageViewModel : BindableBase
    {
        public SearchPageViewModel()
        {
            SearchCommand = new AsyncCommand(Do);
        }

        async Task Do(object obj)
        {
            await Task.Delay(12);
        }
    }

    /// <summary>
    /// fields and properties
    /// </summary>
    public partial class SearchPageViewModel : BindableBase
    {
        public string SearchContent { get; set; }

        public CommandBase SearchCommand { get; set; }

        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                SetProperty(ref _isActive, value);
            }
        }

        public ObservableCollection<HomeModel> HomeModelCollection { get; set; }

        public ObservableCollection<SearchReadingModel> SearchReadingModelCollection { get; set; }

        public ObservableCollection<MusicModel> MusicModelCollection { get; set; }

        public ObservableCollection<MovieListModel> MovieListModelCollection { get; set; }

        public ObservableCollection<HomeModel> AuthorCollection { get; set; }
    }
}
