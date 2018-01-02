using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xeber.Models;

namespace Xeber.Controllers
{
    public class NewsController : Controller
    {
        NewsEntities db = new NewsEntities();

        // GET: News

        public ActionResult read(int? id)
        {
            ViewBag.Post = db.news.SingleOrDefault(x => x.id == id);
            ViewBag.setting = db.settings.Find(1);
            ViewBag.sosial = db.sosial.Take(3).ToList();

            ViewBag.NewsSingle = db.news.Find(id);

            if (ViewBag.NewsSingle == null)
            {
                return HttpNotFound();
            }
            ViewBag.Comments = db.comment.Where(c => c.news_id == id).OrderByDescending(c => c.id).ToList();
            return View(db.news.FirstOrDefault(x=>x.id==id));
        }


        public ActionResult Category(int? id, int date)
        {
            category nct = db.category.Find(id);
            ViewBag.Title = nct.name.Trim();
            ViewBag.News = db.news.OrderByDescending(n => n.date).Where(n => n.category_id == id).ToList();
            ViewBag.Categories = db.category.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Addcomment(int Id, string txtFullname, string txtEmail, string txtContent)
        {
            comment cmt = new comment();
            cmt.fullname = txtFullname;
            cmt.email = txtEmail;
            cmt.content = txtContent;
            cmt.date = DateTime.Now;
            cmt.title = "";
            cmt.accept = true;
            cmt.like = 0;
            cmt.unlike = 0;
            cmt.news_id = Id;
            db.comment.Add(cmt);
            db.SaveChanges();

            news nws = db.news.Find(Id);
            ViewBag.ShowAddedComment = true;
            return RedirectToAction("read" ,new { id = Id });
        }

    }
}