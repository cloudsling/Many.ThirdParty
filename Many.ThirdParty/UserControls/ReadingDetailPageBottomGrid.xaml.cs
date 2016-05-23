using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Many.ThirdParty.Core.ViewModels.ReadingDetailPageViewModels;
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
            DependencyProperty.Register("PraiseNum", typeof(string), typeof(ReadingDetailPageViewModelBase), new PropertyMetadata(0));

        public string CommentNum
        {
            get { return (string)GetValue(CommentNumProperty); }
            set { SetValue(CommentNumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CommentNum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommentNumProperty =
            DependencyProperty.Register("CommentNum", typeof(string), typeof(ReadingDetailPageViewModelBase), new PropertyMetadata(0));

        public string ShareNum
        {
            get { return (string)GetValue(ShareNumProperty); }
            set { SetValue(ShareNumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShareNum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShareNumProperty =
            DependencyProperty.Register("ShareNum", typeof(string), typeof(ReadingDetailPageViewModelBase), new PropertyMetadata(0));


    }
}
