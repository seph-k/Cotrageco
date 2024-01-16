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
    public class RepresentationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RepresentationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Representations
        public async Task<IActionResult> Index()
        {
              return _context.Representations != null ? 
                          View(await _context.Representations.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Representations'  is null.");
        }

        // GET: Representations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Representations == null)
            {
                return NotFound();
            }

            var representation = await _context.Representations
                .FirstOrDefaultAsync(m => m.RepresentationId == id);
            if (representation == null)
            {
                return NotFound();
            }

            return View(representation);
        }

        // GET: Representations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Representations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RepresentationId,Representation_Title,Representation_Description")] Representation representation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(representation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(representation);
        }

        // GET: Representations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Representations == null)
            {
                return NotFound();
            }

            var representation = await _context.Representations.FindAsync(id);
            if (representation == null)
            {
                return NotFound();
            }
            return View(representation);
        }

        // POST: Representations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RepresentationId,Representation_Title,Representation_Description")] Representation representation)
        {
            if (id != representation.RepresentationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(representation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RepresentationExists(representation.RepresentationId))
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
            return View(representation);
        }

        // GET: Representations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Representations == null)
            {
                return NotFound();
            }

            var representation = await _context.Representations
                .FirstOrDefaultAsync(m => m.RepresentationId == id);
            if (representation == null)
            {
                return NotFound();
            }

            return View(representation);
        }

        // POST: Representations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Representations == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Representations'  is null.");
            }
            var representation = await _context.Representations.FindAsync(id);
            if (representation != null)
            {
                _context.Representations.Remove(representation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RepresentationExists(int id)
        {
          return (_context.Representations?.Any(e => e.RepresentationId == id)).GetValueOrDefault();
        }
    }
}
