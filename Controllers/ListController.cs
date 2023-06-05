using MovieRecommendationSystem.BLL.Concrete;
using MovieRecommendationSystem.DAL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieRecommendationSystem.WEBUI.Controllers
{
    [AllowAnonymous]
    public class ListController : Controller
    {
        MovieCommentManager mcm = new MovieCommentManager(new EFMovieCommentDAL());
        
        public ActionResult BestAndWorstList()
        {
            var result = mcm.GetBestAndWorst();
            return View(result);
        }
    }
}