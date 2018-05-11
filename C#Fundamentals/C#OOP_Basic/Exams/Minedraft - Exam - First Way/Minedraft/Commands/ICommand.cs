using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minedraft.Commands
{
    interface ICommand
    {
       Participant Execute(IList<string> args);
    }
}
