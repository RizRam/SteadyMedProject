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
        
        [HttpGet("{id:int}/patients", Name = "GetPhysicianPatients")]
        public IEnumerable<Patient> Index(int id)
        {
            return new List<Patient>
            {
                new Patient()
                {
                    Name = "Joe",
                    Email = "joe@myhouse.com",
                    UserId = 0
                },
                new Patient()
                {
                    Name = "Joe",
                    Email = "joe@myhouse.com",
                    UserId = 1
                },
                new Patient()
                {
                    Name = "Joe",
                    Email = "joe@myhouse.com",
                    UserId = 2
                },
                new Patient()
                {
                    Name = "Joe",
                    Email = "joe@myhouse.com",
                    UserId = 3
                }
            };
        }
    }
}