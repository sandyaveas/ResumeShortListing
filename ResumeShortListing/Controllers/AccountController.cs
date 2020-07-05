using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BAL.Factory;
using BO;
using Microsoft.AspNetCore.Mvc;

namespace ResumeShortListing.Controllers
{
    public class AccountController : Controller
    {
        private IAppServices _appServices;

        public AccountController(IAppServices appServices)
        {
            _appServices = appServices;
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(LoginInfo loginInfo)
        {
            if(string.IsNullOrEmpty(loginInfo.loginType))
            { return RedirectToAction("Login"); }
            

            if (loginInfo.loginType.ToUpper() == "E")
            {
                var candidate = _appServices.Candidate.GetItem(loginInfo.Email, loginInfo.Password);

                if (candidate != null)
                {
                    

                    return RedirectToAction("Edit", "Candidate", new { id = candidate.Id });
                }
                else 
                {
                    return RedirectToAction("Login");
                }
            }
            else 
            {

            }

            return RedirectToAction("Login");
        }



        public IActionResult RegisterCompany()
        {           

            return View("Register");

        }

        

        public IActionResult RegisterEmployee()
        {

            return View("Register");
        }

        [HttpPost]
        public IActionResult RegisterEmployee(Candidate candidate)
        {

            _appServices.Candidate.Save(candidate);




            return RedirectToAction("Edit", "Candidate", new { id = candidate.Id });

        }


        [HttpPost]
        public IActionResult Register(LoginInfo login)
        {
            if (login.loginType == "E" || login.loginType == "C")
            {

            }

            return Json(true);

        }
    }
}