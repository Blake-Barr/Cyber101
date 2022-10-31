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

        public async Task<IActionResult> PhishingSimulatorP3()
        {
            return View(await db.emailTemplates.ToListAsync());
        }

        public IActionResult PhishingSimulatorP2()
        {
            return View();
        }

        public IActionResult PhishingSimulator()
        {
            return View();
        }

        public async Task<IActionResult> EmailTemplateList()
        {
            return View(await db.emailTemplates.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail([FromForm] int template, [FromForm] string emailAddress, [FromForm] string name)
        {
            var emailTemplate = await db.emailTemplates
                .FirstOrDefaultAsync(m => m.ID == template);

            PhishingModel m = new PhishingModel();
            m.sendEmail(emailTemplate, emailAddress, name);

            return RedirectToAction(nameof(PhishingSimulator));
        }
    }
}
