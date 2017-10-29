using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserManagement.Models;
using UserManagement.Services;

namespace UserManagement.Controllers
{ 
    public class UserController : Controller
    {

        IUserService service = new UserService();

        public ActionResult Home()
        {
            if (Session["user"] == null)
                return RedirectToAction("Login", "User");
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User u = new Models.User()
                    {
                        name = model.Name,
                        username = model.Username,
                        email = model.Email,
                        phone = model.Phone,
                        address = model.Address
                    };

                u.salt = HeplerClass.Hepler.GenerateSalt(16);
                u.password = HeplerClass.Hepler.EncryptPassword(model.Password, u.salt);

                service.AddUser(u);

                return View("Login");
            }
            return View();

        }

        public ActionResult Login()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult LogIn(LoginViewModel model)
        {
            User u = null;
            u = service.UserLogin(model.Email, model.Password);
            if (u != null)
            {
                Session["user"] = u;
                ViewData["SpentTime"] = HeplerClass.Hepler.getTotalDaysBetween(@DateTime.Now, u.created_at).ToString();
           
                return RedirectToAction("Home", "User");
            }
               
            else
                return View();

        }
        public ActionResult LogOut()
        {
            Session["user"] = null;
            return RedirectToAction("Login", "User");
        }
    }

}