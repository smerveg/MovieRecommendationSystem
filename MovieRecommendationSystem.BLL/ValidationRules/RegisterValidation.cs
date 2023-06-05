using FluentValidation;
using MovieRecommendationSystem.DAL.Concrete;
using MovieRecommendationSystem.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationSystem.BLL.ValidationRules
{
    public class RegisterValidation:AbstractValidator<User>
    {
        public RegisterValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Name must be at least 3 characters");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Lastname is required");
            RuleFor(x => x.LastName).MinimumLength(3).WithMessage("Lastname must be at least 3 characters");

            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is required");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Username must be at least 3 characters");
            RuleFor(x => new { x.UserName, x.UserID }).Must(x => !DuplicateUserName(x.UserName, x.UserID)).OverridePropertyName(x => x.UserName).WithMessage("Username already exists.");

            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail is required");
            RuleFor(x => x.Mail).EmailAddress().WithMessage("A valid email is required");
            RuleFor(x => new { x.Mail, x.UserID }).Must(x => !DuplicateMail(x.Mail, x.UserID)).OverridePropertyName(x => x.Mail).WithMessage("Mail already exists.");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
            RuleFor(x => x.Password).MinimumLength(3).WithMessage("Password must be at least 3 characters");
        }
        
        private bool DuplicateUserName(string userName,int id)
        {
            using (var c=new Context())
            {
                var result = c.Users.Where(x => x.UserName.Equals(userName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                if (result != null && result.UserID != id)
                {
                    return true;
                }
                else return false;
            }

        }
        private bool DuplicateMail(string mail, int id)
        {
            using (var c = new Context())
            {
                var result = c.Users.Where(x => x.Mail.Equals(mail)).FirstOrDefault();
                if (result != null && result.UserID != id)
                {
                    return true;
                }
                else return false;
            }

        }
    }
}
