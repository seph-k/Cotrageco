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
    public class Corperate_InfoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Corperate_InfoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Corperate_Info
        public async Task<IActionResult> Index()
        {
              return _context.Corperate_Infos != null ? 
                          View(await _context.Corperate_Infos.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Corperate_Infos'  is null.");
        }

        // GET: Corperate_Info/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Corperate_Infos == null)
            {
                return NotFound();
            }

            var corperate_Info = await _context.Corperate_Infos
                .FirstOrDefaultAsync(m => m.Corperate_InfoId == id);
            if (corperate_Info == null)
            {
                return NotFound();
            }

            return View(corperate_Info);
        }

        // GET: Corperate_Info/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Corperate_Info/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Corperate_InfoId,Corperate_Title,Corperate_Icon,Corperate_Description")] Corperate_Info corperate_Info)
        {
            if (ModelState.IsValid)
            {
                _context.Add(corperate_Info);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(corperate_Info);
        }

        // GET: Corperate_Info/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Corperate_Infos == null)
            {
                return NotFound();
            }

            var corperate_Info = await _context.Corperate_Infos.FindAsync(id);
            if (corperate_Info == null)
            {
                return NotFound();
            }
            return View(corperate_Info);
        }

        // POST: Corperate_Info/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Corperate_InfoId,Corperate_Title,Corperate_Icon,Corperate_Description")] Corperate_Info corperate_Info)
        {
            if (id != corperate_Info.Corperate_InfoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(corperate_Info);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Corperate_InfoExists(corperate_Info.Corperate_InfoId))
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
            return View(corperate_Info);
        }

        // GET: Corperate_Info/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Corperate_Infos == null)
            {
                return NotFound();
            }

            var corperate_Info = await _context.Corperate_Infos
                .FirstOrDefaultAsync(m => m.Corperate_InfoId == id);
            if (corperate_Info == null)
            {
                return NotFound();
            }

            return View(corperate_Info);
        }

        // POST: Corperate_Info/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Corperate_Infos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Corperate_Infos'  is null.");
            }
            var corperate_Info = await _context.Corperate_Infos.FindAsync(id);
            if (corperate_Info != null)
            {
                _context.Corperate_Infos.Remove(corperate_Info);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Corperate_InfoExists(int id)
        {
          return (_context.Corperate_Infos?.Any(e => e.Corperate_InfoId == id)).GetValueOrDefault();
        }
    }
}
