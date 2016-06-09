﻿using System.ComponentModel;
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

        public bool NightModeEnable
        {
            get { return ReadSettings(nameof(NightModeEnable), false); }
            set
            {
                SaveSettings(nameof(NightModeEnable), value);
            }
        }
    }
    
    public partial class Settings : INotifyPropertyChanged
    {
        private static ApplicationDataContainer LocalSettings { get; set; } = ApplicationData.Current.LocalSettings;

        public void SaveSettings(string key, object value, [CallerMemberName]string propertyName = null)
        {
            LocalSettings.Values[key] = value;
            OnPropertyChanged(propertyName);
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

        void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            Volatile.Read(ref PropertyChanged)?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
