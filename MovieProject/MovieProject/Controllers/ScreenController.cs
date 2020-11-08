using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieProject.Models;

namespace MovieProject.Controllers
{
    public class ScreenController : Controller
    {
        MoviedatabaseEntities db = new MoviedatabaseEntities();
        // GET: Screen
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit()
        {
            ScreenTable screenTable = db.ScreenTables.Find();
            return View();
        }
    }
}