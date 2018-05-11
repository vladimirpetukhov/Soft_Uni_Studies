using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minedraft.Core
{
   public interface IRepository
    {
        Dictionary<string, Harvester> harvesters { get; }
        Dictionary<string, Provider> providers { get; }
        Dictionary<string, double> energyRequirementMode { get; }
        Dictionary<string, double> oreOutputMode { get; }

        void AddParticipant(Participant participant);
    }
}
