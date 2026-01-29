using Microsoft.AspNetCore.Mvc;
using Mt22KpfuRu.Controllers.Base;
using Mt22KpfuRu.Instruments;
using Mt22KpfuRu.Models.DataModels;
using Mt22KpfuRu.Services.Security;
using Mt22KpfuRu.Services.Storage;

namespace Mt22KpfuRu.Controllers;

[AdminSessionAuthorize]
public sealed class NewsController : AdminControllerBase
{
    private readonly IRepository<NewsEntity> _news;
    private readonly IHtmlSanitizer _sanitizer;
    private readonly IClock _clock;

    public NewsController(IRepository<NewsEntity> news, IHtmlSanitizer sanitizer, IClock clock)
    {
        _news = news;
        _sanitizer = sanitizer;
        _clock = clock;
    }

    [HttpGet("/Admin/News/Create")]
    public IActionResult Create()
        => View();

    [HttpPost("/Admin/News/Create")]
    [ValidateAntiForgeryToken]
    public IActionResult Create(NewsEntity model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        model.Content = _sanitizer.Sanitize(model.Content);
        model.CreateTime = _clock.Now;
        _news.Add(model);
        return RedirectToPanel("news");
    }

    [HttpGet("/Admin/News/{id:int}/Edit")]
    public IActionResult Edit(int id)
    {
        var foundModel = _news.FindById(id);
        if (foundModel == null)
        {
            return NotFound();
        }
        return View(foundModel);
    }

    [HttpPost("/Admin/News/{id:int}/Edit")]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, NewsEntity model)
    {
        // для корректного отображения ошибок в форме
        model.Id = id;

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var foundModel = _news.FindById(id);
        if (foundModel == null)
        {
            return NotFound();
        }

        model.Content = _sanitizer.Sanitize(model.Content);

        foundModel.Title = model.Title;
        foundModel.Description = model.Description;
        foundModel.Content = model.Content;

        _news.SaveChanges();
        return RedirectToPanel("news");
    }

    [HttpPost("/Admin/News/{id:int}/Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var foundModel = _news.FindById(id);
        if (foundModel == null)
        {
            return NotFound();
        }
        _news.Delete(foundModel);
        return RedirectToPanel("news");
    }
}