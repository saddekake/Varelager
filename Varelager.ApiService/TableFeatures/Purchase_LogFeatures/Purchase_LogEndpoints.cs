using Microsoft.EntityFrameworkCore;
using Varelager.ApiService.Data;
using Varelager.ApiService.TableFeatures.Purchase_LogFeatures;

namespace Varelager.ApiService.TableFeatures.Purchase_LogFeatures;

public static class Purchase_LogEndpoints
{
    public static void MapPurchase_LogEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/purchase_Log", CreatePurchase_Log.Handle).RequireAuthorization();
        app.MapGet("/purchase_Log", ReturnPurchase_Log.Handle).RequireAuthorization();
    }
}