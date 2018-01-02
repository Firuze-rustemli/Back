using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xeber.Models;


namespace Xeber.Controllers
{
    public class HomeController : Controller
    {
        private NewsEntities db = new NewsEntities();


        public ActionResult Index(int? id)  
        {
            ViewBag.slide = db.news.Where(x => x.type.name == "Manset").OrderBy(x => x.date).Take(4);
            ViewBag.most = db.news.Take(14).ToList();
            ViewBag.galery = db.news.Where(x => x.type.name == "Galery").OrderBy(x => x.date).Take(4);
            ViewBag.gallery = db.news.Where(x => x.type.name == "Gallery").OrderBy(x => x.date).Take(3);
            ViewBag.picture = db.news.Where(x => x.type.name == "picture").OrderBy(x => x.date).Take(3);
            ViewBag.both = db.news.Where(x => x.type.name == "both").OrderBy(x => x.date).Take(5);
            ViewBag.add = db.news.Where(x => x.type.name == "add").OrderBy(x => x.date).Take(5);
            ViewBag.world = db.news.Where(x => x.type.name == "world").OrderBy(x => x.date).Take(2);
            ViewBag.Inter = db.news.Where(x => x.type.name == "inter").OrderBy(x => x.date).Take(5);
            ViewBag.care = db.care.Take(14).ToList();
            ViewBag.category = db.category.Take(7).ToList();
            ViewBag.sosial = db.sosial.Take(3).ToList();
            ViewBag.main = db.news.Where(x => x.type.name == "side").OrderBy(x => x.date).Take(3);
            ViewBag.exchg = db.exchang.Take(5).ToList();
            ViewBag.setting = db.settings.Find(1);

            return View();
        }


        public ActionResult post1(int? id)
        {
            ViewBag.post = db.news.Find(id);
            return View();
        }


        public ActionResult takeInter(int? id)
        {
            ViewBag.Inter = db.news.Where(x => x.type.name == "inter").OrderBy(x => x.date).Take(5);

            return View();
        }

        public ActionResult takeSlide()
        {
            ViewBag.slide = db.news.Where(x => x.type.name == "Manset").OrderBy(x => x.date).Take(4);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact(int? id)
        {
            ViewBag.setting = db.settings.Find(1);

            return View();
        }


    }
}