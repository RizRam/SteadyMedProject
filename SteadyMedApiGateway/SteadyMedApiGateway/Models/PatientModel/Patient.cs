using System;
using System.Collections.Generic;
using SteadyMedApiGateway.Models.PatientMedicationPlan;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SteadyMedApiGateway.Models.PatientModel
{
    public class Patient : User
    {
        private List<int> _steadyMedsOwned;
        private List<MedicationPlan> _plans;

        public Patient()
        {
            _steadyMedsOwned = new List<int>();
            _plans = new List<MedicationPlan>();
        }

        public List<int> SteadyMedsOwned { get { return _steadyMedsOwned; } set { _steadyMedsOwned = value; } }
        public List<MedicationPlan> Plans { get { return _plans; } set { _plans = value; } }

        //ID of the physician this patient is associated with
        public int PhysicianID;
    }
}
