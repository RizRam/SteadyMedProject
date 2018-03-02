using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SteadyMedClient.Models
{
    public class User : IdentityUser
    {
        public int UserId { get; set; }
        public string Name { get; set; }

    }
}
