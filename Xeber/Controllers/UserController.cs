using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xeber.Models;
using System.Web.Helpers;
using Xeber.Models;

namespace Xeber.Controllers
{
    public class UserController : BaseController
    {
        // GET: User
        [HttpPost]
        public JsonResult Login(string username, string password)
        {
            var pass = Crypto.Hash(password, "MD5");
            User user = db.User.FirstOrDefault(u => u.Fullname == username && u.Password == pass);

            if (user != null)
            {
                Session["user"] = true;
                var response = true;
                return Json(response, JsonRequestBehavior.AllowGet);

            }
            else
            {
                var response = false;
                return Json(response, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult Logout()
        {
            Session["user"] = null;
            Session.Clear();
            return RedirectToAction("index", "index");
        }

        [HttpPost]
        public JsonResult Register(User user)
        {
            if (user.Fullname
                != null && user.Password != null && user.Email != null)
            {
                User usr = db.User.FirstOrDefault(u => u.Email == user.Email);
                if (usr == null)
                {
                    user.Password = Crypto.Hash(user.Password, "MD5");
                    db.User.Add(user);
                    db.SaveChanges();
                    // user.password = Crypto.HashPassword(user.password);


                    Session["user"] = true;
                    var response = true;
                    return Json(response, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var response = false;
                    return Json(response, JsonRequestBehavior.AllowGet);

                }

            }
            else
            {
                var response = false;
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            //  return View();
        }

        [HttpPost]
        public JsonResult checkEmail(string email)
        {
            if (email.Length > 0)
            {
                User user = db.User.FirstOrDefault(usr => usr.Email == email);
                if (user != null)
                {
                    var response = new
                    {
                        valid = false,
                        message = "This email already exists!"
                    };
                    return Json(response, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    var response = new
                    {
                        valid = true,
                    };
                    return Json(response, JsonRequestBehavior.AllowGet);

                }

            }
            else
            {
                var response = new
                {
                    valid = false,
                    message = "Email is required"
                };
                return Json(response, JsonRequestBehavior.AllowGet);
            }
        }
    }
}