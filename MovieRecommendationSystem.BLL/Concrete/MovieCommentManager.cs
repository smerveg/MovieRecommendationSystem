using MovieRecommendationSystem.BLL.Abstract;
using MovieRecommendationSystem.DAL.Abstract;
using MovieRecommendationSystem.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationSystem.BLL.Concrete
{
    public class MovieCommentManager : IMovieCommentService
    {
        IMovieCommentDAL _movieCommentDal;
        public MovieCommentManager(IMovieCommentDAL movieCommentDal)
        {
            _movieCommentDal = movieCommentDal;
        }
        public void Add(MovieComment entity)
        {
            _movieCommentDal.Add(entity);
        }

        public bool AddMovie(int movieId, string userName,string title)
        {
            return _movieCommentDal.AddMovie(movieId, userName, title);
        }

        public void Delete(MovieComment entity)
        {
            entity.Status = false;
            _movieCommentDal.Delete(entity);
        }

        public BestWorstList GetBestAndWorst()
        {
            return _movieCommentDal.GetBestAndWorst();
        }

        public List<MovieComment> GetAll()
        {
            return _movieCommentDal.GetAll();
        }

        public List<MovieComment> GetAllByFilter(Expression<Func<MovieComment, bool>> filter)
        {
            return _movieCommentDal.GetAllByFilter(filter);
        }

        public MovieComment GetByFilter(Expression<Func<MovieComment, bool>> filter)
        {
            return _movieCommentDal.GetByFilter(filter);
        }

        public void Update(MovieComment entity)
        {
            _movieCommentDal.Update(entity);
        }

        public MovieComment AssignCommentInfo(MovieComment movieComment, string score, string comment)
        {
            return _movieCommentDal.AssignCommentInfo(movieComment, score, comment);
        }
    }
}
