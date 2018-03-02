using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SteadyMedClient.Models;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace SteadyMedClient.Controllers
{
    public class MedicationPlanController : Controller
    {
        private readonly UserManager<User> _userManager;
        private IConfiguration _configuration;
        private string _steadyMedServiceURL;
        private string _patientServiceURL;

        public MedicationPlanController(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;

            _steadyMedServiceURL = configuration["ServicesConfig:MedPlanService:baseUrl"];
        }


        public IActionResult Index()
        {
            return View();
        }

        //Create A Medication Plan
        [HttpGet]
        public async Task<IActionResult> CreateMedPlan(int? patientId)
        {
            //Authenticate that User is physician
           

            //Check argument
            if (patientId == null) return NotFound();

            //Get Patient
            //Send HttpRequest
            HttpClient client = new HttpClient();
            Uri uri = new Uri(_patientServiceURL + $"/api/Patient/{patientId}");        
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri);
            HttpResponseMessage response = await client.SendAsync(request);

            //Read Http Response
            if (response.IsSuccessStatusCode)
            {
                //JsonSerializerSettings settings = new JsonSerializerSettings();
                String responseString = await response.Content.ReadAsStringAsync();
                Patient patient = JsonConvert.DeserializeObject<Patient>(responseString);

                /*
                Dictionary<String, String> responseElement = JsonConvert.DeserializeObject<Dictionary<String, String>>(responseString);

                //Build Patient object
                Patient patient = new Patient();

                int pid; int.TryParse(responseElement["UserId"], out pid);
                patient.UserId = pid;
                patient.Name = responseElement["Name"];
                patient.SteadyMedsOwned = new HashSet<int>(JsonConvert.DeserializeObject<HashSet<int>>(responseElement["SteadyMedsOwned"]));
                */
                
                

            }






            //Call failed
            return View("Error");
        }
    }
}