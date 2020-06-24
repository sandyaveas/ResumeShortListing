using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BO;
using DAL.DataContext;

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
            if (skill.Id == 0)
            {
                context.Skill.Add(skill);
            }

            return context.SaveChanges();
        }


        public List<Skill> GetList()
        {
            return context.Skill.ToList();
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
