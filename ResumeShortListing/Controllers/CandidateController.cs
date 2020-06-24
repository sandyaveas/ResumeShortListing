using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BAL.Factory;
using BO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ResumeShortListing.Controllers
{
    public class CandidateController : Controller
    {
        private IAppServices _appServices;

        public CandidateController(IAppServices appServices)
        {
            _appServices = appServices;
        }

        public ActionResult Index()
        {
            return View(_appServices.Candidate.GetList());
        }

        public ActionResult Profile()
        {
            return View();
        }

        
        public async Task<ActionResult> GetBasicDetails(int id)
        {
            var candidate = await _appServices.Candidate.GetItemAsync(id);

            return Json(candidate);
        }



        [HttpPost]
        public ActionResult BasicDetails(Candidate candidate)
        {
            bool isSuccess = false;


            if (_appServices.Candidate.Save(candidate) > 0)
            {
                isSuccess = true;
            }

            return Json(new { isSuccess });
        }


        public ActionResult Edit(int id)
        {
            try
            {
                Candidate candidate = _appServices.Candidate.GetItem(id);

                if (candidate is Candidate)
                {
                    return View("Profile", candidate);
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Candidate candidate)
        {
            try
            {

                if (_appServices.Candidate.Save(candidate) > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View("Profile", candidate);
                }

            }
            catch
            {
                return View("Profile", candidate);
            }
        }



        public ActionResult Details(int id)
        {
            try
            {
                Candidate candidate = _appServices.Candidate.GetItem(id);

                if (candidate is Candidate)
                {
                    return View("Profile", candidate);
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete()
        {
            try
            {


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}