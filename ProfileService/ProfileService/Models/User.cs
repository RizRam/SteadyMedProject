using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SteadyMedClient.Models
{
    public class User : IdentityUser
    {
        public int ID { get; set; }
        public string FirstName { get; set; }

        //User's last name
        public string LastName { get; set; }

    }
}
