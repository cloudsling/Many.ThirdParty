using Many.ThirdParty.Core.ViewModels.ReadingDetailPageViewModels;
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
 
namespace Many.ThirdParty.SubPages.ReadingDetailPage
{ 
    public sealed partial class EssayDetailPage : Page
    {
        public EssayDetailPageViewModel ViewModel { get; set; }

        public EssayDetailPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel = e.Parameter as EssayDetailPageViewModel ?? new EssayDetailPageViewModel();
        }
    }
}
