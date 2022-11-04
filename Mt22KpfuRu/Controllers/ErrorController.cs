using Microsoft.AspNetCore.Mvc;

namespace Mt22KpfuRu.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult StatusCode(string id) => View($"~/Views/Error/{id}.cshtml");
    }
}
