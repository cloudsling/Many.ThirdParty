using Many.ThirdParty.Core.Data;
using Many.ThirdParty.Core.Themes;
using System;
using Windows.UI.Xaml;

namespace Many.ThirdParty.Core.Commons
{
    public class ViewModelBase : BindableBase, IThemeMode
    {
        private static Settings _settings = new Settings();

        protected static event Action<IColorsCollection> OnThemeChanged;

        public ViewModelBase()
        {
            if (_settings == null) _settings = new Settings();

            if (_colorsCollection == null)
            {
                if (_settings.NightModeEnable)
                {
                    _colorsCollection = new NightModeColorsCollection();
                }
                else
                {
                    _colorsCollection = new DayModeColorsCollection();
                }
            }
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

        public void ChangeThemeMode()
        {
            _settings.NightModeEnable = !_settings.NightModeEnable;

            if (_settings.NightModeEnable)
            {
                ColorsCollection = nightColorsCollection;
            }
            else
            {
                ColorsCollection = dayColorsCollection;
            }
            //OnThemeChanged?.Invoke(ColorsCollection);
        } 

        protected static NightModeColorsCollection nightColorsCollection = new NightModeColorsCollection();
        protected static DayModeColorsCollection dayColorsCollection = new DayModeColorsCollection();

        protected static IColorsCollection _colorsCollection;

        public static IColorsCollection GetCurrentColorsCollection() => _colorsCollection;

        public IColorsCollection ColorsCollection
        {
            get { return _colorsCollection; }
            set
            {
                SetProperty(ref _colorsCollection, value);
                OnThemeChanged?.Invoke(_colorsCollection);
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
