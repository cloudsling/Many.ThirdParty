using System.Collections.ObjectModel;
using Many.ThirdParty.Core.Models.CommonModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Many.ThirdParty.UserControls
{
    public sealed partial class CommentList : UserControl
    {
        public CommentList()
        {
            InitializeComponent();
        }

        public ObservableCollection<CommentModel> CommentModelCollection
        {
            get { return (ObservableCollection<CommentModel>)GetValue(CommentModelCollectionProperty); }
            set { SetValue(CommentModelCollectionProperty, value); }
        }
         
        public static readonly DependencyProperty CommentModelCollectionProperty =
            DependencyProperty.Register("CommentModelCollection", typeof(ObservableCollection<CommentModel>), typeof(CommentList), new PropertyMetadata(0));


    }
}
