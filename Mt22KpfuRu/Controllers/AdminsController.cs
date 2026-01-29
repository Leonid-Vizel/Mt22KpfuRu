using Microsoft.AspNetCore.Mvc;
using Mt22KpfuRu.Controllers.Base;
using Mt22KpfuRu.Instruments;
using Mt22KpfuRu.Models.DataModels;
using Mt22KpfuRu.Services.Security;
using Mt22KpfuRu.Services.Storage;

namespace Mt22KpfuRu.Controllers;

[AdminSessionAuthorize]
public sealed class AdminsController : AdminControllerBase
{
    private readonly IRepository<AdminEntity> _admins;
    private readonly IPasswordHasherService _hasher;
    private readonly IAdminSessionRegistry _registry;
    private readonly IAdminSessionService _sessions;

    public AdminsController(
        IRepository<AdminEntity> admins,
        IPasswordHasherService hasher,
        IAdminSessionRegistry registry,
        IAdminSessionService sessions)
    {
        _admins = admins;
        _hasher = hasher;
        _registry = registry;
        _sessions = sessions;
    }

    [HttpGet("/Admin/Create")]
    public IActionResult Create()
        => View();

    [HttpPost("/Admin/Create")]
    [ValidateAntiForgeryToken]
    public IActionResult Create(AdminEntity model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        if (_admins.Items.Any(x => string.Equals(x.Login, model.Login, StringComparison.OrdinalIgnoreCase)))
        {
            ModelState.AddModelError(nameof(AdminEntity.Login), "В системе уже существует администратор с таким логином!");
            return View(model);
        }

        model.HashPassword = _hasher.Hash(model.HashPassword);
        _admins.Add(model);

        // New admin starts with its own stamp (future-proof)
        _registry.GetOrCreateStamp(model.Login);

        return RedirectToPanel("admins");
    }

    [HttpGet("/Admin/{id:int}/Edit")]
    public IActionResult Edit(int id)
    {
        var foundModel = _admins.FindById(id);
        if (foundModel == null)
        {
            return NotFound();
        }
        return View(foundModel);
    }

    [HttpPost("/Admin/{id:int}/Edit")]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return View(new AdminEntity() { Id = id, Name = name });
        }

        var foundModel = _admins.FindById(id);
        if (foundModel == null)
        {
            return NotFound();
        }

        foundModel.Name = name;
        _admins.SaveChanges();
        return RedirectToPanel("admins");
    }

    [HttpPost("/Admin/{id:int}/Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        if (_admins.Items.Count == 1)
        {
            return NotFound();
        }

        var foundModel = _admins.FindById(id);
        if (foundModel == null)
        {
            return NotFound();
        }

        _admins.Delete(foundModel);

        // Revoke all sessions for this login
        _registry.Revoke(foundModel.Login);

        // If current admin deleted themself, sign out immediately
        var current = _sessions.GetCurrent(HttpContext).Login;
        if (!string.IsNullOrWhiteSpace(current) &&
            string.Equals(current, foundModel.Login, StringComparison.OrdinalIgnoreCase))
        {
            _sessions.SignOut(HttpContext);
            return RedirectToAction("Index", "Home");
        }

        return RedirectToPanel("admins");
    }
}