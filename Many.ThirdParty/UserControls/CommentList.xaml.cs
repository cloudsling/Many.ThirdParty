using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Many.ThirdParty.Core.Models.CommonModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Many.ThirdParty.UserControls
{
    public sealed partial class CommentList : UserControl
    {
        public CommentList()
        {
            this.InitializeComponent();
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
