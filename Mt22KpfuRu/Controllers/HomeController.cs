using Microsoft.AspNetCore.Mvc;
using Mt22KpfuRu.Models;
using System.Diagnostics;

namespace Mt22KpfuRu.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            
        }

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