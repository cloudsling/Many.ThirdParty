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
using Many.ThirdParty.Core.Data;
using Many.ThirdParty.Core.Models.CommonModels;
using Many.ThirdParty.Core.Commons;

namespace Many.ThirdParty.Core.ViewModels.AddlPageViewModels
{
    public partial class SearchPageViewModel : ViewModelBase
    {
        public SearchPageViewModel()
        {
            UpdateUI(Visibility.Visible, false);

            NoSearchResult = Visibility.Collapsed;
            //SearchCommand = new AsyncCommand(Search);
            SearchCommand = new Command(Search);

            HomeModelCollection = new ObservableCollection<HomeModel>();
            SearchReadingModelCollection = new ObservableCollection<SearchReadingModel>();
            MusicModelCollection = new ObservableCollection<MusicModel>();
            MovieListModelCollection = new ObservableCollection<MovieListModel>();
            AuthorCollection = new ObservableCollection<Author>();
        }

        public async void Search(object obj)
        {
            UpdateUI(Visibility.Collapsed, true);

            await AddToCollection(HomeModelCollection, obj as string);

            await SearchOther(obj as string);

            IsActive = false;
        }

        async Task SearchOther(string searchContent)
        {
            await AddToCollection(SearchReadingModelCollection, searchContent);
            await AddToCollection(MusicModelCollection, searchContent);
            await AddToCollection(MovieListModelCollection, searchContent);
            await AddToCollection(AuthorCollection, searchContent);
        }

        async Task AddToCollection<T>(ObservableCollection<T> collection, string searchContent) where T : class, new()
        {
            foreach (var item in await Searcher<T>.Search(searchContent))
            {
                collection.Add(item);
                await Task.Delay(1);
            }
        }

        void UpdateUI(Visibility vis, bool isActive)
        {
            Visable = vis;
            IsActive = isActive;
        }

    }

    /// <summary>
    /// fields and properties
    /// </summary>
    public partial class SearchPageViewModel : ViewModelBase
    {
        public string SearchContent { get; set; }

        public CommandBase SearchCommand { get; set; }

        public CommandBase ShowResult { get; set; }

        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                SetProperty(ref _isActive, value);
            }
        }

        Visibility _visable;
        public Visibility Visable
        {
            get { return _visable; }
            set
            {
                SetProperty(ref _visable, value);
            }
        }

        Visibility _noSearchResult;
        public Visibility NoSearchResult
        {
            get { return _noSearchResult; }
            set
            {
                SetProperty(ref _noSearchResult, value);
            }
        }

        public ObservableCollection<HomeModel> HomeModelCollection { get; set; }

        public ObservableCollection<SearchReadingModel> SearchReadingModelCollection { get; set; }

        public ObservableCollection<MusicModel> MusicModelCollection { get; set; }

        public ObservableCollection<MovieListModel> MovieListModelCollection { get; set; }

        public ObservableCollection<Author> AuthorCollection { get; set; }
    }
}
