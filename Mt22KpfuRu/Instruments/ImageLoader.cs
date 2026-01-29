using Microsoft.AspNetCore.Http;

namespace Mt22KpfuRu.Instruments;

public static class WebFileLoader
{
    /// <summary>
    /// Saves an uploaded image into a folder under webroot (e.g. "/img/Kazan/").
    /// Returns:
    ///   "file.ext" - created successfully
    ///   ""         - file is not a valid image (extension/signature/size)
    ///   null       - IO error
    /// </summary>
    public static async Task<string?> LoadImage(IWebHostEnvironment environment, string folderUnderWebroot, IFormFile file)
    {
        string fileName = file?.FileName ?? "";
        string ext = Path.GetExtension(fileName).ToLowerInvariant();

        bool extOk = ext is ".png" or ".jpg" or ".jpeg" or ".jfif";
        if (!extOk) return string.Empty;

        if (file.Length <= 0 || file.Length > FileValidation.MaxImageBytes)
            return string.Empty;

        byte[] header = await FileValidation.ReadHeaderAsync(file, 16);
        bool sigOk = ext == ".png" ? FileValidation.IsPng(header) : FileValidation.IsJpeg(header);
        if (!sigOk) return string.Empty;

        // Normalize folder path
        string cleaned = (folderUnderWebroot ?? "").Replace('\\', '/').Trim('/');
        string folderPath = Path.Combine(environment.WebRootPath, cleaned);
        Directory.CreateDirectory(folderPath);

        Guid guidForName = Guid.NewGuid();
        string outName = $"{guidForName}{ext}";
        string fullPath = Path.Combine(folderPath, outName);
        while (File.Exists(fullPath))
        {
            guidForName = Guid.NewGuid();
            outName = $"{guidForName}{ext}";
            fullPath = Path.Combine(folderPath, outName);
        }

        string tmpPath = fullPath + ".tmp";
        try
        {
            await using (FileStream fs = new FileStream(tmpPath, FileMode.CreateNew, FileAccess.Write, FileShare.None))
            {
                await file.CopyToAsync(fs);
            }
            File.Move(tmpPath, fullPath, overwrite: true);
        }
        catch
        {
            try { if (File.Exists(tmpPath)) File.Delete(tmpPath); } catch { /* ignore */ }
            return null;
        }

        return outName;
    }

    /// <summary>
    /// Saves an uploaded PDF into a folder under webroot. Same return semantics as LoadImage.
    /// </summary>
    public static async Task<string?> LoadPdf(IWebHostEnvironment environment, string folderUnderWebroot, IFormFile file)
    {
        string fileName = file?.FileName ?? "";
        string ext = Path.GetExtension(fileName).ToLowerInvariant();

        if (ext != ".pdf") return string.Empty;

        if (file.Length <= 0 || file.Length > FileValidation.MaxPdfBytes)
            return string.Empty;

        byte[] header = await FileValidation.ReadHeaderAsync(file, 16);
        if (!FileValidation.IsPdf(header))
            return string.Empty;

        string cleaned = (folderUnderWebroot ?? "").Replace('\\', '/').Trim('/');
        string folderPath = Path.Combine(environment.WebRootPath, cleaned);
        Directory.CreateDirectory(folderPath);

        Guid guidForName = Guid.NewGuid();
        string outName = $"{guidForName}{ext}";
        string fullPath = Path.Combine(folderPath, outName);
        while (File.Exists(fullPath))
        {
            guidForName = Guid.NewGuid();
            outName = $"{guidForName}{ext}";
            fullPath = Path.Combine(folderPath, outName);
        }

        string tmpPath = fullPath + ".tmp";
        try
        {
            await using (FileStream fs = new FileStream(tmpPath, FileMode.CreateNew, FileAccess.Write, FileShare.None))
            {
                await file.CopyToAsync(fs);
            }
            File.Move(tmpPath, fullPath, overwrite: true);
        }
        catch
        {
            try { if (File.Exists(tmpPath)) File.Delete(tmpPath); } catch { /* ignore */ }
            return null;
        }

        return outName;
    }
}
