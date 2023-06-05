using MovieRecommendationSystem.BLL.Concrete;
using MovieRecommendationSystem.DAL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieRecommendationSystem.WEBUI.Controllers
{
    [Authorize(Roles ="A")]
    public class UserController : Controller
    {
        UserManager um = new UserManager(new EFUserDAL());
        public ActionResult Index()
        {
            var result=um.GetAll();
            return View(result);
        }

        public JsonResult ChangeStatus(int id)
        {
            var user = um.GetByFilter(x => x.UserID == id);
            if (user!=null)
            {
                user.Status = ChangeStatus(user.Status);
                um.Update(user);
                return Json(true);
            }
            else
            {
                return Json(false);
            }
           

        }
        private bool ChangeStatus(bool status)
        {
            if (status==true)
            {
                return  false;
            }
            else
            {
                return true;
            }
        }
    }
}