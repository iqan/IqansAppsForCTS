using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IqansAppsForCTS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "App by Iqan.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "For any help feel free to contact.";

            return View();
        }
    }
}