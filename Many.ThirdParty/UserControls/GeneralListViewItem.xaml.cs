using Many.ThirdParty.Core.Commons;
using Many.ThirdParty.Core.Themes;
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
         
        public IColorsCollection Colors
        {
            get { return (IColorsCollection)GetValue(ColorsProperty); }
            set { SetValue(ColorsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColorsProperty =
            DependencyProperty.Register("Colors", typeof(IColorsCollection), typeof(GeneralListViewItem), new PropertyMetadata(1));

         
    }
}
