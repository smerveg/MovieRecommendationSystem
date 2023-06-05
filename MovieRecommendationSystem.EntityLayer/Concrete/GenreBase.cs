using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationSystem.EntityLayer.Concrete
{
    public class GenreBase
    {
        [JsonProperty("genres")]
        public Genre[] Genre { get; set; }
    }
}
