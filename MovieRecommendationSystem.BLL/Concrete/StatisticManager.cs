using MovieRecommendationSystem.BLL.Abstract;
using MovieRecommendationSystem.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationSystem.BLL.Concrete
{
    public class StatisticManager : IStatisticService
    {
        IStatisticDAL _statisticDal;
        public StatisticManager(IStatisticDAL statisticDal)
        {
            _statisticDal = statisticDal;
        }
        public int GetCommentCount()
        {
            return _statisticDal.GetCommentCount();
        }

        public int GetUserCount()
        {
            return _statisticDal.GetUserCount();
        }
    }
}
