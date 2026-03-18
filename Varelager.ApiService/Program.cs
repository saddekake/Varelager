using Microsoft.EntityFrameworkCore;
using Varelager.ApiService.Data;
using Varelager.ApiService.TableFeatures.CustomerFeatures;
using Varelager.ApiService.TableFeatures.ProductFeatures;
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

app.MapCustomerEndpoints(); // map customer endpoints
app.MapProductEndpoints();  // map product endpoints
app.MapSupplierEndpoints(); // map supplier endpoints

app.MapDefaultEndpoints();

app.Run();