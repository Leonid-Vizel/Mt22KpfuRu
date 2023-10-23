using Microsoft.AspNetCore.Mvc;
using Mt22KpfuRu.Instruments;

namespace Mt22KpfuRu.Controllers;

public class HomeController : Controller
{
    public IActionResult Index(int page = 1) => View(DataBank.GetIndexModel(page));
    public IActionResult Conferences() => View(DataBank.GetConferencesModel());
    public IActionResult Program() => View(DataBank.GetProgramModel());
    public IActionResult Excursions() => View(DataBank.GetExcursionModel());
    public IActionResult Kazan() => View(DataBank.GetKazanModel());
    public IActionResult Living() => View(DataBank.GetMapModel());
    public IActionResult About() => View(DataBank.GetAboutModel());
    public IActionResult Register() => View();
    public IActionResult IVMIIT() => View();
    public IActionResult Sponsors() => View();
    public IActionResult Participants() => View();
}