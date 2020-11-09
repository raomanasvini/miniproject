using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieProject.Models;

namespace MovieProject.Controllers
{
    public class LoginAuthController : Controller
    {
        MoviedatabaseEntities db = new MoviedatabaseEntities();
        // GET: LoginAuth
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection frm)
        {
            var name = (from c in db.Customers
                        where frm["txtuname"].ToString() == c.CustomerName &&
                        frm["txtpwd"].ToString() == c.password
                        select c.CustomerName);

            if (name != null)
            {
                Session["Loginstatus"] = "valid";
                Session["UserId"] = frm["txtuname"];
                return RedirectToAction("GetBooking", "MovieBooking");
            }
            else
            {
                Session["Loginstatus"] = "Invalid";
                return View();
            }

        }
        public ActionResult LogOff()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}