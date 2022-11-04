using Microsoft.AspNetCore.Mvc;
using Mt22KpfuRu.Instruments;
using Mt22KpfuRu.Models;
using System.Reflection;

namespace Mt22KpfuRu.Controllers
{
    public class AdminController : Controller
    {
        private readonly IWebHostEnvironment Environment;
        public AdminController(IWebHostEnvironment environment)
        {
            Environment = environment;
        }
        #region Auth
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
        #endregion
        #region Panel
        public IActionResult Panel()
        {
            if (!HttpContext.Session.Keys.Contains("Login"))
            {
                return StatusCode(401);
            }
            return View();
        }
        #endregion
        #region News
        #region Create
        public IActionResult CreateNews()
        {
            if (!HttpContext.Session.Keys.Contains("Login"))
            {
                return StatusCode(401);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateNews(News model)
        {
            if (!HttpContext.Session.Keys.Contains("Login"))
            {
                return StatusCode(401);
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            model.CreateTime = DateTime.Now;
            DataBank.NewsStore.Add(model);
            return RedirectToAction("Panel", "Admin");
        }
        #endregion
        #region Edit
        public IActionResult EditNews(int id)
        {
            if (!HttpContext.Session.Keys.Contains("Login"))
            {
                return StatusCode(401);
            }
            News? foundModel = DataBank.NewsStore.List.FirstOrDefault(x => x.Id == id);
            if (foundModel == null)
            {
                return NotFound();
            }
            return View(foundModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditNews(News model)
        {
            if (!HttpContext.Session.Keys.Contains("Login"))
            {
                return StatusCode(401);
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            News? foundModel = DataBank.NewsStore.List.FirstOrDefault(x=>x.Id == model.Id);
            if (foundModel == null)
            {
                return NotFound();
            }
            foundModel.Title = model.Title;
            foundModel.Description = model.Description;
            foundModel.Content = model.Content;
            DataBank.NewsStore.RewriteList();
            return RedirectToAction("Panel", "Admin");
        }
        #endregion
        #region Delete
        public IActionResult DeleteNews(int id)
        {
            if (!HttpContext.Session.Keys.Contains("Login"))
            {
                return StatusCode(401);
            }
            News? foundModel = DataBank.NewsStore.List.FirstOrDefault(x => x.Id == id);
            if (foundModel == null)
            {
                return NotFound();
            }
            DataBank.NewsStore.Delete(foundModel);
            return RedirectToAction("Panel", "Admin");
        }
        #endregion
        #endregion
    }
}
