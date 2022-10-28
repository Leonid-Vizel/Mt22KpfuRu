using Microsoft.AspNetCore.Mvc;

namespace Mt22KpfuRu.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ApplicationDbContext context;
        //public HomeController(ApplicationDbContext context)
        //{
        //    this.context = context;
        //}

        public IActionResult Admin()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Program()
        {
            return View();
        }

        public IActionResult Living()
        {
            return View();
        }
        public IActionResult Sponsors()
        {
            return View();
        }
        public IActionResult Participants()
        {
            return View();
        }
        public IActionResult Conferences()
        {
            return View();
        }
        public IActionResult Excursions()
        {
            return View();
        }
    }
}