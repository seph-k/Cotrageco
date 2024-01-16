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
    public class Project_TitleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Project_TitleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Project_Title
        public async Task<IActionResult> Index()
        {
              return _context.Project_Titles != null ? 
                          View(await _context.Project_Titles.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Project_Titles'  is null.");
        }

        // GET: Project_Title/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Project_Titles == null)
            {
                return NotFound();
            }

            var project_Title = await _context.Project_Titles
                .FirstOrDefaultAsync(m => m.Project_TitleId == id);
            if (project_Title == null)
            {
                return NotFound();
            }

            return View(project_Title);
        }

        // GET: Project_Title/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Project_Title/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Project_TitleId,Title")] Project_Title project_Title)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project_Title);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(project_Title);
        }

        // GET: Project_Title/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Project_Titles == null)
            {
                return NotFound();
            }

            var project_Title = await _context.Project_Titles.FindAsync(id);
            if (project_Title == null)
            {
                return NotFound();
            }
            return View(project_Title);
        }

        // POST: Project_Title/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Project_TitleId,Title")] Project_Title project_Title)
        {
            if (id != project_Title.Project_TitleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project_Title);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Project_TitleExists(project_Title.Project_TitleId))
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
            return View(project_Title);
        }

        // GET: Project_Title/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Project_Titles == null)
            {
                return NotFound();
            }

            var project_Title = await _context.Project_Titles
                .FirstOrDefaultAsync(m => m.Project_TitleId == id);
            if (project_Title == null)
            {
                return NotFound();
            }

            return View(project_Title);
        }

        // POST: Project_Title/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Project_Titles == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Project_Titles'  is null.");
            }
            var project_Title = await _context.Project_Titles.FindAsync(id);
            if (project_Title != null)
            {
                _context.Project_Titles.Remove(project_Title);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Project_TitleExists(int id)
        {
          return (_context.Project_Titles?.Any(e => e.Project_TitleId == id)).GetValueOrDefault();
        }
    }
}
