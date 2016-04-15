using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Many.ThirdParty.Core.ViewModels;
using Windows.UI.Xaml.Shapes;
using Windows.UI;

namespace Many.ThirdParty.SubPages
{
    /// <summary>
    /// auto event
    /// </summary>
    public sealed partial class ReadingPage : Page
    {
        private void fv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = (sender as FlipView).SelectedIndex;

            if (index >= 0 && index <= 8)
            {
                ChangeAllEllipseColor(ManyEllipse.Children, index);
            }
        }
    }

    /// <summary>
    /// field and properties
    /// </summary>
    public sealed partial class ReadingPage : Page
    {
        public ReadingPageViewModel ReadingPageViewModel { get; set; }

        private static ReadingPage CurrentReadingPage;

        private static readonly List<SolidColorBrush> EllipseBackgroundColorCollection = new List<SolidColorBrush> {
            new SolidColorBrush(Colors.SkyBlue),
            new SolidColorBrush(Colors.White),
        };
    }

    /// <summary>
    /// entry and methods
    /// </summary>
    public sealed partial class ReadingPage : Page
    {
        public ReadingPage()
        {
            ReadingPageViewModel = new ReadingPageViewModel();

            InitializeComponent();
            CurrentReadingPage = this;
        }

        /// <summary>
        /// 改变所有的圆点的颜色
        /// </summary>
        /// <param name="CurrentIndex"></param>
        private void ChangeAllEllipseColor(UIElementCollection collection, int currentIndex)
        {
            for (int index = 0; index < collection.Count; index++)
            {
                (collection[index] as Ellipse).Fill = EllipseBackgroundColorCollection[index == currentIndex ? 0 : 1];
            }
        }
    }


}
