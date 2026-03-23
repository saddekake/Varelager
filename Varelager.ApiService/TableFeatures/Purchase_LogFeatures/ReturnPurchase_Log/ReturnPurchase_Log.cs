using Varelager.ApiService.Data;
using Microsoft.EntityFrameworkCore;

namespace Varelager.ApiService.TableFeatures.Purchase_LogFeatures
{
    public class ReturnPurchase_Log
    {
        public static async Task<IResult> Handle(AppDbContext db)
        {
            return Results.Ok(
                await db.Purchase_Log
                .Include(p => p.Product)
                .Include(p => p.Account)
                .ToListAsync());
        }
    }
}