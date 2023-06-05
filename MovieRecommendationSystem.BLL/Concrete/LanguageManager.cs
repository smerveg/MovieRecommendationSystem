using MovieRecommendationSystem.BLL.Abstract;
using MovieRecommendationSystem.DAL.Abstract;
using MovieRecommendationSystem.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationSystem.BLL.Concrete
{
    public class LanguageManager : ILanguageService
    {
        ILanguageDAL _languageDal;
        public LanguageManager(ILanguageDAL languageDal)
        {
            _languageDal = languageDal;
        }

        public Task<bool> Add(string requestUrl)
        {
            return _languageDal.Add(requestUrl);
        }

        public Task<Language> GetGenres(string requestUrl)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Language>> GetLanguages(string requestUrl)
        {
            return _languageDal.GetLanguages(requestUrl);
        }
    }
}
