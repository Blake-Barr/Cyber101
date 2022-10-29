using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WatchfulEye.Data;
using WatchfulEye.Models;

namespace WatchfulEye.Controllers
{
    public class WatchfulEyeController : Controller
    {
        private readonly WatchfulEyeContext db;
        
        public WatchfulEyeController(WatchfulEyeContext db)
        {
            this.db = db;
        }
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

        public async Task<IActionResult> EmailTemplateList()
        {
            return View(await db.emailTemplates.ToListAsync());
        }

        public string testEmail()
        {
            PhishingModel m = new PhishingModel();
            m.testCreateEmail();

            return "Sent";
        }
    }
}
