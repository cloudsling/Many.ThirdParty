using Many.ThirdParty.Core.ViewModels.ReadingDetailPageViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Many.ThirdParty.UserControls
{
    public sealed partial class ReadingDetailPageBottomGrid : UserControl
    {
        public ReadingDetailPageBottomGrid()
        {
            this.InitializeComponent();
        }
         
        public string PraiseNum
        {
            get { return (string)GetValue(PraiseNumProperty); }
            set { SetValue(PraiseNumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PraiseNum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PraiseNumProperty =
            DependencyProperty.Register("PraiseNum", typeof(string), typeof(ReadingDetailPageBottomGrid), new PropertyMetadata(0));

        public string CommentNum
        {
            get { return (string)GetValue(CommentNumProperty); }
            set { SetValue(CommentNumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CommentNum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommentNumProperty =
            DependencyProperty.Register("CommentNum", typeof(string), typeof(ReadingDetailPageBottomGrid), new PropertyMetadata(0));

        public string ShareNum
        {
            get { return (string)GetValue(ShareNumProperty); }
            set { SetValue(ShareNumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShareNum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShareNumProperty =
            DependencyProperty.Register("ShareNum", typeof(string), typeof(ReadingDetailPageBottomGrid), new PropertyMetadata(0));


    }
}
