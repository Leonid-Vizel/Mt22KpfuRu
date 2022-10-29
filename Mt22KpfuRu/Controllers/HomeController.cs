using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using Mt22KpfuRu.Models;
using X.PagedList;
using static System.Net.WebRequestMethods;

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

        public IActionResult Index(int page = 1)
        {
            List<News> newsList = new List<News>()
            {
                new News()
                {
                    Id = 1,
                    Title = "Зеркало",
                    Description = "Появилось зеркало на сайте университета",
                    Content = "С информацией о проведении Школы-конференции в 2022 г. и регистрацией можно ознакомиться по ссылке: <a href=\"https://kpfu.ru/science/nauchno-issledovatelskaya-rabota-studentov-nirs/materialy-i-tehnologii-xxi-veka-xxi-veka\">Материалы и технологии XXI века</a>",
                    CreateTime = new DateTime(2022,10,29,17,12,00)
                }
            };
            return View(newsList.ToPagedList(page, 6));
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