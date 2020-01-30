using System.Web.Mvc;
using MVCEventScheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCEventScheduler.Controllers
{
    public class EventController : Controller
    {
        // GET: Event

        [HttpPost]
        public ActionResult NewEvent(string eventName, string eventType, string eventHost, string email, DateTime eventDateTime, int id, bool isPublic)
        {
            EventModel e = new EventModel()
            {
                EventName = eventName,
                EventType = eventType,
                EventHost = eventHost,
                Email = email,
                EventDateTime = eventDateTime,
                Id = id,
                IsPublic = isPublic

            };

            if (isPublic == true)
            {
                //ViewBag.Message += $"Name: {eventName}    ";              
                //ViewBag.Message += $"Host: {eventHost}    ";
                //ViewBag.Message += $"Email: {email}    ";
                //ViewBag.Message += $"Public: {isPublic}    ";
                return View("ConfirmPublicEvent", e);
            }
            else
            {
                //ViewBag.Message += $"Name: {eventName}    ";
                //ViewBag.Message += $"Host: {eventHost}    ";
                //ViewBag.Message += $"Email: {email}    ";
                //ViewBag.Message += $"Public: {isPublic}    ";
                return View("ConfirmEvent", e);
            }
        }

        public ActionResult NewEvent()
        {
            return View("NewEventForm");
        }

        public ActionResult EventCalc()
        {
            return View("EventCalculator");
        }

        public ActionResult PostedEvents()
        {
            return View("PostedEventsForm");
        }
    }
}