using Microsoft.Extensions.Caching.Memory;
using Mt22KpfuRu.Services.Security;
using Xunit;

namespace Mt22KpfuRu.Tests;

public class AdminSessionRegistryTests
{
    [Fact]
    public void GetOrCreateStamp_IsStableUntilRevoked()
    {
        var cache = new MemoryCache(new MemoryCacheOptions());
        var registry = new AdminSessionRegistry(cache);

        var stamp1 = registry.GetOrCreateStamp("admin");
        var stamp2 = registry.GetOrCreateStamp("admin");

        Assert.Equal(stamp1, stamp2);
        Assert.True(registry.IsValid("admin", stamp1));

        registry.Revoke("admin");
        Assert.False(registry.IsValid("admin", stamp1));

        var stamp3 = registry.GetOrCreateStamp("admin");
        Assert.NotEqual(stamp1, stamp3);
        Assert.True(registry.IsValid("admin", stamp3));
    }
}
