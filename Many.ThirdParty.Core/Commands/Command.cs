using Many.ThirdParty.Core.Commons;
using System;

namespace Many.ThirdParty.Core.Commands
{
    public class Command : CommandBase
    {
        public Action<object> Excute;

        public Command(Action<object> excute, Func<object, bool> canexcute)
        {
            Excute = excute;
            Canexcute = canexcute;
        }

        public Command(Action<object> excute) : this(excute, b => true) { }
        
        public override void Execute(object parameter) => Excute(parameter);
    }
}
