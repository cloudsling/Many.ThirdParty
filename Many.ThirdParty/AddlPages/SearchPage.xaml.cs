using Many.ThirdParty.Config;
using Many.ThirdParty.Core.Models.AddlModels;
using Many.ThirdParty.Core.ViewModels.AddlPageViewModels;
using Many.ThirdParty.Core.ViewModels.ReadingDetailPageViewModels;
using Many.ThirdParty.SubPages;
using Many.ThirdParty.SubPages.ReadingDetailPage;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Many.ThirdParty.AddlPages
{
    /// <summary>
    /// auto event
    /// </summary>
    public sealed partial class SearchPage : Page
    {
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateSearchButtonsUI(sender as Button);
            UpdateListViewVisibility(MappingToListView[sender as Button]);
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.GoBack(this.Frame);
        }

        private void HpList_ItemClick(object sender, ItemClickEventArgs e)
        {
            NavigationManager.GeneralNavigate(typeof(HomePage), e.ClickedItem);
        }

        private async void ReadingList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var model = e.ClickedItem as SearchReadingModel;
            
            switch (model.Type)
            {
                case "essay":
                    NavigationManager.GeneralNavigate(typeof(EssayDetailPage), await EssayDetailPageViewModel.CreateViewModel(model.Id));
                    return;
                case "question":
                    NavigationManager.GeneralNavigate(typeof(QuestionDetailPage), await QuestionDetailPageViewModel.CreateViewModel(model.Id));
                    return;
                case "serialcontent":
                    NavigationManager.GeneralNavigate(typeof(SerialDetailPage), await SerialDetailPageViewModel.CreateViewModel(model.Id));
                    return;
                default:
                    return;
            }
        }

        private void MusicList_ItemClick(object sender, ItemClickEventArgs e)
        {
            NavigationManager.GeneralNavigate(typeof(MusicPage), e.ClickedItem);
        }

        private void MovieList_ItemClick(object sender, ItemClickEventArgs e)
        {
            NavigationManager.GeneralNavigate(typeof(MovieDetailPage), e.ClickedItem);
        }

        private void AuthorList_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        
        private void SearchContent_KeyUp(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
                ViewModel.Search(SearchContent.Text);
        }
    }

    /// <summary>
    /// entry
    /// </summary>
    public sealed partial class SearchPage : Page
    {
        public SearchPage()
        {
            ViewModel = new SearchPageViewModel();
            this.InitializeComponent();
            InitializeFields();

            NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        void InitializeFields()
        {
            CurrentButton = Hp;
            CurrentListView = HpList;

            MappingToListView = new Dictionary<Button, ListView>
            {
                { Hp, HpList },
                { Reading, ReadingList },
                { Music, MusicList },
                { Movie, MovieList },
                { Author, AuthorList }
            };
        }

        private void UpdateListViewVisibility(ListView sender)
        {
            CurrentListView.Visibility = Visibility.Collapsed;

            CurrentListView = sender;

            CurrentListView.Visibility = Visibility.Visible;
        }

        private void UpdateSearchButtonsUI(Button sender)
        {
            CurrentButton.Foreground = unselectColorBrush;

            CurrentButton = sender;

            CurrentButton.Foreground = selectedColorBrush;
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            StartAnimation.Begin();
            await Task.Delay(400);
            SearchContent.Focus(FocusState.Pointer);
        } 
    }

    public sealed partial class SearchPage : Page
    {
        private SearchPageViewModel ViewModel { get; set; }

        private static SolidColorBrush selectedColorBrush = new SolidColorBrush(Color.FromArgb(0xFF, 142, 182, 230));
        private static SolidColorBrush unselectColorBrush = new SolidColorBrush(Color.FromArgb(0xFF, 51, 51, 51));

        private Button CurrentButton;

        private ListView CurrentListView;

        private Dictionary<Button, ListView> MappingToListView;
    }
}
