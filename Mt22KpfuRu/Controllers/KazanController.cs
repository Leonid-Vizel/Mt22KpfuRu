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
public sealed class KazanController : AdminControllerBase
{
    private readonly IRepository<KazanPlaceEntity> _places;
    private readonly IWebFileLoader _files;
    private readonly IWebHostEnvironment _env;
    private readonly IHtmlSanitizer _sanitizer;

    public KazanController(IRepository<KazanPlaceEntity> places, IWebFileLoader files, IWebHostEnvironment env, IHtmlSanitizer sanitizer)
    {
        _places = places;
        _files = files;
        _env = env;
        _sanitizer = sanitizer;
    }

    [HttpGet("/Admin/KazanPlace/Create")]
    public IActionResult Create()
        => View();

    [HttpPost("/Admin/KazanPlace/Create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(KazanCreateModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        string? result = await _files.SaveImage("/img/Kazan/", model.File);
        if (result == null)
        {
            ModelState.AddModelError(nameof(KazanCreateModel.File), "Ошибка записи картинки!");
            return View(model);
        }
        else if (result == "")
        {
            ModelState.AddModelError(nameof(KazanCreateModel.File), "Файл не является изображением!");
            return View(model);
        }

        model.Description = _sanitizer.Sanitize(model.Description);

        KazanPlaceEntity place = new KazanPlaceEntity()
        {
            Name = model.Name,
            Description = model.Description,
            Image = result
        };
        _places.Add(place);
        return RedirectToPanel("kazan");
    }

    [HttpGet("/Admin/KazanPlace/{id:int}/Edit")]
    public IActionResult Edit(int id)
    {
        var foundModel = _places.FindById(id);
        if (foundModel == null)
        {
            return NotFound();
        }
        return View(foundModel);
    }

    [HttpPost("/Admin/KazanPlace/{id:int}/Edit")]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, KazanPlaceEntity model)
    {
        model.Id = id;

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var foundModel = _places.FindById(id);
        if (foundModel == null)
        {
            return NotFound();
        }

        model.Description = _sanitizer.Sanitize(model.Description);

        foundModel.Name = model.Name;
        foundModel.Description = model.Description;
        _places.SaveChanges();
        return RedirectToPanel("kazan");
    }

    [HttpPost("/Admin/KazanPlace/{id:int}/Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var foundModel = _places.FindById(id);
        if (foundModel == null)
        {
            return NotFound();
        }

        _places.Delete(foundModel);

        string filePath = Path.Combine(_env.WebRootPath, "img", "Kazan", foundModel.Image);
        if (System.IO.File.Exists(filePath))
        {
            System.IO.File.Delete(filePath);
        }

        return RedirectToPanel("kazan");
    }
}