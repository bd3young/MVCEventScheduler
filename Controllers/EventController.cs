using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEventScheduler.Controllers
{
    public class EventController : Controller
    {
        // GET: Event

        [HttpPost]
        public ActionResult NewEvent(string eventName, string eventHost, string email, bool isPublic)
        {
            bool t = isPublic;
            if (t == true)
            {
                ViewBag.Message += $"Name: {eventName}    ";              
                ViewBag.Message += $"Host: {eventHost}    ";
                ViewBag.Message += $"Email: {email}    ";
                ViewBag.Message += $"Public: {isPublic}    ";
                return View("ConfirmPublicEvent");
            }
            else
            {
                ViewBag.Message += $"Name: {eventName}    ";
                ViewBag.Message += $"Host: {eventHost}    ";
                ViewBag.Message += $"Email: {email}    ";
                ViewBag.Message += $"Public: {isPublic}    ";
                return View("ConfirmEvent");
            }


        }

        public ActionResult NewEvent()
        {
            return View("NewEventForm");
        }
    }
}