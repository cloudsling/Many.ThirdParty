using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using Windows.Storage;

namespace Many.ThirdParty.Core.Data
{
    /// <summary>
    /// porperties
    /// </summary>
    public partial class Settings : INotifyPropertyChanged
    {
        public double GeneralFontSize
        {
            get { return ReadSettings(nameof(GeneralFontSize), 25); }
            set
            {
                SaveSettings(nameof(GeneralFontSize), value);
            }
        }

        public bool FirstTimeOpen
        {
            get { return ReadSettings(nameof(FirstTimeOpen), true); }
            set
            {
                SaveSettings(nameof(FirstTimeOpen), value);
            }
        }

        public bool NightModeEnable
        {
            get { return ReadSettings(nameof(NightModeEnable), false); }
            set
            {
                SaveSettings(nameof(NightModeEnable), value);
            }
        }

        public bool SkipPreLoadPage
        {
            get { return ReadSettings(nameof(SkipPreLoadPage), false); }
            set
            {
                SaveSettings(nameof(SkipPreLoadPage), value);
            }
        }
        public bool LiveTileWithImage
        {
            get { return ReadSettings(nameof(LiveTileWithImage), false); }
            set
            {
                SaveSettings(nameof(LiveTileWithImage), value);
            }
        }
    }
    
    public partial class Settings : INotifyPropertyChanged
    {
        private static ApplicationDataContainer LocalSettings { get; } = ApplicationData.Current.LocalSettings;

        public void SaveSettings(string key, object value, [CallerMemberName]string propertyName = null)
        {
            LocalSettings.Values[key] = value;
            if (propertyName != null) OnPropertyChanged(propertyName);
        }

        T ReadSettings<T>(string key, T defaultValue)
        {
            if (LocalSettings.Values.ContainsKey(key))
            {
                return (T)LocalSettings.Values[key];
            }
            if (defaultValue != null)
            {
                return defaultValue;
            }
            return default(T);
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            Volatile.Read(ref PropertyChanged)?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

