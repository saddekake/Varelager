using Varelager.ApiService.Data;

namespace Varelager.ApiService.TableFeatures.CountryFeatures
{
    public class DeleteCountry
    {
        public static async Task<IResult> Handle(AppDbContext db, int id)
        {
            var country = await db.Countries.FindAsync(id);

            if (country == null)
                return Results.NotFound();

            db.Countries.Remove(country);
            await db.SaveChangesAsync();

            return Results.Ok();
        }
    }
}
