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
    public class PersonalDetailServices
    {
        ResumeShortListingDBContext context;

        public PersonalDetailServices()
        {
            context = new ResumeShortListingDBContext();
        }

        public int Save(PersonalDetail personalDetail)
        {
            if (personalDetail.CandidateId == 0)
            {
                context.PersonalDetail.Add(personalDetail);                
            }            

            return context.SaveChanges();            
        }


        public List<PersonalDetail> GetList()
        {
            return context.PersonalDetail.ToList();
        }

        public PersonalDetail GetItem(int CandidateId)
        {
            return context.PersonalDetail.Where(a => a.CandidateId == CandidateId).FirstOrDefault();
        }

        public int Delete(int CandidateId)
        {
            int retVal = 0;
            PersonalDetail personalDetail = context.PersonalDetail.Where(a => a.CandidateId == CandidateId).FirstOrDefault();

            if (personalDetail != null)
            {
                context.PersonalDetail.Remove(personalDetail);
                retVal = context.SaveChanges();
            }
            else
            { retVal = -1; }

            return retVal;
        }

    }
}
