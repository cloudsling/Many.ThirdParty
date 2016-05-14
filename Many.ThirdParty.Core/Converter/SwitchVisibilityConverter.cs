using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Many.ThirdParty.Core.Converter
{
    public class SwitchVisibilityConverter : IValueConverter
    {
        Dictionary<bool, Visibility> vis = new Dictionary<bool, Visibility>
        {
            { true , Visibility.Visible },
            { false , Visibility.Collapsed }
        };

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return vis[(Visibility)value != Visibility.Visible];
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
