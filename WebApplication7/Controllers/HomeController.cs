using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DataContext db = new DataContext();
            var cages = db.Cages
                .Include(c => c.Parrots)
                .Where(c => c.Parrots.Any(p => p.Age == 2));

            IQueryable<IGrouping<int, Parrot>> parrots = db.Parrots
                .Where(p => p.Age > 0)
                .GroupBy(p => p.CageId);

            return View(parrots);
        }

        public ActionResult About()
        {
            DataContext db = new DataContext();
            db.Parrots.Add(new Parrot()
            {
                Name = DateTime.Now.ToLongTimeString()
            });
            db.SaveChanges();

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}