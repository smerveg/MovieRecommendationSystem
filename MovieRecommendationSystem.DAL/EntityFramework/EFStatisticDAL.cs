using MovieRecommendationSystem.DAL.Abstract;
using MovieRecommendationSystem.DAL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationSystem.DAL.EntityFramework
{
    public class EFStatisticDAL : IStatisticDAL
    {
        public int GetCommentCount()
        {
            using (var c=new Context())
            {
                return c.MovieComments.Where(x => x.Status == true).Count();
            }
        }

        public int GetUserCount()
        {
            using (var c = new Context())
            {
                return c.Users.Where(x => x.Status == true).Count();
            }
        }
    }
}
