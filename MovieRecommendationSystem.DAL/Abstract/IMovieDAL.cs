using MovieRecommendationSystem.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationSystem.DAL.Abstract
{
    public interface IMovieDAL
    {
        List<Genre> GetGenres();
        List<Language> GetLanguages();
        Task<IEnumerable<Movie>> GetMovies(Movie m);
        MovieDetails GetMovieDetails(int id);
    }
}
