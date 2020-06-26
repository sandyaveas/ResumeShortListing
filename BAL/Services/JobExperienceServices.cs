using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BO;
using DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BAL.Services
{
    public class JobExperienceServices
    {
        ResumeShortListingDBContext context;

        public JobExperienceServices()
        {
            context = new ResumeShortListingDBContext();
        }

        public int Save(JobExperience jobExperience)
        {
                       
            jobExperience.LastUpdated = DateTime.Now;

            if (jobExperience.Id == 0)
            {
                jobExperience.Created = DateTime.Now;

                context.JobExperience.Add(jobExperience);
            }
            else
            {
                context.JobExperience.Update(jobExperience);                
            }

            

            return context.SaveChanges();            
        }

        public List<JobExperience> GetList(int id)
        {
            return context.JobExperience.Where(a => a.Id == id).ToList();
        }

        public async Task<List<JobExperience>> GetListAsync(int id)
        {
            return await context.JobExperience.Where(a => a.Id == id).ToListAsync();
        }


        public List<JobExperience> GetCandidateList(int CandidateId)
        {
            return context.JobExperience.Where(a => a.CandidateId == CandidateId).ToList();
        }

        public async Task<List<JobExperience>> GetCandidateListAsync(int CandidateId)
        {
            return await context.JobExperience.Where(a=> a.CandidateId == CandidateId).ToListAsync();
        }

        public JobExperience GetItem(int Id)
        {
            return context.JobExperience.Where(a => a.Id == Id).FirstOrDefault();
        }

        public int Delete(int Id)
        {
            int retVal = 0;
            JobExperience jobExperience = context.JobExperience.Where(a => a.Id == Id).FirstOrDefault();

            if (jobExperience != null)
            {
                context.JobExperience.Remove(jobExperience);
                retVal = context.SaveChanges();
            }
            else
            { retVal = -1; }

            return retVal;
        }

    }
}
