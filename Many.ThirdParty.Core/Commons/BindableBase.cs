﻿namespace Many.ThirdParty.Core.Commons
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public abstract class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propName = null)
        {
            if (Equals(storage, value)) return false;

            storage = value;
            OnPropertyChanged(propName);
            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            Volatile.Read(ref PropertyChanged)?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
