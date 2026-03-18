using Varelager.ApiService.Data;

namespace Varelager.ApiService.TableFeatures.ProductFeatures
{
    public class UpdateProduct
    {
        public static async Task<IResult> Handle(AppDbContext db, int id, Product updated)
        {
            var product = await db.Products.FindAsync(id);
            if (product == null)
                return Results.NotFound();

            if (!string.IsNullOrEmpty(updated.Name))
                product.Name = updated.Name;

            if (!string.IsNullOrEmpty(updated.Description))
                product.Description = updated.Description;

            if (updated.SupplierId > 0)
                product.SupplierId = updated.SupplierId;

            if (updated.Weight > 0)
                product.Weight = updated.Weight;

            if (updated.Stock >= 0)
                product.Stock = updated.Stock;

            await db.SaveChangesAsync();
            return Results.Ok(product);
        }
    }
}
