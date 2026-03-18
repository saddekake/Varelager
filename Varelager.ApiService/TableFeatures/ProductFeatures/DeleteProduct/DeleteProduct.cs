using Varelager.ApiService.Data;

namespace Varelager.ApiService.TableFeatures.ProductFeatures
{
    public class DeleteProduct
    {
        public static async Task<IResult> Handle(AppDbContext db, int id)
        {
            var product = await db.Products.FindAsync(id);

            if (product == null)
                return Results.NotFound();

            db.Products.Remove(product);
            await db.SaveChangesAsync();

            return Results.Ok();
        }
    }
}
