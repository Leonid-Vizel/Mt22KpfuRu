using Microsoft.AspNetCore.Mvc;

namespace Mt22KpfuRu.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
