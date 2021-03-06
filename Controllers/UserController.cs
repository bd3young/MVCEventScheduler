﻿using System;
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
using System.Data.Entity.Infrastructure;
using MVCEventScheduler.ViewModels;

namespace MVCEventScheduler.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private EventContext db = new EventContext();

        // GET: User
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDisplay([Bind(Include = "ID,UserName,Location,Email")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Display");
            }
            return View(user);
        }

        // GET: Student/Edit/5
        public ActionResult EditDisplay(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        public ActionResult Display()
        {
            return View(db.Users.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserName,Location,Email")] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {

                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }


            return View(user);
        }

        // GET: User/Edit/5
        [Authorize (Roles ="Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User user = db.Users
        //        .Include(i => i.Attendances)
        //        .Where(i => i.ID == id)
        //        .Single();
        //    PopulateAttendanceData(user);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user);
        //}

        //private void PopulateAttendanceData(User user)
        //{
        //    var allAttendances = db.Attendances;
        //    var UserAttendances = new HashSet<int>(user.Attendances.Select(c => c.EventID));
        //    var viewModel = new List<AssignedAttendanceData>();
        //    foreach (var attendance in allAttendances)
        //    {
        //        viewModel.Add(new AssignedAttendanceData
        //        {
        //            EventID = attendance.EventID,
        //            //EventName = attendance.Event.EventName,
        //            UserID = attendance.UserID,
        //            Status = attendance.Status
        //        });
        //    }
        //    ViewBag.Attendances = viewModel;
        //}

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserName,Location,Email")] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {

                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(user);
        }

        //public ActionResult Edit(int? id, Status[] selectedStatus)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var userToUpdate = db.Users
        //       .Include(i => i.Attendances)
        //       .Where(i => i.ID == id)
        //       .Single();

        //    if (TryUpdateModel(userToUpdate, "",
        //       new string[] { "UserName", "Location", "Email" }))
        //    {
        //        try
        //        {
        //            //if (String.IsNullOrWhiteSpace(userToUpdate.Attendances.))
        //            //{
        //            //    userToUpdate.OfficeAssignment = null;
        //            //}

        //            UpdateUserAttendances(selectedStatus, userToUpdate);

        //            db.SaveChanges();

        //            return RedirectToAction("Index");
        //        }
        //        catch (RetryLimitExceededException /* dex */)
        //        {
        //            //Log the error (uncomment dex variable name and add a line here to write a log.
        //            ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
        //        }
        //    }
        //    PopulateAttendanceData(userToUpdate);
        //    return View(userToUpdate);
        //}
        //private void UpdateUserAttendances(Status[] selectedStatus, User userToUpdate)
        //{
        //    if (selectedStatus == null)
        //    {
        //        userToUpdate.Attendances = new List<Attendance>();
        //        return;
        //    }

        //    var selectedStatusHS = new HashSet<Status>(selectedStatus);
        //    var userAttendances = new HashSet<int>
        //        (userToUpdate.Attendances.Select(c => c.Id));
        //    foreach (var attendance in db.Attendances)
        //    {
        //        if (selectedStatusHS.Contains(attendance.Status))
        //        {
        //            if (!userAttendances.Contains(attendance.Id))
        //            {
        //                userToUpdate.Attendances.Add(attendance);
        //            }
        //        }
        //        else
        //        {
        //            if (userAttendances.Contains(attendance.Id))
        //            {
        //                userToUpdate.Attendances.Remove(attendance);
        //            }
        //        }
        //    }
        //}



        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                User user = db.Users.Find(id);
                db.Users.Remove(user);
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
