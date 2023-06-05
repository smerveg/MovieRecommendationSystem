using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationSystem.EntityLayer.Concrete
{
    public class CastAndCrew
    {
        [JsonProperty("cast")]
        public Cast[] Cast { get; set; }
        [JsonProperty("crew")]
        public Crew[] Crew { get; set; }
    }
}
