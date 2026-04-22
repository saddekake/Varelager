using Microsoft.EntityFrameworkCore;
using Varelager.ApiService.Data;
using Varelager.ApiService.TableFeatures.ProductFeatures;

namespace Varelager.ApiService.TableFeatures.ProductFeatures;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/products", CreateProduct.Handle).RequireAuthorization();
        app.MapGet("/products", ReturnProduct.Handle).RequireAuthorization();
        app.MapPatch("/products/{id:int}", UpdateProduct.Handle).RequireAuthorization();
        app.MapDelete("/products/{id:int}", DeleteProduct.Handle).RequireAuthorization();
        app.MapGet("/products/{id:int}", ReturnSpecificProduct.Handle).RequireAuthorization();
    }
}