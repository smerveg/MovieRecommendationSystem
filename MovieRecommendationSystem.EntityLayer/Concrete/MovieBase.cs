using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationSystem.EntityLayer.Concrete
{
    public class MovieBase
    {
        [JsonProperty("results")]
        public Movie[] Movie { get; set; }
    }
}
