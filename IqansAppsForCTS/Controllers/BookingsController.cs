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
using System.Security.Claims;
using System.Web.Helpers;

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
                booking.EmpId = User.Identity.Name;
                booking.BookingTime = DateTime.Now;
                booking.StartTime = startDateTime;
                booking.EndTime = endDateTime;

                var temp = db.BookingNews.Where(x => x.StartDate == booking.StartDate && x.RoomNumber == booking.RoomNumber).ToList();
                TimeRange range = new TimeRange(booking.StartTime, booking.EndTime);

                foreach (var item in temp)
                {
                    TimeRange rangeItem = new TimeRange(item.StartTime, item.EndTime);
                    if (rangeItem.Clashes(range,true))
                    {
                        TempData["Error"] = "Booking Id: " + item.BookingId + " | Start Time:" + item.StartTime + " | End Time:" + item.EndTime + " | Booked By:" + item.EmpId;
                        return RedirectToAction("Create");
                    }
                }
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
            if (booking.EmpId != User.Identity.Name)
            {
                TempData["DeleteError"] = @"You are not allowed to delete this booking. Its Booked By: " + booking.EmpId;
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

    public interface IRange<T>
    {
        T Start { get; }
        T End { get; }
        bool Includes(T value);
        bool Includes(IRange<T> range);
        bool Clashes(TimeRange other, bool inclusive);
    }
    public class TimeRange : IRange<TimeSpan>
    {
        public TimeRange(TimeSpan start, TimeSpan end)
        {
            Start = start;
            End = end;
        }

        public TimeSpan Start { get; private set; }
        public TimeSpan End { get; private set; }

        public bool Includes(TimeSpan value)
        {
            return (Start <= value) && (value <= End);
        }

        public bool Includes(IRange<TimeSpan> range)
        {
            if (Start <= range.Start)
            {
                
            }
            return (Start <= range.Start) && (range.End <= End);
        }

        public bool Clashes(TimeRange other, bool inclusive)
        {
            if (inclusive)
            {
                return (other.Start <= Start && other.End >= End) ||
                    (other.Start < Start && other.End >= Start) ||
                    (other.End > End && other.Start <= End) ||
                    (other.Start >= Start && other.End <= End);
            }
            else
            {
                return (other.Start < Start && other.End > End) ||
                    (other.Start < Start && other.End > Start) ||
                    (other.End > End && other.Start < End) ||
                    (other.Start >= Start && other.End <= End);
            }
        }
        //usage
        //DateRange range = new DateRange(startDate, endDate);
        //range.Includes(date);
    }
}
