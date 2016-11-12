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
using Many.ThirdParty.Core.Tasks;
// ReSharper disable All

namespace Many.ThirdParty
{
    /// <summary>
    /// auto event
    /// </summary>
    public sealed partial class MainFrameContainer
    {
        private void MainFrameContainer_Navigated(object sender, NavigationEventArgs e)
        {
            CurrentScenario = NavigationManager.GetScenarioByName[MainFrameFrameContainer.CurrentSourcePageType.Name];

            UpdateContent(CurrentScenario.PageTitle);
            UpdateGenericUi(CurrentScenario.Index);
        }

        private void MainFrameContainer_BackRequested(object sender, BackRequestedEventArgs e)
        {
            switch (MainFrameFrameContainer.SourcePageType.Name)
            {
                case nameof(HomePage): return;
                case nameof(ReadingPage): return;
                case nameof(MusicPage): return;
                case nameof(MoviePage): return;
                default:
                    {
                        if (MainFrameFrameContainer.CanGoBack)
                        {
                            MainFrameFrameContainer.GoBack();
                            e.Handled = true;
                        }
                        return;
                    }
            }
        }

        private void ChangeBackgroundAndNavigate(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null) ThisNavigate(Convert.ToInt32(button.Tag));
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
    public sealed partial class MainFrameContainer
    {
        public static MainFrameContainer CurrentMainFrameContainer;

        public MainFrameContainerViewModel MainFrameContainerViewModel { get; set; }

        private static List<Image> _footButtonBackgroundImage;

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
            ThisNavigate(Convert.ToInt32(HomeButton.Tag));

            NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            RequestedTheme = MainFrameContainerViewModel.AppSettings.NightModeEnable ? ElementTheme.Dark : ElementTheme.Light;
            ModifyStatusBar();

            HomePage.CurrentHomePage.RequestedTheme = RequestedTheme;

            Window.Current.SizeChanged += Current_SizeChanged;

            SystemNavigationManager.GetForCurrentView().BackRequested += MainFrameContainer_BackRequested;
            await LiveTileTask.RequestUpdate();
        }
        
        private void ThisNavigate(int index)
        {
            ThisFrameNavigate(NavigationManager.MainScenarios[index].PageType);
        }

        private void ThisFrameNavigate(Type pageType)
        {
            MainFrameFrameContainer.Navigate(pageType);
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
            _footButtonBackgroundImage = new List<Image>
            {
                CurrentMainFrameContainer.HomeButtonBkImg,
                CurrentMainFrameContainer.ReadButtonBkImg,
                CurrentMainFrameContainer.MusicButtonBkImg,
                CurrentMainFrameContainer.MovieButtonBkImg
            };
        }

        private void UpdateContent(string title)
        {
            MainFrameContainerViewModel.PageTitle = title;
        }

        private void UpdateGenericUi(int index)
        {
            if (index < 4)
            {
                MainFrameContainerViewModel.SetBottomNavBtnAndProfileVisibe();
                UpdateBottomButtonUi(index);
            }
            else
            {
                MainFrameContainerViewModel.SetBottomNavBtnAndProfileCollapsed();
            }
        }

        private void UpdateBottomButtonUi(int index)
        {
            _footButtonBackgroundImage[CurrentBottomImageIndex].Source = DelegationManager.FootButtonSource[CurrentBottomImageIndex];

            CurrentBottomImageIndex = index;

            _footButtonBackgroundImage[CurrentBottomImageIndex].Source = DelegationManager.FootButtonActivedSource[CurrentBottomImageIndex];
        }

        public void ModifyStatusBar()
        {
            switch (RequestedTheme)
            {
                case ElementTheme.Light:
                    StatusBarModifier.SetLightStatusBar();
                    return;
                case ElementTheme.Dark:
                    StatusBarModifier.SetDarkStatusBar();
                    return;
            }
        }

        public void ChangeNotifyUserMessage(string message)
        {
            NotifyUserMessage.Text = message;
        }

        public static void NotifyUser(string message)
        {
            CurrentMainFrameContainer.ChangeNotifyUserMessage(message);
            CurrentMainFrameContainer.NotifyUserAnimation.Begin();
        }
    }
}
