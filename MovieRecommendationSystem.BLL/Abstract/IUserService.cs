using MovieRecommendationSystem.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationSystem.BLL.Abstract
{
    public interface IUserService:IGenericService<User>
    {        
        bool PasswordVerification(string password, string storedHash);
        User AssignUserInfo(User u);
    }
}
