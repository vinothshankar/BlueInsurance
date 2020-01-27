using DAL.Context;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceService.Service
{
    public class UtilityService
    {
        InsuranceContext context;
        public UtilityService()
        {
            context = new InsuranceContext();
        }
        public (List<UserMaster>, List<CourseMaster>) getLookUpData()
        {
            List<UserMaster> userMaster = new List<UserMaster>();
            List<CourseMaster> courseMaster = new List<CourseMaster>();
            try
            {
                userMaster = context.UserMasters.ToList();
                courseMaster = context.CourseMasters.ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return (userMaster, courseMaster);
        }
    }
}
