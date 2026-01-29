using System.Text.RegularExpressions;

namespace Mt22KpfuRu.Instruments;

/// <summary>
/// Lightweight HTML sanitizer to prevent stored XSS in places where the site renders stored HTML via Html.Raw().
/// This is a defensive measure; for rich HTML authoring consider a proper whitelist sanitizer.
/// </summary>
public static class HtmlSanitizerLite
{
    private static readonly Regex ScriptStyle =
        new(@"<\s*(script|style)\b[^>]*>.*?<\s*/\s*\1\s*>",
            RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);

    private static readonly Regex DangerousTags =
        new(@"<\s*/?\s*(iframe|object|embed|link|meta|base)\b[^>]*>",
            RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);

    private static readonly Regex OnHandlers =
        new(@"\s+on[a-z]+\s*=\s*(?:""[^""]*"" | '[^']*'|[^\s>]+)",
            RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);

    private static readonly Regex JsProtocols =
        new(@"\s+(href|src)\s*=\s*([""'])\s*(javascript:|vbscript:|data:text/html)[^""']*\2",
            RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);

    private static readonly Regex BadStyle =
        new(@"\s+style\s*=\s*([""'])[^""']*(expression|javascript:|vbscript:)[^""']*\1",
            RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);

    public static string Sanitize(string? html)
    {
        if (string.IsNullOrWhiteSpace(html)) return "";

        string s = html;
        s = ScriptStyle.Replace(s, "");
        s = DangerousTags.Replace(s, "");
        s = OnHandlers.Replace(s, "");
        s = JsProtocols.Replace(s, "");
        s = BadStyle.Replace(s, "");

        return s;
    }
}
