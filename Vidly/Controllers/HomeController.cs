using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace VidlyMovies.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Vidly - the online movie store by Renu Systems Inc.";

            return View();
        }

        [ActionName(name:"AboutCompany")]
        public ActionResult About(int id)
        {
            ViewBag.Message = "Vidly - the online movie store by "+ id;

            return View("About");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Renu Systems Inc.";

            return View();
        }
    }
}