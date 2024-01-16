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
using System.Security.AccessControl;
using Microsoft.AspNetCore.Hosting;

namespace Cotrageco.Controllers
{
    public class Sectors_Of_InterventionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment; // Added this line

        public Sectors_Of_InterventionController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Sectors_Of_Intervention
        public async Task<IActionResult> Index()
        {
              return _context.Sectors_Of_Interventions != null ? 
                          View(await _context.Sectors_Of_Interventions.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Sectors_Of_Interventions'  is null.");
        }

        // GET: Sectors_Of_Intervention/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sectors_Of_Interventions == null)
            {
                return NotFound();
            }

            var sectors_Of_Intervention = await _context.Sectors_Of_Interventions
                .FirstOrDefaultAsync(m => m.Sectors_Of_InterventionId == id);
            if (sectors_Of_Intervention == null)
            {
                return NotFound();
            }

            return View(sectors_Of_Intervention);
        }

        // GET: Sectors_Of_Intervention/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sectors_Of_Intervention/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Sectors_Of_InterventionId,Sectors_Title,Sectors_Description,Sector,Sectors_Image")] Sectors_Of_Intervention sectors_Of_Intervention, IFormFile Sectors_Image) //added IFormFile
        {
            if (ModelState.IsValid)
            {

                if (Sectors_Image != null && Sectors_Image.Length > 0)
                {
                    // Generate a unique file name for the image (you can customize this logic)
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + Sectors_Image.FileName;

                    // Define the path to save the image in the wwwroot/uploads folder
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // Create the uploads folder if it doesn't exist
                    Directory.CreateDirectory(uploadsFolder);

                    // Save the uploaded image to the file system
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await Sectors_Image.CopyToAsync(stream);
                    }

                    // Save the image file path to the database
                    sectors_Of_Intervention.Sectors_Image = "/uploads/" + uniqueFileName; // Relative path to the image

                    _context.Add(sectors_Of_Intervention);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                }

            }
            return View(sectors_Of_Intervention);
        }

        // GET: Sectors_Of_Intervention/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sectors_Of_Interventions == null)
            {
                return NotFound();
            }

            var sectors_Of_Intervention = await _context.Sectors_Of_Interventions.FindAsync(id);
            if (sectors_Of_Intervention == null)
            {
                return NotFound();
            }
            return View(sectors_Of_Intervention);
        }

        // POST: Sectors_Of_Intervention/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Sectors_Of_InterventionId,Sectors_Title,Sectors_Description,Sector,Sectors_Image")] Sectors_Of_Intervention sectors_Of_Intervention, IFormFile Sectors_Image)
        {
            if (id != sectors_Of_Intervention.Sectors_Of_InterventionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Check if an image was uploaded
                    if (Sectors_Image != null && Sectors_Image.Length > 0)
                    {
                        // Generate a unique file name for the image (you can customize this logic)
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + Sectors_Image.FileName;

                        // Define the path to save the image in the wwwroot/uploads folder
                        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        // Create the uploads folder if it doesn't exist
                        Directory.CreateDirectory(uploadsFolder);

                        // Save the uploaded image to the file system
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await Sectors_Image.CopyToAsync(stream);
                        }

                        // Save the image file path to the database
                        sectors_Of_Intervention.Sectors_Image = "/uploads/" + uniqueFileName; // Relative path to the image
                    }


                    _context.Update(sectors_Of_Intervention);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Sectors_Of_InterventionExists(sectors_Of_Intervention.Sectors_Of_InterventionId))
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
            return View(sectors_Of_Intervention);
        }

        // GET: Sectors_Of_Intervention/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sectors_Of_Interventions == null)
            {
                return NotFound();
            }

            var sectors_Of_Intervention = await _context.Sectors_Of_Interventions
                .FirstOrDefaultAsync(m => m.Sectors_Of_InterventionId == id);
            if (sectors_Of_Intervention == null)
            {
                return NotFound();
            }

            return View(sectors_Of_Intervention);
        }

        // POST: Sectors_Of_Intervention/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sectors_Of_Interventions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Sectors_Of_Interventions'  is null.");
            }
            var sectors_Of_Intervention = await _context.Sectors_Of_Interventions.FindAsync(id);
            if (sectors_Of_Intervention != null)
            {
                _context.Sectors_Of_Interventions.Remove(sectors_Of_Intervention);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Sectors_Of_InterventionExists(int id)
        {
          return (_context.Sectors_Of_Interventions?.Any(e => e.Sectors_Of_InterventionId == id)).GetValueOrDefault();
        }
    }
}
