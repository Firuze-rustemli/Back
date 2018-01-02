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
    public class exchangsController : Controller
    {
        private NewsEntities db = new NewsEntities();

        // GET: Admins/exchangs
        public ActionResult Index()
        {
            var exchang = db.exchang.ToList();
            return View(exchang);
        }

        // GET: Admins/exchangs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            exchang exchang = await db.exchang.FindAsync(id);
            if (exchang == null)
            {
                return HttpNotFound();
            }
            return View(exchang);
        }

        // GET: Admins/exchangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admins/exchangs/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,name,buying,sales")] exchang exchang)
        {
            if (ModelState.IsValid)
            {
                db.exchang.Add(exchang);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(exchang);
        }

        // GET: Admins/exchangs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            exchang exchang = await db.exchang.FindAsync(id);
            if (exchang == null)
            {
                return HttpNotFound();
            }
            return View(exchang);
        }

        // POST: Admins/exchangs/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,name,buying,sales")] exchang exchang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exchang).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(exchang);
        }

        // GET: Admins/exchangs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            exchang exchang = await db.exchang.FindAsync(id);
            if (exchang == null)
            {
                return HttpNotFound();
            }
            return View(exchang);
        }

        // POST: Admins/exchangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            exchang exchang = await db.exchang.FindAsync(id);
            db.exchang.Remove(exchang);
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
