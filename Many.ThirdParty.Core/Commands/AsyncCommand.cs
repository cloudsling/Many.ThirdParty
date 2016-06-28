using Many.ThirdParty.Core.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Many.ThirdParty.Core.Commands
{
    public class AsyncCommand : CommandBase
    {
        public AsyncCommand(Func<object, Task> excute, Func<object, bool> canexcute)
        {
            Excute = excute;
            Canexcute = canexcute;
        }

        public AsyncCommand(Func<object, Task> excute) : this(excute, b => true) { }

        public Func<object, Task> Excute { get; set; }

        public override async void Execute(object parameter)
        {
            await Excute(parameter);
        }
    }
}
