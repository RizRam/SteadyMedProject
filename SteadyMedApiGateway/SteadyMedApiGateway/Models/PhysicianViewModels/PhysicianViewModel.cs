using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SteadyMedApiGateway.Models.PatientModel;

//Model for the physician that will encapsulate information regarding the physician along with
//references to each patient the physician is responsible for.
namespace SteadyMedApiGateway.Models.PhysicianViewModels
{
    public class PhysicianViewModel
    {
        //ID of the physician
        public string PhysicianId { get; set; }

        //First name of the physician
        public string PhysicianFirstName { get; set; }

        //Last name of the physician
        public string PhysicianLastName { get; set; }

        //List of patients seeing the physician
        public IEnumerable<Patient> Patients { get; set; }
    }
}
