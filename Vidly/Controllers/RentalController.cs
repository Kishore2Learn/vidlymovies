using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VidlyMovies.Controllers
{
    public class RentalController : Controller
    {
        // GET: Rentals
        [Authorize]
        public ActionResult New()
        {
            return View();
        }

        [Authorize]
        public ActionResult Returns()
        {
            return View();
        }
    }
}