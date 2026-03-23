using Microsoft.EntityFrameworkCore;
using Varelager.ApiService.Data;
using Varelager.ApiService.TableFeatures.CustomerFeatures;
using Varelager.ApiService.TableFeatures.ProductFeatures;

namespace Varelager.ApiService.TableFeatures.CustomerFeatures;

public static class CustomerEndpoints
{
    public static void MapCustomerEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/customers", CreateCustomer.Handle);
        app.MapGet("/customers", ReturnCustomer.Handle);
        app.MapPatch("/customers/{id}", UpdateCustomer.Handle);
        app.MapDelete("/customers/{id}", DeleteCustomer.Handle);
        app.MapGet("/customers/{lname}", ReturnSpecificCustomer.Handle);
    }
}