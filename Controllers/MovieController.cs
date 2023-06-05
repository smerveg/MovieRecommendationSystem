using FluentValidation.Results;
using MovieRecommendationSystem.BLL.Concrete;
using MovieRecommendationSystem.BLL.ValidationRules;
using MovieRecommendationSystem.DAL.EntityFramework;
using MovieRecommendationSystem.EntityLayer.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MovieRecommendationSystem.WEBUI.Controllers
{
    [AllowAnonymous]
    public class MovieController : Controller
    {
        MovieManager mm = new MovieManager(new EFMovieDAL());      

        [HttpGet]
        public  ActionResult Index()
        {
            LoadDropdowns();
            return View();
        }

        [HttpGet]
        public ActionResult GetMovies(IEnumerable<Movie> movieList)
        {
            ViewBag.Username = Session["Username"].ToString();
            return View(movieList);
        }

        [HttpPost]
        public ActionResult GetMovies(Movie m)
        {
            MovieValidation mv = new MovieValidation();
            ValidationResult result = mv.Validate(m);
            if (result.IsValid)
            {
                var movies = mm.GetMovies(m).Result;
                return View(movies);
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    
                }
                LoadDropdowns();
                return View("Index");
            }
            
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            MovieDetails result=mm.GetMovieDetails(id);            
            return View(result);
        }



       //-----            
        private List<SelectListItem> Genres()
        {
            var result = (from g in mm.GetGenres()
                          select new SelectListItem
                          {
                              Text = g.GenreName,
                              Value = g.GenreIDFromApi.ToString()
                          }).ToList();
            return result;

            
        }

        private List<SelectListItem> Languages()
        {
            var result = (from l in mm.GetLanguages()
                          select new SelectListItem
                          {
                              Text = l.EnglishName,
                              Value = l.iso_639_1
                          }).ToList();
            return result;
        }
        private List<SelectListItem> Years()
        {
            List<SelectListItem> years = new List<SelectListItem>();
            years.Add(new SelectListItem
            {
                Text = "2000s",
                Value = 2.ToString()

            });
            years.Add(new SelectListItem
            {
                Text = "90s",
                Value = 9.ToString()

            });
            years.Add(new SelectListItem
            {
                Text = "80s",
                Value = 8.ToString()

            });
            return years;

        }
        public void LoadDropdowns()
        {
            ViewBag.Genres = Genres();
            ViewBag.Languages = Languages();
            ViewBag.Years = Years();
        }
    }
}