using BlueInsurance.Constants;
using InsuranceService.IService;
using InsuranceService.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BlueInsurance.Controllers
{
    public class BaseController<T, V> : Controller
        where T : class, new()
        where V : class, new()
    {
       
        protected IBaseService<T,V> _baseService;
        protected UtilityService _utilityService;
       
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _baseService = new BaseService<T, V>();
            _utilityService = new UtilityService();
            var data = _utilityService.getLookUpData();
            Session[AppConstants.StaffListSession] = data.Item1.Where(a=>a.UserType==AppConstants.AdminUserType).ToList();
            Session[AppConstants.StudentListSession] = data.Item1.Where(a => a.UserType == AppConstants.StudentUserType).ToList();
            Session[AppConstants.CourseListSession] = data.Item2;
            base.OnActionExecuting(filterContext);
        }

        [HttpGet]
        public virtual ActionResult Index(string successmessage = "", string errormessage = "")
        {
            List<V> data = new List<V>();
            ActionResult actionResult = View("Index",data);
            try
            {
                if (Session[AppConstants.UserTypeSession].ToString().TrimEnd() == AppConstants.AdminUserType)
                {
                    var dataResponse = _baseService.GetAll();
                    actionResult = View("Index", dataResponse);
                }
                else
                {
                    int userId = int.Parse(Session[AppConstants.UserIdSession].ToString());
                    var dataResponse = _baseService.GetById(userId);
                    data.Add(dataResponse);
                    actionResult = View("Index", data);
                }
                
                ViewBag.SuccessMessage = successmessage;
                ViewBag.ErrorMessage = errormessage;
                
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message.ToString();
            }
            return actionResult;
        }

        [HttpGet]
        public virtual ActionResult GetById(int Id)
        {
            V data = new V();
            ActionResult actionResult = View("CreateUpdate", data);
            try
            {
                if (Id > 0)
                {
                    var dataResponse = _baseService.GetById(Id);
                    actionResult = View("CreateUpdate", dataResponse);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message.ToString();
            }
            return actionResult;
        }

        [HttpPost]
        public virtual ActionResult CreateOrUpdate(T recordToSave)
        {
            ActionResult actionResult = View(recordToSave);
            
            if (ModelState.IsValid)
            {
                try
                {
                    var dataResponse = _baseService.CreateorUpdate(recordToSave);
                    ViewBag.SuccessMessage = "Record Updated Successfully";
                    actionResult = RedirectToAction("Index", new { successmessage = ViewBag.SuccessMessage });

                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = ex.Message.ToString();
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Model Invalid";
            }
           
            return actionResult;
        }


        [HttpGet]
        public ActionResult Delete(int Id)
        {
            ActionResult actionResult = RedirectToAction("Index");
            
            try
                {
                    if (Id > 0)
                    {
                        var dataResponse = _baseService.Delete(Id);
                        ViewBag.SuccessMessage = "Record Deleted";
                        actionResult = RedirectToAction("Index", new { successmessage = ViewBag.SuccessMessage });
                    }
                    else
                    {
                        actionResult = RedirectToAction("Index", new { errormessage = "Delete error" });
                    }
                }
                catch (Exception ex)
                {
                ViewBag.ErrorMessage = ex.Message.ToString();
                }
            
            return actionResult;
        }

    }
}