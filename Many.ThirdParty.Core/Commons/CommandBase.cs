using System;
using System.Threading;
using System.Windows.Input;

namespace Many.ThirdParty.Core.Commons
{
    public abstract class CommandBase : ICommand
    {
        public Func<object, bool> Canexcute;

        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter)
        {
            return Canexcute(parameter);
        }

        public abstract void Execute(object parameter);

        public void OnCanExecuteChange()
        {
            Volatile.Read(ref CanExecuteChanged)?.Invoke(this, EventArgs.Empty);
        }
    }
}
