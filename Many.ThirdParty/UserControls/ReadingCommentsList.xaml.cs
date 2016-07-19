using System.Collections.ObjectModel;
using Many.ThirdParty.Core.Models.CommonModels;
using Many.ThirdParty.Core.Models.ReadingModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Many.ThirdParty.UserControls
{
    public sealed partial class ReadingCommentsList : UserControl
    {
        public ReadingCommentsList()
        {
            InitializeComponent();
        }

        public Visibility Vis => ContentModelCollection == null || ContentModelCollection.Count <= 0 ? Visibility.Collapsed : Visibility.Visible;

        public ObservableCollection<ReadingModelBase> ContentModelCollection
        {
            get { return (ObservableCollection<ReadingModelBase>)GetValue(ContentModelCollectionProperty); }
            set { SetValue(ContentModelCollectionProperty, value); }
        }

        public ObservableCollection<CommentModel> HotComments
        {
            get { return (ObservableCollection<CommentModel>)GetValue(HotCommentsProperty); }
            set { SetValue(HotCommentsProperty, value); }
        }

        public ObservableCollection<CommentModel> NormalComments
        {
            get { return (ObservableCollection<CommentModel>)GetValue(NormalCommentsProperty); }
            set { SetValue(NormalCommentsProperty, value); }
        }

        public static readonly DependencyProperty ContentModelCollectionProperty =
            DependencyProperty.Register("ContentModelCollection", typeof(ObservableCollection<ReadingModelBase>), typeof(ReadingCommentsList), new PropertyMetadata(2));

        public static readonly DependencyProperty HotCommentsProperty =
            DependencyProperty.Register("HotComments", typeof(ObservableCollection<CommentModel>), typeof(ReadingCommentsList), new PropertyMetadata(0));

        public static readonly DependencyProperty NormalCommentsProperty =
            DependencyProperty.Register("NormalComments", typeof(ObservableCollection<CommentModel>), typeof(ReadingCommentsList), new PropertyMetadata(1));

    }
}
