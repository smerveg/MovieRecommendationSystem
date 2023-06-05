using MovieRecommendationSystem.Core.Enums;
using MovieRecommendationSystem.DAL.Abstract;
using MovieRecommendationSystem.DAL.Concrete;
using MovieRecommendationSystem.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationSystem.DAL.EntityFramework
{
    public class EFUserDAL:GenericRepository<User>,IUserDAL
    {
        public User AssignUserInfo(User u)
        {
            u.RoleID = (int)RoleEnum.User;
            u.RoleCode = "U";
            u.Status = true;
            u.Password = PasswordEncryption(u.Password);
            return u;
        }        
        public bool PasswordVerification(string password, string hashPass)
        {
            bool result = true;

            byte[] hashBytes = Convert.FromBase64String(hashPass);
            byte[] salt = new byte[20];
            Array.Copy(hashBytes, 0, salt, 0, 20);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            try
            {
                for (int i = 0; i < 20; i++)
                {
                    if (hashBytes[i + 20] != hash[i])
                    {
                        result = false;
                    }
                }
            }
            catch (Exception)
            {

                result = false;
            }


            return result;

        }
        private string PasswordEncryption(string password)
        {

            string hashPass = string.Empty;
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[20]);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[40];
            Array.Copy(salt, 0, hashBytes, 0, 20);
            Array.Copy(hash, 0, hashBytes, 20, 20);

            hashPass = Convert.ToBase64String(hashBytes);

            return hashPass;

        }
    }
}
