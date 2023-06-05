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
    public class MRSystemController : Controller
    {
        StatisticManager sm = new StatisticManager(new EFStatisticDAL());
        public ActionResult Index()
        {
            ViewBag.CommentCount = sm.GetCommentCount();
            ViewBag.UserCount = sm.GetUserCount();
            return View();
        }
    }
}