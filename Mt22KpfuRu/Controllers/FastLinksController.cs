using Microsoft.AspNetCore.Mvc;
using Mt22KpfuRu.Controllers.Base;
using Mt22KpfuRu.Instruments;
using Mt22KpfuRu.Models.DataModels;
using Mt22KpfuRu.Services.Storage;

namespace Mt22KpfuRu.Controllers;

[AdminSessionAuthorize]
public sealed class FastLinksController : AdminControllerBase
{
    private readonly IRepository<FastLinkEntity> _links;

    public FastLinksController(IRepository<FastLinkEntity> links)
    {
        _links = links;
    }

    [HttpGet("new")]
    [HttpGet("/Admin/FastLink/Create")]
    public IActionResult Create()
        => View();

    [HttpPost("new")]
    [HttpPost("/Admin/FastLink/Create")]
    [ValidateAntiForgeryToken]
    public IActionResult Create(FastLinkEntity model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        _links.Add(model);
        return RedirectToPanel("fastlinks");
    }

    [HttpGet("/Admin/FastLink/{id:int}/Edit")]
    public IActionResult Edit(int id)
    {
        var foundModel = _links.FindById(id);
        if (foundModel == null)
        {
            return NotFound();
        }
        return View(foundModel);
    }

    [HttpPost("/Admin/FastLink/{id:int}/Edit")]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, FastLinkEntity model)
    {
        model.Id = id;
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var foundModel = _links.FindById(id);
        if (foundModel == null)
        {
            return NotFound();
        }

        foundModel.Name = model.Name;
        foundModel.Url = model.Url;
        _links.SaveChanges();
        return RedirectToPanel("fastlinks");
    }

    [HttpPost("/Admin/FastLink/{id:int}/Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var foundModel = _links.FindById(id);
        if (foundModel == null)
        {
            return NotFound();
        }
        _links.Delete(foundModel);
        return RedirectToPanel("fastlinks");
    }
}