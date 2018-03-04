using System;
using System.Collections.Generic;
using SteadyMedApiGateway.Models.MedicationPlan;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SteadyMedApiGateway.Models.PatientModel
{
    public class Patient
    {
        [DisplayName("Paient ID")]
        //Patients ID
        public int ID { get; set; }

        [DisplayName("First Name")]
        //Patients first name
        public string PatientFirstName { get; set; }

        [DisplayName("Last Name")]
        //Patient's last name
        public string PatientLastName { get; set; }

        [DisplayName("Middle Initial")]
        //Patient's middle name
        public string PatientMiddleName { get; set; }

        [DisplayName("Age")]
        //Patient's age
        public string PatientAge { get; set; }

        //List of medication plans for the patient
        public IEnumerable<PatientMedicationPlan> PatientMedicationPlans;
    }
}
