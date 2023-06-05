using MovieRecommendationSystem.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationSystem.DAL.Abstract
{
    public interface IUserDAL:IRepository<User>
    {
        //string PasswordEncryption(string password);
        bool PasswordVerification(string password, string storedHash);
        User AssignUserInfo(User u);
    }
}
