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
    public class Realisation_CaptionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Realisation_CaptionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Realisation_Caption
        public async Task<IActionResult> Index()
        {
              return _context.Realisation_Captions != null ? 
                          View(await _context.Realisation_Captions.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Realisation_Caption'  is null.");
        }

        // GET: Realisation_Caption/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Realisation_Captions == null)
            {
                return NotFound();
            }

            var realisation_Caption = await _context.Realisation_Captions
                .FirstOrDefaultAsync(m => m.Realisation_CaptionId == id);
            if (realisation_Caption == null)
            {
                return NotFound();
            }

            return View(realisation_Caption);
        }

        // GET: Realisation_Caption/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Realisation_Caption/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Realisation_CaptionId,Caption")] Realisation_Caption realisation_Caption)
        {
            if (ModelState.IsValid)
            {
                _context.Add(realisation_Caption);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(realisation_Caption);
        }

        // GET: Realisation_Caption/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Realisation_Captions == null)
            {
                return NotFound();
            }

            var realisation_Caption = await _context.Realisation_Captions.FindAsync(id);
            if (realisation_Caption == null)
            {
                return NotFound();
            }
            return View(realisation_Caption);
        }

        // POST: Realisation_Caption/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Realisation_CaptionId,Caption")] Realisation_Caption realisation_Caption)
        {
            if (id != realisation_Caption.Realisation_CaptionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(realisation_Caption);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Realisation_CaptionExists(realisation_Caption.Realisation_CaptionId))
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
            return View(realisation_Caption);
        }

        // GET: Realisation_Caption/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Realisation_Captions == null)
            {
                return NotFound();
            }

            var realisation_Caption = await _context.Realisation_Captions
                .FirstOrDefaultAsync(m => m.Realisation_CaptionId == id);
            if (realisation_Caption == null)
            {
                return NotFound();
            }

            return View(realisation_Caption);
        }

        // POST: Realisation_Caption/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Realisation_Captions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Realisation_Caption'  is null.");
            }
            var realisation_Caption = await _context.Realisation_Captions.FindAsync(id);
            if (realisation_Caption != null)
            {
                _context.Realisation_Captions.Remove(realisation_Caption);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Realisation_CaptionExists(int id)
        {
          return (_context.Realisation_Captions?.Any(e => e.Realisation_CaptionId == id)).GetValueOrDefault();
        }
    }
}
