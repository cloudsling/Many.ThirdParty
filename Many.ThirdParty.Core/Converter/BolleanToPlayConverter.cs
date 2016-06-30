using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace Many.ThirdParty.Core.Converter
{
    public class BolleanToPlayConverter : IValueConverter
    {
        private static readonly List<BitmapImage> AudioPlayImage = new List<BitmapImage>
        {
            new BitmapImage(new Uri("ms-appx:///Resources/BgImages/play.png")),
            new BitmapImage(new Uri("ms-appx:///Resources/BgImages/pause.png")),
        };

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (bool)value ? AudioPlayImage[0] : AudioPlayImage[1];
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
