using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace Many.ThirdParty.Core.Converter
{
    public class ReadingTypeBtnImageConverter : IValueConverter
    {
        private const string BaseUri = "ms-appx:///Resources/BgImages/";

        private static readonly IList<Uri> ReadingTypeButtonImage = new List<Uri> {
            new Uri(BaseUri + "essay_image.png"),
            new Uri(BaseUri + "serial_image.png"),
            new Uri(BaseUri + "question_image.png")
        };

        private static readonly Dictionary<string, Uri> ImageSource = new Dictionary<string, Uri>
        {
            { "essay",  ReadingTypeButtonImage[0] },
            { "serial",  ReadingTypeButtonImage[1]},
            { "serialcontent", ReadingTypeButtonImage[1]},
            { "question",  ReadingTypeButtonImage[2]},
        };

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var str = value as string;
            if (str != null)
            {
                return ImageSource.ContainsKey(str) ? new BitmapImage(ImageSource[str]) : new BitmapImage(new Uri(str));
            }

            return new BitmapImage(ReadingTypeButtonImage[(int)value - 1]);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
