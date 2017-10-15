using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelerikAcademyASPNETWebApp.Database;

namespace TelerikAcademyASPNETWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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

        /// <summary>
        /// Test connection method.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //[ValidateAntiForgeryToken]
        public ActionResult GetUsersData()
        {
            ModelDb db;
            using (db = new ModelDb())
            {
                var data = db.VW_AcademyUsers.ToList();
                return Json(new
                {
                    data = data
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}