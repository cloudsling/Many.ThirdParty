using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Many.ThirdParty.Core.Converter
{
    public class ReadingTypeBtnImageConverter : IValueConverter
    {
        private static readonly IList<Uri> ReadingTypeButtonImage = new List<Uri> {
            new Uri("ms-appx:///Resources/BgImages/essay_image.png"),
            new Uri("ms-appx:///Resources/BgImages/serial_image.png"),
            new Uri("ms-appx:///Resources/BgImages/question_image.png")
        };

        private static readonly Dictionary<string, Uri> ImageSource = new Dictionary<string, Uri>
        {
            { "essay",  ReadingTypeButtonImage[0] },
            { "serial",  ReadingTypeButtonImage[1]},
            { "question",  ReadingTypeButtonImage[2]},
        };

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if ((value as string) != null)
            {
                if (ImageSource.ContainsKey(value as string))
                    return new BitmapImage(ImageSource[value as string]);
                return new BitmapImage(ReadingTypeButtonImage[0]);
            }
            return new BitmapImage(ReadingTypeButtonImage[(int)value - 1]);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
