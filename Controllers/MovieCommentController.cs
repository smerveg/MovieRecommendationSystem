using MovieRecommendationSystem.BLL.Concrete;
using MovieRecommendationSystem.DAL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieRecommendationSystem.WEBUI.Controllers
{
    [Authorize(Roles ="A,U")]
    public class MovieCommentController : Controller
    {
        MovieCommentManager mcm = new MovieCommentManager(new EFMovieCommentDAL());
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Add(int id,string title)
        {
            string userName = Session["Username"].ToString();
            bool flag=mcm.AddMovie(id, userName,title);

            return Json(flag);
        }
        [HttpGet]
        public ActionResult WatchListAndComments()
        {
            string userName = Session["Username"].ToString();
            var result = mcm.GetAllByFilter(x => x.Status == true && x.User.UserName==userName);
            return View(result);
        }
        public JsonResult Delete(int id)
        {
            bool flag = false;
            var result = mcm.GetByFilter(x => x.MovieCommentID == id);
            if (result != null)
            {
                flag = true;
                mcm.Delete(result);
            }

            return Json(flag);
        }
        public JsonResult AddComment(int id,string score,string comment)
        {
            bool flag = false;
            string userName = Session["Username"].ToString();
            var result = mcm.GetByFilter(x => x.MovieCommentID == id && x.User.UserName==userName);
            if (result != null)
            {
                if (score!="" && comment!="")
                {
                    result = mcm.AssignCommentInfo(result, score, comment);
                    mcm.Update(result);
                    flag = true;
                }
                

            }
            return Json(flag);

        }
        
    }
}