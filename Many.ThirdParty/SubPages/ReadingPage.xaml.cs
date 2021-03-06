﻿using Many.ThirdParty.Core.ViewModels;
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

namespace Many.ThirdParty.SubPages
{
    /// <summary>
    /// auto event
    /// </summary>
    public sealed partial class ReadingPage
    {
        private const int CarouselCount = 6;
        private void fv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GetIndexFromFlipView(sender) >= 0 && GetIndexFromFlipView(sender) <= CarouselCount)
            {
                ChangeAllEllipseColor(
                    GetIndexFromFlipView(sender),
                    ManyEllipse.Children);
            }
        }

        private static int GetIndexFromFlipView(object sender)
        {
            return (sender as FlipView)?.SelectedIndex ?? 0;
        }

        private int GetIndexFromFlipView() => Fv.SelectedIndex;

        private async void MainListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var modelBase = e.ClickedItem as ReadingModelBase;

            if (modelBase == null) return;

            NavigationManager.GeneralNavigate(
                NavigationManager.MainScenarios[modelBase.Type + 4].PageType,
                await ReadingViewModelFactory.CreateReadingDetailPageViewModel(modelBase));
        }

        private async void BlankButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.GeneralNavigate(typeof(CarouselDetailPage),
               await CarouselDetailPageViewModelFactory.CreateViewModel(ViewModel.CarouselModelCollection[GetIndexFromFlipView()]));
        }
    }

    /// <summary>
    /// field and properties
    /// </summary>
    public sealed partial class ReadingPage
    {
        public ReadingPageViewModel ViewModel { get; set; }

        private static ReadingPage _currentReadingPage;

        private static readonly IList<SolidColorBrush> EllipseBackgroundColorCollection = new List<SolidColorBrush> {
            new SolidColorBrush(Colors.SkyBlue),
            new SolidColorBrush(Colors.White)
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
            _currentReadingPage = this;

            NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            if (ViewModel.CarouselModelCollection.Count <= 0)
            {
                await ViewModel.RefreshCollection();
            }

            RegisterTimer(_timer, ViewModel.CarouselModelCollection.Count - 1);

            _timer.Start();
        }

        private const double Fps = .2;

        private readonly DispatcherTimer _timer = new DispatcherTimer();

        private void RegisterTimer(DispatcherTimer timer, int count)
        {
            if (timer == null)
                throw new ArgumentNullException(nameof(timer));

            timer.Interval = TimeSpan.FromMilliseconds(1000 / Fps);

            timer.Tick += (p1, p2) =>
            {
                if (GetIndexFromFlipView() == count)
                    Fv.SelectedIndex = 0;
                else
                    Fv.SelectedIndex += 1;
            };
        }

        /// <summary>
        /// 改变所有的圆点的颜色
        /// </summary>
        /// <param name="currentIndex"></param>
        /// <param name="collection"></param>
        private static void ChangeAllEllipseColor(int currentIndex, UIElementCollection collection)
        {
            for (int index = 0; index < collection.Count; index++)
            {
                var ellipse = collection[index] as Ellipse;
                if (ellipse != null)
                    ellipse.Fill = EllipseBackgroundColorCollection[index == currentIndex ? 0 : 1];
            }
        }

        public static void NavigateToDetail(Type pageType)
        {
            _currentReadingPage.Frame.Navigate(pageType);
        }
    }
}
