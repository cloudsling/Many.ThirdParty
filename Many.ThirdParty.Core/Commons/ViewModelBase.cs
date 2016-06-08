using Many.ThirdParty.Core.Data;
using System;
using Windows.UI.Xaml;

namespace Many.ThirdParty.Core.Commons
{
    public class ViewModelBase : BindableBase
    {
        private static Settings _settings = new Settings();

    
        public ViewModelBase()
        {
            if (_settings == null) _settings = new Settings();
        }

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
         

        public void ChangeThemeMode(ElementTheme theme)
        {
            _settings.NightModeEnable = theme == ElementTheme.Dark;
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
