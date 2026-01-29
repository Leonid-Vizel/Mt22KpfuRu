using Microsoft.AspNetCore.Mvc;
using Mt22KpfuRu.Controllers.Base;
using Mt22KpfuRu.Instruments;
using Mt22KpfuRu.Models.DataModels;
using Mt22KpfuRu.Models.ViewModels;
using Mt22KpfuRu.Services.Files;
using Mt22KpfuRu.Services.Security;
using Mt22KpfuRu.Services.Storage;

namespace Mt22KpfuRu.Controllers;

[AdminSessionAuthorize]
public sealed class ExcursionsController : AdminControllerBase
{
    private readonly IRepository<ExcursionPartEntity> _excursions;
    private readonly IWebFileLoader _files;
    private readonly IWebHostEnvironment _env;
    private readonly IHtmlSanitizer _sanitizer;

    public ExcursionsController(IRepository<ExcursionPartEntity> excursions, IWebFileLoader files, IWebHostEnvironment env, IHtmlSanitizer sanitizer)
    {
        _excursions = excursions;
        _files = files;
        _env = env;
        _sanitizer = sanitizer;
    }

    [HttpGet("/Admin/Excursion/Create")]
    public IActionResult Create()
        => View();

    [HttpPost("/Admin/Excursion/Create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ExcursionCreateModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        string? result1 = await _files.SaveImage("/img/excursions/", model.File1);
        if (result1 == null)
        {
            ModelState.AddModelError(nameof(ExcursionCreateModel.File1), "Ошибка записи картинки!");
            return View(model);
        }
        else if (result1 == "")
        {
            ModelState.AddModelError(nameof(ExcursionCreateModel.File1), "Файл не является изображением!");
            return View(model);
        }

        string? result2 = null;
        if (model.File2 != null)
        {
            result2 = await _files.SaveImage("/img/excursions/", model.File2);
            if (result2 == null)
            {
                ModelState.AddModelError(nameof(ExcursionCreateModel.File2), "Ошибка записи картинки!");
                return View(model);
            }
            else if (result2 == "")
            {
                ModelState.AddModelError(nameof(ExcursionCreateModel.File2), "Файл не является изображением!");
                return View(model);
            }
        }

        model.Description = _sanitizer.Sanitize(model.Description);

        ExcursionPartEntity part = new ExcursionPartEntity()
        {
            Name = model.Name,
            Description = model.Description,
            Image1 = result1,
            Image2 = result2
        };

        _excursions.Add(part);
        return RedirectToPanel("excursions");
    }

    [HttpGet("/Admin/Excursion/{id:int}/Edit")]
    public IActionResult Edit(int id)
    {
        var foundModel = _excursions.FindById(id);
        if (foundModel == null)
        {
            return NotFound();
        }
        return View(foundModel);
    }

    [HttpPost("/Admin/Excursion/{id:int}/Edit")]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, ExcursionPartEntity model)
    {
        model.Id = id;

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var foundModel = _excursions.FindById(id);
        if (foundModel == null)
        {
            return NotFound();
        }

        model.Description = _sanitizer.Sanitize(model.Description);

        foundModel.Name = model.Name;
        foundModel.Description = model.Description;

        _excursions.SaveChanges();
        return RedirectToPanel("excursions");
    }

    [HttpPost("/Admin/Excursion/{id:int}/Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var foundModel = _excursions.FindById(id);
        if (foundModel == null)
        {
            return NotFound();
        }

        _excursions.Delete(foundModel);

        string dir = Path.Combine(_env.WebRootPath, "img", "excursions");
        string file1 = Path.Combine(dir, foundModel.Image1);
        if (System.IO.File.Exists(file1))
        {
            System.IO.File.Delete(file1);
        }

        if (!string.IsNullOrWhiteSpace(foundModel.Image2))
        {
            string file2 = Path.Combine(dir, foundModel.Image2);
            if (System.IO.File.Exists(file2))
            {
                System.IO.File.Delete(file2);
            }
        }

        return RedirectToPanel("excursions");
    }
}