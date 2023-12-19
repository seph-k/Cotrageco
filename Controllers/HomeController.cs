using Cotrageco.Data;
using Cotrageco.Models;
using Cotrageco.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cotrageco.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            //fetch the data from the database, add _context if it missing 
            var ourgoals = _context.Objectives.ToList();
            var corperateinfo = _context.Corperate_Infos.ToList();
            var projects = _context.Projects.ToList();
            var cotragecocontent = _context.Cotrageco_Contents.ToList();

            // add the data collected to the view model, dont forget to pass the object in parameter
            var homeviewmodel = new HomeViewModel
            {
                Objectives = ourgoals,
                Corperate_Infos = corperateinfo,
                Projects = projects,
                cotrageco_Contents = cotragecocontent
            };
            return View(homeviewmodel);
        }

        // About method
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}