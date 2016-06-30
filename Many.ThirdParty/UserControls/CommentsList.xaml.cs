using System.Collections.ObjectModel;
using Many.ThirdParty.Core.Models.CommonModels;
using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Many.ThirdParty.Core.Models.ReadingModels;

namespace Many.ThirdParty.UserControls
{
    public sealed partial class CommentsList : UserControl
    {
        public CommentsList()
        {
            this.InitializeComponent();
        }

        //public ObservableCollection<ReadingModelBase> ContentModelCollection
        //{
        //    get { return (ObservableCollection<ReadingModelBase>)GetValue(ContentModelCollectionProperty); }
        //    set { SetValue(ContentModelCollectionProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for ContentModelCollection.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty ContentModelCollectionProperty =
        //    DependencyProperty.Register("ContentModelCollection", typeof(ObservableCollection<ReadingModelBase>), typeof(CommentsList), new PropertyMetadata(2));


        public ObservableCollection<CommentModel> HotComments
        {
            get { return (ObservableCollection<CommentModel>)GetValue(HotCommentsProperty); }
            set { SetValue(HotCommentsProperty, value); }
        }

        public static readonly DependencyProperty HotCommentsProperty =
            DependencyProperty.Register("HotComments", typeof(ObservableCollection<CommentModel>), typeof(CommentsList), new PropertyMetadata(0));

        public ObservableCollection<CommentModel> NormalComments
        {
            get { return (ObservableCollection<CommentModel>)GetValue(NormalCommentsProperty); }
            set { SetValue(NormalCommentsProperty, value); }
        }

        public static readonly DependencyProperty NormalCommentsProperty =
            DependencyProperty.Register("NormalComments", typeof(ObservableCollection<CommentModel>), typeof(CommentsList), new PropertyMetadata(1));

        private async void ScrollViewer_DragOver(object sender, DragEventArgs e)
        {
            await new MessageDialog("DragOver!!!!").ShowAsync();
        }

        private async void ScrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            await new MessageDialog("ViewChaanged!!!!").ShowAsync();
        }
    }
}
