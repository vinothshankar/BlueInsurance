using BlueInsurance.Constants;
using BlueInsurance.ViewModel;
using InsuranceService.Service;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BlueInsurance.Controllers
{
    public class AccountController: Controller
    {
        private LoginService _loginService;
        public AccountController()
        {
            _loginService = new LoginService();
        }

        [HttpGet]
        public ActionResult Login(string message = "")
        {
            HttpContext.Session.Clear();
            ViewBag.errorMessage = message;
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(string email,string password="")
        {
            ActionResult actionResult = View("Login");
            if (email != null)
            {
                try
                {
                    var data = _loginService.AuthenticateUser(email);
                    if (data!= null)
                    {
                        Session[AppConstants.UserIdSession] = data.UserId;
                        Session[AppConstants.UserNameSession] = data.FirstName;
                        Session[AppConstants.UserTypeSession] = data.UserType;
                        LoadMenu(data.UserType);
                        actionResult = RedirectToAction("Index", "Student");
                        
                    }
                    else
                    {
                        ViewBag.errorMessage = "Invalid credentilas";
                        actionResult = View("Login");
                    }
                }catch(Exception ex)
                {
                    ViewBag.errorMessage = "Invalid credentilas";
                    actionResult = View("Login");
                }

            }
            return actionResult;
        }

        [HttpGet]
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        private void LoadMenu(string userType)
        {
            List<MenuVM> menuVM = new List<MenuVM>();

            menuVM.Add(new MenuVM { ActionName = "Index", ControllerName = "Student", MenuName = "Student" });
            menuVM.Add(new MenuVM { ActionName = "Index", ControllerName = "UserCourseMap", MenuName = "Register Course" });
            if (userType.TrimEnd() == AppConstants.AdminUserType)
            {
                menuVM.Add(new MenuVM { ActionName = "Index", ControllerName = "Course", MenuName = "Course" });
                
            }
           
            Session[AppConstants.MenuListSession] = menuVM;
        }
    }
}