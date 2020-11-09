using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieProject.Models;

namespace MovieProject.Controllers
{
    public class MovieBookingController : Controller
    {
        MoviedatabaseEntities db = new MoviedatabaseEntities();
        // GET: MovieBooking
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetBooking()
        {
            List<MovieBooking> MB = db.MovieBookings.ToList();
            return View(MB);
        }
        public ActionResult Create()
        {
            ViewBag.Mid = new SelectList(db.Movietables, "MovieID", "MovieName");
            ViewBag.Sid = new SelectList(db.ScreenTables, "ScreenId", "ScreenId");
            return View();
        }
        [HttpPost]
        public ActionResult Create(MovieBooking movieBooking)
        {
            ScreenTable ST = new ScreenTable();
            var amount = (from s in db.ScreenTables
                          where s.ScreenId == movieBooking.Sid
                          select s.Amount).First();
            var Tamount = amount * movieBooking.NumberofSeats;
            ViewBag.TotalAmount = Tamount;

            if (ModelState.IsValid)
            {
                db.MovieBookings.Add(movieBooking);
                movieBooking.TotalAmount = Tamount;
                ScreenTable sc = db.ScreenTables.Find(ST.ScreenId = Convert.ToInt32(movieBooking.Sid));
                sc.NumberofSeats = (sc.NumberofSeats - movieBooking.NumberofSeats);
                db.SaveChanges();
                return RedirectToAction("GetBooking");
            }

            ViewBag.Mid = new SelectList(db.Movietables, "MovieID", "MovieName", movieBooking.Mid);
            ViewBag.Sid = new SelectList(db.ScreenTables, "ScreenId", "ScreenId", movieBooking.Sid);

            return View(movieBooking);
        }
        public ActionResult Details(int id)
        {
            MovieBooking movieBooking = db.MovieBookings.Find(id);
            return View(movieBooking);
        }

        public ActionResult Delete(int id)
        {
            ScreenTable ST = new ScreenTable();
            MovieBooking movieBooking = db.MovieBookings.Find(id);
            ScreenTable screen = db.ScreenTables.Find(ST.ScreenId = Convert.ToInt32(movieBooking.Sid));
            screen.NumberofSeats = (screen.NumberofSeats + movieBooking.NumberofSeats);
            db.MovieBookings.Remove(movieBooking);
            db.SaveChanges();
            return RedirectToAction("GetBooking");
        }
    }
}