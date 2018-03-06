using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteadyMedClient.Models
{
    public class Patient : User
    {
        private HashSet<int> _steadyMedsOwned;
        private SortedSet<MedicationPlan> _plans;

        public Patient()
        {
            _steadyMedsOwned = new HashSet<int>();
            _plans = new SortedSet<MedicationPlan>();
        }

        public HashSet<int> SteadyMedsOwned { get { return _steadyMedsOwned;  } set { _steadyMedsOwned = value; } }
        public SortedSet<MedicationPlan> Plans { get { return _plans; } set { _plans = value; } }

        //ID of the physician this patient is associated with
        public int PhysicianID;
    }
}
