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
    public class OFSController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment; // Add this line

        public OFSController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: OFS
        public async Task<IActionResult> Index()
        {
              return _context.OFSs != null ? 
                          View(await _context.OFSs.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.OFSs'  is null.");
        }

        // GET: OFS/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OFSs == null)
            {
                return NotFound();
            }

            var oFS = await _context.OFSs
                .FirstOrDefaultAsync(m => m.OFSId == id);
            if (oFS == null)
            {
                return NotFound();
            }

            return View(oFS);
        }

        // GET: OFS/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OFS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OFSId,OFS_Title,OFS_Icon")] OFS oFS, IFormFile OFS_Icon)
        {
            if (ModelState.IsValid)
            {

                // Check if an image was uploaded
                if (OFS_Icon != null && OFS_Icon.Length > 0)
                {
                    // Generate a unique file name for the image (you can customize this logic)
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + OFS_Icon.FileName;

                    // Define the path to save the image in the wwwroot/uploads folder
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // Create the uploads folder if it doesn't exist
                    Directory.CreateDirectory(uploadsFolder);

                    // Save the uploaded image to the file system
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await OFS_Icon.CopyToAsync(stream);
                    }

                    // Save the image file path to the database
                    oFS.OFS_Icon = "/uploads/" + uniqueFileName; // Relative path to the image

                    //var sanitizer = new HtmlSanitizer();
                    //oFS.OFS_Title = sanitizer.Sanitize(oFS.OFS_Title);


                    _context.Add(oFS);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(oFS);
        }

        // GET: OFS/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OFSs == null)
            {
                return NotFound();
            }

            var oFS = await _context.OFSs.FindAsync(id);
            if (oFS == null)
            {
                return NotFound();
            }
            return View(oFS);
        }

        // POST: OFS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OFSId,OFS_Title,OFS_Icon")] OFS oFS, IFormFile OFS_Icon)
        {
            if (id != oFS.OFSId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Check if an image was uploaded
                    if (OFS_Icon != null && OFS_Icon.Length > 0)
                    {
                        // Generate a unique file name for the image (you can customize this logic)
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + OFS_Icon.FileName;

                        // Define the path to save the image in the wwwroot/uploads folder
                        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        // Create the uploads folder if it doesn't exist
                        Directory.CreateDirectory(uploadsFolder);

                        // Save the uploaded image to the file system
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await OFS_Icon.CopyToAsync(stream);
                        }

                        // Save the image file path to the database
                        oFS.OFS_Icon = "/uploads/" + uniqueFileName; // Relative path to the image
                    }


                    _context.Update(oFS);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OFSExists(oFS.OFSId))
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
            return View(oFS);
        }

        // GET: OFS/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OFSs == null)
            {
                return NotFound();
            }

            var oFS = await _context.OFSs
                .FirstOrDefaultAsync(m => m.OFSId == id);
            if (oFS == null)
            {
                return NotFound();
            }

            return View(oFS);
        }

        // POST: OFS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OFSs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.OFSs'  is null.");
            }
            var oFS = await _context.OFSs.FindAsync(id);
            if (oFS != null)
            {
                _context.OFSs.Remove(oFS);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OFSExists(int id)
        {
          return (_context.OFSs?.Any(e => e.OFSId == id)).GetValueOrDefault();
        }
    }
}
