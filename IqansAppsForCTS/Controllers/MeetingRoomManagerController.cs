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
            var temp = list.OrderBy(l => l.StartDateTime);
            return View(temp);
        }

        // GET: MeetingRoomManager/Details/5
        public ActionResult Details(MeetingRoom mr)
        {
            return View(mr);
        }

        // GET: MeetingRoomManager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MeetingRoomManager/Create
        [HttpPost]
        public ActionResult Create(MeetingRoom mrObj)
        {
            try
            {
                // TODO: Add insert logic here

                if (ModelState.IsValid)
                {
                    mrObj.Bookingtime = DateTime.Now;
                    var mr1 = DbMethods.Booking(mrObj);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Correct the details.");
                    return View();
                }
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
