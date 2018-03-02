using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteadyMedClient.Models
{
    //A User of SteadyMed
    interface ISteadyMedUser
    {
        //Collection of SteadyMeds owned
        HashSet<int> SteadyMedsOwned { get; set; }
        SortedSet<MedicationPlan> Plans { get; set; }
    }
}
