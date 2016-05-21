using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Many.ThirdParty.UserControls
{
    public sealed partial class GeneralListViewItem : UserControl
    {
        public GeneralListViewItem()
        { 
            this.InitializeComponent();
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(GeneralListViewItem), new PropertyMetadata(0));
        
    }
}
