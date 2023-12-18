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
    public class Home_BannerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Home_BannerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Home_Banner
        public async Task<IActionResult> Index()
        {
              return _context.Home_Banners != null ? 
                          View(await _context.Home_Banners.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Home_Banners'  is null.");
        }

        // GET: Home_Banner/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Home_Banners == null)
            {
                return NotFound();
            }

            var home_Banner = await _context.Home_Banners
                .FirstOrDefaultAsync(m => m.Home_BannerId == id);
            if (home_Banner == null)
            {
                return NotFound();
            }

            return View(home_Banner);
        }

        // GET: Home_Banner/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Home_Banner/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Home_BannerId,Home_Title,Home_Description,Home_Image")] Home_Banner home_Banner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(home_Banner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(home_Banner);
        }

        // GET: Home_Banner/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Home_Banners == null)
            {
                return NotFound();
            }

            var home_Banner = await _context.Home_Banners.FindAsync(id);
            if (home_Banner == null)
            {
                return NotFound();
            }
            return View(home_Banner);
        }

        // POST: Home_Banner/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Home_BannerId,Home_Title,Home_Description,Home_Image")] Home_Banner home_Banner)
        {
            if (id != home_Banner.Home_BannerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(home_Banner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Home_BannerExists(home_Banner.Home_BannerId))
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
            return View(home_Banner);
        }

        // GET: Home_Banner/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Home_Banners == null)
            {
                return NotFound();
            }

            var home_Banner = await _context.Home_Banners
                .FirstOrDefaultAsync(m => m.Home_BannerId == id);
            if (home_Banner == null)
            {
                return NotFound();
            }

            return View(home_Banner);
        }

        // POST: Home_Banner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Home_Banners == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Home_Banners'  is null.");
            }
            var home_Banner = await _context.Home_Banners.FindAsync(id);
            if (home_Banner != null)
            {
                _context.Home_Banners.Remove(home_Banner);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Home_BannerExists(int id)
        {
          return (_context.Home_Banners?.Any(e => e.Home_BannerId == id)).GetValueOrDefault();
        }
    }
}
