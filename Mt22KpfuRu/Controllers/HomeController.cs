﻿using Microsoft.AspNetCore.Mvc;
using Mt22KpfuRu.Instruments;

namespace Mt22KpfuRu.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int page = 1) => View(DataBank.IndexModel.CopyFromPage(page));
        public IActionResult Conferences() => View(DataBank.ConferencesModel.Copy());
        public IActionResult Program() => View(DataBank.ProgramModel.Copy());
        public IActionResult About() => View();
        public IActionResult Register() => View();
        public IActionResult Living() => View();
        public IActionResult Sponsors() => View();
        public IActionResult Participants() => View();
        public IActionResult Excursions() => View();
        public IActionResult Kazan() => View();
    }
}