using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using SteadyMedApiGateway.Models.PatientModel;
using SteadyMedApiGateway.Models.PhysicianViewModels;
using Newtonsoft.Json;
using SteadyMedApiGateway.Models;
using SteadyMedApiGateway.Data;

/// <summary>
/// Author: Craig Rainey
/// Controller to link the front-end with the service to retrieve patients associated with a physician.
/// </summary>
namespace SteadyMedApiGateway.Controllers
{
    public class PhysicianController : Controller
    {
        //HTTP Client used for REST calls
        private HttpClient httpClient;
        private MyUserManager _userManager;

        //URL of the service
        private const string PATIENT_PROFILE_URL = "http://localhost:56693/api/physicianprofile";

        //Constructor
        public PhysicianController(HttpClient client, MyUserManager myUserManager)
        {
            httpClient = client;
            _userManager = myUserManager;
        }


        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            PhysicianViewModel model = new PhysicianViewModel();

            IEnumerable<Patient> patients = new List<Patient>();
            HttpResponseMessage response = await httpClient.GetAsync(String.Format("{0}/{1}", PATIENT_PROFILE_URL, id));
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                patients = JsonConvert.DeserializeObject<List<Patient>>(responseBody);
            }

            model.Patients = patients;
            model.Name = _userManager.User.Name;

            //return View(new PhysicianViewModel() { Patients = patients });
            return View(model);
        }
    }
}