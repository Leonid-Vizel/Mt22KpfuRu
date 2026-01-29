using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Caching.Memory;
using Mt22KpfuRu.Services.Security;
using Mt22KpfuRu.Tests.TestUtils;
using Xunit;

namespace Mt22KpfuRu.Tests;

public class AdminSessionAuthorizeFilterTests
{
    [Fact]
    public void OnAuthorization_Sets401_WhenNotAuthenticated()
    {
        var cache = new MemoryCache(new MemoryCacheOptions());
        var registry = new AdminSessionRegistry(cache);
        var sessions = new AdminSessionService(registry);
        var filter = new AdminSessionAuthorizeFilter(sessions);

        var ctx = HttpContextFactory.CreateWithSession(new TestSession());
        var actionContext = new ActionContext(ctx, new RouteData(), new ActionDescriptor());
        var authContext = new AuthorizationFilterContext(actionContext, new List<IFilterMetadata>());

        filter.OnAuthorization(authContext);

        Assert.IsType<StatusCodeResult>(authContext.Result);
        Assert.Equal(401, ((StatusCodeResult)authContext.Result!).StatusCode);
    }

    [Fact]
    public void OnAuthorization_Allows_WhenAuthenticated()
    {
        var cache = new MemoryCache(new MemoryCacheOptions());
        var registry = new AdminSessionRegistry(cache);
        var sessions = new AdminSessionService(registry);
        var filter = new AdminSessionAuthorizeFilter(sessions);

        var session = new TestSession();
        var ctx = HttpContextFactory.CreateWithSession(session);
        sessions.SignIn(ctx, "admin", "Admin");

        var actionContext = new ActionContext(ctx, new RouteData(), new ActionDescriptor());
        var authContext = new AuthorizationFilterContext(actionContext, new List<IFilterMetadata>());

        filter.OnAuthorization(authContext);

        Assert.Null(authContext.Result);
    }
}
