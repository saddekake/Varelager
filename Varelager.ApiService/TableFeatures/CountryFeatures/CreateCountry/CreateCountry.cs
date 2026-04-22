using Varelager.ApiService.Data;

namespace Varelager.ApiService.TableFeatures.CountryFeatures
{
    public class CreateCountry
    {
        public static async Task<IResult> Handle(AppDbContext db, Country country)
        {
            db.Countries.Add(country);
            await db.SaveChangesAsync();
            return Results.Ok(country);
        }
    }
}