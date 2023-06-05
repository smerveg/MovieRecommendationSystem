using MovieRecommendationSystem.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationSystem.DAL.Abstract
{
    public interface IMovieCommentDAL:IRepository<MovieComment>
    {
        bool AddMovie(int movieId, string userName,string title);
        BestWorstList GetBestAndWorst();
        MovieComment AssignCommentInfo(MovieComment movieComment, string score, string comment);
    }
}
