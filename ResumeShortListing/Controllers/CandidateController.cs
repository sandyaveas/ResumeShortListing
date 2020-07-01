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
            FillDropDowns();

            return View();
        }

        public ActionResult Edit(int id)
        {
            try
            {
                Candidate candidate = _appServices.Candidate.GetItem(id);

                if (candidate is Candidate)
                {
                    FillDropDowns();

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


        //---------------------BASIC DETAILS-------------------------//
        public async Task<ActionResult> GetBasicDetails(int id)
        {
            var candidate = await _appServices.Candidate.GetItemAsync(id);

            return Json(candidate);
        }

        [HttpPost]
        public ActionResult SaveBasicDetails(Candidate candidate)
        {
            bool isSuccess = false;


            if (_appServices.Candidate.Save(candidate) > 0)
            {
                isSuccess = true;
            }

            return Json(new { isSuccess });
        }


        //---------------------EXPERIENCES-------------------------//
        public async Task<ActionResult> GetExperiences(int id)
        {
            var jobExperiences = await _appServices.JobExperience.GetCandidateListAsync(id);

            return Json(jobExperiences);
        }


        public ActionResult GetExperience(int id)
        {
            var jobExperience = _appServices.JobExperience.GetItem(id);

            return Json(jobExperience);
        }       


        [HttpPost]
        public ActionResult SaveExperience(JobExperience jobExperience)
        {
            bool isSuccess = false;


            if (_appServices.JobExperience.Save(jobExperience) > 0)
            {
                isSuccess = true;
            }

            return Json(new { isSuccess });
        }

        [HttpPost]
        public ActionResult DeleteExperience(int expId)
        {
            bool isSuccess = false;


            if (_appServices.JobExperience.Delete(expId) > 0)
            {
                isSuccess = true;
            }

            return Json(new { isSuccess });
        }


        //---------------------SKILLS-------------------------//
        public async Task<ActionResult> GetSkills(int id)
        {
            var skills = await _appServices.Skill.GetCandidateListAsync(id);

            return Json(skills);
        }


        public ActionResult GetSkill(int id)
        {
            var skill = _appServices.Skill.GetItem(id);

            return Json(skill);
        }


        [HttpPost]
        public ActionResult SaveSkill(Skill skill)
        {
            bool isSuccess = false;


            if (_appServices.Skill.Save(skill) > 0)
            {
                isSuccess = true;
            }

            return Json(new { isSuccess });
        }

        [HttpPost]
        public ActionResult DeleteSkill(int skillId)
        {
            bool isSuccess = false;


            if (_appServices.Skill.Delete(skillId) > 0)
            {
                isSuccess = true;
            }

            return Json(new { isSuccess });
        }


        private void FillDropDowns() 
        {
            //------------------Blood Group-----------------//
            Dictionary<string, string> dicBloodGroup = new Dictionary<string, string>();
            dicBloodGroup.Add("A+", "A+");
            dicBloodGroup.Add("A-", "A-");
            dicBloodGroup.Add("B+", "B+");
            dicBloodGroup.Add("B-", "B-");
            dicBloodGroup.Add("O+", "O+");
            dicBloodGroup.Add("O-", "O-");
            dicBloodGroup.Add("AB+", "AB+");
            dicBloodGroup.Add("AB-", "AB-");
            ViewBag.BloodGroup = dicBloodGroup;

            //------------------Martial Status-----------------//
            Dictionary<string, string> dicMartialStatus = new Dictionary<string, string>();
            dicMartialStatus.Add("U", "Single/UnMarried");
            dicMartialStatus.Add("M", "Married");
            dicMartialStatus.Add("W", "Widowed");
            dicMartialStatus.Add("D", "Divorced");
            dicMartialStatus.Add("S", "Seperated");
            dicMartialStatus.Add("O-", "Other");
            ViewBag.MartialStatus = dicMartialStatus;

        }
    }
};