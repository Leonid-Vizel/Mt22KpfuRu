using Microsoft.AspNetCore.Mvc;
using Mt22KpfuRu.Controllers.Base;
using Mt22KpfuRu.Instruments;
using Mt22KpfuRu.Models.DataModels;
using Mt22KpfuRu.Services.Storage;

namespace Mt22KpfuRu.Controllers;

[AdminSessionAuthorize]
public sealed class ProgcomsController : AdminControllerBase
{
    private readonly IRepository<ProgcomEntity> _progcoms;

    public ProgcomsController(IRepository<ProgcomEntity> progcoms)
    {
        _progcoms = progcoms;
    }

    [HttpGet("/Admin/Progcom/Create")]
    public IActionResult Create()
        => View();

    [HttpPost("/Admin/Progcom/Create")]
    [ValidateAntiForgeryToken]
    public IActionResult Create(ProgcomEntity model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        _progcoms.Add(model);
        return RedirectToPanel("progcoms");
    }

    [HttpGet("/Admin/Progcom/{id:int}/Edit")]
    public IActionResult Edit(int id)
    {
        var foundModel = _progcoms.FindById(id);
        if (foundModel == null)
        {
            return NotFound();
        }
        return View(foundModel);
    }

    [HttpPost("/Admin/Progcom/{id:int}/Edit")]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, ProgcomEntity model)
    {
        model.Id = id;

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var foundModel = _progcoms.FindById(id);
        if (foundModel == null)
        {
            return NotFound();
        }

        foundModel.Name = model.Name;
        foundModel.Url = model.Url;

        _progcoms.SaveChanges();
        return RedirectToPanel("progcoms");
    }

    [HttpPost("/Admin/Progcom/{id:int}/Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var foundModel = _progcoms.FindById(id);
        if (foundModel == null)
        {
            return NotFound();
        }
        _progcoms.Delete(foundModel);
        return RedirectToPanel("progcoms");
    }
}