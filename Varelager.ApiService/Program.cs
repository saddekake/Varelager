using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Varelager.ApiService.Data;
using Varelager.ApiService.TableFeatures.AccountFeatures;
using Varelager.ApiService.TableFeatures.CountryFeatures;
using Varelager.ApiService.TableFeatures.CustomerFeatures;
using Varelager.ApiService.TableFeatures.ProductFeatures;
using Varelager.ApiService.TableFeatures.Purchase_LogFeatures;
using Varelager.ApiService.TableFeatures.Sale_LogFeatures;
using Varelager.ApiService.TableFeatures.SupplierFeatures;

var builder = WebApplication.CreateBuilder(args);

var domain = builder.Configuration["Auth0:Domain"];
var audience = builder.Configuration["Auth0:Audience"];

System.Diagnostics.Debug.WriteLine($"Auth0 Domain: {domain}");
System.Diagnostics.Debug.WriteLine($"Auth0 Audience: {audience}");

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = $"https://{builder.Configuration["Auth0:Domain"]}/";
        options.Audience = "https://varelager-api";
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

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHealthChecks();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (!db.Account.Any())
    {
        var hasher = new PasswordHasher<Account>();

        var admin = new Account
        {
            Name = "admin",
            Type = "Admin"
        };

        admin.PasswordHash = hasher.HashPassword(admin, "password");

        db.Account.Add(admin);
        db.SaveChanges();
    }
}

app.MapCustomerEndpoints();
app.MapProductEndpoints();
app.MapSupplierEndpoints();
app.MapAccountEndpoints();
app.MapPurchase_LogEndpoints();
app.MapSale_LogEndpoints();
app.MapCountryEndpoints();

app.MapDefaultEndpoints();

app.Run();