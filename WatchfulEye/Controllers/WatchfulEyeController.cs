using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WatchfulEye.Data;
using WatchfulEye.Models;
using WatchfulEye.Controllers;
using WatchfulEye.Models.Simulator;

namespace WatchfulEye.Controllers
{
    public class WatchfulEyeController : Controller
    {
        private readonly WatchfulEyeContext db;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public WatchfulEyeController(WatchfulEyeContext db, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.db = db;
            this._userManager = userManager;
            this._signInManager = signInManager;
        }
        public IActionResult BruteForceTesting()
        {
            return View();
        }

        public async Task<IActionResult> PhishingSimulatorP3()
        {
            return View(await db.emailTemplates.ToListAsync());
        }

        public IActionResult PhishingSimulatorP4()
        {
            return View();
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

            return RedirectToAction(nameof(PhishingSimulatorP3));
        }

        // Test
        public IActionResult ShadySiteExample()
        {
            return View();
        }

        public async Task<IActionResult> Simulator()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if(currentUser != null)
            {
                var lvl = currentUser.CurrentCompletedLevel;

                
                if(currentUser.AssignedLevelId != null)
                {
                    SimulatorLevel level = db.simLevels.Where(b => b.Id == currentUser.AssignedLevelId).FirstOrDefault();
                    return View(level);
                }
                else
                {
                    if (lvl > 3)
                    {
                        Random rnd = new Random();
                        var num = rnd.Next(0, 10);
                        // test value
                        num = 0;

                        var simLevel = new SimulatorLevel(lvl, num);
                        currentUser.AssignedLevel = simLevel;
                        IdentityResult res = await _userManager.UpdateAsync(currentUser);

                        db.SaveChanges();

                        return View(simLevel);
                    }
                    else
                    {
                        var simLevel = new SimulatorLevel(lvl + 1, -1);
                        SimulatorLevelContent simLevelContent = db.simContent.Where(b => b.Id == lvl + 1).FirstOrDefault();
                        simLevel.HTMLContent = simLevelContent.HTMLContent;
                        simLevel.LevelDesc = simLevelContent.LevelDescription;
                        simLevel.LevelName = simLevelContent.LevelTitle;
                        currentUser.AssignedLevel = simLevel;
                        IdentityResult res = await _userManager.UpdateAsync(currentUser);
                        return View(simLevel);
                    }
                }
            }
            return RedirectToAction("Login", "Account");
        }

        public async Task<IActionResult> CompleteLevel()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser != null)
            {
                if (currentUser.AssignedLevelId != null)
                {
                    currentUser.AssignedLevelId = null;
                }

                currentUser.AwardXP(10);
                IdentityResult res = await _userManager.UpdateAsync(currentUser);

                db.SaveChanges();

            }

            return RedirectToAction("Index", "Home");
        }
    }
}
