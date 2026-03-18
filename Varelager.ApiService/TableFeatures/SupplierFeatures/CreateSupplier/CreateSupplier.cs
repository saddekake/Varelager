using Varelager.ApiService.Data;

namespace Varelager.ApiService.TableFeatures.SupplierFeatures
{
    public class CreateSupplier
    {
        public static async Task<IResult> Handle(AppDbContext db, Supplier supplier)
        {
            db.Suppliers.Add(supplier);
            await db.SaveChangesAsync();
            return Results.Ok(supplier);
        }
    }
}
