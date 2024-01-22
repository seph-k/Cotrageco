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
    public class BannersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment; // Add this line


        public BannersController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Banners
        public async Task<IActionResult> Index()
        {
              return _context.Banner != null ? 
                          View(await _context.Banner.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Banner'  is null.");
        }

        // GET: Banners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Banner == null)
            {
                return NotFound();
            }

            var banner = await _context.Banner
                .FirstOrDefaultAsync(m => m.BannerId == id);
            if (banner == null)
            {
                return NotFound();
            }

            return View(banner);
        }

        // Helper method to save the uploaded image
        private async Task<string> SaveImage(IFormFile file)
        {

            if (file != null && file.Length > 0)
            {
                // Generate a unique file name for the image (you can customize this logic)
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;

                // Define the path to save the image in the wwwroot/uploads folder
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Create the uploads folder if it doesn't exist
                Directory.CreateDirectory(uploadsFolder);

                // Save the uploaded image to the file system
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Save the image file path to the database
                var filepath = "/uploads/" + uniqueFileName; // Relative path to the image

                return filePath; // Return the file path
            }

            return null; // No file uploaded
        }

        // GET: Banners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Banners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BannerId,Website_Logo,AboutUs_Banner,OFS_Banner,Services_Banner,Contact_Banner")] Banner banner, IFormFile Website_Logo, IFormFile AboutUs_Banner, IFormFile OFS_Banner, IFormFile Services_Banner, IFormFile Contact_Banner)
        {
            if (ModelState.IsValid)
            {
                // Save the uploaded images
                banner.Website_Logo = await SaveImage(Website_Logo);
                banner.AboutUs_Banner = await SaveImage(AboutUs_Banner);
                banner.OFS_Banner = await SaveImage(OFS_Banner);
                banner.Services_Banner = await SaveImage(Services_Banner);
                banner.Contact_Banner = await SaveImage(Contact_Banner);

                _context.Add(banner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(banner);
        }

        // GET: Banners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Banner == null)
            {
                return NotFound();
            }

            var banner = await _context.Banner.FindAsync(id);
            if (banner == null)
            {
                return NotFound();
            }
            return View(banner);
        }

        // POST: Banners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BannerId,Website_Logo,AboutUs_Banner,OFS_Banner,Services_Banner,Contact_Banner")] Banner banner, IFormFile Website_Logo, IFormFile AboutUs_Banner, IFormFile OFS_Banner, IFormFile Services_Banner, IFormFile Contact_Banner)
        {
            if (id != banner.BannerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(banner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BannerExists(banner.BannerId))
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
            return View(banner);
        }

        // GET: Banners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Banner == null)
            {
                return NotFound();
            }

            var banner = await _context.Banner
                .FirstOrDefaultAsync(m => m.BannerId == id);
            if (banner == null)
            {
                return NotFound();
            }

            return View(banner);
        }

        // POST: Banners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Banner == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Banner'  is null.");
            }
            var banner = await _context.Banner.FindAsync(id);
            if (banner != null)
            {
                _context.Banner.Remove(banner);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BannerExists(int id)
        {
          return (_context.Banner?.Any(e => e.BannerId == id)).GetValueOrDefault();
        }
    }
}
