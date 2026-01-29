using Microsoft.AspNetCore.Mvc;
using Mt22KpfuRu.Controllers.Base;
using Mt22KpfuRu.Services.Security;

namespace Mt22KpfuRu.Controllers;

public sealed class AuthController : AdminControllerBase
{
    private readonly IAdminAuthService _auth;
    private readonly IAdminSessionService _sessions;

    public AuthController(IAdminAuthService auth, IAdminSessionService sessions)
    {
        _auth = auth;
        _sessions = sessions;
    }

    [HttpGet("/Login")]
    public IActionResult Login()
    {
        if (_sessions.IsAuthenticated(HttpContext))
        {
            return RedirectToPanel();
        }
        return View();
    }

    [HttpPost("/Login")]
    [ValidateAntiForgeryToken]
    public IActionResult Login(string login, string password)
    {
        if (_auth.TrySignIn(HttpContext, login, password))
        {
            return RedirectToPanel();
        }

        return StatusCode(401);
    }

    [HttpGet("/Logout")]
    public IActionResult Logout()
    {
        _auth.SignOut(HttpContext);
        return RedirectToAction("Index", "Home");
    }
}