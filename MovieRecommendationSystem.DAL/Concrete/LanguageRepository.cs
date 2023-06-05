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
    public class LanguageRepository : ILanguageDAL
    {
        private string baseUrl = "https://api.themoviedb.org/3/";
        private readonly HttpClient _client = new HttpClient();
        public async Task<bool> Add(string requestUrl)
        {
            try
            {
                var result = await GetLanguages(requestUrl);
                using (var c = new Context())
                {
                    List<Language> list = new List<Language>();

                    foreach (var item in result)
                    {
                        list.Add(new Language
                        {
                            iso_639_1 = item.iso_639_1,
                            EnglishName = item.EnglishName,
                            Name = item.Name
                        });
                    }

                    c.Languages.AddRange(list);
                    await c.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public async Task<IEnumerable<Language>> GetLanguages(string requestUrl)
        {
            _client.BaseAddress = new Uri(baseUrl);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var result = _client.GetAsync(requestUrl).Result;
                if (result.IsSuccessStatusCode)
                {
                    var resultString = await result.Content.ReadAsStringAsync();
                    var desResult = JsonConvert.DeserializeObject<IEnumerable<Language>>(resultString);
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
