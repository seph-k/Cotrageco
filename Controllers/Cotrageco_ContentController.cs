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
    public class Cotrageco_ContentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Cotrageco_ContentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cotrageco_Content
        public async Task<IActionResult> Index()
        {
              return _context.Cotrageco_Contents != null ? 
                          View(await _context.Cotrageco_Contents.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Cotrageco_Contents'  is null.");
        }

        // GET: Cotrageco_Content/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cotrageco_Contents == null)
            {
                return NotFound();
            }

            var cotrageco_Content = await _context.Cotrageco_Contents
                .FirstOrDefaultAsync(m => m.Cotrageco_ContentId == id);
            if (cotrageco_Content == null)
            {
                return NotFound();
            }

            return View(cotrageco_Content);
        }

        // GET: Cotrageco_Content/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cotrageco_Content/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cotrageco_ContentId,Objective_Title,Objective_Description,Project_Title,Project_Description,AboutUs_Title,AboutUs_Description,OFS_Title,OFS_Description,Services_Title,Services_Description,Realisations_Title,Realisations_Description,Purpose_Title,Purpose_Description,Contact_Title,Contact_Description,Contact_Address,Contact_Email,Contact_Phone,Resource_Title,Resource_Description,Representation_Title,Representation_Description")] Cotrageco_Content cotrageco_Content)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cotrageco_Content);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cotrageco_Content);
        }

        // GET: Cotrageco_Content/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cotrageco_Contents == null)
            {
                return NotFound();
            }

            var cotrageco_Content = await _context.Cotrageco_Contents.FindAsync(id);
            if (cotrageco_Content == null)
            {
                return NotFound();
            }
            return View(cotrageco_Content);
        }

        // POST: Cotrageco_Content/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cotrageco_ContentId,Objective_Title,Objective_Description,Project_Title,Project_Description,AboutUs_Title,AboutUs_Description,OFS_Title,OFS_Description,Services_Title,Services_Description,Realisations_Title,Realisations_Description,Purpose_Title,Purpose_Description,Contact_Title,Contact_Description,Contact_Address,Contact_Email,Contact_Phone,Resource_Title,Resource_Description,Representation_Title,Representation_Description")] Cotrageco_Content cotrageco_Content)
        {
            if (id != cotrageco_Content.Cotrageco_ContentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cotrageco_Content);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Cotrageco_ContentExists(cotrageco_Content.Cotrageco_ContentId))
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
            return View(cotrageco_Content);
        }

        // GET: Cotrageco_Content/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cotrageco_Contents == null)
            {
                return NotFound();
            }

            var cotrageco_Content = await _context.Cotrageco_Contents
                .FirstOrDefaultAsync(m => m.Cotrageco_ContentId == id);
            if (cotrageco_Content == null)
            {
                return NotFound();
            }

            return View(cotrageco_Content);
        }

        // POST: Cotrageco_Content/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cotrageco_Contents == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Cotrageco_Contents'  is null.");
            }
            var cotrageco_Content = await _context.Cotrageco_Contents.FindAsync(id);
            if (cotrageco_Content != null)
            {
                _context.Cotrageco_Contents.Remove(cotrageco_Content);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Cotrageco_ContentExists(int id)
        {
          return (_context.Cotrageco_Contents?.Any(e => e.Cotrageco_ContentId == id)).GetValueOrDefault();
        }
    }
}
