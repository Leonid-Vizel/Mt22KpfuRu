using Microsoft.AspNetCore.Mvc;
using Mt22KpfuRu.Instruments;
using Mt22KpfuRu.Models;
using Mt22KpfuRu.Models.ViewModels;

namespace Mt22KpfuRu.Controllers;

public class AdminController : Controller
{
    private readonly IWebHostEnvironment environment;
    
    public AdminController(IWebHostEnvironment environment)
    {
        this.environment = environment;
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
        HttpContext.Session.SetString("Name", foundAdmin.Name);
        return RedirectToAction("Panel", "Admin");
    }
    public IActionResult Exit()
    {
        HttpContext.Session.Remove("Login");
        return RedirectToAction("Index", "Home");
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
        return RedirectToAction("Panel", "Admin", "news");
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
        return RedirectToAction("Panel", "Admin", "news");
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
        return RedirectToAction("Panel", "Admin", "news");
    }
    #endregion
    #endregion
    #region FastLinks
    #region Create
    public IActionResult CreateFastLink()
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CreateFastLink(FastLink model)
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        DataBank.FastLinkStore.Add(model);
        return RedirectToAction("Panel", "Admin", "fastlinks");
    }
    #endregion
    #region Edit
    public IActionResult EditFastLink(int id)
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        FastLink? foundModel = DataBank.FastLinkStore.List.FirstOrDefault(x => x.Id == id);
        if (foundModel == null)
        {
            return NotFound();
        }
        return View(foundModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult EditFastLink(FastLink model)
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        FastLink? foundModel = DataBank.FastLinkStore.List.FirstOrDefault(x => x.Id == model.Id);
        if (foundModel == null)
        {
            return NotFound();
        }
        foundModel.Name = model.Name;
        foundModel.Url = model.Url;
        DataBank.FastLinkStore.RewriteList();
        return RedirectToAction("Panel", "Admin", "fastlinks");
    }
    #endregion
    #region Delete
    public IActionResult DeleteFastLink(int id)
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        FastLink? foundModel = DataBank.FastLinkStore.List.FirstOrDefault(x => x.Id == id);
        if (foundModel == null)
        {
            return NotFound();
        }
        DataBank.FastLinkStore.Delete(foundModel);
        return RedirectToAction("Panel", "Admin", "fastlinks");
    }
    #endregion
    #endregion
    #region Thesis
    #region Create
    public IActionResult CreateThesis()
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CreateThesis(Thesis model)
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        DataBank.ThesisStore.Add(model);
        return RedirectToAction("Panel", "Admin", "thesis");
    }
    #endregion
    #region Edit
    public IActionResult EditThesis(int id)
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        Thesis? foundModel = DataBank.ThesisStore.List.FirstOrDefault(x => x.Id == id);
        if (foundModel == null)
        {
            return NotFound();
        }
        return View(foundModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult EditThesis(Thesis model)
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        Thesis? foundModel = DataBank.ThesisStore.List.FirstOrDefault(x => x.Id == model.Id);
        if (foundModel == null)
        {
            return NotFound();
        }
        foundModel.Name = model.Name;
        foundModel.Description = model.Description;
        DataBank.ThesisStore.RewriteList();
        return RedirectToAction("Panel", "Admin", "thesis");
    }
    #endregion
    #region Delete
    public IActionResult DeleteThesis(int id)
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        Thesis? foundModel = DataBank.ThesisStore.List.FirstOrDefault(x => x.Id == id);
        if (foundModel == null)
        {
            return NotFound();
        }
        DataBank.ThesisStore.Delete(foundModel);
        return RedirectToAction("Panel", "Admin", "thesis");
    }
    #endregion
    #endregion
    #region Admin
    #region Create
    public IActionResult CreateAdmin()
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CreateAdmin(Admin model)
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        if (DataBank.AdminStore.List.Any(x=>x.Login.ToLower().Equals(model.Login.ToLower())))
        {
            ModelState.AddModelError("Login", "В системе уже существует администратор с таким логином!");
            return View(model);
        }
        model.HashPassword = Hasher.ComputeHash(model.Login, model.HashPassword);
        DataBank.AdminStore.Add(model);
        return RedirectToAction("Panel", "Admin", "admins");
    }
    #endregion
    #region Edit
    public IActionResult EditAdmin(int id)
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        Admin? foundModel = DataBank.AdminStore.List.FirstOrDefault(x => x.Id == id);
        if (foundModel == null)
        {
            return NotFound();
        }
        return View(foundModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult EditAdmin(int id, string name)
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        if (string.IsNullOrEmpty(name))
        {
            return View(new Admin() { Id = id, Name = name});
        }
        Admin? foundModel = DataBank.AdminStore.List.FirstOrDefault(x => x.Id == id);
        if (foundModel == null)
        {
            return NotFound();
        }
        foundModel.Name = name;
        DataBank.AdminStore.RewriteList();
        return RedirectToAction("Panel", "Admin", "admins");
    }
    #endregion
    #region Delete
    public async Task<IActionResult> DeleteAdmin(int id)
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        if (DataBank.AdminStore.List.Count == 1)
        {
            return NotFound();
        }
        Admin? foundModel = DataBank.AdminStore.List.FirstOrDefault(x => x.Id == id);
        if (foundModel == null)
        {
            return NotFound();
        }
        string? chech = HttpContext.Session.GetString("Login");
        DataBank.AdminStore.Delete(foundModel);
        await SessionOperations.EndSessionsByLogin(HttpContext.Session, foundModel.Login);
        return RedirectToAction("Panel", "Admin", "admins");
    }
    #endregion
    #endregion
    #region Date
    #region Create
    public IActionResult CreateDate()
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CreateDate(Date model)
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        DataBank.DateStore.Add(model);
        return RedirectToAction("Panel", "Admin", "dates");
    }
    #endregion
    #region Edit
    public IActionResult EditDate(int id)
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        Date? foundModel = DataBank.DateStore.List.FirstOrDefault(x => x.Id == id);
        if (foundModel == null)
        {
            return NotFound();
        }
        return View(foundModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult EditDate(Date model)
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        Date? foundModel = DataBank.DateStore.List.FirstOrDefault(x => x.Id == model.Id);
        if (foundModel == null)
        {
            return NotFound();
        }
        foundModel.Name = model.Name;
        foundModel.DateTime = model.DateTime;
        foundModel.ShowTime = model.ShowTime;
        DataBank.DateStore.RewriteList();
        return RedirectToAction("Panel", "Admin", "dates");
    }
    #endregion
    #region Delete
    public IActionResult DeleteDate(int id)
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        Date? foundModel = DataBank.DateStore.List.FirstOrDefault(x => x.Id == id);
        if (foundModel == null)
        {
            return NotFound();
        }
        DataBank.DateStore.Delete(foundModel);
        return RedirectToAction("Panel", "Admin", "dates");
    }
    #endregion
    #endregion
    #region Orgcoms
    #region Create
    public IActionResult CreateOrgcom()
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CreateOrgcom(Orgcom model)
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        DataBank.OrgcomStore.Add(model);
        return RedirectToAction("Panel", "Admin", "orgcoms");
    }
    #endregion
    #region Edit
    public IActionResult EditOrgcom(int id)
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        Orgcom? foundModel = DataBank.OrgcomStore.List.FirstOrDefault(x => x.Id == id);
        if (foundModel == null)
        {
            return NotFound();
        }
        return View(foundModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult EditOrgcom(Orgcom model)
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        Orgcom? foundModel = DataBank.OrgcomStore.List.FirstOrDefault(x => x.Id == model.Id);
        if (foundModel == null)
        {
            return NotFound();
        }
        foundModel.Name = model.Name;
        foundModel.Url = model.Url;
        DataBank.OrgcomStore.RewriteList();
        return RedirectToAction("Panel", "Admin", "orgcoms");
    }
    #endregion
    #region Delete
    public IActionResult DeleteOrgcom(int id)
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        Orgcom? foundModel = DataBank.OrgcomStore.List.FirstOrDefault(x => x.Id == id);
        if (foundModel == null)
        {
            return NotFound();
        }
        DataBank.OrgcomStore.Delete(foundModel);
        return RedirectToAction("Panel", "Admin", "orgcoms");
    }
    #endregion
    #endregion
    #region Program
    #region Create
    public IActionResult CreateProgram()
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CreateProgram(ProgramPart model)
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        DataBank.ProgramPartStore.Add(model);
        return RedirectToAction("Panel", "Admin", "program");
    }
    #endregion
    #region Edit
    public IActionResult EditProgram(int id)
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        ProgramPart? foundModel = DataBank.ProgramPartStore.List.FirstOrDefault(x => x.Id == id);
        if (foundModel == null)
        {
            return NotFound();
        }
        return View(foundModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult EditProgram(ProgramPart model)
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        ProgramPart? foundModel = DataBank.ProgramPartStore.List.FirstOrDefault(x => x.Id == model.Id);
        if (foundModel == null)
        {
            return NotFound();
        }
        foundModel.Name = model.Name;
        foundModel.Date = model.Date;
        foundModel.TimeStart = model.TimeStart;
        foundModel.TimeEnd = model.TimeEnd;
        foundModel.Place = model.Place;
        DataBank.ProgramPartStore.RewriteList();
        return RedirectToAction("Panel", "Admin", "program");
    }
    #endregion
    #region Delete
    public IActionResult DeleteProgram(int id)
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        ProgramPart? foundModel = DataBank.ProgramPartStore.List.FirstOrDefault(x => x.Id == id);
        if (foundModel == null)
        {
            return NotFound();
        }
        DataBank.ProgramPartStore.Delete(foundModel);
        return RedirectToAction("Panel", "Admin", "program");
    }
    #endregion
    #endregion
    #region Kazan
    #region Create
    public IActionResult CreateKazanPlace()
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateKazanPlace(KazanCreateModel model)
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        string? result = await WebFileLoader.LoadImage(environment, "/img/Kazan/", model.File);
        if (result == null)
        {
            ModelState.AddModelError("File", "Ошибка записи картинки!");
            return View(model);
        }
        else if (result == "")
        {
            ModelState.AddModelError("File", "Файл не является изображением!");
            return View(model);
        }
        KazanPlace place = new KazanPlace()
        {
            Name = model.Name,
            Description = model.Description,
            Image = result
        };
        DataBank.KazanStore.Add(place);
        return RedirectToAction("Panel", "Admin", "kazan");
    }
    #endregion
    #region Edit
    public IActionResult EditKazanPlace(int id)
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        KazanPlace? foundModel = DataBank.KazanStore.List.FirstOrDefault(x => x.Id == id);
        if (foundModel == null)
        {
            return NotFound();
        }
        return View(foundModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult EditKazanPlace(KazanPlace model)
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        KazanPlace? foundModel = DataBank.KazanStore.List.FirstOrDefault(x => x.Id == model.Id);
        if (foundModel == null)
        {
            return NotFound();
        }
        foundModel.Name = model.Name;
        foundModel.Description = model.Description;
        DataBank.KazanStore.RewriteList();
        return RedirectToAction("Panel", "Admin", "kazan");
    }
    #endregion
    #region Delete
    public IActionResult DeleteKazanPlace(int id)
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        KazanPlace? foundModel = DataBank.KazanStore.List.FirstOrDefault(x => x.Id == id);
        if (foundModel == null)
        {
            return NotFound();
        }
        DataBank.KazanStore.Delete(foundModel);
        string filePath = $"{environment.WebRootPath}/img/Kazan/{foundModel.Image}";
        if (System.IO.File.Exists(filePath))
        {
            System.IO.File.Delete(filePath);
        }
        return RedirectToAction("Panel", "Admin", "kazan");
    }
    #endregion
    #endregion
    #region Coordinator
    #region Create
    public IActionResult CreateCoordinator()
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateCoordinator(CoordinatorCreateModel model)
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        string? result = await WebFileLoader.LoadImage(environment, "/img/orgs/", model.File);
        if (result == null)
        {
            ModelState.AddModelError("File", "Ошибка записи картинки!");
            return View(model);
        }
        else if (result == "")
        {
            ModelState.AddModelError("File", "Файл не является изображением!");
            return View(model);
        }
        Coordinator place = new Coordinator()
        {
            Name = model.Name,
            Url = model.Url,
            Image = result
        };
        DataBank.CoordinatorStore.Add(place);
        return RedirectToAction("Panel", "Admin", "coordinators");
    }
    #endregion
    #region Edit
    public IActionResult EditCoordinator(int id)
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        Coordinator? foundModel = DataBank.CoordinatorStore.List.FirstOrDefault(x => x.Id == id);
        if (foundModel == null)
        {
            return NotFound();
        }
        return View(foundModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult EditCoordinator(Coordinator model)
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        Coordinator? foundModel = DataBank.CoordinatorStore.List.FirstOrDefault(x => x.Id == model.Id);
        if (foundModel == null)
        {
            return NotFound();
        }
        foundModel.Name = model.Name;
        foundModel.Url = model.Url;
        DataBank.CoordinatorStore.RewriteList();
        return RedirectToAction("Panel", "Admin", "coordinators");
    }
    #endregion
    #region Delete
    public IActionResult DeleteCoordinator(int id)
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        Coordinator? foundModel = DataBank.CoordinatorStore.List.FirstOrDefault(x => x.Id == id);
        if (foundModel == null)
        {
            return NotFound();
        }
        DataBank.CoordinatorStore.Delete(foundModel);
        string filePath = $"{environment.WebRootPath}/img/orgs/{foundModel.Image}";
        if (System.IO.File.Exists(filePath))
        {
            System.IO.File.Delete(filePath);
        }
        return RedirectToAction("Panel", "Admin", "coordinators");
    }
    #endregion
    #endregion
    #region Excursion
    #region Create
    public IActionResult CreateExcursionPart()
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateExcursionPart(ExcursionCreateModel model)
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        string? result1 = await WebFileLoader.LoadImage(environment, "/img/excursions/", model.File1);
        if (result1 == null)
        {
            ModelState.AddModelError("File", "Ошибка записи картинки!");
            return View(model);
        }
        else if (result1 == "")
        {
            ModelState.AddModelError("File", "Файл не является изображением!");
            return View(model);
        }
        string? result2 = null;
        if (model.File2 != null)
        {
            result2 = await WebFileLoader.LoadImage(environment, "/img/excursions/", model.File2);
            if (result2 == null)
            {
                ModelState.AddModelError("File", "Ошибка записи картинки!");
                return View(model);
            }
            else if (result2 == "")
            {
                ModelState.AddModelError("File", "Файл не является изображением!");
                return View(model);
            }
        }
        ExcursionPart place = new ExcursionPart()
        {
            Name = model.Name,
            Description = model.Description,
            Image1 = result1
        };
        if (model.File2 != null)
        {
            place.Image2 = result2;
        }    
        DataBank.ExcursionStore.Add(place);
        return RedirectToAction("Panel", "Admin", "excursions");
    }
    #endregion
    #region Edit
    public IActionResult EditExcursionPart(int id)
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        ExcursionPart? foundModel = DataBank.ExcursionStore.List.FirstOrDefault(x => x.Id == id);
        if (foundModel == null)
        {
            return NotFound();
        }
        return View(foundModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult EditExcursionPart(ExcursionPart model)
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        ExcursionPart? foundModel = DataBank.ExcursionStore.List.FirstOrDefault(x => x.Id == model.Id);
        if (foundModel == null)
        {
            return NotFound();
        }
        foundModel.Name = model.Name;
        foundModel.Description = model.Description;
        DataBank.ExcursionStore.RewriteList();
        return RedirectToAction("Panel", "Admin", "excursions");
    }
    #endregion
    #region Delete
    public IActionResult DeleteExcursionPart(int id)
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        ExcursionPart? foundModel = DataBank.ExcursionStore.List.FirstOrDefault(x => x.Id == id);
        if (foundModel == null)
        {
            return NotFound();
        }
        DataBank.ExcursionStore.Delete(foundModel);
        string filePath = $"{environment.WebRootPath}/img/excursions/";
        if (System.IO.File.Exists($"{filePath}/{foundModel.Image1}"))
        {
            System.IO.File.Delete($"{filePath}/{foundModel.Image1}");
        }
        if (!string.IsNullOrEmpty(foundModel.Image2) && System.IO.File.Exists($"{filePath}/{foundModel.Image2}"))
        {
            System.IO.File.Delete($"{filePath}/{foundModel.Image2}");
        }
        return RedirectToAction("Panel", "Admin", "excursions");
    }
    #endregion
    #endregion
    #region Conference
    #region Create
    public IActionResult CreateConference()
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateConference(ConferenceCreateModel model)
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        if (DataBank.ConferenceStore.List.Any(x=>x.Year == model.Year))
        {
            ModelState.AddModelError("Year","Запись с таком годом уже существует!");
            return View(model);
        }
        if (model.Year < 1990)
        {
            ModelState.AddModelError("Year", "Год должен быть позднее 1990!");
            return View(model);
        }
        if (model.File1 == null && model.File2 == null && model.File3 == null)
        {
            ModelState.AddModelError("File1", "Прикрепите хотя бы один из файлов!");
            ModelState.AddModelError("File2", "Прикрепите хотя бы один из файлов!");
            ModelState.AddModelError("File3", "Прикрепите хотя бы один из файлов!");
            return View(model);
        }
        if (model.File1 != null && !model.File1.FileName.EndsWith(".pdf"))
        {
            ModelState.AddModelError("File1", "Укажите файл формата PDF!");
            return View(model);
        }
        if (model.File2 != null && !model.File2.FileName.EndsWith(".pdf"))
        {
            ModelState.AddModelError("File2", "Укажите файл формата PDF!");
            return View(model);
        }
        if (model.File3 != null && !model.File3.FileName.EndsWith(".pdf"))
        {
            ModelState.AddModelError("File3", "Укажите файл формата PDF!");
            return View(model);
        }

        Directory.CreateDirectory($"{environment.WebRootPath}/docs/history/{model.Year}");
        Conference conference = new Conference()
        {
            Year = model.Year
        };
        if (model.File1 != null)
        {
            try
            {
                using (FileStream imageCreateStream = new FileStream($"{environment.WebRootPath}/docs/history/{model.Year}/Program.pdf", FileMode.Create))
                {
                    await model.File1.CopyToAsync(imageCreateStream);
                }
            }
            catch
            {
                ModelState.AddModelError("File1", "Ошибка записи файла!");
                return View(model);
            }
            conference.Program = true;
        }
        if (model.File2 != null)
        {
            try
            {
                using (FileStream imageCreateStream = new FileStream($"{environment.WebRootPath}/docs/history/{model.Year}/Thesis.pdf", FileMode.Create))
                {
                    await model.File2.CopyToAsync(imageCreateStream);
                }
            }
            catch
            {
                ModelState.AddModelError("File2", "Ошибка записи файла!");
                return View(model);
            }
            conference.Thesis = true;
        }
        if (model.File3 != null)
        {
            try
            {
                using (FileStream imageCreateStream = new FileStream($"{environment.WebRootPath}/docs/history/{model.Year}/Winners.pdf", FileMode.Create))
                {
                    await model.File3.CopyToAsync(imageCreateStream);
                }
            }
            catch
            {
                ModelState.AddModelError("File3", "Ошибка записи файла!");
                return View(model);
            }
            conference.Winners = true;
        }
        DataBank.ConferenceStore.Add(conference);
        return RedirectToAction("Panel", "Admin", "history");
    }
    #endregion
    #region Delete
    public IActionResult DeleteConference(int id)
    {
        if (!HttpContext.Session.Keys.Contains("Login"))
        {
            return StatusCode(401);
        }
        Conference? foundModel = DataBank.ConferenceStore.List.FirstOrDefault(x => x.Id == id);
        if (foundModel == null)
        {
            return NotFound();
        }
        DataBank.ConferenceStore.Delete(foundModel);
        Directory.Delete($"{environment.WebRootPath}/docs/history/{foundModel.Year}", true);
        return RedirectToAction("Panel", "Admin", "history");
    }
    #endregion
    #endregion
}