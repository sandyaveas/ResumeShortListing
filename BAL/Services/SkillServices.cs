using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using DAL.DataContext;
using Microsoft.EntityFrameworkCore;

namespace BAL.Services
{
    public class SkillServices
    {
        ResumeShortListingDBContext context;

        public SkillServices()
        {
            context = new ResumeShortListingDBContext();
        }

        public int Save(Skill skill)
        {          

            skill.LastUpdated = DateTime.Now;

            if (skill.Id == 0)
            {
                skill.Created = DateTime.Now;

                context.Skill.Add(skill);
            }
            else
            {
                context.Skill.Update(skill);
            }

            return context.SaveChanges();
        }


        public List<Skill> GetList(int id)
        {
            return context.Skill.Where(a => a.Id == id).ToList();
        }

        public async Task<List<Skill>> GetListAsync(int id)
        {
            return await context.Skill.Where(a => a.Id == id).ToListAsync();
        }


        public List<Skill> GetCandidateList(int CandidateId)
        {
            return context.Skill.Where(a => a.CandidateId == CandidateId).ToList();
        }

        public async Task<List<Skill>> GetCandidateListAsync(int CandidateId)
        {
            return await context.Skill
                .Where(a => a.CandidateId == CandidateId)
                .OrderBy(a => a.SkillName)                
                .ToListAsync();
        }

        public Skill GetItem(int Id)
        {
            return context.Skill.Where(a => a.Id == Id).FirstOrDefault();
        }

        public int Delete(int Id)
        {
            int retVal = 0;
            Skill skill = context.Skill.Where(a => a.Id == Id).FirstOrDefault();

            if (skill != null)
            {
                context.Skill.Remove(skill);
                retVal = context.SaveChanges();
            }
            else
            { retVal = -1; }

            return retVal;
        }
    }
}
