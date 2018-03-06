using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SteadyMedClient.Models;

namespace ProfileService.Controllers
{
    [Route("api/[controller]")]
    public class PhysicianProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet("{id}", Name = "GetPhysicianPatients")]
        public IEnumerable<Patient> Index(int id)
        {
            return new List<Patient>
            {
                new Patient()
                {
                    FirstName = "Justin",
                    LastName = "Gilroy",
                    Email = "justin@example.com",
                    ID = 0,
                    PhysicianID = 1
                },
                new Patient()
                {
                    FirstName = "Rizky",
                    LastName = "Ramdhani",
                    Email = "riz@example.com",
                    ID = 1,
                    PhysicianID = 1
                },
                new Patient()
                {
                    FirstName = "Daniel",
                    LastName = "Blashaw",
                    Email = "daniel@example.com",
                    ID = 2,
                    PhysicianID = 1
                },
                new Patient()
                {
                    FirstName = "Craig",
                    LastName = "Rainey",
                    Email = "craig@myhouse.com",
                    ID = 3,
                    PhysicianID = 1
                }
            };
        }
    }
}