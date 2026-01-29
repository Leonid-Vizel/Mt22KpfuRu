using Microsoft.AspNetCore.Mvc;
using Mt22KpfuRu.Controllers.Base;
using Mt22KpfuRu.Instruments;
using Mt22KpfuRu.Models.DataModels;
using Mt22KpfuRu.Services.Security;
using Mt22KpfuRu.Services.Storage;

namespace Mt22KpfuRu.Controllers;

[AdminSessionAuthorize]
public sealed class ThesisController : AdminControllerBase
{
    private readonly IRepository<ThesisEntity> _thesis;
    private readonly IHtmlSanitizer _sanitizer;

    public ThesisController(IRepository<ThesisEntity> thesis, IHtmlSanitizer sanitizer)
    {
        _thesis = thesis;
        _sanitizer = sanitizer;
    }

    [HttpGet("/Admin/Thesis/Create")]
    public IActionResult Create()
        => View();

    [HttpPost("/Admin/Thesis/Create")]
    [ValidateAntiForgeryToken]
    public IActionResult Create(ThesisEntity model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        model.Description = _sanitizer.Sanitize(model.Description);

        _thesis.Add(model);
        return RedirectToPanel("thesis");
    }

    [HttpGet("/Admin/Thesis/{id:int}/Edit")]
    public IActionResult Edit(int id)
    {
        var foundModel = _thesis.FindById(id);
        if (foundModel == null)
        {
            return NotFound();
        }
        return View(foundModel);
    }

    [HttpPost("/Admin/Thesis/{id:int}/Edit")]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, ThesisEntity model)
    {
        model.Id = id;
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var foundModel = _thesis.FindById(id);
        if (foundModel == null)
        {
            return NotFound();
        }

        model.Description = _sanitizer.Sanitize(model.Description);

        foundModel.Name = model.Name;
        foundModel.Description = model.Description;

        _thesis.SaveChanges();
        return RedirectToPanel("thesis");
    }

    [HttpPost("/Admin/Thesis/{id:int}/Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var foundModel = _thesis.FindById(id);
        if (foundModel == null)
        {
            return NotFound();
        }
        _thesis.Delete(foundModel);
        return RedirectToPanel("thesis");
    }
}