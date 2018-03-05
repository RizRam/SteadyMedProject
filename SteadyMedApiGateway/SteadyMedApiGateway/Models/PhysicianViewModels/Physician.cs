using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SteadyMedApiGateway.Models.PatientModel;
using SteadyMedApiGateway.Models.PatientMedicationPlan;

namespace SteadyMedApiGateway.Models.PhysicianViewModels
{
    public class Physician : User
    {
        public HashSet<int> SteadyMedsOwned { get; set; }
        public HashSet<Patient> Patients { get; set; }
        public SortedSet<MedicationPlan> Plans { get; set; }
    }
}
