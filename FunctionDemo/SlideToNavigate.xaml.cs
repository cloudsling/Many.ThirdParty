using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace FunctionDemo
{
    public sealed partial class SlideToNavigate : Page
    {
        public SlideToNavigate()
        {
            this.InitializeComponent();
        }

        private void Grid_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            var point = e.Cumulative.Translation;
            var grid = sender as FrameworkElement;

            grid.SetValue(MarginProperty, new Thickness(0, grid.Margin.Top + point.Y, 0, 0));
        }

        private async void Grid_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            await new MessageDialog("Completed!!").ShowAsync();
        }
    }
}
