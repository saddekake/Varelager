using Varelager.ApiService.Data;
using Microsoft.EntityFrameworkCore;

namespace Varelager.ApiService.TableFeatures.CountryFeatures
{
    public class ReturnSpecificCountry
    {
        public static async Task<IResult> Handle(AppDbContext db, string name)
        {
            var country = await db.Countries
                .FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());

            if (country == null)
                return Results.NotFound();

            return Results.Ok(country);
        }
    }
}