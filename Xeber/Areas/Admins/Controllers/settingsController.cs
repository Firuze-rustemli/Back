using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Xeber.Models;

namespace Xeber.Areas.Admins.Controllers
{
    public class settingsController : Controller
    {
        private NewsEntities db = new NewsEntities();

        // GET: Admins/settings
        public ActionResult Index()
        {
            var settings = db.settings.ToList();
            return View(settings);
        }

        // GET: Admins/settings/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            settings settings = await db.settings.FindAsync(id);
            if (settings == null)
            {
                return HttpNotFound();
            }
            return View(settings);
        }

        // GET: Admins/settings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admins/settings/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,logo,flogo,advertsment,fadvertsment,location,email,phono")] settings settings)
        {
            if (ModelState.IsValid)
            {
                db.settings.Add(settings);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(settings);
        }

        // GET: Admins/settings/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            settings settings = await db.settings.FindAsync(id);
            if (settings == null)
            {
                return HttpNotFound();
            }
            return View(settings);
        }

        // POST: Admins/settings/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,logo,flogo,advertsment,fadvertsment,location,email,phono")] settings settings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(settings).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(settings);
        }

        // GET: Admins/settings/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            settings settings = await db.settings.FindAsync(id);
            if (settings == null)
            {
                return HttpNotFound();
            }
            return View(settings);
        }

        // POST: Admins/settings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            settings settings = await db.settings.FindAsync(id);
            db.settings.Remove(settings);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
