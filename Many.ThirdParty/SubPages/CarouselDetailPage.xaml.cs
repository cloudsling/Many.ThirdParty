using Many.ThirdParty.Config;
using Many.ThirdParty.Core.Factories;
using Many.ThirdParty.Core.Models.ReadingModels;
using Many.ThirdParty.Core.ViewModels;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Many.ThirdParty.SubPages
{
    public sealed partial class CarouselDetailPage : Page
    {
        public CarouselDetailPageViewModel ViewModel { get; set; }

        public CarouselDetailPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel = e.Parameter as CarouselDetailPageViewModel ?? new CarouselDetailPageViewModel();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationManager.GoBack(Frame);
        }

        private async void CarouselList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var model = e.ClickedItem as CarouselDetailModel;
             
            NavigationManager.GeneralNavigate(
                NavigationManager.MainScenarios[Convert.ToInt32(model?.Type) + 4].PageType,
                await ReadingViewModelFactory.CreateReadingDetailPageViewModel(model));
        }
    }
}
