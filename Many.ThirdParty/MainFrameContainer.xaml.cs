using Many.ThirdParty.Config;
using Many.ThirdParty.Core.ViewModels;
using Many.ThirdParty.SubPages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace Many.ThirdParty
{
    /// <summary>
    /// auto event
    /// </summary>
    public sealed partial class MainFrameContainer : Page
    {
        private void MainFrameContainer_Navigated(object sender, NavigationEventArgs e)
        {
            CurrentScenario = NavigationCommonConfig.GetScenarioByName[mainFrameContainer.CurrentSourcePageType.Name];

            UpdateContent(CurrentScenario.PageTitle);

            UpdateGenericUI(CurrentScenario.Index);
        }

        private void MainFrameContainer_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (mainFrameContainer.CanGoBack)
                mainFrameContainer.GoBack();
            e.Handled = true;
        }

        private void ChangeBackgroundAndNavigate(object sender, RoutedEventArgs e)
        {
            mainFrameContainer.Navigate(NavigationCommonConfig.MainScenarios[Convert.ToInt32((sender as Button).Tag)].PageType);
        }
    }

    /// <summary>
    /// fields and properties
    /// </summary>
    public sealed partial class MainFrameContainer : Page
    {
        public static MainFrameContainer CurrentMainFrameContainer;

        public MainFrameContainerViewModel MainFrameContainerViewModel { get; set; }

        private static List<Image> FootButtonBackgroundImage;

        internal Scenario CurrentScenario { get; set; }

        private static readonly List<BitmapImage> FootButtonSource = new List<BitmapImage> {
          new BitmapImage (new Uri ("ms-appx:///Resources/MFCImages/home.png")),
           new BitmapImage (new Uri ("ms-appx:///Resources/MFCImages/reading.png")),
           new BitmapImage (new Uri ("ms-appx:///Resources/MFCImages/music.png")),
           new BitmapImage (new Uri ("ms-appx:///Resources/MFCImages/movie.png"))
        };

        private static readonly List<BitmapImage> FootButtonActivedSource = new List<BitmapImage> {
           new BitmapImage (new Uri ("ms-appx:///Resources/MFCImages/home_active.png")),
           new BitmapImage (new Uri ("ms-appx:///Resources/MFCImages/reading_active.png")),
           new BitmapImage (new Uri ("ms-appx:///Resources/MFCImages/music_active.png")),
           new BitmapImage (new Uri ("ms-appx:///Resources/MFCImages/movie_active.png"))
        };
    }

    /// <summary>
    /// entry and method
    /// </summary>
    public sealed partial class MainFrameContainer : Page
    {
        public MainFrameContainer()
        {
            MainFrameContainerViewModel = new MainFrameContainerViewModel();

            InitializeComponent();
            CurrentMainFrameContainer = this;

            InitializeField();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            mainFrameContainer.Navigated += MainFrameContainer_Navigated;

            ChangeBackgroundAndNavigate(homeButton, new RoutedEventArgs());

            SystemNavigationManager.GetForCurrentView().BackRequested += MainFrameContainer_BackRequested;
        }

        private static void InitializeField()
        {
            FootButtonBackgroundImage = new List<Image>
            {
                CurrentMainFrameContainer.homeButtonBkImg,
                CurrentMainFrameContainer.readButtonBkImg,
                CurrentMainFrameContainer.musicButtonBkImg,
                CurrentMainFrameContainer.movieButtonBkImg
            };
        }

        private void UpdateContent(string title)
        {
            MainFrameContainerViewModel.PageTitle = title;
        }

        private void UpdateGenericUI(int index)
        {
            if (index < 4)
            {
                MainFrameContainerViewModel.SetBottomNavBtnAndProfileVisibe();
                UpdateBottomButtonUI(index);
            }
            else
            {
                MainFrameContainerViewModel.SetBottomNavBtnAndProfileCollapsed();
            }
        }

        private void UpdateBottomButtonUI(int index)
        {
            for (int i = 0; i < 4; i++)
            {
                FootButtonBackgroundImage[i].Source = FootButtonSource[i];
            }

            FootButtonBackgroundImage[index].Source = FootButtonActivedSource[index];
        }
    }
}
