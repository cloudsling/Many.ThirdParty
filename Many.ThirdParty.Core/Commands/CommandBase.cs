using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Many.ThirdParty.Core.Commands
{
    public abstract class CommandBase : ICommand
    {
        public Func<object, bool> _canexcute;

        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter)
        {
            return _canexcute(parameter);
        }

        public abstract void Execute(object parameter);

        public void OnCanExecuteChange()
        {
            Volatile.Read(ref CanExecuteChanged)?.Invoke(this, EventArgs.Empty);
        }
    }
}
