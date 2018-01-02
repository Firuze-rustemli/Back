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
    public class ViewsController : Controller
    {
        private NewsEntities db = new NewsEntities();

        // GET: Admins/Views
        public ActionResult Index()
        {
            var view = db.Views.ToList();
            return View(view);
        }

        // GET: Admins/Views/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Views views = await db.Views.FindAsync(id);
            if (views == null)
            {
                return HttpNotFound();
            }
            return View(views);
        }

        // GET: Admins/Views/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admins/Views/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,name")] Views views)
        {
            if (ModelState.IsValid)
            {
                db.Views.Add(views);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(views);
        }

        // GET: Admins/Views/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Views views = await db.Views.FindAsync(id);
            if (views == null)
            {
                return HttpNotFound();
            }
            return View(views);
        }

        // POST: Admins/Views/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,name")] Views views)
        {
            if (ModelState.IsValid)
            {
                db.Entry(views).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(views);
        }

        // GET: Admins/Views/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Views views = await db.Views.FindAsync(id);
            if (views == null)
            {
                return HttpNotFound();
            }
            return View(views);
        }

        // POST: Admins/Views/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Views views = await db.Views.FindAsync(id);
            db.Views.Remove(views);
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
