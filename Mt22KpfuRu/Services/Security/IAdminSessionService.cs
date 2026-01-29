using Microsoft.AspNetCore.Http;

namespace Mt22KpfuRu.Services.Security;

public interface IAdminSessionService
{
    bool IsAuthenticated(HttpContext httpContext);
    void SignIn(HttpContext httpContext, string login, string name);
    void SignOut(HttpContext httpContext);
    (string? Login, string? Name) GetCurrent(HttpContext httpContext);
}
