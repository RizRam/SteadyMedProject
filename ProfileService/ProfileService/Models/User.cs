using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ProfileService.Models
{
    public class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }

        //User's last name
        public string LastName { get; set; }

    }
}
