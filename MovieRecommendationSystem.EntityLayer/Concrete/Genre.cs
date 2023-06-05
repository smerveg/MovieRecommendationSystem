using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationSystem.EntityLayer.Concrete
{
    public class Genre
    {
        public int GenreID { get; set; }
        [JsonProperty("id")]
        public int GenreIDFromApi { get; set; }
        [JsonProperty("name")]
        public string GenreName { get; set; }
    }
}
