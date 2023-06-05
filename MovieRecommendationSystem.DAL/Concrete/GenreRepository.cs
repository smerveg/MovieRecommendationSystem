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
    public class GenreRepository: IGenreDAL
    {
        private string baseUrl = "https://api.themoviedb.org/3/";
        private readonly HttpClient _client = new HttpClient();
        public async Task<bool> Add(string requestUrl)
        {
            
            try
            {
                var result = await GetGenres(requestUrl);
                using (var c = new Context())
                {
                    List<Genre> list = new List<Genre>();

                    foreach (var item in result.Genre)
                    {
                        list.Add(new Genre
                        {
                            GenreIDFromApi = item.GenreIDFromApi,
                            GenreName = item.GenreName
                        });
                    }

                    c.Genres.AddRange(list);
                    await c.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception e)
            {

                return false;
            }



        }

        public async Task<GenreBase> GetGenres(string requestUrl)
        {
            _client.BaseAddress = new Uri(baseUrl);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var result = _client.GetAsync(requestUrl).Result;
                if (result.IsSuccessStatusCode)
                {
                    var resultString = await result.Content.ReadAsStringAsync();
                    var desResult = JsonConvert.DeserializeObject<GenreBase>(resultString);
                    return desResult;
                }
                throw new Exception(result.StatusCode.ToString());

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        
    }
}
