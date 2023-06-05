using MovieRecommendationSystem.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationSystem.BLL.Abstract
{
    public interface IMovieCommentService:IGenericService<MovieComment>
    {
        bool AddMovie(int movieId, string userNanme,string title);
        BestWorstList GetBestAndWorst();
        MovieComment AssignCommentInfo(MovieComment movieComment, string score, string comment);
    }
}
