using Microsoft.AspNetCore.Mvc;
using Mt22KpfuRu.Instruments;

namespace Mt22KpfuRu.Controllers;

public sealed class HomeController : Controller
{
    public Task<ViewResult> Index(int page = 1)
        => Task.FromResult(View(DataBank.GetIndexModel(page)));
    public Task<ViewResult> Conferences()
        => Task.FromResult(View(DataBank.GetConferencesModel()));
    public Task<ViewResult> Program()
        => Task.FromResult(View(DataBank.GetProgramModel()));
    public Task<ViewResult> Excursions()
        => Task.FromResult(View(DataBank.GetExcursionModel()));
    public Task<ViewResult> Kazan()
        => Task.FromResult(View(DataBank.GetKazanModel()));
    public Task<ViewResult> Living()
        => Task.FromResult(View(DataBank.GetMapModel()));
    public Task<ViewResult> About()
        => Task.FromResult(View(DataBank.GetAboutModel()));
    public Task<ViewResult> Register()
        => Task.FromResult(View());
    public Task<ViewResult> IVMIIT()
        => Task.FromResult(View());
    public Task<ViewResult> Sponsors()
        => Task.FromResult(View());
    public Task<ViewResult> Participants()
        => Task.FromResult(View());
}