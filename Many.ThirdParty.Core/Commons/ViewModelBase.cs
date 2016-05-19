using Many.ThirdParty.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Many.ThirdParty.Core.Commons
{
    public class ViewModelBase : BindableBase
    {
        public static Settings _settings;

        public Settings AppSettings
        {
            get
            {
                return _settings;
            }
            private set
            {
                _settings = value;
            }
        }

        public double WindowHeight
        {
            get
            {
                return Window.Current.Bounds.Height;
            }
        }

        public double WindowWidth
        {
            get
            {
                return Window.Current.Bounds.Width;
            }
        }
    }
}
