using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace Mt22KpfuRu.Tests.TestUtils;

public sealed class FakeHostEnvironment : IHostEnvironment
{
    public string EnvironmentName { get; set; } = Environments.Development;
    public string ApplicationName { get; set; } = "Mt22KpfuRu.Tests";
    public string ContentRootPath { get; set; }
    public IFileProvider ContentRootFileProvider { get; set; } = new NullFileProvider();

    public FakeHostEnvironment(string contentRootPath)
    {
        ContentRootPath = contentRootPath;
    }
}
