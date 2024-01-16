using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cotrageco.Data;
using Cotrageco.Models;
using Ganss.Xss;
using Microsoft.AspNetCore.Hosting;
using System.Security.AccessControl;

namespace Cotrageco.Controllers
{
    public class Our_RealisationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment; // Add this line

        public Our_RealisationController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Our_Realisation
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Our_Realisations.Include(o => o.Realisation_Captions);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Our_Realisation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Our_Realisations == null)
            {
                return NotFound();
            }

            var our_Realisation = await _context.Our_Realisations
                .Include(o => o.Realisation_Captions)
                .FirstOrDefaultAsync(m => m.Our_RealisationId == id);
            if (our_Realisation == null)
            {
                return NotFound();
            }

            return View(our_Realisation);
        }

        // GET: Our_Realisation/Create
        public IActionResult Create()
        {
            ViewData["Realisation_CaptionId"] = new SelectList(_context.Realisation_Captions, "Caption", "Caption");
            return View();
        }

        // POST: Our_Realisation/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Our_RealisationId,Realisation_CaptionId,Realisation_Image")] Our_Realisation our_Realisation, IFormFile Realisation_Image)
        {
            if (ModelState.IsValid)
            {
                // Check if an image was uploaded
                if (Realisation_Image != null && Realisation_Image.Length > 0)
                {
                    // Generate a unique file name for the image (you can customize this logic)
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + Realisation_Image.FileName;

                    // Define the path to save the image in the wwwroot/uploads folder
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // Create the uploads folder if it doesn't exist
                    Directory.CreateDirectory(uploadsFolder);

                    // Save the uploaded image to the file system
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await Realisation_Image.CopyToAsync(stream);
                    }

                    // Save the image file path to the database
                    our_Realisation.Realisation_Image = "/uploads/" + uniqueFileName; // Relative path to the image


                    _context.Add(our_Realisation);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

            }
            ViewData["Realisation_CaptionId"] = new SelectList(_context.Realisation_Captions, "Realisation_CaptionId", "Realisation_CaptionId", our_Realisation.Realisation_CaptionId);
            return View(our_Realisation);
        }

        // GET: Our_Realisation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Our_Realisations == null)
            {
                return NotFound();
            }

            var our_Realisation = await _context.Our_Realisations.FindAsync(id);
            if (our_Realisation == null)
            {
                return NotFound();
            }
            ViewData["Realisation_CaptionId"] = new SelectList(_context.Realisation_Captions, "Realisation_CaptionId", "Realisation_CaptionId", our_Realisation.Realisation_CaptionId);
            return View(our_Realisation);
        }

        // POST: Our_Realisation/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Our_RealisationId,Realisation_CaptionId,Realisation_Image")] Our_Realisation our_Realisation, IFormFile Realisation_Image)
        {
            if (id != our_Realisation.Our_RealisationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Check if an image was uploaded
                    if (Realisation_Image != null && Realisation_Image.Length > 0)
                    {
                        // Generate a unique file name for the image (you can customize this logic)
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + Realisation_Image.FileName;

                        // Define the path to save the image in the wwwroot/uploads folder
                        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        // Create the uploads folder if it doesn't exist
                        Directory.CreateDirectory(uploadsFolder);

                        // Save the uploaded image to the file system
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await Realisation_Image.CopyToAsync(stream);
                        }

                        // Save the image file path to the database
                        our_Realisation.Realisation_Image = "/uploads/" + uniqueFileName; // Relative path to the image
                    }
                    _context.Update(our_Realisation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Our_RealisationExists(our_Realisation.Our_RealisationId))
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
            ViewData["Realisation_CaptionId"] = new SelectList(_context.Realisation_Captions, "Realisation_CaptionId", "Realisation_CaptionId", our_Realisation.Realisation_CaptionId);
            return View(our_Realisation);
        }

        // GET: Our_Realisation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Our_Realisations == null)
            {
                return NotFound();
            }

            var our_Realisation = await _context.Our_Realisations
                .Include(o => o.Realisation_Captions)
                .FirstOrDefaultAsync(m => m.Our_RealisationId == id);
            if (our_Realisation == null)
            {
                return NotFound();
            }

            return View(our_Realisation);
        }

        // POST: Our_Realisation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Our_Realisations == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Our_Realisations'  is null.");
            }
            var our_Realisation = await _context.Our_Realisations.FindAsync(id);
            if (our_Realisation != null)
            {
                _context.Our_Realisations.Remove(our_Realisation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Our_RealisationExists(int id)
        {
          return (_context.Our_Realisations?.Any(e => e.Our_RealisationId == id)).GetValueOrDefault();
        }
    }
}
