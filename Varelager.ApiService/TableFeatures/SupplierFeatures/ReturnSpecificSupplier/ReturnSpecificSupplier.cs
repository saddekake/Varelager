using Varelager.ApiService.Data;
using Microsoft.EntityFrameworkCore;

namespace Varelager.ApiService.TableFeatures.SupplierFeatures
{
    public class ReturnSpecificSupplier
    {
        public static async Task<IResult> Handle(AppDbContext db, string name)
        {
            var supplier = await db.Suppliers
                       .Where(s => s.Name.ToLower() == name.ToLower()) // where supplier.name.lowercase == name.lowercase
                       .ToListAsync();
            
            if (supplier.Count == 0)
                return Results.NotFound();

            return Results.Ok(supplier);
        }
    }
}
