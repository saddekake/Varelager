using Varelager.ApiService.Data;
using Microsoft.EntityFrameworkCore;

namespace Varelager.ApiService.TableFeatures.Sale_LogFeatures
{
    public class ReturnSale_Log
    {
        public static async Task<IResult> Handle(AppDbContext db)
        {
            return Results.Ok(
                await db.Sale_Log
                .Include(s => s.Product)
                .Include(s => s.Customer)
                .Include(s => s.Account)
                .ToListAsync());
        }
    }
}