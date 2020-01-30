using System.Web.Mvc;
using MVCEventScheduler.Models;

namespace MVCEventScheduler.Controllers
{
    public class EventController : Controller
    {
        // GET: Event

        [HttpPost]
        public ActionResult NewEvent(string eventName, string eventHost, string email)
        {
            EventModel e = new EventModel()
            {

            };
            ViewBag.Message = $"Name: {eventName}";
            ViewBag.Message = $"Host: {eventHost}";
            ViewBag.Message += $"email: {email}";
            return View("ConfirmEvent");
        }

        public ActionResult NewEvent()
        {
            return View("NewEventForm");
        }
    }
}