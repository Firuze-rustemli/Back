using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xeber.Models;

namespace Xeber.Controllers
{
    public class CategoryController : Controller
    {
        private NewsEntities db = new NewsEntities();

        // GET: Category
        public ActionResult Index()
        {
            ViewBag.setting = db.settings.Find(1);
            ViewBag.sosial = db.sosial.Take(3).ToList();
            ViewBag.first = db.news.Where(x => x.type.name == "first").OrderBy(x => x.date).Take(2);
            ViewBag.first2 = db.news.Where(x => x.type.name == "first2").OrderBy(x => x.date).Take(1);
            ViewBag.snd = db.news.Where(x => x.type.name == "snd").OrderBy(x => x.date).Take(3);
            ViewBag.scnd = db.news.Where(x => x.type.name == "scnd").OrderBy(x => x.date).Take(3);
            ViewBag.third = db.news.Where(x => x.type.name == "thrd ").OrderBy(x => x.date).Take(3);
            ViewBag.third2 = db.news.Where(x => x.type.name == "third2 ").OrderBy(x => x.date).Take(1);
            ViewBag.fourth = db.news.Where(x => x.type.name == "frth ").OrderBy(x => x.date).Take(3);
            ViewBag.fourth2= db.news.Where(x => x.type.name == "frth2 ").OrderBy(x => x.date).Take(1);
            ViewBag.fifth = db.news.Where(x => x.type.name == "fifth").OrderBy(x => x.date).Take(3);
            ViewBag.fifth2 = db.news.Where(x => x.type.name == "fifth2").OrderBy(x => x.date).Take(1);
            ViewBag.side = db.news.Where(x => x.type.name == "aside").OrderBy(x => x.date).Take(7);
            ViewBag.sidecol = db.news.Where(x => x.type.name == "sidecol").OrderBy(x => x.date).Take(6);

            return View();
        }

        public ActionResult sport()
        {
            ViewBag.setting = db.settings.Find(1);
            ViewBag.sosial = db.sosial.Take(3).ToList();
            ViewBag.sport = db.news.Where(x => x.type.name == "sport").OrderBy(x => x.date).Take(7);
            ViewBag.sport_snd = db.news.Where(x => x.type.name == "sprt_nd").OrderBy(x => x.date).Take(6);
            ViewBag.sport_rd = db.news.Where(x => x.type.name == "sprt_rd").OrderBy(x => x.date).Take(6);
            ViewBag.sport_side = db.news.Where(x => x.type.name == "sprt_side").OrderBy(x => x.date).Take(6);
            ViewBag.sport_down = db.news.Where(x => x.type.name == "sprt_dwn").OrderBy(x => x.date).Take(6);
            ViewBag.sport_right = db.news.Where(x => x.type.name == "sprt_rgh").OrderBy(x => x.date).Take(6);

            return View();
        }


        public ActionResult social()
        {
            ViewBag.setting = db.settings.Find(1);
            ViewBag.sosial = db.sosial.Take(3).ToList();
            ViewBag.social = db.news.Where(x => x.type.name == "social").OrderBy(x => x.date).Take(9);
            ViewBag.social_snd = db.news.Where(x => x.type.name == "social_snd").OrderBy(x => x.date).Take(4);
            ViewBag.social_thr = db.news.Where(x => x.type.name == "social_trh").OrderBy(x => x.date).Take(7);
            ViewBag.social_fth= db.news.Where(x => x.type.name == "social_fth").OrderBy(x => x.date).Take(4);
            ViewBag.social_fifth = db.news.Where(x => x.type.name == "social_fifth").OrderBy(x => x.date).Take(5);
            ViewBag.social_side= db.news.Where(x => x.type.name == "social_side").OrderBy(x => x.date).Take(18);
            ViewBag.social_sidecol = db.news.Where(x => x.type.name == "social_sidecol").OrderBy(x => x.date).Take(8);
            ViewBag.social_cols = db.news.Where(x => x.type.name == "social_cols").OrderBy(x => x.date).Take(3);


            return View();
        }

        public ActionResult world()
        {
            ViewBag.setting = db.settings.Find(1);
            ViewBag.sosial = db.sosial.Take(3).ToList();
            ViewBag.world_frst = db.news.Where(x => x.type.name == "world_frst").OrderBy(x => x.date).Take(6);
            ViewBag.world_snd = db.news.Where(x => x.type.name == "world_snd").OrderBy(x => x.date).Take(6);
            ViewBag.world_trd = db.news.Where(x => x.type.name == "world_trd").OrderBy(x => x.date).Take(3);
            ViewBag.world_fth = db.news.Where(x => x.type.name == "world_fth").OrderBy(x => x.date).Take(6);
            ViewBag.world_fifth = db.news.Where(x => x.type.name == "world_fifth").OrderBy(x => x.date).Take(8);
            ViewBag.world_side = db.news.Where(x => x.type.name == "world_side").OrderBy(x => x.date).Take(6);


            return View();
        }


        public ActionResult crime(int? id)
        {
            ViewBag.setting = db.settings.Find(1);
            ViewBag.sosial = db.sosial.Take(3).ToList();
            ViewBag.crime = db.news.Where(x => x.type.name == "crime").OrderBy(x => x.date).Take(9);
            ViewBag.crime_snd = db.news.Where(x => x.type.name == "crime_snd").OrderBy(x => x.date).Take(8);
            ViewBag.crime_trd= db.news.Where(x => x.type.name == "crime_trd").OrderBy(x => x.date).Take(6);
            ViewBag.crime_fth = db.news.Where(x => x.type.name == "crime_fth").OrderBy(x => x.date).Take(3);
            ViewBag.crime_down = db.news.Where(x => x.type.name == "crime_down").OrderBy(x => x.date).Take(3);
            ViewBag.crime_down2 = db.news.Where(x => x.type.name == "crime_down2").OrderBy(x => x.date).Take(1);
            ViewBag.crime_side= db.news.Where(x => x.type.name == "crime_side").OrderBy(x => x.date).Take(8);
            ViewBag.all = db.news.Where(x => x.type.name == "crime_all").OrderBy(x => x.date).Take(14);

            return View();
        }

        public ActionResult magasin()
        {
            ViewBag.setting = db.settings.Find(1);
            ViewBag.sosial = db.sosial.Take(3).ToList();
            ViewBag.magasin = db.news.Where(x => x.type.name == "magasin").OrderBy(x => x.date).Take(2);
            ViewBag.magasin2 = db.news.Where(x => x.type.name == "magasin2").OrderBy(x => x.date).Take(1);
            ViewBag.magasin_fouth = db.news.Where(x => x.type.name == "magasin_fouth").OrderBy(x => x.date).Take(4);
            ViewBag.magasin_trd = db.news.Where(x => x.type.name == "magasin_trd").OrderBy(x => x.date).Take(14);
            ViewBag.magasin_section = db.news.Where(x => x.type.name == "magasin_section").OrderBy(x => x.date).Take(6);
            ViewBag.magasin_slide= db.news.Where(x => x.type.name == "magasin_slide").OrderBy(x => x.date).Take(4);
            ViewBag.magasin_down = db.news.Where(x => x.type.name == "magasin_down").OrderBy(x => x.date).Take(6);


            return View();
        }


        public ActionResult healthy()

        {

            ViewBag.setting = db.settings.Find(1);
            ViewBag.sosial = db.sosial.Take(3).ToList();
            ViewBag.healthy= db.news.Where(x => x.type.name == "healhty").OrderBy(x => x.date).Take(1);
            ViewBag.healthy_nd = db.news.Where(x => x.type.name == "healhty_nd").OrderBy(x => x.date).Take(4);
            ViewBag.healthy_rd = db.news.Where(x => x.type.name == "healhty_rd").OrderBy(x => x.date).Take(3);
            ViewBag.healthy_fth = db.news.Where(x => x.type.name == "healhty_fth").OrderBy(x => x.date).Take(3);
            ViewBag.healthy_slide = db.news.Where(x => x.type.name == "healhty_slide").OrderBy(x => x.date).Take(3);
            ViewBag.healthy_colms= db.news.Where(x => x.type.name == "healhty_colms").OrderBy(x => x.date).Take(7);
            ViewBag.care = db.care.Take(14).ToList();


            return View(); 

        }


        public ActionResult tech()

        {

            ViewBag.setting = db.settings.Find(1);


            return View();

        }

    }
}