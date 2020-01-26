using System.Web.Mvc;

namespace MVCEventScheduler.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Welcome to Event Scheduler, a website that allows you to schedule private and public events.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "My Email: deyoun39@mail.nmc.edu";

            return View();
        }
    }
}