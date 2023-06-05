using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationSystem.EntityLayer.Concrete
{
    public class Language
    {
        public int LanguageID { get; set; }
        [JsonProperty("iso_639_1")]
        public string iso_639_1 { get; set; }
        [JsonProperty("english_name")]
        public string EnglishName { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
