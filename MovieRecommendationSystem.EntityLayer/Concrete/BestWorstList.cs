using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationSystem.EntityLayer.Concrete
{
    public class BestWorstList
    {
        public List<Movie> BestList { get; set; }
        public List<Movie> WorstList { get; set; }
    }
}
