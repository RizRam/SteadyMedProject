using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SteadyMedClient.Models;

namespace SteadyMedClient.Controllers
{
    public class PhysicianController : Controller
    {
        private HttpClient httpClient;

        PhysicianController(HttpClient client)
        {
            httpClient = client;
        }
        

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IEnumerable<ServicePatient> patients()
        {
            IEnumerable<ServicePatient> patients = null;

            var serializer = new DataContractJsonSerializer(typeof(List<ServicePatient>));

            var stream = httpClient.GetStreamAsync("");

            stream.Wait();

            patients = serializer.ReadObject(stream.Result) as List<ServicePatient>;

            return patients;
        }
    }
}