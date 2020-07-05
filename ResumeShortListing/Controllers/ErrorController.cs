using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ResumeShortListing.Controllers
{
    public class ErrorController : Controller
    {

        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Index()
        {


            return View();
        }

        [Route("Error/{statusCode}")]
        [AllowAnonymous]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:

                    ViewBag.ErroMessage = "Sorry, the resource you requested couldn't be found.";
                
                    break;
            }

            return View("NotFound");
        }


        
    }
}