using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Many.ThirdParty.Core.Converter
{
    public class ReadingTypeBtnImageConverter : IValueConverter
    {
        private static readonly IList<string> ReadingTypeButtonImage = new List<string> {
            "ms-appx:///Resources/BgImages/essay_image.png",
            "ms-appx:///Resources/BgImages/serial_image.png",
            "ms-appx:///Resources/BgImages/question_image.png"
        };

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ReadingTypeButtonImage[(int)value - 1];
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
