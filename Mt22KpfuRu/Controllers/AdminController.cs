using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mt22KpfuRu.Instruments;
using Mt22KpfuRu.Models;

namespace Mt22KpfuRu.Controllers
{
    public class AdminController : Controller
    {
        private readonly IWebHostEnvironment Environment;
        public AdminController(IWebHostEnvironment environment)
        {
            Environment = environment;
        }

        public IActionResult Auth()
        {
            if (HttpContext.Session.Keys.Contains("Login"))
            {
                return RedirectToAction("Panel", "Admin");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Auth(string login, string password)
        {
            string hash = Hasher.ComputeHash(login, password);
            Admin? foundAdmin = DataBank.AdminStore.List.FirstOrDefault(x=>x.Login.Equals(login) && x.HashPassword.Equals(hash));
            if (foundAdmin == null)
            {
                return StatusCode(401);
            }
            HttpContext.Session.SetString("Login", login);
            return RedirectToAction("Panel", "Admin");
        }
        public IActionResult Panel()
        {
            if (!HttpContext.Session.Keys.Contains("Login"))
            {
                return StatusCode(401);
            }
            return View();
        }
    }
}
