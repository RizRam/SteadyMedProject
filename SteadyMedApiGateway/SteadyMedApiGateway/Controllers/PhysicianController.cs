using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using SteadyMedApiGateway.Models.PatientModel;
using SteadyMedApiGateway.Models.PhysicianViewModels;
using Newtonsoft.Json;

namespace SteadyMedApiGateway.Controllers
{
    public class PhysicianController : Controller
    {
        private HttpClient httpClient;

        private const string PATIENT_PROFILE_URL = "http://localhost:";

        public PhysicianController(HttpClient client)
        {
            httpClient = client;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            /*
            HttpResponseMessage response = await httpClient.GetAsync(String.Format("{0}/{1}", PATIENT_PROFILE_URL, id));
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                patients = JsonConvert.DeserializeObject<List<Patient>>(responseBody);
            }
            */

            IEnumerable<Patient> patients = new List<Patient>
            {
                new Patient()
                {
                    ID = 1, FirstName = "Joseph", LastName = "Stalin"
                },
                new Patient()
                {
                    ID = 2, FirstName = "Johnson", LastName = "& Johnson"
                },
                new Patient() {
                    ID = 3, FirstName = "Samantha", LastName = "Robinson"
                }
            };

            return View(new PhysicianViewModel(){ Patients = patients });
        }
    }
}