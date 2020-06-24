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
    public class CanActivityServices
    {
        ResumeShortListingDBContext context;

        public CanActivityServices()
        {
            context = new ResumeShortListingDBContext();
        }

        public int Save(CanActivity canActivity)
        {
            if (canActivity.Id == 0)
            {
                context.CanActivity.Add(canActivity);                
            }            

            return context.SaveChanges();            
        }


        public List<CanActivity> GetList()
        {
            return context.CanActivity.ToList();
        }

        public CanActivity GetItem(int Id)
        {
            return context.CanActivity.Where(a => a.Id == Id).FirstOrDefault();
        }

        public int Delete(int Id)
        {
            int retVal = 0;
            CanActivity canActivity = context.CanActivity.Where(a => a.Id == Id).FirstOrDefault();

            if (canActivity != null)
            {
                context.CanActivity.Remove(canActivity);
                retVal = context.SaveChanges();
            }
            else
            { retVal = -1; }

            return retVal;
        }

    }
}
