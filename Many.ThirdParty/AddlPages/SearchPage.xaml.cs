using Many.ThirdParty.Config;
using Many.ThirdParty.Core.Models.HomeModels;
using Many.ThirdParty.Core.ViewModels.AddlPageViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Many.ThirdParty.AddlPages
{
    /// <summary>
    /// auto event
    /// </summary>
    public sealed partial class SearchPage : Page
    {
        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var model = sender as HomeModel;
        }

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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            StartAnimation.Begin();
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
