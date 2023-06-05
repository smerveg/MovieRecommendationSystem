using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationSystem.DAL.Abstract
{
    //for user and moviecomment
    public interface IRepository<T> where T:class
    {
        List<T> GetAll();
        List<T> GetAllByFilter(Expression<Func<T,bool>> filter);
        T GetByFilter(Expression<Func<T,bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        
    }
}
