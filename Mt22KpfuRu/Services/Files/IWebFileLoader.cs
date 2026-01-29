using Microsoft.AspNetCore.Http;

namespace Mt22KpfuRu.Services.Files;

public interface IWebFileLoader
{
    Task<string?> SaveImage(string folderUnderWebroot, IFormFile file);
    Task<string?> SavePdf(string folderUnderWebroot, IFormFile file);
}
