using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCEventScheduler.DAL;
using MVCEventScheduler.Models;
using PagedList;

namespace MVCEventScheduler.Controllers
{
    [Authorize]
    public class AttendanceController : Controller
    {
        private EventContext db = new EventContext();

        // GET: Attendance
        [AllowAnonymous]
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.EventSortParm = String.IsNullOrEmpty(sortOrder) ? "event_desc" : "";
            ViewBag.StatusSortParm = sortOrder == "Status" ? "status_desc" : "Status";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var attendances = from s in db.Attendances select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                attendances = attendances.Where(s => s.Event.EventName.Contains(searchString) || s.Status.ToString().Contains(searchString));
            }
            switch (sortOrder)
            {
                case "event_desc":
                    attendances = attendances.OrderByDescending(s => s.EventID);
                    break;
                case "Status":
                    attendances = attendances.OrderBy(s => s.Status);
                    break;
                case "status_desc":
                    attendances = attendances.OrderByDescending(s => s.Status);
                    break;
                default:
                    attendances = attendances.OrderBy(s => s.EventID);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(attendances.ToPagedList(pageNumber, pageSize));
        }

        // GET: Attendance/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }

        // GET: Attendance/Create
        public ActionResult Create()
        {
            ViewBag.EventID = new SelectList(db.Events, "Id", "EventName");
            ViewBag.UserID = new SelectList(db.Users, "ID", "UserName");
            return View();
        }

        // POST: Attendance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AttendanceId,EventID,UserID,Status")] Attendance attendance)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Attendances.Add(attendance);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {

                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }


            ViewBag.EventID = new SelectList(db.Events, "Id", "EventName", attendance.EventID);
            ViewBag.UserID = new SelectList(db.Users, "ID", "UserName", attendance.UserID);
            return View(attendance);
        }

        // GET: Attendance/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventID = new SelectList(db.Events, "Id", "EventName", attendance.EventID);
            ViewBag.UserID = new SelectList(db.Users, "ID", "UserName", attendance.UserID);
            return View(attendance);
        }

        // POST: Attendance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AttendanceId,EventID,UserID,Status")] Attendance attendance)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(attendance).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {

                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            ViewBag.EventID = new SelectList(db.Events, "Id", "EventName", attendance.EventID);
            ViewBag.UserID = new SelectList(db.Users, "ID", "UserName", attendance.UserID);
            return View(attendance);
        }

        // GET: Attendance/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }

        // POST: Attendance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Attendance attendance = db.Attendances.Find(id);
                db.Attendances.Remove(attendance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DataException)
            {

                return RedirectToAction("Delete", new { id = id, saveChangesError = true });

            }

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
