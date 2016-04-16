using Many.ThirdParty.Config;
using Many.ThirdParty.Core.ViewModels;
using Many.ThirdParty.SubPages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
            ThisNavigate(Convert.ToInt32((sender as Button).Tag));
        }
        
        private void Current_SizeChanged(object sender, WindowSizeChangedEventArgs e)
        {
            ResetWidth();
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
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Window.Current.SizeChanged += Current_SizeChanged;
            mainFrameContainer.Navigated += MainFrameContainer_Navigated;

            ThisNavigate(Convert.ToInt32(homeButton.Tag));

            SystemNavigationManager.GetForCurrentView().BackRequested += MainFrameContainer_BackRequested;
        }

        private void ThisNavigate(int index)
        {
            mainFrameContainer.Navigate(NavigationCommonConfig.MainScenarios[index].PageType);
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
            for (int i = 0; i < 4; i++)
            {
                FootButtonBackgroundImage[i].Source = DelegationCommonConfig.FootButtonSource[i];
            }

            FootButtonBackgroundImage[index].Source = DelegationCommonConfig.FootButtonActivedSource[index];
        }
    }
}
