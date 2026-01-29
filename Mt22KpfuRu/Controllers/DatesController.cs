using Microsoft.AspNetCore.Mvc;
using Mt22KpfuRu.Controllers.Base;
using Mt22KpfuRu.Instruments;
using Mt22KpfuRu.Models.DataModels;
using Mt22KpfuRu.Services.Storage;

namespace Mt22KpfuRu.Controllers;

[AdminSessionAuthorize]
public sealed class DatesController : AdminControllerBase
{
    private readonly IRepository<DateEntity> _dates;

    public DatesController(IRepository<DateEntity> dates)
    {
        _dates = dates;
    }

    [HttpGet("/Admin/Date/Create")]
    public IActionResult Create()
        => View();

    [HttpPost("/Admin/Date/Create")]
    [ValidateAntiForgeryToken]
    public IActionResult Create(DateEntity model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        _dates.Add(model);
        return RedirectToPanel("dates");
    }

    [HttpGet("/Admin/Date/{id:int}/Edit")]
    public IActionResult Edit(int id)
    {
        var foundModel = _dates.FindById(id);
        if (foundModel == null)
        {
            return NotFound();
        }
        return View(foundModel);
    }

    [HttpPost("/Admin/Date/{id:int}/Edit")]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, DateEntity model)
    {
        model.Id = id;

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var foundModel = _dates.FindById(id);
        if (foundModel == null)
        {
            return NotFound();
        }
        foundModel.Name = model.Name;
        foundModel.DateTime = model.DateTime;
        foundModel.ShowTime = model.ShowTime;
        _dates.SaveChanges();
        return RedirectToPanel("dates");
    }

    [HttpPost("/Admin/Date/{id:int}/Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var foundModel = _dates.FindById(id);
        if (foundModel == null)
        {
            return NotFound();
        }
        _dates.Delete(foundModel);
        return RedirectToPanel("dates");
    }
}