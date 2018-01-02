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
    public class caresController : Controller
    {
        private NewsEntities db = new NewsEntities();

        // GET: Admins/cares
        public ActionResult Index()
        {
            var care = db.care.ToList();
            return View(care);
        }

        // GET: Admins/cares/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            care care = await db.care.FindAsync(id);
            if (care == null)
            {
                return HttpNotFound();
            }
            return View(care);
        }

        // GET: Admins/cares/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admins/cares/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,count,description,date")] care care)
        {
            if (ModelState.IsValid)
            {
                db.care.Add(care);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(care);
        }

        // GET: Admins/cares/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            care care = await db.care.FindAsync(id);
            if (care == null)
            {
                return HttpNotFound();
            }
            return View(care);
        }

        // POST: Admins/cares/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,count,description,date")] care care)
        {
            if (ModelState.IsValid)
            {
                db.Entry(care).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(care);
        }

        // GET: Admins/cares/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            care care = await db.care.FindAsync(id);
            if (care == null)
            {
                return HttpNotFound();
            }
            return View(care);
        }

        // POST: Admins/cares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            care care = await db.care.FindAsync(id);
            db.care.Remove(care);
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
