using MovieRecommendationSystem.DAL.Abstract;
using MovieRecommendationSystem.DAL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationSystem.DAL.EntityFramework
{
    public class EFMovieDAL:MovieRepository,IMovieDAL
    {
    }
}
