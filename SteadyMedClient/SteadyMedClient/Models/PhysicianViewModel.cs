using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteadyMedClient.Models
{
    public class ServicePatient
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class PhysicianViewModel
    {
        public PhysicianViewModel(IEnumerable<ServicePatient> patients)
        {
            this.patients = patients;
        }

        IEnumerable<ServicePatient> patients { get; set; }
    }
}
