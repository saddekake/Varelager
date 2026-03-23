using Microsoft.EntityFrameworkCore;
using Varelager.ApiService.Data;
using Varelager.ApiService.TableFeatures.Sale_LogFeatures;

namespace Varelager.ApiService.TableFeatures.Sale_LogFeatures;

public static class Sale_LogEndpoints
{
    public static void MapSale_LogEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/sale_Log", CreateSale_Log.Handle);
        app.MapGet("/sale_Log", ReturnSale_Log.Handle);
    }
}