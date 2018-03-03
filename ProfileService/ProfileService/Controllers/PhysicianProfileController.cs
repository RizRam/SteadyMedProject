using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProfileService.Controllers
{
    public class PhysicianProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}