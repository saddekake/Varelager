using Microsoft.EntityFrameworkCore;
using Varelager.ApiService.Data;
using Varelager.ApiService.TableFeatures.AccountFeatures;

namespace Varelager.ApiService.TableFeatures.AccountFeatures;

public static class AccountEndpoints
{
    public static void MapAccountEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/accounts", CreateAccount.Handle);
        app.MapGet("/accounts", ReturnAccount.Handle);
        app.MapPatch("/accounts/{id}", UpdateAccount.Handle);
        app.MapDelete("/accounts/{id}", DeleteAccount.Handle);
        app.MapPost("/accounts/login", LoginAccount.Handle);
    }
}