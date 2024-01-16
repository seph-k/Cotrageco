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
    public class Our_ResourceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Our_ResourceController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Our_Resource
        public async Task<IActionResult> Index()
        {
              return _context.Our_Resources != null ? 
                          View(await _context.Our_Resources.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Our_Resources'  is null.");
        }

        // GET: Our_Resource/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Our_Resources == null)
            {
                return NotFound();
            }

            var our_Resource = await _context.Our_Resources
                .FirstOrDefaultAsync(m => m.Our_ResourceId == id);
            if (our_Resource == null)
            {
                return NotFound();
            }

            return View(our_Resource);
        }

        // GET: Our_Resource/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Our_Resource/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Our_ResourceId,Resource_Title,Resource_Description")] Our_Resource our_Resource)
        {
            if (ModelState.IsValid)
            {
                _context.Add(our_Resource);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(our_Resource);
        }

        // GET: Our_Resource/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Our_Resources == null)
            {
                return NotFound();
            }

            var our_Resource = await _context.Our_Resources.FindAsync(id);
            if (our_Resource == null)
            {
                return NotFound();
            }
            return View(our_Resource);
        }

        // POST: Our_Resource/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Our_ResourceId,Resource_Title,Resource_Description")] Our_Resource our_Resource)
        {
            if (id != our_Resource.Our_ResourceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(our_Resource);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Our_ResourceExists(our_Resource.Our_ResourceId))
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
            return View(our_Resource);
        }

        // GET: Our_Resource/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Our_Resources == null)
            {
                return NotFound();
            }

            var our_Resource = await _context.Our_Resources
                .FirstOrDefaultAsync(m => m.Our_ResourceId == id);
            if (our_Resource == null)
            {
                return NotFound();
            }

            return View(our_Resource);
        }

        // POST: Our_Resource/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Our_Resources == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Our_Resources'  is null.");
            }
            var our_Resource = await _context.Our_Resources.FindAsync(id);
            if (our_Resource != null)
            {
                _context.Our_Resources.Remove(our_Resource);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Our_ResourceExists(int id)
        {
          return (_context.Our_Resources?.Any(e => e.Our_ResourceId == id)).GetValueOrDefault();
        }
    }
}
