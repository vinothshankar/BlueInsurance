using BlueInsurance.Constants;
using DAL.Models;
using InsuranceService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlueInsurance.Controllers
{
    public class UserCourseMapController : BaseController<UserCourseMap,vUserCourseMap>
    {

        public UserCourseMapService userCourseMapService;
        public UserCourseMapController()
        {
            userCourseMapService = new UserCourseMapService();
        }

        public JsonResult Upsert(UserCourseMap entity)
        {
            int success = 0;
            JsonResult actionResult = Json(success);
            try
            {
                var dataResponse = userCourseMapService.CreateorUpdate(entity);
                actionResult = Json(dataResponse);
            }
            catch (Exception ex)
            {
                 actionResult = Json(ex.Message.ToString());
            }
            return actionResult;
        }

        public override ActionResult Index(string successmessage = "", string errormessage = "")
        {
            List<vUserCourseMap> data = new List<vUserCourseMap>();
            ActionResult actionResult = View("Index", data);
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
                    var dataResponse = userCourseMapService.getUserCourseMap(userId);
                    actionResult = View("Index", dataResponse);
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

    }
}