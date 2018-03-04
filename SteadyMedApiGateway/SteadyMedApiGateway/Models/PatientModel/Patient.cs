using System;
using System.Collections.Generic;
using SteadyMedApiGateway.Models.MedicationPlan;
using System.Linq;
using System.Threading.Tasks;

namespace SteadyMedApiGateway.Models.PatientModel
{
    public class Patient
    {
        //Patients ID
        public int ID { get; set; }

        //Patients first name
        public string PatientFirstName { get; set; }

        //Patient's last name
        public string PatientLastName { get; set; }

        //Patient's middle name
        public string PatientMiddleName { get; set; }

        //Patient's age
        public string PatientAge { get; set; }

        //List of medication plans for the patient
        public IEnumerable<PatientMedicationPlan> PatientMedicationPlans;
    }
}
