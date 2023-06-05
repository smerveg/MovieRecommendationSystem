using FluentValidation.Results;
using MovieRecommendationSystem.BLL.Concrete;
using MovieRecommendationSystem.BLL.ValidationRules;
using MovieRecommendationSystem.Core.Enums;
using MovieRecommendationSystem.DAL.EntityFramework;
using MovieRecommendationSystem.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace MovieRecommendationSystem.WEBUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        UserManager um = new UserManager(new EFUserDAL());
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User u)
        {
            LoginValidation lv = new LoginValidation();
            ValidationResult result = lv.Validate(u);

            if (result.IsValid)
            {
                var user = um.GetByFilter(x => x.UserName==u.UserName && x.Status==true);
                if (user!=null)
                {
                    if(um.PasswordVerification(u.Password, user.Password))
                    {
                        FormsAuthentication.SetAuthCookie(u.UserName, false);
                        Session["Username"] = u.UserName;

                        if (user.RoleID==(int)RoleEnum.Admin)
                        {
                            return RedirectToAction("Index", "MRSystem");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Movie");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(u.Password, "Password is wrong.");
                        return View(u);
                    }
                }
                else
                {
                    ModelState.AddModelError("UserName", "User not exist.");
                    return View();
                }
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(u);
            }
          
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User u)
        {
            RegisterValidation rv = new RegisterValidation();
            ValidationResult result = rv.Validate(u);

            if (result.IsValid)
            {
                u = um.AssignUserInfo(u);
                um.Add(u);

                FormsAuthentication.SetAuthCookie(u.UserName, false);
                Session["Username"] = u.UserName;

                return RedirectToAction("Index", "Movie");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(u);
            }
            
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }
    }
}