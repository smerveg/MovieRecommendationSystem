using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MovieRecommendationSystem.EntityLayer.Concrete
{
    public class Movie
    {
        [JsonProperty("id")]
        public string ID { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }       
        public IEnumerable<int> SelectedGenres { get; set; }
        [JsonProperty("original_language")]
        public string iso_639_1 { get; set; }
        
        [Required(ErrorMessage ="Year is required")]
        public int Year { get; set; }
        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }
        [JsonProperty("genre_ids")]
        public IEnumerable<int> GenreIds { get; set; }
        public int MovieID { get; set; }
        public int ScoreSum { get; set; }
        public int Count { get; set; }
        public double AverageScore { get; set; }


    }
}
