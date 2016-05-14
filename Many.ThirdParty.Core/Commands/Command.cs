using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Many.ThirdParty.Core.Commands
{
    public class Command : CommandBase
    {
        public Action<object> _excute;

        public Command(Action<object> excute, Func<object, bool> canexcute)
        {
            _excute = excute;
            _canexcute = canexcute;
        }

        public Command(Action<object> excute) : this(excute, b => true) { }
        
        public override void Execute(object parameter)
        {
            _excute(parameter);
        }
    }
}
