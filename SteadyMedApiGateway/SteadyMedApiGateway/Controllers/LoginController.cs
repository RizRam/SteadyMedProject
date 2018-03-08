using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using SteadyMedApiGateway.Models.LoginViewModels;
using SteadyMedApiGateway.Models;
using SteadyMedApiGateway.Data;

namespace SteadyMedApiGateway.Controllers
{
    public class LoginController : Controller
    {
        //HTTP Client used for REST calls
        private HttpClient httpClient;
        private MyUserManager _userManager;

        //URL of the service
        private const string ACCOUNT_SERVICE_URL = "http://localhost:51195/api/Login";

        public LoginController(HttpClient client, MyUserManager myUserManager)
        {
            httpClient = client;
            _userManager = myUserManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            LoginViewModel model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (model == null) return RedirectToAction("Index");
            string path = $"{ACCOUNT_SERVICE_URL}?userName={model.UserName}&password={model.Password}";

            HttpResponseMessage response = await httpClient.GetAsync(path);

            if (response.IsSuccessStatusCode)
            {
                Account account = null;
                var responseBody = await response.Content.ReadAsStringAsync();
                account = JsonConvert.DeserializeObject<Account>(responseBody);

                _userManager.User = account;

                return RedirectToAction("Details", "Physician", new { id = 1 });
            }
            else
            {
                return Content(response.StatusCode.ToString());
            }
        }

    }
}