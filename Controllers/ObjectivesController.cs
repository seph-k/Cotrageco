using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cotrageco.Data;
using Cotrageco.Models;

namespace Cotrageco.Controllers
{
    public class ObjectivesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ObjectivesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Objectives
        public async Task<IActionResult> Index()
        {
              return _context.Objectives != null ? 
                          View(await _context.Objectives.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Objectives'  is null.");
        }

        // GET: Objectives/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Objectives == null)
            {
                return NotFound();
            }

            var objective = await _context.Objectives
                .FirstOrDefaultAsync(m => m.ObjectiveId == id);
            if (objective == null)
            {
                return NotFound();
            }

            return View(objective);
        }

        // GET: Objectives/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Objectives/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ObjectiveId,Objective_Title,Objective_Description,Objective_Icon")] Objective objective)
        {
            if (ModelState.IsValid)
            {
                _context.Add(objective);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(objective);
        }

        // GET: Objectives/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Objectives == null)
            {
                return NotFound();
            }

            var objective = await _context.Objectives.FindAsync(id);
            if (objective == null)
            {
                return NotFound();
            }
            return View(objective);
        }

        // POST: Objectives/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ObjectiveId,Objective_Title,Objective_Description,Objective_Icon")] Objective objective)
        {
            if (id != objective.ObjectiveId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(objective);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObjectiveExists(objective.ObjectiveId))
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
            return View(objective);
        }

        // GET: Objectives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Objectives == null)
            {
                return NotFound();
            }

            var objective = await _context.Objectives
                .FirstOrDefaultAsync(m => m.ObjectiveId == id);
            if (objective == null)
            {
                return NotFound();
            }

            return View(objective);
        }

        // POST: Objectives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Objectives == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Objectives'  is null.");
            }
            var objective = await _context.Objectives.FindAsync(id);
            if (objective != null)
            {
                _context.Objectives.Remove(objective);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObjectiveExists(int id)
        {
          return (_context.Objectives?.Any(e => e.ObjectiveId == id)).GetValueOrDefault();
        }
    }
}
