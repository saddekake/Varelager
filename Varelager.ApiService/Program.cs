using Microsoft.EntityFrameworkCore;
using Varelager.ApiService.Data;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated(); // creates tables if they don't exist
}

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

string[] summaries = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];

app.MapGet("/", () => "API service is running. Navigate to /weatherforecast to see sample data.");

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

// api create row to db
app.MapPost("/items", async (AppDbContext db, Item item) => // database, content
{
    db.Items.Add(item); // add row with content
    await db.SaveChangesAsync(); // commit changes
    return Results.Ok(item); // return new item with ok
});

// api return rows from db
app.MapGet("/items", async (AppDbContext db) => // database
{
    return await db.Items.ToListAsync(); // return list of whole table
});

// api update row to db
app.MapPatch("/items/{id}", async (AppDbContext db, int id, Item updatedItem) => // database, id of row, updated content
{
    var item = await db.Items.FindAsync(id); // find row by id

    if (item == null) // null check
    {
        return Results.NotFound();
    }
    item.Name = updatedItem.Name; // update item Name column

    await db.SaveChangesAsync(); // commit changes

    return Results.Ok(item); // return updated item with ok
});

// api delete row from db
app.MapDelete("/items/{id}", async (AppDbContext db, int id) => // database, id of row
{
    var item = await db.Items.FindAsync(id); // find row by id

    if (item == null) // null check
        return Results.NotFound();

    db.Items.Remove(item); // remove row

    await db.SaveChangesAsync(); // commit changes

    return Results.Ok(); // return ok
});

app.MapDefaultEndpoints();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
