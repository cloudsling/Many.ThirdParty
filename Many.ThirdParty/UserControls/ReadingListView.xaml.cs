using System.Collections.ObjectModel;
using Many.ThirdParty.Config;
using Many.ThirdParty.Core.Factories;
using Many.ThirdParty.Core.Models.ReadingModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Many.ThirdParty.UserControls
{
    public sealed partial class ReadingListView : UserControl
    {
        public ReadingListView()
        {
            this.InitializeComponent();
        }

        private async void MainListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            ReadingModelBase modelBase = e.ClickedItem as ReadingModelBase;

            NavigationManager.GeneralNavigate(
                NavigationManager.MainScenarios[modelBase.Type + 4].PageType,
                await ReadingViewModelFactory.CreateReadingDetailPageViewModel(modelBase));
        }

        public ObservableCollection<ReadingModelBase> ContentModelCollection
        {
            get { return (ObservableCollection<ReadingModelBase>)GetValue(ContentModelCollectionProperty); }
            set { SetValue(ContentModelCollectionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ContentModelCollection.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContentModelCollectionProperty =
            DependencyProperty.Register("ContentModelCollection", typeof(ObservableCollection<ReadingModelBase>), typeof(ReadingListView), new PropertyMetadata(0));


    }
}
