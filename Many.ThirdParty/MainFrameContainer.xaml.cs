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
using Windows.UI.Xaml.Navigation;

namespace Many.ThirdParty
{
    /// <summary>
    /// Auto event
    /// </summary>
    public sealed partial class MainFrameContainer : Page
    {
        void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            var size = e.Size;
            MainFrameContainerViewModel.CurrentWindowHeight = size.Height;
            MainFrameContainerViewModel.CurrentWindowWidth = size.Width;
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
            InitializeViewModel();

            InitializeComponent();
            CurrentMainFrameContainer = this;

            Window.Current.SizeChanged += Current_SizeChanged;
        }
        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
           // mainFrame.Navigate(typeof(HomePage));
        }

        void InitializeViewModel()
        {
            MainFrameContainerViewModel.CurrentWindowHeight = Window.Current.Bounds.Height;
            MainFrameContainerViewModel.CurrentWindowWidth = Window.Current.Bounds.Width;
        }
    }
}
