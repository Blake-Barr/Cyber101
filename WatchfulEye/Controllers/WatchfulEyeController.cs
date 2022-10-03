using Microsoft.AspNetCore.Mvc;

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
    }
}
