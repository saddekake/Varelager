using Microsoft.EntityFrameworkCore;
using Varelager.ApiService.Data;

namespace Varelager.ApiService.TableFeatures.SupplierFeatures;

public static class SupplierEndpoints
{
    public static void MapSupplierEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/suppliers", CreateSupplier.Handle).RequireAuthorization();
        app.MapGet("/suppliers", ReturnSupplier.Handle).RequireAuthorization();
        app.MapPatch("/suppliers/{id}", UpdateSupplier.Handle).RequireAuthorization();
        app.MapDelete("/suppliers/{id}", DeleteSupplier.Handle).RequireAuthorization();
        app.MapGet("/suppliers/{name}", ReturnSpecificSupplier.Handle).RequireAuthorization();
    }
}