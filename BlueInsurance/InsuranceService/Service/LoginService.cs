using DAL.Context;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InsuranceService.Service
{
    public class LoginService
    {
        private InsuranceContext _context;

        public LoginService()
        {
            _context = new InsuranceContext();
        }

        public UserMaster AuthenticateUser(string email)
        {
            UserMaster userMaster = null;
            try
            {
                if(email != null)
                {
                    userMaster = _context.UserMasters.FirstOrDefault(a => a.Email.TrimEnd() == email);
                }
                
            }
            catch(Exception ex)
            {
                throw new Exception("Error while authenticating",ex);
            }
            return (userMaster);
        }

       

    }
}
