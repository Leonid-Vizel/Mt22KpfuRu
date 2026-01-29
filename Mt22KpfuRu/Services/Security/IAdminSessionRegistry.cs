namespace Mt22KpfuRu.Services.Security;

/// <summary>
/// Keeps a per-login session stamp. By rotating the stamp we can revoke all active sessions for a login
/// without enumerating session store internals.
/// </summary>
public interface IAdminSessionRegistry
{
    string GetOrCreateStamp(string login);
    bool IsValid(string login, string stamp);
    void Revoke(string login);
}
