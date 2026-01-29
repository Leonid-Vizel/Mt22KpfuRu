using Microsoft.AspNetCore.Http;

namespace Mt22KpfuRu.Services.Security;

public interface IAdminAuthService
{
    /// <summary>
    /// Verifies credentials and, on success, signs the admin into the session.
    /// May upgrade stored password hash (PBKDF2 migration) transparently.
    /// </summary>
    bool TrySignIn(HttpContext httpContext, string login, string password);
    void SignOut(HttpContext httpContext);
}
