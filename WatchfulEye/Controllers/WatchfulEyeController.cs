using Microsoft.AspNetCore.Mvc;
using WatchfulEye.Models;

namespace WatchfulEye.Controllers
{
    public class WatchfulEyeController : Controller
    {
        public IActionResult BruteForceTesting()
        {
            return View();
        }

        public IActionResult PhishingSimulator()
        {
            return View();
        }

        public IActionResult PhishingSimulatorP2()
        {
            return View();
        }

        public IActionResult PhishingSimulatorP3()
        {
            return View();
        }

        public string testEmail()
        {
            PhishingModel m = new PhishingModel();
            m.testCreateEmail();

            return "Sent";
        }
    }
}
