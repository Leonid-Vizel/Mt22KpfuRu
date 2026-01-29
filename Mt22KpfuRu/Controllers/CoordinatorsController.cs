using Microsoft.AspNetCore.Mvc;
using Mt22KpfuRu.Controllers.Base;
using Mt22KpfuRu.Instruments;
using Mt22KpfuRu.Models.DataModels;
using Mt22KpfuRu.Models.ViewModels;
using Mt22KpfuRu.Services.Files;
using Mt22KpfuRu.Services.Storage;

namespace Mt22KpfuRu.Controllers;

[AdminSessionAuthorize]
public sealed class CoordinatorsController : AdminControllerBase
{
    private readonly IRepository<CoordinatorEntity> _coordinators;
    private readonly IWebFileLoader _files;
    private readonly IWebHostEnvironment _env;

    public CoordinatorsController(IRepository<CoordinatorEntity> coordinators, IWebFileLoader files, IWebHostEnvironment env)
    {
        _coordinators = coordinators;
        _files = files;
        _env = env;
    }

    [HttpGet("/Admin/Coordinator/Create")]
    public IActionResult Create()
        => View();

    [HttpPost("/Admin/Coordinator/Create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CoordinatorCreateModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        string? result = await _files.SaveImage("/img/orgs/", model.File);
        if (result == null)
        {
            ModelState.AddModelError(nameof(CoordinatorCreateModel.File), "Ошибка записи картинки!");
            return View(model);
        }
        else if (result == "")
        {
            ModelState.AddModelError(nameof(CoordinatorCreateModel.File), "Файл не является изображением!");
            return View(model);
        }

        CoordinatorEntity coordinator = new CoordinatorEntity()
        {
            Name = model.Name,
            Url = model.Url,
            Image = result
        };

        _coordinators.Add(coordinator);
        return RedirectToPanel("coordinators");
    }

    [HttpGet("/Admin/Coordinator/{id:int}/Edit")]
    public IActionResult Edit(int id)
    {
        var foundModel = _coordinators.FindById(id);
        if (foundModel == null)
        {
            return NotFound();
        }
        return View(foundModel);
    }

    [HttpPost("/Admin/Coordinator/{id:int}/Edit")]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, CoordinatorEntity model)
    {
        model.Id = id;

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var foundModel = _coordinators.FindById(id);
        if (foundModel == null)
        {
            return NotFound();
        }
        foundModel.Name = model.Name;
        foundModel.Url = model.Url;

        _coordinators.SaveChanges();
        return RedirectToPanel("coordinators");
    }

    [HttpPost("/Admin/Coordinator/{id:int}/Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var foundModel = _coordinators.FindById(id);
        if (foundModel == null)
        {
            return NotFound();
        }
        _coordinators.Delete(foundModel);

        string filePath = Path.Combine(_env.WebRootPath, "img", "orgs", foundModel.Image);
        if (System.IO.File.Exists(filePath))
        {
            System.IO.File.Delete(filePath);
        }

        return RedirectToPanel("coordinators");
    }
}