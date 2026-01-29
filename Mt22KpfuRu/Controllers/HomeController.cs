using Microsoft.AspNetCore.Mvc;
using Mt22KpfuRu.Services.Public;

namespace Mt22KpfuRu.Controllers;

public sealed class HomeController : Controller
{
    private readonly IPublicContentService _content;

    public HomeController(IPublicContentService content)
    {
        _content = content;
    }

    public Task<ViewResult> Index(int page = 1)
        => Task.FromResult(View(_content.GetIndexModel(page)));

    public Task<ViewResult> Conferences()
        => Task.FromResult(View(_content.GetConferencesModel()));

    public Task<ViewResult> Program()
        => Task.FromResult(View(_content.GetProgramModel()));

    public Task<ViewResult> Excursions()
        => Task.FromResult(View(_content.GetExcursionModel()));

    public Task<ViewResult> Kazan()
        => Task.FromResult(View(_content.GetKazanModel()));

    public Task<ViewResult> Living()
        => Task.FromResult(View(_content.GetMapModel()));

    public Task<ViewResult> About()
        => Task.FromResult(View(_content.GetAboutModel()));

    public Task<ViewResult> Register() => Task.FromResult(View());
    public Task<ViewResult> Sponsors() => Task.FromResult(View());
    public Task<ViewResult> Participants() => Task.FromResult(View());
}