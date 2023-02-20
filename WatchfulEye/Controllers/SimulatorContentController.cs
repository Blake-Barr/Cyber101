using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WatchfulEye.Data;
using WatchfulEye.Models;
using WatchfulEye.Models.Simulator;

namespace WatchfulEye.Controllers
{
    public class SimulatorContentController : Controller
    {
        private readonly WatchfulEyeContext _context;

        public SimulatorContentController(WatchfulEyeContext context)
        {
            _context = context;
        }

        // GET: EmailTemplates
        public async Task<IActionResult> Index()
        {
            return View(await _context.simContent.ToListAsync());
        }

        // GET: EmailTemplates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmailTemplates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HTMLContent,GameType,LevelDescription,LevelTitle")] SimulatorLevelContent simContent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(simContent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(simContent);
        }

        // GET: EmailTemplates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.simContent == null)
            {
                return NotFound();
            }

            var simContent = await _context.simContent.FindAsync(id);
            if (simContent == null)
            {
                return NotFound();
            }
            return View(simContent);
        }

        // POST: EmailTemplates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HTMLContent,GameType,LevelDescription,LevelTitle")] SimulatorLevelContent simContent)
        {
            if (id != simContent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(simContent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SimContentExists(simContent.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(simContent);
        }

        // GET: EmailTemplates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.simContent == null)
            {
                return NotFound();
            }

            var simContent = await _context.simContent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (simContent == null)
            {
                return NotFound();
            }

            return View(simContent);
        }

        // POST: EmailTemplates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.simContent == null)
            {
                return Problem("Entity set 'WatchfulEyeContext.simContent'  is null.");
            }
            var simContent = await _context.simContent.FindAsync(id);
            if (simContent != null)
            {
                _context.simContent.Remove(simContent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SimContentExists(int id)
        {
            return _context.simContent.Any(e => e.Id == id);
        }
    }
}
