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

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHealthChecks();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

using (var scope = app.Services.CreateScope()) // create default admin account
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

app.MapCustomerEndpoints();     // map customer endpoints
app.MapProductEndpoints();      // map product endpoints
app.MapSupplierEndpoints();     // map supplier endpoints
app.MapAccountEndpoints();      // map account endpoints
app.MapPurchase_LogEndpoints(); // map purchase_log endpoints
app.MapSale_LogEndpoints();     // map sale_log endpoints
app.MapCountryEndpoints();      // map country endpoints

app.MapDefaultEndpoints();

app.Run();