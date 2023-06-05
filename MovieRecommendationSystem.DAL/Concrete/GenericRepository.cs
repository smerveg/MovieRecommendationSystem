using MovieRecommendationSystem.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationSystem.DAL.Concrete
{
    //for users and movieomments
    public class GenericRepository<T> : IRepository<T> where T:class
    {
        Context conn = new Context();

        DbSet<T> _object;
        public GenericRepository()
        {
            _object = conn.Set<T>();
        }
        public void Add(T entity)
        {
            var t = conn.Entry(entity);
            t.State = EntityState.Added;
            conn.SaveChanges();

        }

        public void Delete(T entity)
        {
            var t = conn.Entry(entity);
            t.State = EntityState.Modified;
            conn.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _object.ToList();
        }

        public List<T> GetAllByFilter(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public T GetByFilter(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).FirstOrDefault();
        }

        public void Update(T entity)
        {
            var t = conn.Entry(entity);
            t.State = EntityState.Modified;
            conn.SaveChanges();
        }
    }
}
