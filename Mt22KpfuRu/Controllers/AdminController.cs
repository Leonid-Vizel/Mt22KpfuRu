using Microsoft.AspNetCore.Mvc;

namespace Mt22KpfuRu.Controllers
{
    public class AdminController : Controller
    {
        #region Admin Panel
        public IActionResult Panel()
        {
            return View();
        }
        #endregion

        #region News
        #region Add
        public IActionResult CreateNews()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateNews(object model)
        {
            return View();
        }
        #endregion
        #region Edit
        public IActionResult EditNews(int id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditNews(object model)
        {
            return View();
        }
        #endregion
        #region List
        public IActionResult News()
        {
            return View();
        }
        #endregion
        #endregion
    }
}
