using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILog logger = LogManager.GetLogger(typeof(HomeController));

        public ActionResult Index()
        {
            logger.Info("Index page opened");

            return View();
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