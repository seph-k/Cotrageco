using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cotrageco.Data;
using Cotrageco.Models;
using System.Security.AccessControl;

namespace Cotrageco.Controllers
{
    public class Corperate_PurposeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment; // Add this line

        public Corperate_PurposeController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Corperate_Purpose
        public async Task<IActionResult> Index()
        {
              return _context.Corperate_Purposes != null ? 
                          View(await _context.Corperate_Purposes.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Corperate_Purposes'  is null.");
        }

        // GET: Corperate_Purpose/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Corperate_Purposes == null)
            {
                return NotFound();
            }

            var corperate_Purpose = await _context.Corperate_Purposes
                .FirstOrDefaultAsync(m => m.Corperate_PurposeId == id);
            if (corperate_Purpose == null)
            {
                return NotFound();
            }

            return View(corperate_Purpose);
        }

        // GET: Corperate_Purpose/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Corperate_Purpose/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Corperate_PurposeId,Purpose_Title,Purpose_Icon,Purpose_Description")] Corperate_Purpose corperate_Purpose, IFormFile Purpose_Icon)
        {
            if (ModelState.IsValid)
            {

                // Check if an image was uploaded
                if (Purpose_Icon != null && Purpose_Icon.Length > 0)
                {
                    // Generate a unique file name for the image (you can customize this logic)
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + Purpose_Icon.FileName;

                    // Define the path to save the image in the wwwroot/uploads folder
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // Create the uploads folder if it doesn't exist
                    Directory.CreateDirectory(uploadsFolder);

                    // Save the uploaded image to the file system
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await Purpose_Icon.CopyToAsync(stream);
                    }

                    // Save the image file path to the database
                    corperate_Purpose.Purpose_Icon = "/uploads/" + uniqueFileName; // Relative path to the image

                    //var sanitizer = new HtmlSanitizer();
                    //corperate_Purpose.Purpose_Description = sanitizer.Sanitize(corperate_Purpose.Purpose_Description);

                    _context.Add(corperate_Purpose);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }



            }
            return View(corperate_Purpose);
        }

        // GET: Corperate_Purpose/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Corperate_Purposes == null)
            {
                return NotFound();
            }

            var corperate_Purpose = await _context.Corperate_Purposes.FindAsync(id);
            if (corperate_Purpose == null)
            {
                return NotFound();
            }
            return View(corperate_Purpose);
        }

        // POST: Corperate_Purpose/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Corperate_PurposeId,Purpose_Title,Purpose_Icon,Purpose_Description")] Corperate_Purpose corperate_Purpose, IFormFile Purpose_Icon)
        {
            if (id != corperate_Purpose.Corperate_PurposeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    // Check if an image was uploaded
                    if (Purpose_Icon != null && Purpose_Icon.Length > 0)
                    {
                        // Generate a unique file name for the image (you can customize this logic)
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + Purpose_Icon.FileName;

                        // Define the path to save the image in the wwwroot/uploads folder
                        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        // Create the uploads folder if it doesn't exist
                        Directory.CreateDirectory(uploadsFolder);

                        // Save the uploaded image to the file system
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await Purpose_Icon.CopyToAsync(stream);
                        }

                        // Save the image file path to the database
                        corperate_Purpose.Purpose_Icon = "/uploads/" + uniqueFileName; // Relative path to the image
                    }


                    _context.Update(corperate_Purpose);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Corperate_PurposeExists(corperate_Purpose.Corperate_PurposeId))
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
            return View(corperate_Purpose);
        }

        // GET: Corperate_Purpose/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Corperate_Purposes == null)
            {
                return NotFound();
            }

            var corperate_Purpose = await _context.Corperate_Purposes
                .FirstOrDefaultAsync(m => m.Corperate_PurposeId == id);
            if (corperate_Purpose == null)
            {
                return NotFound();
            }

            return View(corperate_Purpose);
        }

        // POST: Corperate_Purpose/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Corperate_Purposes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Corperate_Purposes'  is null.");
            }
            var corperate_Purpose = await _context.Corperate_Purposes.FindAsync(id);
            if (corperate_Purpose != null)
            {
                _context.Corperate_Purposes.Remove(corperate_Purpose);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Corperate_PurposeExists(int id)
        {
          return (_context.Corperate_Purposes?.Any(e => e.Corperate_PurposeId == id)).GetValueOrDefault();
        }
    }
}
