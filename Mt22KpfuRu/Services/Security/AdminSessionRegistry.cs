using Microsoft.Extensions.Caching.Memory;

namespace Mt22KpfuRu.Services.Security;

public sealed class AdminSessionRegistry : IAdminSessionRegistry
{
    private readonly IMemoryCache _cache;
    private static readonly object _sync = new();

    public AdminSessionRegistry(IMemoryCache cache)
    {
        _cache = cache;
    }

    private static string Key(string login) => $"admin-stamp::{login}";

    public string GetOrCreateStamp(string login)
    {
        // per-login lock to avoid double-create in high concurrency
        lock (_sync)
        {
            if (_cache.TryGetValue(Key(login), out string? stamp) && !string.IsNullOrWhiteSpace(stamp))
            {
                return stamp!;
            }

            stamp = Guid.NewGuid().ToString("N");
            _cache.Set(Key(login), stamp);
            return stamp;
        }
    }

    public bool IsValid(string login, string stamp)
    {
        if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(stamp))
            return false;

        if (!_cache.TryGetValue(Key(login), out string? current) || string.IsNullOrWhiteSpace(current))
            return false;

        return string.Equals(current, stamp, StringComparison.Ordinal);
    }

    public void Revoke(string login)
    {
        if (string.IsNullOrWhiteSpace(login)) return;
        lock (_sync)
        {
            _cache.Set(Key(login), Guid.NewGuid().ToString("N"));
        }
    }
}
