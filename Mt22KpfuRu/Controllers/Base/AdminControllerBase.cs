using Microsoft.AspNetCore.Mvc;

namespace Mt22KpfuRu.Controllers.Base;

/// <summary>
/// Базовый класс для админ-контроллеров.
/// Позволяет продолжать использовать существующие Razor Views из папки Views/Admin,
/// не перенося их под новые имена контроллеров.
/// </summary>
public abstract class AdminControllerBase : Controller
{
    protected IActionResult RedirectToPanel(string? section = null)
    {
        if (string.IsNullOrWhiteSpace(section))
        {
            return Redirect("/Admin");
        }
        return Redirect($"/admin#{section}");
    }
}