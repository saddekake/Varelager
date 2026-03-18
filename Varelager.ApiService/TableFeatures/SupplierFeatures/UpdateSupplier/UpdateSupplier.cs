using Varelager.ApiService.Data;

namespace Varelager.ApiService.TableFeatures.SupplierFeatures
{
    public class UpdateSupplier
    {
        public static async Task<IResult> Handle(AppDbContext db, int id, Supplier updated)
        {
            var supplier = await db.Suppliers.FindAsync(id);

            if (supplier == null)
                return Results.NotFound();

            supplier.Name = updated.Name;
            supplier.Phone = updated.Phone;
            supplier.Email = updated.Email;
            supplier.Country = updated.Country;

            await db.SaveChangesAsync();

            return Results.Ok(supplier);
        }
    }
}
