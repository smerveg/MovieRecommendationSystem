using MovieRecommendationSystem.BLL.Abstract;
using MovieRecommendationSystem.DAL.Abstract;
using MovieRecommendationSystem.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationSystem.BLL.Concrete
{
    public class UserManager : IUserService
    {
        IUserDAL _userDal;
        public UserManager(IUserDAL userDal)
        {
            _userDal = userDal;
        }
        public void Add(User entity)
        {
            _userDal.Add(entity);
        }

        public User AssignUserInfo(User u)
        {
            return _userDal.AssignUserInfo(u);
        }

        public void Delete(User entity)
        {
            entity.Status = false;
            _userDal.Delete(entity);
        }

        public List<User> GetAll()
        {
            return _userDal.GetAll();
        }

        public List<User> GetAllByFilter(Expression<Func<User, bool>> filter)
        {
            return _userDal.GetAllByFilter(filter);
        }

        public User GetByFilter(Expression<Func<User, bool>> filter)
        {
            return _userDal.GetByFilter(filter);
        }

        public bool PasswordVerification(string password, string storedHash)
        {
            return _userDal.PasswordVerification(password, storedHash);
        }

        public void Update(User entity)
        {
            _userDal.Update(entity);
        }
    }
}
