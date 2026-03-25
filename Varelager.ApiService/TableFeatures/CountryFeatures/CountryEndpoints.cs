using Microsoft.EntityFrameworkCore;
using Varelager.ApiService.Data;
using Varelager.ApiService.TableFeatures.CountryFeatures;

namespace Varelager.ApiService.TableFeatures.CountryFeatures;

public static class CountryEndpoints
{
    public static void MapCountryEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/countries", CreateCountry.Handle);
        app.MapGet("/countries", ReturnCountry.Handle);
        app.MapPatch("/countries/{id}", UpdateCountry.Handle);
        app.MapDelete("/countries/{id}", DeleteCountry.Handle);
        app.MapGet("/countries/{name}", ReturnSpecificCountry.Handle);
    }
}