using Many.ThirdParty.Core.ViewModels;
using Many.ThirdParty.SubPages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    /// Auto event
    /// </summary>
    public sealed partial class MainFrameContainer : Page
    {
        private void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            MainFrameContainerViewModel.CurrentWindowHeight = e.Size.Height;
            MainFrameContainerViewModel.CurrentWindowWidth = e.Size.Width;
        }

        private void ChangeBackgroundAndNavigate(object sender, RoutedEventArgs e)
        {
            currentIndex = Convert.ToInt32((sender as Button).Tag);
            ResettinBackground();
            ChangeSpecificBtnBackground(currentIndex);
            mainFrameContainer.Navigate(CurrentNavigationType[currentIndex]);
        }
    }

    /// <summary>
    /// fields and properties
    /// </summary>
    public sealed partial class MainFrameContainer : Page
    {
        public static MainFrameContainer CurrentMainFrameContainer;
        public static int currentIndex = 0;
        public MainFrameContainerViewModel MainFrameContainerViewModel { get; set; }

        private static readonly List<Type> CurrentNavigationType = new List<Type> {
            typeof(HomePage),
            typeof(ReadingPage),
            typeof(MusicPage),
            typeof(MoviePage)
        };

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
            InitializeViewModel();

            InitializeComponent();
            CurrentMainFrameContainer = this;

            ResettinBackground();
            ChangeBackgroundAndNavigate(homeButton, new RoutedEventArgs());

            Window.Current.SizeChanged += Current_SizeChanged;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }

        private void InitializeViewModel()
        {
            MainFrameContainerViewModel.CurrentWindowHeight = Window.Current.Bounds.Height;
            MainFrameContainerViewModel.CurrentWindowWidth = Window.Current.Bounds.Width;
        }

        private Image GetFootButtonBackgroundImage(int index)
        {
            switch (index)
            {
                case 0:
                    return CurrentMainFrameContainer.homeButtonBkImg;
                case 1:
                    return CurrentMainFrameContainer.readButtonBkImg;
                case 2:
                    return CurrentMainFrameContainer.musicButtonBkImg;
                case 3:
                    return CurrentMainFrameContainer.movieButtonBkImg;
                default:
                    return null;
            }
        }

        private void ResettinBackground()
        {
            for (int i = 0; i < 4; i++)
            {
                GetFootButtonBackgroundImage(i).Source = FootButtonSource[i];
            }
        }

        private void ChangeSpecificBtnBackground(int index)
        {
            GetFootButtonBackgroundImage(index).Source = FootButtonActivedSource[index];
        }
    }
}
