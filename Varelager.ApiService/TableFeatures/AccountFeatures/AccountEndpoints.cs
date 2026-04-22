namespace Varelager.ApiService.TableFeatures.AccountFeatures;

public static class AccountEndpoints
{
    public static void MapAccountEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/accounts", CreateAccount.Handle).RequireAuthorization();
        app.MapGet("/accounts", ReturnAccount.Handle).RequireAuthorization();
        app.MapPatch("/accounts/{id}", UpdateAccount.Handle).RequireAuthorization();
        app.MapDelete("/accounts/{id}", DeleteAccount.Handle).RequireAuthorization();
    }
}