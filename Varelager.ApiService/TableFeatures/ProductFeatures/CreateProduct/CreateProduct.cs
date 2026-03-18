using Varelager.ApiService.Data;

namespace Varelager.ApiService.TableFeatures.ProductFeatures
{
    public class CreateProduct
    {
        public static async Task<IResult> Handle(AppDbContext db, Product product)
        {
            db.Products.Add(product);
            await db.SaveChangesAsync();
            return Results.Ok(product);
        }
    }
}
