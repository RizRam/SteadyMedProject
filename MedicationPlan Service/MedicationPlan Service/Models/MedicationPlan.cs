using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicationPlan_Service.Models
{

    /// <summary>
    /// Model for a Medication Plan, which contains informatin
    /// needed for a medication plan
    /// </summary>
    public class MedicationPlan
    {
        //ID for the medication plan
        public int MedicationPlanId { get; set; }

        //ID of the Patient
        public int PatientId { get; set; }

        //ID of the issuing physician
        public int PhysicianId { get; set; }

        //ID of the SteadyMed device assigned for this medication plan
        public int SteadyMedId { get; set; }

        //Name of the medication
        public string Medication { get; set; }

        //Time period to take medication
        public int HourlyInterval { get; set; }

        //Amount of medication to take for each interval
        public int PillsPerInterval { get; set; }

        //Whether the medication plan is completed or ongoing
	    public bool Completed { get; set; }
    }
}
