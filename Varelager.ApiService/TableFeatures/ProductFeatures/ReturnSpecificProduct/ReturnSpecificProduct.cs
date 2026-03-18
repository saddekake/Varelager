using Varelager.ApiService.Data;
using Microsoft.EntityFrameworkCore;

namespace Varelager.ApiService.TableFeatures.ProductFeatures
{
    public class ReturnSpecificProduct
    {
        public static async Task<IResult> Handle(AppDbContext db, string name)
        {
            var product = await db.Products
                .FirstOrDefaultAsync(p => p.Name.ToLower() == name.ToLower());

            if (product == null)
                return Results.NotFound();

            return Results.Ok(product);
        }
    }
}
