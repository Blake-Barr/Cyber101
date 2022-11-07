using Microsoft.AspNetCore.Mvc;
using WatchfulEye.Data;

namespace WatchfulEye.Controllers
{
    public class InteractiveController : Controller
    {
        private readonly WatchfulEyeContext db;
        public InteractiveController(WatchfulEyeContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult SpotGame()
        {
            var site = db.fakeSites.First();
            return View(site);
        }
    }
}
