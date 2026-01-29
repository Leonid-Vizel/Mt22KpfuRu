using Mt22KpfuRu.Instruments;

namespace Mt22KpfuRu.Services.Security;

public sealed class HtmlSanitizer : IHtmlSanitizer
{
    public string Sanitize(string? html) => HtmlSanitizerLite.Sanitize(html);
}
