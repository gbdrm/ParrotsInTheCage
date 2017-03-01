using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    public class CagesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Cages
        public ActionResult Index()
        {
            return View(db.Cages.ToList());
        }

        // GET: Cages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cage cage = db.Cages.Include(c => c.Parrots)
                .FirstOrDefault(c=>c.CageId == id);
            
            if (cage == null)
            {
                return HttpNotFound();
            }
            return View(cage);
        }

        // GET: Cages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CageId,Name")] Cage cage)
        {
            if (ModelState.IsValid)
            {
                db.Cages.Add(cage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cage);
        }

        // GET: Cages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cage cage = db.Cages.Find(id);
            if (cage == null)
            {
                return HttpNotFound();
            }
            return View(cage);
        }

        // POST: Cages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CageId,Name")] Cage cage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cage);
        }

        // GET: Cages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cage cage = db.Cages.Find(id);
            if (cage == null)
            {
                return HttpNotFound();
            }
            return View(cage);
        }

        // POST: Cages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cage cage = db.Cages.Find(id);
            db.Cages.Remove(cage);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Parrots()
        {
            var parrots = db.Parrots.ToList();
            return View(parrots);
        }

        [HttpPost]
        public ActionResult Parrots(IList<Parrot> parrots)
        {
            return View();
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
