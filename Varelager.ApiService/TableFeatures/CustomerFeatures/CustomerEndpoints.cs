using Microsoft.EntityFrameworkCore;
using Varelager.ApiService.Data;
using Varelager.ApiService.TableFeatures.CustomerFeatures;
using Varelager.ApiService.TableFeatures.ProductFeatures;

namespace Varelager.ApiService.TableFeatures.CustomerFeatures;

public static class CustomerEndpoints
{
    public static void MapCustomerEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/customers", CreateCustomer.Handle).RequireAuthorization();
        app.MapGet("/customers", ReturnCustomer.Handle).RequireAuthorization();
        app.MapPatch("/customers/{id}", UpdateCustomer.Handle).RequireAuthorization();
        app.MapDelete("/customers/{id}", DeleteCustomer.Handle).RequireAuthorization();
        app.MapGet("/customers/{lname}", ReturnSpecificCustomer.Handle).RequireAuthorization();
    }
}