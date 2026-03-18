using Varelager.ApiService.Data;

namespace Varelager.ApiService.TableFeatures.SupplierFeatures
{
    public class DeleteSupplier
    {
        public static async Task<IResult> Handle(AppDbContext db, int id)
        {
            var supplier = await db.Suppliers.FindAsync(id);

            if (supplier == null)
                return Results.NotFound();

            db.Suppliers.Remove(supplier);
            await db.SaveChangesAsync();

            return Results.Ok();
        }
    }
}
