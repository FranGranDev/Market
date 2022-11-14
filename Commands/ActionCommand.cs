using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Commands
{
    public class ActionCommand : CommandBase
    {
        public ActionCommand(Action action)
        {
            this.action = action;
        }

        private readonly Action action;

        public override void Execute(object parameter)
        {
            action?.Invoke();
        }
    }
}
