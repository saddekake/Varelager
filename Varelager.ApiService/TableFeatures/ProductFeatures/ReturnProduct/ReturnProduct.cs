using Varelager.ApiService.Data;
using Microsoft.EntityFrameworkCore;

namespace Varelager.ApiService.TableFeatures.ProductFeatures
{
    public class ReturnProduct
    {
        public static async Task<IResult> Handle(AppDbContext db)
        {
            return Results.Ok(await db.Products.ToListAsync());
        }
    }
}
