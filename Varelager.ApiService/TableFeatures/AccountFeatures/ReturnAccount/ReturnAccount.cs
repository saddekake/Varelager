using Varelager.ApiService.Data;
using Microsoft.EntityFrameworkCore;

namespace Varelager.ApiService.TableFeatures.AccountFeatures
{
    public class ReturnAccount
    {
        public static async Task<IResult> Handle(AppDbContext db)
        {
            return Results.Ok(await db.Account.ToListAsync());
        }
    }
}