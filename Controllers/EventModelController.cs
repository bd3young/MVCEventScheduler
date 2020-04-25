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
using MVCEventScheduler.ViewModels;

namespace MVCEventScheduler.Controllers
{
    [Authorize]
    public class EventModelController : Controller
    {
        private EventContext db = new EventContext();

        // GET: EventModel
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.Events.ToList());
        }
        //public ActionResult Index(int? id, int? attendanceId)
        //{
        //    var viewModel = new EventIndexData();
        //    viewModel.Events = db.Events
        //        .Include(i => i.Attendances.Select(a => a.User.UserName))
        //        .OrderBy(i => i.EventName);

        //    if (id != null)
        //    {
        //        ViewBag.EventID = id.Value;
        //        viewModel.Attendances = viewModel.Events.Where(
        //            i => i.Id == id.Value).Single().Attendances;
        //    }
        //    return View(viewModel);
        //}

        // GET: EventModel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventModel eventModel = db.Events.Find(id);
            if (eventModel == null)
            {
                return HttpNotFound();
            }
            return View(eventModel);
        }

        // GET: EventModel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventModel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EventName,EventType,EventHost,Email,EventDateTime,IsPublic,Location")] EventModel eventModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Events.Add(eventModel);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }


            return View(eventModel);
        }

        // GET: EventModel/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventModel eventModel = db.Events.Find(id);
            if (eventModel == null)
            {
                return HttpNotFound();
            }
            return View(eventModel);
        }

        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    EventModel events = db.Events
        //        .Include(i => i.Attendances)
        //        .Where(i => i.Id == id)
        //        .Single();
        //    PopulateAssignedAttendanceData(events);
        //    if (events == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(events);
        //}

        //private void PopulateAssignedAttendanceData(EventModel events)
        //{
        //    var allAttendances = db.Attendances;
        //    var instructorCourses = new HashSet<int>(events.Attendances.Select(c => c.UserID));
        //    var viewModel = new List<AssignedAttendanceData>();
        //    foreach (var attendance in allAttendances)
        //    {
        //        viewModel.Add(new AssignedAttendanceData
        //        {
        //            UserID = attendance.UserID,
        //            Status = attendance.Status,
        //        });
        //    }
        //    ViewBag.Courses = viewModel;
        //}

        // POST: EventModel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EventName,EventType,EventHost,Email,EventDateTime,IsPublic,Location")] EventModel eventModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(eventModel).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {

                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(eventModel);
        }
        //public ActionResult Edit(int? id, string[] selectedCourses)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var eventToUpdate = db.Events
        //       .Include(i => i.Attendances)
        //       .Where(i => i.Id == id)
        //       .Single();

        //    if (TryUpdateModel(eventToUpdate, "",
        //       new string[] { "EventName", "EventType", "EventHost", "Email", "EventDataTime", "IsPublic", "Location" }))
        //    {
        //        try
        //        {
        //            if (String.IsNullOrWhiteSpace(eventToUpdate.Attendances.))
        //            {
        //                instructorToUpdate.OfficeAssignment = null;
        //            }

        //            UpdateInstructorCourses(selectedCourses, instructorToUpdate);

        //            db.SaveChanges();

        //            return RedirectToAction("Index");
        //        }
        //        catch (RetryLimitExceededException /* dex */)
        //        {
        //            //Log the error (uncomment dex variable name and add a line here to write a log.
        //            ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
        //        }
        //    }
        //    PopulateAssignedCourseData(instructorToUpdate);
        //    return View(instructorToUpdate);
        //}
        //private void UpdateInstructorCourses(string[] selectedCourses, Instructor instructorToUpdate)
        //{
        //    if (selectedCourses == null)
        //    {
        //        instructorToUpdate.Courses = new List<Course>();
        //        return;
        //    }

        //    var selectedCoursesHS = new HashSet<string>(selectedCourses);
        //    var instructorCourses = new HashSet<int>
        //        (instructorToUpdate.Courses.Select(c => c.CourseID));
        //    foreach (var course in db.Courses)
        //    {
        //        if (selectedCoursesHS.Contains(course.CourseID.ToString()))
        //        {
        //            if (!instructorCourses.Contains(course.CourseID))
        //            {
        //                instructorToUpdate.Courses.Add(course);
        //            }
        //        }
        //        else
        //        {
        //            if (instructorCourses.Contains(course.CourseID))
        //            {
        //                instructorToUpdate.Courses.Remove(course);
        //            }
        //        }
        //    }
        //}

        // GET: EventModel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventModel eventModel = db.Events.Find(id);
            if (eventModel == null)
            {
                return HttpNotFound();
            }
            return View(eventModel);
        }

        // POST: EventModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                EventModel eventModel = db.Events.Find(id);
                db.Events.Remove(eventModel);
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
