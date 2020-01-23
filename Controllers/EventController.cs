using System.Web.Mvc;

namespace MVCEventScheduler.Controllers
{
    public class EventController : Controller
    {
        // GET: Event

        [HttpPost]
        public ActionResult NewEvent(string eventName, string eventHost, string email)
        {
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