using Varelager.ApiService.Data;

namespace Varelager.ApiService.TableFeatures.CountryFeatures
{
    public class UpdateCountry
    {
        public static async Task<IResult> Handle(AppDbContext db, int id, Country updated)
        {
            var country = await db.Countries.FindAsync(id);
            if (country == null)
                return Results.NotFound();

            if (!string.IsNullOrEmpty(updated.Name))
                country.Name = updated.Name;

            if (updated.Distance > 0)
                country.Distance = updated.Distance;

            await db.SaveChangesAsync();
            return Results.Ok(country);
        }
    }
}
