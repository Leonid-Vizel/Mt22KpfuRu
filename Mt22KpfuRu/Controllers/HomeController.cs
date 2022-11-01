using Microsoft.AspNetCore.Mvc;
using Mt22KpfuRu.Instruments;

namespace Mt22KpfuRu.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int page = 1) => View(DataBank.IndexModel.CopyFromPage(page));
        public IActionResult Conferences() => View(DataBank.ConferencesModel.Copy());
        public IActionResult Program() => View(DataBank.ProgramModel.Copy());
        public IActionResult Excursions() => View(DataBank.ExcursionModel);
        public IActionResult Kazan() => View(DataBank.KazanModel);
        public IActionResult Living() => View(DataBank.MapModel);
        public IActionResult About() => View();
        public IActionResult Register() => View();
        public IActionResult Sponsors() => View();
        public IActionResult Participants() => View();
    }
}