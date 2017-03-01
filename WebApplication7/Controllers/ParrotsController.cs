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
    public class ParrotsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Parrots
        public ActionResult Index()
        {
            var parrots = db.Parrots.Include(p => p.Cage);
            return View(parrots.ToList());
        }

        // GET: Parrots/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parrot parrot = db.Parrots.Find(id);
            if (parrot == null)
            {
                return HttpNotFound();
            }
            return View(parrot);
        }

        // GET: Parrots/Create
        public ActionResult Create()
        {
            ViewBag.CageId = new SelectList(db.Cages, "CageId", "Name");
            return View();
        }

        // POST: Parrots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Age,Color,CageId")] Parrot parrot)
        {
            if (ModelState.IsValid)
            {
                db.Parrots.Add(parrot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CageId = new SelectList(db.Cages, "CageId", "Name", parrot.CageId);
            return View(parrot);
        }

        // GET: Parrots/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parrot parrot = db.Parrots.Find(id);
            if (parrot == null)
            {
                return HttpNotFound();
            }
            ViewBag.CageId = new SelectList(db.Cages, "CageId", "Name", parrot.CageId);
            return View(parrot);
        }

        // POST: Parrots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Age,Color,CageId")] Parrot parrot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parrot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CageId = new SelectList(db.Cages, "CageId", "Name", parrot.CageId);
            return View(parrot);
        }

        // GET: Parrots/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parrot parrot = db.Parrots.Find(id);
            if (parrot == null)
            {
                return HttpNotFound();
            }
            return View(parrot);
        }

        // POST: Parrots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Parrot parrot = db.Parrots.Find(id);
            db.Parrots.Remove(parrot);
            db.SaveChanges();
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
