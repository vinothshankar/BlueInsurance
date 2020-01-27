using DAL.Models;
using InsuranceService.Service;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BlueInsurance.Controllers
{
    public class StudentController : BaseController<UserMaster, UserMaster>
    {
        StudentService studentService;
        public StudentController()
        {
            studentService = new StudentService();
        }
        // GET: Student
        public ActionResult FilterIndex(string FirstName, string SurName)
        {
            List<UserMaster> data = new List<UserMaster>();
            ActionResult actionResult = View("Index", data);
            try
            {
                data = studentService.FilterIndex(FirstName,SurName);
                actionResult = View("Index", data);
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message.ToString();
            }
           
            return actionResult;
        }
    }
}