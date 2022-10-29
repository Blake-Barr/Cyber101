using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WatchfulEye.Data;
using WatchfulEye.Models;

namespace WatchfulEye.Controllers
{
    public class EmailTemplatesController : Controller
    {
        private readonly WatchfulEyeContext _context;

        public EmailTemplatesController(WatchfulEyeContext context)
        {
            _context = context;
        }

        // GET: EmailTemplates
        public async Task<IActionResult> Index()
        {
              return View(await _context.emailTemplates.ToListAsync());
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
        public async Task<IActionResult> Create([Bind("ID,HTML,difficultyLevel,name,header")] EmailTemplate emailTemplate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emailTemplate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emailTemplate);
        }

        // GET: EmailTemplates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.emailTemplates == null)
            {
                return NotFound();
            }

            var emailTemplate = await _context.emailTemplates.FindAsync(id);
            if (emailTemplate == null)
            {
                return NotFound();
            }
            return View(emailTemplate);
        }

        // POST: EmailTemplates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,HTML,difficultyLevel,name,header")] EmailTemplate emailTemplate)
        {
            if (id != emailTemplate.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emailTemplate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmailTemplateExists(emailTemplate.ID))
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
            return View(emailTemplate);
        }

        // GET: EmailTemplates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.emailTemplates == null)
            {
                return NotFound();
            }

            var emailTemplate = await _context.emailTemplates
                .FirstOrDefaultAsync(m => m.ID == id);
            if (emailTemplate == null)
            {
                return NotFound();
            }

            return View(emailTemplate);
        }

        // POST: EmailTemplates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.emailTemplates == null)
            {
                return Problem("Entity set 'WatchfulEyeContext.emailTemplates'  is null.");
            }
            var emailTemplate = await _context.emailTemplates.FindAsync(id);
            if (emailTemplate != null)
            {
                _context.emailTemplates.Remove(emailTemplate);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmailTemplateExists(int id)
        {
          return _context.emailTemplates.Any(e => e.ID == id);
        }
    }
}
