using Many.ThirdParty.Core.ViewModels;
using Many.ThirdParty.SubPages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Many.ThirdParty
{
    /// <summary>
    /// auto event
    /// </summary>
    public sealed partial class MainFrameContainer : Page
    {
        void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            var size = e.Size;
            MainFrameContainerViewModel.CurrentWindowWidth = size.Width;
            MainFrameContainerViewModel.CurrentWindowHeight = size.Height;
        }

        async void Button_Click(object sender, RoutedEventArgs e)
        {
            await new MessageDialog("!!!!!!!!!!!!!!").ShowAsync();
        }
    }

    /// <summary>
    /// fields and properties
    /// </summary>
    public sealed partial class MainFrameContainer : Page
    {
        public static MainFrameContainer CurrentMainFrameContainer;
        public MainFrameContainerViewModel MainFrameContainerViewModel { get; set; }
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

            InitializeViewModel();
            Window.Current.SizeChanged += Current_SizeChanged;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            // mainFrame.Navigate(typeof(HomePage));
        }

        void InitializeViewModel()
        {
            var rect = Window.Current.Bounds;
            MainFrameContainerViewModel.CurrentWindowWidth = rect.Width;
            MainFrameContainerViewModel.CurrentWindowHeight = rect.Height;
        }
    }
}
