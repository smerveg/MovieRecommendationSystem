using MovieRecommendationSystem.BLL.Abstract;
using MovieRecommendationSystem.DAL.Abstract;
using MovieRecommendationSystem.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationSystem.BLL.Concrete
{
    public class MovieManager : IMovieService
    {
        IMovieDAL _movieDal;
        public MovieManager(IMovieDAL movieDal)
        {
            _movieDal = movieDal;
        }
        public List<Genre> GetGenres()
        {
            return _movieDal.GetGenres();
        }

        public List<Language> GetLanguages()
        {
            return _movieDal.GetLanguages();
        }

        public MovieDetails GetMovieDetails(int id)
        {
            return _movieDal.GetMovieDetails(id);
        }

        public Task<IEnumerable<Movie>> GetMovies(Movie m)
        {
            return _movieDal.GetMovies(m);
        }
    }
}
