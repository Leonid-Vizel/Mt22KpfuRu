using Microsoft.AspNetCore.Mvc;
using Mt22KpfuRu.Services.Security;

namespace Mt22KpfuRu.Instruments;

/// <summary>
/// DI-friendly admin auth attribute.
/// Uses <see cref="AdminSessionAuthorizeFilter"/> which validates session using <see cref="IAdminSessionService"/>.
/// Returns 401 when not authorized (rendered via UseStatusCodePagesWithReExecute).
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public sealed class AdminSessionAuthorizeAttribute : TypeFilterAttribute
{
    public AdminSessionAuthorizeAttribute() : base(typeof(AdminSessionAuthorizeFilter))
    {
    }
}
