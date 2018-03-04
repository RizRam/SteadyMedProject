using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SteadyMedApiGateway.Models.PatientModel;
using System.ComponentModel;

//Model for the physician that will encapsulate information regarding the physician along with
//references to each patient the physician is responsible for.
namespace SteadyMedApiGateway.Models.PhysicianViewModels
{
    public class PhysicianViewModel
    {
        [DisplayName("ID")]
        //ID of the physician
        public string PhysicianId { get; set; }

        [DisplayName("First Name")]
        //First name of the physician
        public string PhysicianFirstName { get; set; }

        [DisplayName("Last Name")]
        //Last name of the physician
        public string PhysicianLastName { get; set; }

        //List of patients seeing the physician
        public IEnumerable<Patient> Patients { get; set; }
    }
}
