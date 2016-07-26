using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IqansAppsForCTS.Models;
using System.Net.Mail;

namespace IqansAppsForCTS.Controllers
{
    [Authorize]
    public class BookingsController : Controller
    {
        private MeetingRoomManagerEntities db = new MeetingRoomManagerEntities();

        // GET: Bookings
        public ActionResult Index()
        {
            Session["EmpId"] = User.Identity.Name;
            var temp = db.BookingNews.ToList();
            List<BookingNew> sortedList = temp.OrderBy(o => o.StartDate).ThenBy(o => o.StartTime).ToList();
            return View(sortedList);
        }

        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingNew booking = db.BookingNews.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookingNew booking, TimeSpan startDateTime, TimeSpan endDateTime)
        {
            if (ModelState.IsValid)
            {
                booking.EmpId = Session["EmpId"].ToString();
                booking.BookingTime = DateTime.Now;
                booking.StartTime = startDateTime;
                booking.EndTime = endDateTime;
                db.BookingNews.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(booking);
        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingNew booking = db.BookingNews.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookingNew booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingNew booking = db.BookingNews.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            if (booking.EmpId != Session["EmpId"].ToString())
            {
                TempData["DeleteError"] = "You are not allowed to delete this.";
                TempData.Keep();
                return RedirectToAction("Index", booking);
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookingNew booking = db.BookingNews.Find(id);
            db.BookingNews.Remove(booking);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
