using Many.ThirdParty.Core.ViewModels;
using Many.ThirdParty.Core.Models.ReadingModels;
using Many.ThirdParty.Config;
using Many.ThirdParty.Core.Factories;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
using Windows.UI;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml;
using System.Diagnostics; 

namespace Many.ThirdParty.SubPages
{
    /// <summary>
    /// auto event
    /// </summary>
    public sealed partial class ReadingPage : Page
    {
        private void fv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GetIndexFromFlipView(sender) >= 0 && GetIndexFromFlipView(sender) <= 8)
            {
                ChangeAllEllipseColor(ManyEllipse.Children, GetIndexFromFlipView(sender));
            }
        }

        private int GetIndexFromFlipView(object sender) => (sender as FlipView).SelectedIndex;

        private int GetIndexFromFlipView() => fv.SelectedIndex;

        private async void MainListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            ReadingModelBase modelBase = e.ClickedItem as ReadingModelBase;

            NavigationManager.GeneralNavigate(
                NavigationManager.MainScenarios[modelBase.Type + 4].PageType,
                await ReadingViewModelFactory.CreateReadingDetailPageViewModel(modelBase));
        }

        private async void BlankButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            NavigationManager.GeneralNavigate(typeof(CarouselDetailPage),
               await CarouselDetailPageViewModelFactory.CreateViewModel(ViewModel.CarouselModelCollection[GetIndexFromFlipView()]));
        }

        private void ScrollViewer_ViewChanging(object sender, ScrollViewerViewChangingEventArgs e)
        {
            if (e.NextView.VerticalOffset == e.FinalView.VerticalOffset) return;

            MainFrameContainer.CurrentMainFrameContainer.MainFrameContainerViewModel.BottomNavBtnAndProfileVisibility
                = e.FinalView.VerticalOffset > e.NextView.VerticalOffset
                ? Visibility.Collapsed : Visibility.Visible;
        }
    }

    /// <summary>
    /// field and properties
    /// </summary>
    public sealed partial class ReadingPage : Page
    {
        public ReadingPageViewModel ViewModel { get; set; }

        private static ReadingPage CurrentReadingPage;

        private static readonly List<SolidColorBrush> EllipseBackgroundColorCollection = new List<SolidColorBrush> {
            new SolidColorBrush(Colors.SkyBlue),
            new SolidColorBrush(Colors.White),
        };
    }

    /// <summary>
    /// entry and methods
    /// </summary>
    public sealed partial class ReadingPage : Page
    {
        public ReadingPage()
        {
            ViewModel = new ReadingPageViewModel();

            InitializeComponent();
            CurrentReadingPage = this;

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            if (ViewModel.CarouselModelCollection.Count <= 0)
            {
                await ViewModel.RefreshCollection();
                // await ViewModel.RefreshListView();
            }
            //MainListView.ItemsSource = ViewModel.ReadingModelCollection;
            RegisterTimer(timer);

            timer.Start();
        }

        private void RegisterTimer(DispatcherTimer timer)
        {
            timer.Interval = TimeSpan.FromMilliseconds(1000 / fps);

            timer.Tick += (p1, p2) =>
            {
                if (GetIndexFromFlipView() == 8)
                    fv.SelectedIndex = 0;
                else
                    fv.SelectedIndex += 1;
#if DEBUG
                Debug.WriteLine(fv.SelectedIndex);
#endif
            };
        }

        private double fps = .2;

        private DispatcherTimer timer = new DispatcherTimer();

        /// <summary>
        /// 改变所有的圆点的颜色
        /// </summary>
        /// <param name="CurrentIndex"></param>
        private void ChangeAllEllipseColor(UIElementCollection collection, int currentIndex)
        {
            for (int index = 0; index < collection.Count; index++)
            {
                (collection[index] as Ellipse).Fill = EllipseBackgroundColorCollection[index == currentIndex ? 0 : 1];
            }
        }

        public static void NavigateToDetail(Type pageType)
        {
            CurrentReadingPage.Frame.Navigate(pageType);
        }
    }
}
