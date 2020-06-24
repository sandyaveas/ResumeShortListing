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
    public class CandidateServices
    {
        ResumeShortListingDBContext context;

        public CandidateServices()
        {
            context = new ResumeShortListingDBContext();
        }

        public int Save(Candidate candidate)
        {

            candidate.LoggedInAt = DateTime.Now;
            candidate.LastUpdated = DateTime.Now;

            if (candidate.Id == 0)
            {
                candidate.Created = DateTime.Now;

                context.Candidate.Add(candidate);
            }
            else
            {
                context.Candidate.Update(candidate);

                //var cntxtCandidate = context.Candidate.Where(a => a.Id == candidate.Id).FirstOrDefault();

                //if (cntxtCandidate is Candidate)
                //{
                //    cntxtCandidate = candidate;
                //}
            }




            return context.SaveChanges();
        }


        public List<Candidate> GetList()
        {
            return context.Candidate.ToList();
        }

        public Candidate GetItem(int Id)
        {
            return context.Candidate.Where(a => a.Id == Id).FirstOrDefault();
        }

        public async Task<Candidate> GetItemAsync(int Id)
        {
            return await context.Candidate.FirstOrDefaultAsync(a => a.Id == Id);
        }

        public int Delete(int Id)
        {
            int retVal = 0;
            Candidate candidate = context.Candidate.Where(a => a.Id == Id).FirstOrDefault();

            if (candidate != null)
            {
                context.Candidate.Remove(candidate);
                retVal = context.SaveChanges();
            }
            else
            { retVal = -1; }

            return retVal;
        }

    }
}
