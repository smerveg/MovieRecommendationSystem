using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationSystem.BLL.Abstract
{
    public interface IGenericServiceForApi<T>
    {
        Task<IEnumerable<T>> GetLanguages(string requestUrl);
        Task<T> GetGenres(string requestUrl);
        Task<bool> Add(string requestUrl);
    }
}
