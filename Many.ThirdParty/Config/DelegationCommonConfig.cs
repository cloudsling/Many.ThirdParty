using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace Many.ThirdParty.Config
{
    internal static class DelegationCommonConfig
    {
        internal static readonly List<BitmapImage> FootButtonSource = new List<BitmapImage> {
          new BitmapImage (new Uri ("ms-appx:///Resources/MFCImages/home.png")),
           new BitmapImage (new Uri ("ms-appx:///Resources/MFCImages/reading.png")),
           new BitmapImage (new Uri ("ms-appx:///Resources/MFCImages/music.png")),
           new BitmapImage (new Uri ("ms-appx:///Resources/MFCImages/movie.png"))
        };

        internal static readonly List<BitmapImage> FootButtonActivedSource = new List<BitmapImage> {
           new BitmapImage (new Uri ("ms-appx:///Resources/MFCImages/home_active.png")),
           new BitmapImage (new Uri ("ms-appx:///Resources/MFCImages/reading_active.png")),
           new BitmapImage (new Uri ("ms-appx:///Resources/MFCImages/music_active.png")),
           new BitmapImage (new Uri ("ms-appx:///Resources/MFCImages/movie_active.png"))
        };
    }
}
