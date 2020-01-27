using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceService.Service
{
    public class StudentService:BaseService<UserMaster, UserMaster>
    {
        public List<UserMaster> FilterIndex(string firstName,string surName)
        {
            List<UserMaster> vStudent = new List<UserMaster>();
            try
            {
                var data = _baseRepsitory.GetAll();
                if (firstName != string.Empty)
                {
                    data = data.Where(a => a.FirstName.Contains(firstName));
                }
                if (surName != string.Empty)
                {
                    data = data.Where(a => a.SurName.Contains(surName));
                }
                vStudent = data.ToList();

            }
            catch(Exception ex)
            {
                throw new Exception("Error While filtering", ex);
            }
            return vStudent;
        }
    }
}
