using Microsoft.AspNetCore.Http;

namespace Mt22KpfuRu.Services.Security;

public sealed class AdminSessionService : IAdminSessionService
{
    private readonly IAdminSessionRegistry _registry;

    public AdminSessionService(IAdminSessionRegistry registry)
    {
        _registry = registry;
    }

    public bool IsAuthenticated(HttpContext httpContext)
    {
        var session = httpContext.Session;
        if (session == null) return false;

        var login = session.GetString(SessionKeys.Login);
        var stamp = session.GetString(SessionKeys.Stamp);

        if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(stamp))
            return false;

        if (_registry.IsValid(login!, stamp!))
            return true;

        // revoked or stale -> wipe session
        SignOut(httpContext);
        return false;
    }

    public void SignIn(HttpContext httpContext, string login, string name)
    {
        // Protect against session fixation: wipe old session state before setting admin flags.
        httpContext.Session.Clear();

        string stamp = _registry.GetOrCreateStamp(login);
        httpContext.Session.SetString(SessionKeys.Login, login);
        httpContext.Session.SetString(SessionKeys.Name, name ?? "");
        httpContext.Session.SetString(SessionKeys.Stamp, stamp);
    }

    public void SignOut(HttpContext httpContext)
    {
        httpContext.Session.Remove(SessionKeys.Login);
        httpContext.Session.Remove(SessionKeys.Name);
        httpContext.Session.Remove(SessionKeys.Stamp);
    }

    public (string? Login, string? Name) GetCurrent(HttpContext httpContext)
    {
        var session = httpContext.Session;
        return (session.GetString(SessionKeys.Login), session.GetString(SessionKeys.Name));
    }
}
