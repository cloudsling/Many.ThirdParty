using Many.ThirdParty.Core.Data;
using Windows.UI.Xaml;

namespace Many.ThirdParty.Core.Commons
{
    public class ViewModelBase : BindableBase
    {
        public static Settings CurrentSettings { get; private set; } = new Settings();
        
        public ViewModelBase()
        {
            if (CurrentSettings == null) CurrentSettings = new Settings();
        }

        public Settings AppSettings => CurrentSettings;
         
        public void ChangeThemeMode(ElementTheme theme) => CurrentSettings.NightModeEnable = theme == ElementTheme.Dark;

        public double WindowHeight => Window.Current.Bounds.Height;

        public double WindowWidth => Window.Current.Bounds.Width;
    }
}
