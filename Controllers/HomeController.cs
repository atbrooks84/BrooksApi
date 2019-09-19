using BrooksApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrooksApi.Controllers
{
    public class HomeController : Controller
    {
        private ApiDbContext db = new ApiDbContext();
        public ActionResult Index()
        {
            var households = db
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
