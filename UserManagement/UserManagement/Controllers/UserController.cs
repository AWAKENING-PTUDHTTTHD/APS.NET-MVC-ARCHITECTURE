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

        // GET: User
        //public ActionResult Index()
        //{
        //    return View(service.GetAll());
        //}

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

        // LOGIN
        // GET: Admin/Login
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
                return View("Home");
            else
                return View();

            //try
            //{
            //    using (var context = new CmsDbContext())
            //    {
            //        var getUser = (from s in context.ObjRegisterUser where s.UserName == userName || s.EmailId == userName select s).FirstOrDefault();
            //        if (getUser != null)
            //        {
            //            var hashCode = getUser.VCode;
            //            //Password Hasing Process Call Helper Class Method
            //            var encodingPasswordString = Helper.EncodePassword(password, hashCode);
            //            //Check Login Detail User Name Or Password
            //            var query = (from s in context.ObjRegisterUser where (s.UserName == userName || s.EmailId == userName) && s.Password.Equals(encodingPasswordString) select s).FirstOrDefault();
            //            if (query != null)
            //            {
            //                //RedirectToAction("Details/" + id.ToString(), "FullTimeEmployees");
            //                //return View("../Admin/Registration"); url not change in browser
            //                return RedirectToAction("Index", "Admin");
            //            }
            //            ViewBag.ErrorMessage = "Invallid User Name or Password";
            //            return View();
            //        }
            //        ViewBag.ErrorMessage = "Invallid User Name or Password";
            //        return View();
            //    }
            //}
            //catch (Exception e)
            //{
            //    ViewBag.ErrorMessage = " Error!!! contact cms@info.in";
            //    return View();
            //}
            return View();
        }
    }

}