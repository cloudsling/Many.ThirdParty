using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Many.ThirdParty.Core.Converter
{
    public class SwitchVisibilityConverter : IValueConverter
    {
        private readonly Dictionary<bool, Visibility> _vis = new Dictionary<bool, Visibility>
        {
            { true , Visibility.Visible },
            { false , Visibility.Collapsed }
        };

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return _vis[(Visibility)value != Visibility.Visible];
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
