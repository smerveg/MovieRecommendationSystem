using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationSystem.EntityLayer.Concrete
{
    public class MovieComment
    {
        public int MovieCommentID { get; set; }
        public int MovieIDFromApi { get; set; }
        public string MovieTitle { get; set; }
        public int Score { get; set; }
        public string Comment { get; set; }
        public bool Status { get; set; }
        public DateTime CommentDate { get; set; }

        public User User { get; set; }
        public int UserID { get; set; }
    }
}
