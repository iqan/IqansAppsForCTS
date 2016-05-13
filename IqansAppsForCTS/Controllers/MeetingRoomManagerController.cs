using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IqansAppsForCTS.Controllers
{
    public class MeetingRoomManagerController : Controller
    {
        // GET: MeetingRoomManager
        public ActionResult Index()
        {
            return View();
        }

        // GET: MeetingRoomManager/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
        public ActionResult Edit(int id)
        {
            return View();
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
    }
}
