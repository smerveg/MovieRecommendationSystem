using MovieRecommendationSystem.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationSystem.BLL.Abstract
{
    public interface IMovieService
    {
        List<Genre> GetGenres();
        List<Language> GetLanguages();
        Task<IEnumerable<Movie>> GetMovies(Movie m);
        MovieDetails GetMovieDetails(int id);
    }
}
