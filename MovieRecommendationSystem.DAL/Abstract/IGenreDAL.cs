using MovieRecommendationSystem.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationSystem.DAL.Abstract
{
    public interface IGenreDAL
    {
        Task<GenreBase> GetGenres(string requestUrl);
        Task<bool> Add(string requestUrl);

    }
}
