using Microsoft.EntityFrameworkCore;
using Varelager.ApiService.Data;

namespace Varelager.ApiService.TableFeatures.SupplierFeatures;

public static class SupplierEndpoints
{
    public static void MapSupplierEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/suppliers", CreateSupplier.Handle);
        app.MapGet("/suppliers", ReturnSupplier.Handle);
        app.MapPatch("/suppliers/{id}", UpdateSupplier.Handle);
        app.MapDelete("/suppliers/{id}", DeleteSupplier.Handle);
        app.MapGet("/suppliers/{name}", ReturnSpecificSupplier.Handle);
    }
}