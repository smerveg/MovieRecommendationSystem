using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationSystem.EntityLayer.Concrete
{
    public class MovieDetails:Movie
    {
        [JsonProperty("overview")]
        public string Overview { get; set; }
        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }
        [JsonProperty("genres")]
        public Genre[] Genres { get; set; }
        [JsonProperty("cast")]
        public Cast[] Cast { get; set; }
        [JsonProperty("crew")]
        public Crew[] Crew { get; set; }
        public List<MovieComment> Comments { get; set; }


    }
}
