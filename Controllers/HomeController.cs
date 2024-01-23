using Cotrageco.Data;
using Cotrageco.Models;
using Cotrageco.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var banner = _context.Home_Banners.ToList();
            var ourgoals = _context.Objectives.ToList();
            var corperateinfo = _context.Corperate_Infos.ToList();
            var projects = _context.Projects.Include(m => m.Project_Title).ToList();
            var cotragecocontent = _context.Cotrageco_Contents.ToList();
            var allbanners = _context.Banner.ToList();

            // add the data collected to the view model, dont forget to pass the object in parameter
            var homeviewmodel = new HomeViewModel
            {
                Home_Banners = banner,
                Objectives = ourgoals,
                Corperate_Infos = corperateinfo,
                Projects = projects,
                cotrageco_Contents = cotragecocontent,
                Banner = allbanners
            };
            return View(homeviewmodel);
        }

        // About method
        public IActionResult About()
        {
            //fetch the data from the database, add _context if it missing 
            var cotragecocontent = _context.Cotrageco_Contents.ToList();
            var interventionsectors = _context.Sectors_Of_Interventions.ToList();
            var registration = _context.Registrations.ToList();
            var ofs = _context.OFSs.ToList();
            var partners = _context.Partners.ToList();
            var allbanners = _context.Banner.ToList();


            // add the data collected to the view model, dont forget to pass the object in parameter
            var aboutviewmodel = new AboutViewModel
            {
                cotrageco_Contents = cotragecocontent,
                Sectors_Of_Interventions = interventionsectors,
                Registrations = registration,
                OFSs = ofs,
                Partners = partners,
                Banner = allbanners
            };
            return View(aboutviewmodel);
        }

        // Services Method
        public IActionResult Services()
        {
            //fetch the data from the database, add _context if it missing 
            var cotragecocontent = _context.Cotrageco_Contents.ToList();
            var ourrealisations = _context.Our_Realisations.ToList();
            var corperatepurpose = _context.Corperate_Purposes.ToList();
            var allbanners = _context.Banner.ToList();

            // add the data collected to the view model, dont forget to pass the object in parameter
            var servicesviewmodel = new ServicesViewModel
            {
                cotrageco_Contents = cotragecocontent,
                Our_Realisations = ourrealisations,
                Corperate_Purposes = corperatepurpose,
                Banner = allbanners
            };
            return View(servicesviewmodel);
        }

        //Contact Method
        public IActionResult Contact()
        {
            //fetch the data from the database, add _context if it missing 
            var cotragecocontent = _context.Cotrageco_Contents.ToList();
            var allbanners = _context.Banner.ToList();

            // add the data collected to the view model, dont forget to pass the object in parameter
            var contactviewmodel = new ContactViewModel
            {
                cotrageco_Contents = cotragecocontent,
                Banner = allbanners
            };
            return View(contactviewmodel);
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