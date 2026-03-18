using Microsoft.EntityFrameworkCore;
using Varelager.ApiService.Data;
using Varelager.ApiService.TableFeatures.ProductFeatures;

namespace Varelager.ApiService.TableFeatures.ProductFeatures;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/products", CreateProduct.Handle);
        app.MapGet("/products", ReturnProduct.Handle);
        app.MapPatch("/products/{id}", UpdateProduct.Handle);
        app.MapDelete("/products/{id}", DeleteProduct.Handle);
        app.MapGet("/products/{name}", ReturnSpecificProduct.Handle);
    }
}