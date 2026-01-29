using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

namespace Mt22KpfuRu.Tests.TestUtils;

public sealed class TestSessionFeature : ISessionFeature
{
    public ISession Session { get; set; }

    public TestSessionFeature(ISession session)
    {
        Session = session;
    }
}
