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
    public class sosialsController : Controller
    {
        private NewsEntities db = new NewsEntities();

        // GET: Admins/sosials
        public ActionResult Index()
        {
            var sosials = db.sosial.ToList();
            return View(sosials);
        }

        // GET: Admins/sosials/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sosial sosial = await db.sosial.FindAsync(id);
            if (sosial == null)
            {
                return HttpNotFound();
            }
            return View(sosial);
        }

        // GET: Admins/sosials/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admins/sosials/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,link,name")] sosial sosial)
        {
            if (ModelState.IsValid)
            {
                db.sosial.Add(sosial);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(sosial);
        }

        // GET: Admins/sosials/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sosial sosial = await db.sosial.FindAsync(id);
            if (sosial == null)
            {
                return HttpNotFound();
            }
            return View(sosial);
        }

        // POST: Admins/sosials/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,link,name")] sosial sosial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sosial).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sosial);
        }

        // GET: Admins/sosials/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sosial sosial = await db.sosial.FindAsync(id);
            if (sosial == null)
            {
                return HttpNotFound();
            }
            return View(sosial);
        }

        // POST: Admins/sosials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            sosial sosial = await db.sosial.FindAsync(id);
            db.sosial.Remove(sosial);
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
