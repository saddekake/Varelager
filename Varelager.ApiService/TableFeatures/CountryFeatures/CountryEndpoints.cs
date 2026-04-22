using Microsoft.EntityFrameworkCore;
using Varelager.ApiService.Data;
using Varelager.ApiService.TableFeatures.CountryFeatures;

namespace Varelager.ApiService.TableFeatures.CountryFeatures;

public static class CountryEndpoints
{
    public static void MapCountryEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/countries", CreateCountry.Handle).RequireAuthorization();
        app.MapGet("/countries", ReturnCountry.Handle).RequireAuthorization();
        app.MapPatch("/countries/{id}", UpdateCountry.Handle).RequireAuthorization();
        app.MapDelete("/countries/{id}", DeleteCountry.Handle).RequireAuthorization();
        app.MapGet("/countries/{name}", ReturnSpecificCountry.Handle).RequireAuthorization();
    }
}