using Microsoft.AspNetCore.Mvc;
using Mt22KpfuRu.Controllers.Base;
using Mt22KpfuRu.Instruments;
using Mt22KpfuRu.Models.DataModels;
using Mt22KpfuRu.Services.Storage;

namespace Mt22KpfuRu.Controllers;

[AdminSessionAuthorize]
public sealed class OrgcomsController : AdminControllerBase
{
    private readonly IRepository<OrgcomEntity> _orgcoms;

    public OrgcomsController(IRepository<OrgcomEntity> orgcoms)
    {
        _orgcoms = orgcoms;
    }

    [HttpGet("/Admin/Orgcom/Create")]
    public IActionResult Create()
        => View();

    [HttpPost("/Admin/Orgcom/Create")]
    [ValidateAntiForgeryToken]
    public IActionResult Create(OrgcomEntity model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        _orgcoms.Add(model);
        return RedirectToPanel("orgcoms");
    }

    [HttpGet("/Admin/Orgcom/{id:int}/Edit")]
    public IActionResult Edit(int id)
    {
        var foundModel = _orgcoms.FindById(id);
        if (foundModel == null)
        {
            return NotFound();
        }
        return View(foundModel);
    }

    [HttpPost("/Admin/Orgcom/{id:int}/Edit")]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, OrgcomEntity model)
    {
        model.Id = id;

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var foundModel = _orgcoms.FindById(id);
        if (foundModel == null)
        {
            return NotFound();
        }
        foundModel.Name = model.Name;
        foundModel.Url = model.Url;
        _orgcoms.SaveChanges();
        return RedirectToPanel("orgcoms");
    }

    [HttpPost("/Admin/Orgcom/{id:int}/Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var foundModel = _orgcoms.FindById(id);
        if (foundModel == null)
        {
            return NotFound();
        }
        _orgcoms.Delete(foundModel);
        return RedirectToPanel("orgcoms");
    }
}