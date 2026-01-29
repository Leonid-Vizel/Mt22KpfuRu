using Microsoft.AspNetCore.Http;

namespace Mt22KpfuRu.Instruments;

public static class FileValidation
{
    public const long MaxImageBytes = 5 * 1024 * 1024;   // 5 MB
    public const long MaxPdfBytes   = 20 * 1024 * 1024;  // 20 MB

    public static bool IsJpeg(ReadOnlySpan<byte> b) =>
        b.Length >= 3 && b[0] == 0xFF && b[1] == 0xD8 && b[2] == 0xFF;

    public static bool IsPng(ReadOnlySpan<byte> b) =>
        b.Length >= 8 &&
        b[0] == 0x89 && b[1] == 0x50 && b[2] == 0x4E && b[3] == 0x47 &&
        b[4] == 0x0D && b[5] == 0x0A && b[6] == 0x1A && b[7] == 0x0A;

    public static bool IsPdf(ReadOnlySpan<byte> b) =>
        b.Length >= 5 && b[0] == 0x25 && b[1] == 0x50 && b[2] == 0x44 && b[3] == 0x46 && b[4] == 0x2D; // %PDF-

    public static async Task<byte[]> ReadHeaderAsync(IFormFile file, int n = 16)
    {
        await using var s = file.OpenReadStream();
        byte[] buf = new byte[n];
        int read = await s.ReadAsync(buf, 0, n);
        return read == n ? buf : buf.Take(read).ToArray();
    }
}
