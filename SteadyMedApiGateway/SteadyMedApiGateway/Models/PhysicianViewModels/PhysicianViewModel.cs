using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SteadyMedApiGateway.Models.PatientModel;
using System.ComponentModel;

/// <summary>
/// View model for the physician's. This contains information regarding the Physician along with a list of patients
/// that are associated with the Physician.
/// </summary>
namespace SteadyMedApiGateway.Models.PhysicianViewModels
{
    public class PhysicianViewModel
    {
        //ID of the physician
        [DisplayName("ID")]
        public string PhysicianId { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        //First name of the physician
        [DisplayName("First Name")]
        public string PhysicianFirstName { get; set; }

        //Last name of the physician
        [DisplayName("Last Name")]
        public string PhysicianLastName { get; set; }

        //List of patients seeing the physician
        public IEnumerable<Patient> Patients { get; set; }
    }
}
