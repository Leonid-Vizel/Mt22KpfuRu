using Microsoft.AspNetCore.Mvc;
using Mt22KpfuRu.Controllers.Base;
using Mt22KpfuRu.Instruments;
using Mt22KpfuRu.Services.Admin;

namespace Mt22KpfuRu.Controllers;

[AdminSessionAuthorize]
public sealed class DashboardController : AdminControllerBase
{
    private readonly IAdminPanelService _panel;

    public DashboardController(IAdminPanelService panel)
    {
        _panel = panel;
    }

    [HttpGet("/Admin")]
    public IActionResult Index()
    {
        var model = _panel.Build();
        return View(model);
    }
}