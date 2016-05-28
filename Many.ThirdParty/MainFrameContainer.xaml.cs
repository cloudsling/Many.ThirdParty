using Many.ThirdParty.AddlPages;
using Many.ThirdParty.SubPages;
using Many.ThirdParty.Config;
using Many.ThirdParty.Core.Tools;
using Many.ThirdParty.Core.ViewModels;
using System;
using System.Collections.Generic;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
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
            CurrentScenario = NavigationManager.GetScenarioByName[mainFrameContainer.CurrentSourcePageType.Name];

            UpdateContent(CurrentScenario.PageTitle);
            UpdateGenericUI(CurrentScenario.Index);
        }

        private void MainFrameContainer_BackRequested(object sender, BackRequestedEventArgs e)
        {
            switch (mainFrameContainer.SourcePageType.Name)
            {
                case nameof(HomePage): return;
                case nameof(ReadingPage): return;
                case nameof(MusicPage): return;
                case nameof(MoviePage): return;
                default:
                    {
                        if (mainFrameContainer.CanGoBack)
                        {
                            mainFrameContainer.GoBack();
                            e.Handled = true;
                        }
                        return;
                    }
            }
        }

        private void ChangeBackgroundAndNavigate(object sender, RoutedEventArgs e)
        {
            ThisNavigate(Convert.ToInt32((sender as Button).Tag));
        }

        private void Current_SizeChanged(object sender, WindowSizeChangedEventArgs e)
        {
            ResetWidth();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.GeneralNavigate(typeof(SearchPage));
        }

        private void UserButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.GeneralNavigate(typeof(UserPage));
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

        private int CurrentBottomImageIndex { get; set; } = 0;
    }

    /// <summary>
    /// entry and method
    /// </summary>
    public sealed partial class MainFrameContainer : Page
    {
        public MainFrameContainer()
        {
            InitializeViewModel();

            InitializeComponent();
            CurrentMainFrameContainer = this;

            InitializeField();
            ThisNavigate(Convert.ToInt32(homeButton.Tag));

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.RequestedTheme = MainFrameContainerViewModel.AppSettings.NightModeEnable ? ElementTheme.Dark : ElementTheme.Light;
            ModifyStatusBar();

            HomePage.CurrentHomePage.RequestedTheme = this.RequestedTheme;

            Window.Current.SizeChanged += Current_SizeChanged;

            SystemNavigationManager.GetForCurrentView().BackRequested += MainFrameContainer_BackRequested;
        }

        private void ThisNavigate(int index)
        {
            ThisFrameNavigate(NavigationManager.MainScenarios[index].PageType);
        }

        private void ThisFrameNavigate(Type pageType)
        {
            mainFrameContainer.Navigate(pageType);
        }

        private void InitializeViewModel()
        {
            MainFrameContainerViewModel = new MainFrameContainerViewModel();

            ResetWidth();
        }

        private void ResetWidth()
        {
            MainFrameContainerViewModel.WindowCurrentWidth = Window.Current.Bounds.Width;
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
            FootButtonBackgroundImage[CurrentBottomImageIndex].Source = DelegationManager.FootButtonSource[CurrentBottomImageIndex];

            CurrentBottomImageIndex = index;

            FootButtonBackgroundImage[CurrentBottomImageIndex].Source = DelegationManager.FootButtonActivedSource[CurrentBottomImageIndex];
        }

        public void ModifyStatusBar()
        {
            switch (this.RequestedTheme)
            {
                case ElementTheme.Light:
                    StatusBarModifier.SetLightStatusBar();
                    return;
                case ElementTheme.Dark:
                    StatusBarModifier.SetDarkStatusBar();
                    return;
                default:
                    break;
            }
        }
    }
}
