using Microsoft.AspNetCore.Mvc;

namespace WatchfulEye.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Settings()
        {
            return View();
        }

        public IActionResult Main()
        {
            return View();
        }
    }
}
