using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WatchfulEye.Data;
using WatchfulEye.Models;
using WatchfulEye.Controllers;
using WatchfulEye.Models.Simulator;
using WatchfulEye.ViewModels;
using System.Text.Json.Nodes;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Net.Mail;
using System.Xml.Linq;

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
                    SimulatorLevelContent slc = db.simContent.Where(b => b.Id == level.SLCId).FirstOrDefault();
                    return View(new SimulatorLevelViewModel(level,slc));
                }
                else
                {
                    if (lvl > 3)
                    {
                        Random rnd = new Random();
                        var num = rnd.Next(0, 10);
                        // test value
                        num = 5;

                        var simLevel = new SimulatorLevel(lvl);
                        SimulatorLevelContent[] contents = db.simContent.Where(b => b.GameType == num).ToArray();
                        SimulatorLevelContent randomRes = contents[rnd.Next(0, contents.Length)];
                        currentUser.AssignedLevel = simLevel;
                        simLevel.SLC = randomRes;
                        IdentityResult res = await _userManager.UpdateAsync(currentUser);

                        return View(new SimulatorLevelViewModel(simLevel, simLevel.SLC));
                    }
                    else
                    {
                        var simLevel = new SimulatorLevel(lvl);
                        SimulatorLevelContent simLevelContent = db.simContent.Where(b => b.TutorialLevel == lvl).FirstOrDefault();
                        simLevel.SLC = simLevelContent;
                        currentUser.AssignedLevel = simLevel;
                        IdentityResult res = await _userManager.UpdateAsync(currentUser);
                        return View(new SimulatorLevelViewModel(simLevel, simLevel.SLC));
                    }
                }
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<JsonObject> CheckCompletion(SimulatorLevelViewModel slvm, string answers, int spotCount, string email, int template, string name)
        {
            var obj = new JsonObject();
            switch (slvm.simulatorLevelContent.GameType)
            {
                case -1:
                    obj.Add("completed", await CompleteLevel());
                    return obj;
                case 0:
                    QuizResults results = slvm.simulatorLevelContent.CheckAnswers(answers);
                    if (results.Completed)
                    {
                        obj.Add("completed", await CompleteLevel());
                        return obj;
                    }
                    else
                    {
                        obj.Add("completed", false);
                        obj.Add("incorrectList", String.Join("", results.Matches));
                        return obj;
                    }
                case 1:
                    if(spotCount >= slvm.simulatorLevelContent.TotalSpots)
                    {
                        obj.Add("completed", await CompleteLevel());
                        return obj;
                    }
                    else
                    {
                        obj.Add("completed", false);
                        return obj;
                    }
                case 2:
                    var currentUser = await _userManager.GetUserAsync(User);
                    PhishingModel m = new PhishingModel();
                    var emailTemplate = await db.emailTemplates.FirstOrDefaultAsync(m => m.ID == template);
                    m.sendEmail(emailTemplate, email, name, currentUser.Id);
                    obj.Add("completed", await CompleteLevel());
                    return obj;
                case 3:
                    obj.Add("completed", await CompleteLevel());
                    return obj;
                case 4:
                    obj.Add("completed", await CompleteLevel());
                    return obj;
                case 5:
                    obj.Add("completed", await CompleteLevel());
                    return obj;
            }

            return obj;

        }

        public async Task<bool> CompleteLevel()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser != null)
            {
                if (currentUser.AssignedLevelId != null)
                {
                    currentUser.AssignedLevelId = null;
                }

                currentUser.AwardXP(10);
                currentUser.CurrentCompletedLevel++;
                IdentityResult res = await _userManager.UpdateAsync(currentUser);

                db.SaveChanges();

            }

            return true;
        }

        public bool UpdateObjectives(bool[] objectives)
        {
            var completed = true;

            foreach(var objective in objectives)
            {
                if(!objective)
                {
                    completed = false;
                }
            }

            return completed;
        }

        [HttpPost]
        public JsonResult GetEmailTemplates(int amount)
        {
            Random rnd = new Random();
            List<EmailTemplate> templates = db.emailTemplates.ToList();
            templates = templates.OrderBy(x => rnd.Next()).Take(amount).ToList();
            return Json(templates);
        }

        public async Task<IActionResult> Fooled(string userId)
        {
            var responsibleUser = await db.Users.FirstOrDefaultAsync(m => m.Id == userId);
            if (responsibleUser != null)
            {
                responsibleUser.AwardXP(50);
            }

            return View();
        }
    }
}
