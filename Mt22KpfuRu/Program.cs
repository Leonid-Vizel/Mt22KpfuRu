using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Http.Features;
using Mt22KpfuRu.Services.Admin;
using Mt22KpfuRu.Services.Files;
using Mt22KpfuRu.Services.Public;
using Mt22KpfuRu.Services.Security;
using Mt22KpfuRu.Services.Storage;

var builder = WebApplication.CreateBuilder(args);

// ===== Services =====
builder.Services.AddControllersWithViews();

// Upload limits (defense-in-depth)
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 25 * 1024 * 1024; // 25 MB
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(6);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.SameSite = SameSiteMode.Lax;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});

// Storage / repositories
builder.Services.AddSingleton<IStorageRootProvider, StorageRootProvider>();
builder.Services.AddSingleton<IStoreFileNameProvider, StoreFileNameProvider>();
builder.Services.AddSingleton(typeof(IRepository<>), typeof(XmlRepository<>));

// Domain services
builder.Services.AddSingleton<IPublicContentService, PublicContentService>();
builder.Services.AddSingleton<IAdminPanelService, AdminPanelService>();

// Cross-cutting services
builder.Services.AddSingleton<IHtmlSanitizer, HtmlSanitizer>();
builder.Services.AddSingleton<IClock, SystemClock>();
builder.Services.AddSingleton<IPasswordHasherService, PasswordHasherService>();
builder.Services.AddSingleton<IWebFileLoader, WebRootFileLoader>();

// Admin auth
builder.Services.AddSingleton<IAdminSessionRegistry, AdminSessionRegistry>();
builder.Services.AddScoped<IAdminSessionService, AdminSessionService>();
builder.Services.AddScoped<IAdminAuthService, AdminAuthService>();
builder.Services.AddScoped<AdminSessionAuthorizeFilter>();

var app = builder.Build();

// ===== Pipeline =====
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Session must be before endpoints
app.UseSession();

app.UseAuthorization();

// Basic security headers (keep permissive to avoid breaking existing inline scripts/styles)
app.Use(async (ctx, next) =>
{
    ctx.Response.Headers["X-Content-Type-Options"] = "nosniff";
    ctx.Response.Headers["X-Frame-Options"] = "SAMEORIGIN";
    ctx.Response.Headers["Referrer-Policy"] = "strict-origin-when-cross-origin";
    ctx.Response.Headers["Permissions-Policy"] = "geolocation=(), microphone=(), camera=()";
    ctx.Response.Headers["Content-Security-Policy"] =
        "default-src 'self'; " +
        "img-src 'self' https: data:; " +
        "style-src 'self' 'unsafe-inline' https:; " +
        "script-src 'self' 'unsafe-inline' https:; " +
        "frame-src https://yandex.ru https://*.yandex.ru; " +
        "connect-src 'self' https:; " +
        "object-src 'none'; base-uri 'self'; form-action 'self'";
    await next();
});

// show custom 401/404 pages
app.UseStatusCodePagesWithReExecute("/Error/StatusCode/{0}");

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
