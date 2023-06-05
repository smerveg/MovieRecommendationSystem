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
    public class GenreManager : IGenreService
    {
        IGenreDAL _genreDal;
        public GenreManager(IGenreDAL genreDal)
        {
            _genreDal = genreDal;
        }

        public Task<bool> Add(string requestUrl)
        {
            return _genreDal.Add(requestUrl);
        }

        public Task<GenreBase> GetGenres(string requestUrl)
        {
            return _genreDal.GetGenres(requestUrl);
        }

        public Task<IEnumerable<GenreBase>> GetLanguages(string requestUrl)
        {
            throw new NotImplementedException();
        }
    }
}
