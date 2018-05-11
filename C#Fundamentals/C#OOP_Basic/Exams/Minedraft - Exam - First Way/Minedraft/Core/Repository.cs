using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minedraft.Core
{
    public class Repository : IRepository
    {
        public Dictionary<string, Harvester> harvesters => new Dictionary<string, Harvester>();
        public Dictionary<string, Provider> providers => new Dictionary<string, Provider>();
        public Dictionary<string, double> energyRequirementMode => new Dictionary<string, double>();
        public Dictionary<string, double> oreOutputMode => new Dictionary<string, double>();

        public void AddParticipant(Participant participant)
        {
            Object typeParticypant = null;

        }
    }
}
