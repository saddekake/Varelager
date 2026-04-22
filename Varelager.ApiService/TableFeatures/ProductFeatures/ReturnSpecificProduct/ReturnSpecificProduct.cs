using Varelager.ApiService.Data;
using Microsoft.EntityFrameworkCore;

namespace Varelager.ApiService.TableFeatures.ProductFeatures
{
    public class ReturnSpecificProduct
    {
        public static async Task<IResult> Handle(AppDbContext db, int id)
        {
            var product = await db.Products.FindAsync(id);

            if (product == null)
                return Results.NotFound();

            return Results.Ok(product);
        }
    }
}