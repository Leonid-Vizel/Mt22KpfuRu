using Microsoft.AspNetCore.Http;

namespace Mt22KpfuRu.Tests.TestUtils;

public static class HttpContextFactory
{
    public static DefaultHttpContext CreateWithSession(ISession session)
    {
        var ctx = new DefaultHttpContext();
        ctx.Features.Set<Microsoft.AspNetCore.Http.Features.ISessionFeature>(new TestSessionFeature(session));
        return ctx;
    }
}
