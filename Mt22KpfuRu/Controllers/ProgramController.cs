using Microsoft.AspNetCore.Mvc;
using Mt22KpfuRu.Controllers.Base;
using Mt22KpfuRu.Instruments;
using Mt22KpfuRu.Models.DataModels;
using Mt22KpfuRu.Services.Security;
using Mt22KpfuRu.Services.Storage;

namespace Mt22KpfuRu.Controllers;

[AdminSessionAuthorize]
public sealed class ProgramController : AdminControllerBase
{
    private readonly IRepository<ProgramPartEntity> _program;
    private readonly IHtmlSanitizer _sanitizer;

    public ProgramController(IRepository<ProgramPartEntity> program, IHtmlSanitizer sanitizer)
    {
        _program = program;
        _sanitizer = sanitizer;
    }

    [HttpGet("/Admin/Program/Create")]
    public IActionResult Create()
        => View();

    [HttpPost("/Admin/Program/Create")]
    [ValidateAntiForgeryToken]
    public IActionResult Create(ProgramPartEntity model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        model.Name = _sanitizer.Sanitize(model.Name);
        model.Place = _sanitizer.Sanitize(model.Place);

        _program.Add(model);
        return RedirectToPanel("program");
    }

    [HttpGet("/Admin/Program/{id:int}/Edit")]
    public IActionResult Edit(int id)
    {
        var foundModel = _program.FindById(id);
        if (foundModel == null)
        {
            return NotFound();
        }
        return View(foundModel);
    }

    [HttpPost("/Admin/Program/{id:int}/Edit")]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, ProgramPartEntity model)
    {
        model.Id = id;
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var foundModel = _program.FindById(id);
        if (foundModel == null)
        {
            return NotFound();
        }

        model.Name = _sanitizer.Sanitize(model.Name);
        model.Place = _sanitizer.Sanitize(model.Place);

        foundModel.Name = model.Name;
        foundModel.Date = model.Date;
        foundModel.TimeStart = model.TimeStart;
        foundModel.TimeEnd = model.TimeEnd;
        foundModel.Place = model.Place;

        _program.SaveChanges();
        return RedirectToPanel("program");
    }

    [HttpPost("/Admin/Program/{id:int}/Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var foundModel = _program.FindById(id);
        if (foundModel == null)
        {
            return NotFound();
        }
        _program.Delete(foundModel);
        return RedirectToPanel("program");
    }
}