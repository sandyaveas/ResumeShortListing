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
            if (jobExperience.Id == 0)
            {
                context.JobExperience.Add(jobExperience);                
            }            

            return context.SaveChanges();            
        }


        public List<JobExperience> GetList()
        {
            return context.JobExperience.ToList();
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
