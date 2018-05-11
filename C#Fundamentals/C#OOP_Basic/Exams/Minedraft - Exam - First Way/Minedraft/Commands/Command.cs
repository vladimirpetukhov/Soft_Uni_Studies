using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minedraft.Commands
{
    public abstract class Command 
    {
        
       

        public Command(List<string> args)
        {
            this.CommandArgs = args;
        }

        public IList<string> CommandArgs { get; set; }
        
    }
}
