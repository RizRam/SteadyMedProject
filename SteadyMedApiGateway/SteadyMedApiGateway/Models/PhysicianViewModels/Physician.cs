using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SteadyMedApiGateway.Models.PatientModel;
using SteadyMedApiGateway.Models.PatientMedicationPlan;

/// <summary>
/// Model to encapulate Physician information.
/// </summary>
namespace SteadyMedApiGateway.Models.PhysicianViewModels
{
    public class Physician : User
    {
        //List of devices meds owned
        public HashSet<int> SteadyMedsOwned { get; set; }

        //List of patients
        public HashSet<Patient> Patients { get; set; }

        //Plans for the physician
        public SortedSet<MedicationPlan> Plans { get; set; }
    }
}
