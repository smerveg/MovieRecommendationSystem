using MovieRecommendationSystem.DAL.Abstract;
using MovieRecommendationSystem.DAL.Concrete;
using MovieRecommendationSystem.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationSystem.DAL.EntityFramework
{
    public class EFMovieCommentDAL : GenericRepository<MovieComment>, IMovieCommentDAL
    {
        public bool AddMovie(int movieId, string userName,string title)
        {
            bool flag = false;
            using (var c=new Context())
            {
                int userId= GetUserId(userName);
                var result = c.MovieComments.Where(x => x.MovieIDFromApi == movieId && x.UserID == userId).FirstOrDefault();

                if (result==null)
                {
                    MovieComment mc = new MovieComment();
                    mc.MovieIDFromApi = movieId;
                    mc.MovieTitle = title;
                    mc.CommentDate = DateTime.Now;
                    mc.Status = true;
                    mc.UserID = userId;
                    c.MovieComments.Add(mc);
                    c.SaveChanges();
                    flag = true;
                }
                return flag;
                
            }
        }

        public MovieComment AssignCommentInfo(MovieComment movieComment, string score, string comment)
        {
            movieComment.Comment = comment;
            movieComment.Score= Convert.ToInt32(score);
            movieComment.CommentDate = DateTime.Now;
            return movieComment;
        }

        public BestWorstList GetBestAndWorst()
        {
            BestWorstList list = new BestWorstList();
            using (var c = new Context())
            {
                var result = c.MovieComments.Where(m=>m.Score>0)
                                            .GroupBy(x => x.MovieIDFromApi)
                                            .Select(y => new Movie{
                                                Title=y.FirstOrDefault().MovieTitle,
                                                MovieID = y.Key, 
                                                ScoreSum = y.Sum(z => z.Score),
                                                Count=y.Count(),
                                                AverageScore=(y.Sum(z => z.Score))/ (y.Count())
                                            }
                                            )
                                            .ToList().OrderByDescending(x => x.AverageScore);
                list.BestList = result.Take(5).ToList();
                list.WorstList = result.Skip(result.Count() - 5).Reverse().ToList();
                return list;
            }
        }

        //---
        private int GetUserId(string userName)
        {
            using (var c=new Context())
            {
                return c.Users.Where(x => x.UserName == userName).FirstOrDefault().UserID;

            }
        }
    }
}
