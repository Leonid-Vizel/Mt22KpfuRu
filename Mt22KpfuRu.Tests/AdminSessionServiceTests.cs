using Microsoft.Extensions.Caching.Memory;
using Mt22KpfuRu.Services.Security;
using Mt22KpfuRu.Tests.TestUtils;
using Xunit;

namespace Mt22KpfuRu.Tests;

public class AdminSessionServiceTests
{
    [Fact]
    public void SignIn_SetsSessionKeys_AndIsAuthenticated()
    {
        var cache = new MemoryCache(new MemoryCacheOptions());
        var registry = new AdminSessionRegistry(cache);
        var service = new AdminSessionService(registry);

        var session = new TestSession();
        var ctx = HttpContextFactory.CreateWithSession(session);

        service.SignIn(ctx, "admin", "Admin Name");

        Assert.True(service.IsAuthenticated(ctx));
        var (login, name) = service.GetCurrent(ctx);
        Assert.Equal("admin", login);
        Assert.Equal("Admin Name", name);
    }

    [Fact]
    public void IsAuthenticated_FalseWhenStampRevoked_AndSessionCleared()
    {
        var cache = new MemoryCache(new MemoryCacheOptions());
        var registry = new AdminSessionRegistry(cache);
        var service = new AdminSessionService(registry);

        var session = new TestSession();
        var ctx = HttpContextFactory.CreateWithSession(session);
        service.SignIn(ctx, "admin", "Admin");
        Assert.True(service.IsAuthenticated(ctx));

        registry.Revoke("admin");
        Assert.False(service.IsAuthenticated(ctx));

        // keys should be removed
        Assert.DoesNotContain(SessionKeys.Login, session.Keys);
        Assert.DoesNotContain(SessionKeys.Stamp, session.Keys);
    }

    [Fact]
    public void SignOut_RemovesSessionKeys()
    {
        var cache = new MemoryCache(new MemoryCacheOptions());
        var registry = new AdminSessionRegistry(cache);
        var service = new AdminSessionService(registry);

        var session = new TestSession();
        var ctx = HttpContextFactory.CreateWithSession(session);
        service.SignIn(ctx, "admin", "Admin");
        service.SignOut(ctx);

        Assert.False(service.IsAuthenticated(ctx));
    }
}
