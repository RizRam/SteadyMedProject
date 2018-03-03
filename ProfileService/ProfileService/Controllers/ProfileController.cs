using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProfileService.Models;
using ProfileService.Data;

namespace ProfileService.Controllers
{
    [Route("api/[controller]")]
    public class ProfileController : Controller
    {
        private readonly ProfileCollection _collection;

        public ProfileController(ProfileCollection collection)
        {
            _collection = collection;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Profile> Get()
        {
            return _collection.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
