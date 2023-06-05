using MovieRecommendationSystem.BLL.Concrete;
using MovieRecommendationSystem.DAL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MovieRecommendationSystem.WEBUI.Controllers
{
    [Authorize(Roles ="A")]
    public class ConfigurationController : Controller
    {
        GenreManager gm = new GenreManager(new EFGenreDAL());
        LanguageManager lm = new LanguageManager(new EFLanguageDAL());
        public ActionResult Index()
        {
            return View();
        }
        public async Task<JsonResult> LoadGenre()
        {

            var result = await gm.Add("genre/movie/list?api_key=ddffc5104b686e12bf490d13671df63a");
            if (result)
            {
                return  Json("Genres are loaded", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return  Json("Genres are not loaded", JsonRequestBehavior.AllowGet);
            }

        }
        public JsonResult LoadLanguage()
        {
            var result = lm.Add("configuration/languages?api_key=ddffc5104b686e12bf490d13671df63a").Result;
            if (result)
            {
                return Json("Languages are loaded", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Languages are not loaded", JsonRequestBehavior.AllowGet);
            }

        }


    }
}