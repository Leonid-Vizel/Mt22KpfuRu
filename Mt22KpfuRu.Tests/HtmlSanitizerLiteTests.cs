using Mt22KpfuRu.Instruments;
using Xunit;

namespace Mt22KpfuRu.Tests;

public class HtmlSanitizerLiteTests
{
    [Fact]
    public void Sanitize_RemovesScriptTagsAndEventHandlers()
    {
        var html = "<p onclick=\"alert(1)\">Hi</p><script>alert(1)</script><a href=\"javascript:alert(2)\">x</a>";
        var sanitized = HtmlSanitizerLite.Sanitize(html);

        Assert.DoesNotContain("<script", sanitized, StringComparison.OrdinalIgnoreCase);
        Assert.DoesNotContain("onclick", sanitized, StringComparison.OrdinalIgnoreCase);
        Assert.DoesNotContain("javascript:", sanitized, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("<p", sanitized, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void Sanitize_RemovesDangerousTags()
    {
        var html = "<iframe src=\"https://evil.example\"></iframe><p>ok</p>";
        var sanitized = HtmlSanitizerLite.Sanitize(html);
        Assert.DoesNotContain("iframe", sanitized, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("<p>ok</p>", sanitized, StringComparison.OrdinalIgnoreCase);
    }
}
