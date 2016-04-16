using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FunctionDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainViewModel MainViewModel { get; set; }

        public MainPage()
        {
            MainViewModel = new MainViewModel();


            this.InitializeComponent();
            var X = Window.Current.Bounds.Height;

            
        }


        public double WindowCurrentBoundsHeight
        {
            get
            {
                return Window.Current.Bounds.Height;
            }
            set { }
        }
        public double WindowCurrentBoundsWidth
        {
            get
            {
                return Window.Current.Bounds.Width;
            }
            set { }
        }
        //private void Grid_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        //{
        //    if (e.Cumulative.Translation.X < 0)
        //    {
        //        MainViewModel.Visable = Visibility.Collapsed;
        //        fv.SelectedIndex += 1;
        //        return;
        //    }

        //    LeftGrid.Width += e.Cumulative.Translation.X / 12;
        //}

        //private async void Grid_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        //{
        //    while (LeftGrid.Width > 0)
        //    {
        //        await Task.Delay(1);
        //        LeftGrid.Width -= LeftGrid.Width / 25;

        //        if (LeftGrid.Width < 3)
        //            LeftGrid.Width = 0.0;
        //    }
        //    //DispatcherTimer timer = new DispatcherTimer();
        //    //timer.Interval = new TimeSpan(1);
        //    //timer.Tick += Timer_Tick;
        //    //timer.Start();
        //}

        //private void Timer_Tick(object sender, object e)
        //{
        //    if (LeftGrid.Width > 0)
        //    {
        //        LeftGrid.Width -= LeftGrid.Width / 10;
        //    }
        //}

        private void fv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as FlipView).SelectedIndex == 0)
            {
                MainViewModel.Visable = Visibility.Visible;
            }
        }
    }

    public class MainViewModel : BindableBase
    {
        public MainViewModel()
        {
            SourcePath = new ObservableCollection<string>
            {
                "ms-appx:///Assets/test.jpg",
                "ms-appx:///Assets/test.jpg",
                "ms-appx:///Assets/test.jpg",
                "ms-appx:///Assets/test.jpg",
                "ms-appx:///Assets/test.jpg",
                "ms-appx:///Assets/test.jpg"
            };
            Visable = Visibility.Visible;
        }


        Visibility _visable;
        public Visibility Visable
        {
            get { return _visable; }
            set
            {
                SetProperty(ref _visable, value);
            }
        }

        public ObservableCollection<string> SourcePath { get; set; }
    }


    public abstract class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propName = null)
        {
            if (Equals(storage, value))
            {
                return false;
            }
            storage = value;
            OnPropertyChanged(propName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            var temp = Volatile.Read(ref PropertyChanged);
            if (temp != null)
            {
                temp(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
