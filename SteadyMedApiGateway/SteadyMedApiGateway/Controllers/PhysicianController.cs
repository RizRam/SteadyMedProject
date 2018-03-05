﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using SteadyMedApiGateway.Models.PatientModel;
using SteadyMedApiGateway.Models.PhysicianViewModels;

namespace SteadyMedApiGateway.Controllers
{
    public class PhysicianController : Controller
    {
        private HttpClient httpClient;

        public PhysicianController(HttpClient client)
        {
            httpClient = client;
        }

        [HttpGet]
        public IActionResult Index()
        {
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

            //IEnumerable<ServicePatient> patients = null;

            //var serializer = new DataContractJsonSerializer(typeof(List<ServicePatient>));

            //var stream = httpClient.GetStreamAsync("");

            //stream.Wait();

            //patients = serializer.ReadObject(stream.Result) as List<ServicePatient>;

            return View(new PhysicianViewModel(){ Patients = patients });
        }
    }
}