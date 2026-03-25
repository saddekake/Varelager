using Varelager.ApiService.Data;
using Microsoft.EntityFrameworkCore;

namespace Varelager.ApiService.TableFeatures.SupplierFeatures
{
    public class ReturnSupplier
    {
        public static async Task<IResult> Handle(AppDbContext db)
        {
            return Results.Ok(await db.Suppliers
                .Include(s => s.Country)
                .ToListAsync()
                );
        }
    }
}
