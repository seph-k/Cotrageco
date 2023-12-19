using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cotrageco.Data;
using Cotrageco.Models;
using Ganss.Xss;

namespace Cotrageco.Controllers
{
    public class ObjectivesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment; // Add this line

        public ObjectivesController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Objectives
        public async Task<IActionResult> Index()
        {
              return _context.Objectives != null ? 
                          View(await _context.Objectives.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Objectives'  is null.");
        }

        // GET: Objectives/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Objectives == null)
            {
                return NotFound();
            }

            var objective = await _context.Objectives
                .FirstOrDefaultAsync(m => m.ObjectiveId == id);
            if (objective == null)
            {
                return NotFound();
            }

            return View(objective);
        }

        // GET: Objectives/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Objectives/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ObjectiveId,Objective_Title,Objective_Description,Objective_Icon")] Objective objective, IFormFile Objective_Icon)
        {
            // i added ifromfile to the parameter, to accept the image from the view and to process it to save the url in the database
            if (ModelState.IsValid)
            {
                // Check if an image was uploaded
                if (Objective_Icon != null && Objective_Icon.Length > 0)
                {
                    // Generate a unique file name for the image (you can customize this logic)
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + Objective_Icon.FileName;

                    // Define the path to save the image in the wwwroot/uploads folder
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // Create the uploads folder if it doesn't exist
                    Directory.CreateDirectory(uploadsFolder);

                    // Save the uploaded image to the file system
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await Objective_Icon.CopyToAsync(stream);
                    }

                    // Save the image file path to the database
                   objective.Objective_Icon = "/uploads/" + uniqueFileName; // Relative path to the image

                    var sanitizer = new HtmlSanitizer();
                    objective.Objective_Description = sanitizer.Sanitize(objective.Objective_Description);

                    _context.Add(objective);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(objective);
        }

        // GET: Objectives/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Objectives == null)
            {
                return NotFound();
            }

            var objective = await _context.Objectives.FindAsync(id);
            if (objective == null)
            {
                return NotFound();
            }
            return View(objective);
        }

        // POST: Objectives/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ObjectiveId,Objective_Title,Objective_Description,Objective_Icon")] Objective objective, IFormFile Objective_Icon)
        {
            if (id != objective.ObjectiveId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Check if an image was uploaded
                    if (Objective_Icon != null && Objective_Icon.Length > 0)
                    {
                        // Generate a unique file name for the image (you can customize this logic)
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + Objective_Icon.FileName;

                        // Define the path to save the image in the wwwroot/uploads folder
                        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        // Create the uploads folder if it doesn't exist
                        Directory.CreateDirectory(uploadsFolder);

                        // Save the uploaded image to the file system
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await Objective_Icon.CopyToAsync(stream);
                        }

                        // Save the image file path to the database
                        objective.Objective_Icon = "/uploads/" + uniqueFileName; // Relative path to the image
                    }


                    _context.Update(objective);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObjectiveExists(objective.ObjectiveId))
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
            return View(objective);
        }

        // GET: Objectives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Objectives == null)
            {
                return NotFound();
            }

            var objective = await _context.Objectives
                .FirstOrDefaultAsync(m => m.ObjectiveId == id);
            if (objective == null)
            {
                return NotFound();
            }

            return View(objective);
        }

        // POST: Objectives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Objectives == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Objectives'  is null.");
            }
            var objective = await _context.Objectives.FindAsync(id);
            if (objective != null)
            {
                _context.Objectives.Remove(objective);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObjectiveExists(int id)
        {
          return (_context.Objectives?.Any(e => e.ObjectiveId == id)).GetValueOrDefault();
        }
    }
}
