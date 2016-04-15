using Many.ThirdParty.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

namespace Many.ThirdParty.UserControls
{
    public sealed partial class ReadingPageSemanticZoom : UserControl
    {
        public ReadingPageSemanticZoom()
        {
            ReadingPageViewModel = new ReadingPageSemanticZoomViewModel();

            this.InitializeComponent();
        }

        public ReadingPageSemanticZoomViewModel ReadingPageViewModel { get; set; }

        //private static readonly List<SolidColorBrush> EllipseBackgroundColorCollection = new List<SolidColorBrush> {
        //    new SolidColorBrush(Colors.SkyBlue),
        //    new SolidColorBrush(Colors.White),
        //};
        //private void fv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    int index = (sender as FlipView).SelectedIndex;

        //    if (index >= 0 && index <= 8)
        //    {
        //        // ChangeAllEllipseColor(ManyEllipse.Children, index);
        //    }
        //}

        ///// <summary>
        ///// 改变所有的圆点的颜色
        ///// </summary>
        ///// <param name="CurrentIndex"></param>
        //private void ChangeAllEllipseColor(UIElementCollection collection, int currentIndex)
        //{
        //    for (int index = 0; index < collection.Count; index++)
        //    {
        //        (collection[index] as Ellipse).Fill = EllipseBackgroundColorCollection[index == currentIndex ? 0 : 1];
        //    }
        //}
    }
}
