using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteadyMedClient.Models
{
    public class Patient : User, ISteadyMedUser
    {
        public HashSet<int> SteadyMedsOwned { get; set; }
        public SortedSet<MedicationPlan> Plans { get; set; }
    }
}
