using Microsoft.AspNetCore.Mvc;
using Mt22KpfuRu.Controllers.Base;
using Mt22KpfuRu.Instruments;
using Mt22KpfuRu.Models.DataModels;
using Mt22KpfuRu.Models.ViewModels;
using Mt22KpfuRu.Services.Storage;

namespace Mt22KpfuRu.Controllers;

[AdminSessionAuthorize]
public sealed class HistoryController : AdminControllerBase
{
    private readonly IWebHostEnvironment _environment;
    private readonly IRepository<ConferenceEntity> _conferences;

    public HistoryController(IWebHostEnvironment environment, IRepository<ConferenceEntity> conferences)
    {
        _environment = environment;
        _conferences = conferences;
    }

    [HttpGet("/Admin/Conference/Create")]
    public IActionResult Create()
        => View();

    [HttpPost("/Admin/Conference/Create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ConferenceCreateModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        if (_conferences.Items.Any(x => x.Year == model.Year))
        {
            ModelState.AddModelError(nameof(ConferenceCreateModel.Year), "Запись с таком годом уже существует!");
            return View(model);
        }
        if (model.Year < 1990)
        {
            ModelState.AddModelError(nameof(ConferenceCreateModel.Year), "Год должен быть позднее 1990!");
            return View(model);
        }

        if (model.File1 == null && model.File2 == null && model.File3 == null)
        {
            ModelState.AddModelError(nameof(ConferenceCreateModel.File1), "Прикрепите хотя бы один из файлов!");
            ModelState.AddModelError(nameof(ConferenceCreateModel.File2), "Прикрепите хотя бы один из файлов!");
            ModelState.AddModelError(nameof(ConferenceCreateModel.File3), "Прикрепите хотя бы один из файлов!");
            return View(model);
        }

        if (model.File1 != null && !model.File1.FileName.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
        {
            ModelState.AddModelError(nameof(ConferenceCreateModel.File1), "Укажите файл формата PDF!");
            return View(model);
        }
        if (model.File2 != null && !model.File2.FileName.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
        {
            ModelState.AddModelError(nameof(ConferenceCreateModel.File2), "Укажите файл формата PDF!");
            return View(model);
        }
        if (model.File3 != null && !model.File3.FileName.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
        {
            ModelState.AddModelError(nameof(ConferenceCreateModel.File3), "Укажите файл формата PDF!");
            return View(model);
        }

        // Content validation (size + signature)
        if (model.File1 != null)
        {
            if (model.File1.Length <= 0 || model.File1.Length > FileValidation.MaxPdfBytes)
            {
                ModelState.AddModelError(nameof(ConferenceCreateModel.File1), "Файл слишком большой!");
                return View(model);
            }
            byte[] h = await FileValidation.ReadHeaderAsync(model.File1, 16);
            if (!FileValidation.IsPdf(h))
            {
                ModelState.AddModelError(nameof(ConferenceCreateModel.File1), "Файл не является корректным PDF!");
                return View(model);
            }
        }
        if (model.File2 != null)
        {
            if (model.File2.Length <= 0 || model.File2.Length > FileValidation.MaxPdfBytes)
            {
                ModelState.AddModelError(nameof(ConferenceCreateModel.File2), "Файл слишком большой!");
                return View(model);
            }
            byte[] h = await FileValidation.ReadHeaderAsync(model.File2, 16);
            if (!FileValidation.IsPdf(h))
            {
                ModelState.AddModelError(nameof(ConferenceCreateModel.File2), "Файл не является корректным PDF!");
                return View(model);
            }
        }
        if (model.File3 != null)
        {
            if (model.File3.Length <= 0 || model.File3.Length > FileValidation.MaxPdfBytes)
            {
                ModelState.AddModelError(nameof(ConferenceCreateModel.File3), "Файл слишком большой!");
                return View(model);
            }
            byte[] h = await FileValidation.ReadHeaderAsync(model.File3, 16);
            if (!FileValidation.IsPdf(h))
            {
                ModelState.AddModelError(nameof(ConferenceCreateModel.File3), "Файл не является корректным PDF!");
                return View(model);
            }
        }

        string yearDir = Path.Combine(_environment.WebRootPath, "docs", "history", model.Year.ToString());
        Directory.CreateDirectory(yearDir);

        ConferenceEntity conference = new ConferenceEntity()
        {
            Year = model.Year
        };

        if (model.File1 != null)
        {
            try
            {
                await using FileStream fs = new FileStream(Path.Combine(yearDir, "Program.pdf"), FileMode.Create);
                await model.File1.CopyToAsync(fs);
                conference.Program = true;
            }
            catch
            {
                ModelState.AddModelError(nameof(ConferenceCreateModel.File1), "Ошибка записи файла!");
                return View(model);
            }
        }
        if (model.File2 != null)
        {
            try
            {
                await using FileStream fs = new FileStream(Path.Combine(yearDir, "Thesis.pdf"), FileMode.Create);
                await model.File2.CopyToAsync(fs);
                conference.Thesis = true;
            }
            catch
            {
                ModelState.AddModelError(nameof(ConferenceCreateModel.File2), "Ошибка записи файла!");
                return View(model);
            }
        }
        if (model.File3 != null)
        {
            try
            {
                await using FileStream fs = new FileStream(Path.Combine(yearDir, "Winners.pdf"), FileMode.Create);
                await model.File3.CopyToAsync(fs);
                conference.Winners = true;
            }
            catch
            {
                ModelState.AddModelError(nameof(ConferenceCreateModel.File3), "Ошибка записи файла!");
                return View(model);
            }
        }

        _conferences.Add(conference);
        return RedirectToPanel("history");
    }

    [HttpPost("/Admin/Conference/{id:int}/Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var foundModel = _conferences.FindById(id);
        if (foundModel == null)
        {
            return NotFound();
        }

        _conferences.Delete(foundModel);

        string yearDir = Path.Combine(_environment.WebRootPath, "docs", "history", foundModel.Year.ToString());
        if (Directory.Exists(yearDir))
        {
            Directory.Delete(yearDir, true);
        }

        return RedirectToPanel("history");
    }
}
