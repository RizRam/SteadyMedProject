using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProfileService.Data;
using ProfileService.Models;

namespace ProfileService.Controllers
{
    [Route("api/[controller]")]
    public class PhysicianProfileController : Controller
    {
        private readonly ProfileCollection _collection;

        public PhysicianProfileController(ProfileCollection collection)
        {
            _collection = collection;
        }

        public IEnumerable<Profile> Index()
        {
            return _collection.GetAll();
        }
        
        [HttpGet("{id}", Name = "GetPhysicianPatients")]
        public IEnumerable<Patient> Index(int id)
        {
            Profile phys = _collection.GetProfile(id);
            return phys.Patients;
        }
    }
}