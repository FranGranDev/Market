using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Commands
{
    public class ExitAppCommand : CommandBase
    {
        public override void Execute(object parameter)
        {
            App.Current.Shutdown();
        }
    }
}
