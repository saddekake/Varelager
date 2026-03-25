using Varelager.ApiService.Data;
using Microsoft.EntityFrameworkCore;

namespace Varelager.ApiService.TableFeatures.CountryFeatures
{
    public class ReturnCountry
    {
        public static async Task<IResult> Handle(AppDbContext db)
        {
            return Results.Ok(
                await db.Countries
                .ToListAsync()
            );
        }
    }
}