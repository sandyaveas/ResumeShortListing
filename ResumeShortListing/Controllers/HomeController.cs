using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BAL;
using BAL.Factory;
using BO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace ResumeShortListing.Controllers
{
    public class HomeController : Controller
    {        
        public IAppServices _appServices { get; }

        public HomeController(IAppServices appServices)
        {
            _appServices = appServices;            
        }        

        public IActionResult Index()
        {           

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }        
    }
}
