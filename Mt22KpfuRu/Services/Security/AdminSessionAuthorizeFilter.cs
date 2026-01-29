using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Mt22KpfuRu.Services.Security;

public sealed class AdminSessionAuthorizeFilter : IAuthorizationFilter
{
    private readonly IAdminSessionService _sessions;

    public AdminSessionAuthorizeFilter(IAdminSessionService sessions)
    {
        _sessions = sessions;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        if (!_sessions.IsAuthenticated(context.HttpContext))
        {
            context.Result = new StatusCodeResult(401);
        }
    }
}
