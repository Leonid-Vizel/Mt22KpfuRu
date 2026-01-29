using Mt22KpfuRu.Models.DataModels;
using Mt22KpfuRu.Services.Storage;

namespace Mt22KpfuRu.Services.Security;

public sealed class AdminAuthService : IAdminAuthService
{
    private readonly IRepository<AdminEntity> _admins;
    private readonly IPasswordHasherService _hasher;
    private readonly IAdminSessionService _sessions;

    public AdminAuthService(IRepository<AdminEntity> admins, IPasswordHasherService hasher, IAdminSessionService sessions)
    {
        _admins = admins;
        _hasher = hasher;
        _sessions = sessions;
    }

    public bool TrySignIn(HttpContext httpContext, string login, string password)
    {
        if (string.IsNullOrWhiteSpace(login) || string.IsNullOrEmpty(password))
            return false;

        var admin = _admins.Items.FirstOrDefault(a => string.Equals(a.Login, login, StringComparison.Ordinal));
        if (admin == null)
            return false;

        if (!_hasher.VerifyAndMaybeUpgrade(admin.HashPassword, admin.Login, password, out var upgraded))
            return false;

        if (!string.IsNullOrEmpty(upgraded))
        {
            admin.HashPassword = upgraded!;
            _admins.SaveChanges();
        }

        _sessions.SignIn(httpContext, admin.Login, admin.Name);
        return true;
    }

    public void SignOut(HttpContext httpContext) => _sessions.SignOut(httpContext);
}
