using MovieRecommendationSystem.DAL.Abstract;
using MovieRecommendationSystem.EntityLayer.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationSystem.DAL.Concrete
{
    public class MovieRepository : IMovieDAL
    {
        private string baseUrl = "https://api.themoviedb.org/3/";
        //private string requestUrl = "discover/movie?with_genres=28,12&api_key=ddffc5104b686e12bf490d13671df63a";
        HttpClient _client = new HttpClient();
        //_client.BaseAddress = new Uri(baseUrl);
        //_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        public List<Genre> GetGenres()
        {
            using (var c=new Context())
            {
                return c.Genres.ToList();
            }
        }

        public List<Language> GetLanguages()
        {
            using (var c=new Context())
            {
                return c.Languages.ToList();
            }
        }

        public async Task<IEnumerable<Movie>> GetMovies(Movie m)
        {
            var movieList = await MovieList(m);
            string s = GetYear(m.Year);
            var mm = movieList.Movie.Where(x => x.ReleaseDate.StartsWith(s))
             .Where(x => x.iso_639_1.Equals(m.iso_639_1)).ToList();
                 
            
            
            
            return mm;

            
        }
        MovieDetails IMovieDAL.GetMovieDetails(int id)
        {
            var det = MovieDetailss(id).Result;
            var cc = CastandCrews(id).Result;

            MovieDetails ms = new MovieDetails();
            ms.Title = det.Title;
            ms.iso_639_1 = det.iso_639_1;
            ms.Overview = det.Overview;
            ms.ReleaseDate = det.ReleaseDate;
            ms.PosterPath = "https://image.tmdb.org/t/p/w185/" + det.PosterPath;
            ms.Genres = det.Genres;
            ms.Cast = cc.Cast.Take(5).ToArray();
            ms.Crew = cc.Crew.Where(x => x.Job.Equals("Director")).ToArray();
            ms.Comments = GetMovieComments(id);
            return ms;
        }

        //----
        private List<MovieComment> GetMovieComments(int movieId)
        {
            using (var c=new Context())
            {
                return c.MovieComments.Where(x => x.MovieIDFromApi == movieId).ToList();

            }
        }
        private async Task<MovieDetails> MovieDetailss(int id)
        {
            _client.BaseAddress = new Uri(baseUrl);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var result = _client.GetAsync("movie/" + id + "?api_key=ddffc5104b686e12bf490d13671df63a").Result;
            if (result.IsSuccessStatusCode)
            {
                var resultString = await result.Content.ReadAsStringAsync();
                var desResult = JsonConvert.DeserializeObject<MovieDetails>(resultString);
                return desResult;


            }
            throw new Exception(result.StatusCode.ToString());
        }        
        private async Task<CastAndCrew> CastandCrews(int id)
        {
            //_client.BaseAddress = new Uri(baseUrl);
            //_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var result = _client.GetAsync("movie/" + id + "/credits?api_key=ddffc5104b686e12bf490d13671df63a").Result;
            if (result.IsSuccessStatusCode)
            {
                var resultString = await result.Content.ReadAsStringAsync();
                var desResult = JsonConvert.DeserializeObject<CastAndCrew>(resultString);
                return desResult;


            }
            throw new Exception(result.StatusCode.ToString());
        }
        private async Task<MovieBase> MovieList(Movie m)
        {
            string requestUrl = CreateRequestUrl(m.SelectedGenres);
            _client.BaseAddress = new Uri(baseUrl);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            var result = _client.GetAsync(requestUrl).Result;
            if (result.IsSuccessStatusCode)
            {
                var resultString = await result.Content.ReadAsStringAsync();
                var desResult = JsonConvert.DeserializeObject<MovieBase>(resultString);
                return desResult;
            }
            throw new Exception(result.StatusCode.ToString());

        }

        private string CreateRequestUrl(IEnumerable<int> selectedGenres)
        {
            //genres
            StringBuilder sb = new StringBuilder();
            int c = 0;
            foreach (var item in selectedGenres)
            {
                c++;
                sb.Append(item);
                if (c != selectedGenres.Count())
                {
                    sb.Append(",");
                }

            }
            string genres = sb.ToString();

            string requestUrl = "discover/movie?api_key=ddffc5104b686e12bf490d13671df63a&with_genres=" + genres;

            return requestUrl;
        }

        private string GetYear(int year)
        {
            string y = "";
            switch (year)
            {
                case 2:
                   y="20";
                    break;
                case 8:
                    y= "198";
                    break;
                case 9:
                    y= "199";
                    break;
            }
            return y;
        }

        
    }
}

