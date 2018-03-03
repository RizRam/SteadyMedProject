using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteadyMedClient.Models
{
    public class Physician : User, ISteadyMedUser, IHealthCarePerson
    {
        public HashSet<int> SteadyMedsOwned { get; set; }
        public HashSet<Patient> Patients { get; set; }
        public SortedSet<MedicationPlan> Plans { get; set; }
    }
}
