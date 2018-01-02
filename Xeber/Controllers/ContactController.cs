using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Xeber.Models;

namespace Xeber.Controllers
{
    public class ContactController : Controller
    {
        private NewsEntities db = new NewsEntities();
        // GET: Contact
        public ActionResult Index(int? id)
        {
            ViewBag.setting = db.settings.Find(1);
            return View();
        }



        [HttpPost]
        public ActionResult Index(ContactModels model)
        {
            if (ModelState.IsValid)
            {
                var body = new StringBuilder();
                body.AppendLine("Ad/Soyad: " + model.fullname);
                body.AppendLine("Email: " + model.email);
                body.AppendLine("Mesaj: " + model.text);
                Gmail.SendMail(body.ToString());
                ViewBag.Success = true;
            }
            ViewBag.setting = db.settings.Find(1); 
            return View();
        }


    }
}