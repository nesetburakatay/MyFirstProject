using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationBlog.Models;
using System.Data.Entity;


namespace WebApplicationBlog.Controllers
{
    public class HomeController : Controller
    {
        MainContext db = new MainContext();
        
        public ActionResult Index()
        {
            db.CarCategories.ToList();
            return View();
        }

        public ActionResult About()
        {
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