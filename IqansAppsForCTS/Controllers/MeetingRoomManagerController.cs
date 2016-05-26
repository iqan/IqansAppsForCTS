using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IqansAppsForCTS.Models;
using IqansAppsForCTS.DBMethods;

namespace IqansAppsForCTS.Controllers
{
    public class MeetingRoomManagerController : Controller
    {
        // GET: MeetingRoomManager /
        public ActionResult Index()
        {
            var list = new List<MeetingRoom>();
            list = DbMethods.GetMeetingsByDate();
            return View(list);
        }

        // GET: MeetingRoomManager/Details/5
        public ActionResult Details()
        {
            MeetingRoom mr = new MeetingRoom();
            mr.RoomNumber = "2C1A";
            mr.EmpName = "Iqan";
            mr.StartDateTime = DateTime.Now;
            mr.EndDateTime = DateTime.Now.AddHours(1);
            mr.Subject = "test";
            mr.BookingId = "booking1";
            mr.Bookingtime = DateTime.Now;
            mr.EmpId = 513548;

            return View(mr);
        }

        // GET: MeetingRoomManager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MeetingRoomManager/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MeetingRoomManager/Edit/5
        public ActionResult Edit(MeetingRoom obj)
        {
            return View(obj);
        }

        // POST: MeetingRoomManager/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MeetingRoomManager/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MeetingRoomManager/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult test2()
        {
            var list = new List<MeetingRoom>();
            list = DbMethods.GetMeetingsByDate();
            return View(list);
        }
    }
}
