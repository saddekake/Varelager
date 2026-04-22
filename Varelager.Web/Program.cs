using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.IdentityModel.Tokens;
using MudBlazor.Services;
using Varelager.Web.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthorization();

builder.Services.AddAuth0WebAppAuthentication(options =>
{
    options.Domain = builder.Configuration["Auth0:Domain"];
    options.ClientId = builder.Configuration["Auth0:ClientId"];
    options.ClientSecret = builder.Configuration["Auth0:ClientSecret"];

})
.WithAccessToken(options =>
{
    //options.Audience = builder.Configuration["Auth0:Audience"];

    options.Scope = "openid profile read:api";
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy =>
        policy.RequireClaim("https://varelager.no/roles", "Admin"));

    options.AddPolicy("SalesOnly", policy =>
        policy.RequireClaim("https://varelager.no/roles", "Salesperson", "Admin"));

    options.AddPolicy("WarehouseOnly", policy =>
        policy.RequireClaim("https://varelager.no/roles", "Warehouse Manager", "Admin"));
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<TokenHandler>();

builder.Services.AddHttpClient("Api", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]!);
})
.AddHttpMessageHandler<TokenHandler>();

builder.Services.AddScoped(sp =>
    sp.GetRequiredService<IHttpClientFactory>().CreateClient("Api"));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseAntiforgery();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/login", async (HttpContext ctx, string? returnUrl) =>
{
    var props = new LoginAuthenticationPropertiesBuilder()
        .WithRedirectUri(string.IsNullOrWhiteSpace(returnUrl) ? "/" : returnUrl)
        .WithAudience(builder.Configuration["Auth0:Audience"]!)
        .WithScope("openid profile read:api")
        .Build();

    await ctx.ChallengeAsync(Auth0Constants.AuthenticationScheme, props);
});

app.MapGet("/logout", async (HttpContext ctx) =>
{
    var props = new LogoutAuthenticationPropertiesBuilder()
        .WithRedirectUri("/")
        .Build();

    await ctx.SignOutAsync(Auth0Constants.AuthenticationScheme, props);
    await ctx.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
});

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();