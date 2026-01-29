using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Mt22KpfuRu.Instruments;

namespace Mt22KpfuRu.Services.Files;

public sealed class WebRootFileLoader : IWebFileLoader
{
    private readonly IWebHostEnvironment _env;

    public WebRootFileLoader(IWebHostEnvironment env)
    {
        _env = env;
    }

    public Task<string?> SaveImage(string folderUnderWebroot, IFormFile file)
        => WebFileLoader.LoadImage(_env, folderUnderWebroot, file);

    public Task<string?> SavePdf(string folderUnderWebroot, IFormFile file)
        => WebFileLoader.LoadPdf(_env, folderUnderWebroot, file);
}
