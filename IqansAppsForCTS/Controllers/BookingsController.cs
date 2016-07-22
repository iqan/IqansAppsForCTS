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
    public class BookingsController : Controller
    {
        private MeetingRoomManagerEntities db = new MeetingRoomManagerEntities();

        // GET: Bookings
        public ActionResult Index()
        {
            var temp = db.Bookings.ToList();
            List<Booking> SortedList = temp.OrderBy(o => o.StartDateTime).ToList();
            return View(SortedList);
        }

        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
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
        public ActionResult Create([Bind(Include = "BookingId,RoomNumber,StartDateTime,EndDateTime,EmpName,EmpId,BookingTime,Subject")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                booking.BookingTime = DateTime.Now;
                db.Bookings.Add(booking);
                db.SaveChanges();
                //MailMessage mail = new MailMessage();
                //mail.To.Add(booking.EmpName);
                //mail.From = new MailAddress("iqan.shaikh@gmail.com");
                //mail.Subject = "Booking Confirmation";
                //string Body = "Booking Confirmed: From " + booking.StartDateTime + " To " + booking.EndDateTime + " For : " + booking.Subject + " By " + booking.EmpName;
                //mail.Body = Body;
                //mail.IsBodyHtml = true;
                //SmtpClient smtp = new SmtpClient();
                //smtp.Host = "smtp.gmail.com";
                //smtp.Port = 587;
                //smtp.UseDefaultCredentials = false;
                //smtp.Credentials = new System.Net.NetworkCredential
                //("iqan.shaikh@gmail.com", "**");// Enter seders User name and password
                //smtp.EnableSsl = true;
                //smtp.Send(mail);
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
            Booking booking = db.Bookings.Find(id);
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
        public ActionResult Edit([Bind(Include = "BookingId,RoomNumber,StartDateTime,EndDateTime,EmpName,EmpId,BookingTime,Subject")] Booking booking)
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
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
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
