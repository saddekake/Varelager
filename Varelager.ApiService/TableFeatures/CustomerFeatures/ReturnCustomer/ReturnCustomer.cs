using Varelager.ApiService.Data;
using Microsoft.EntityFrameworkCore;

namespace Varelager.ApiService.TableFeatures.CustomerFeatures
{
    public class ReturnCustomer
    {
        public static async Task<IResult> Handle(AppDbContext db)
        {
            return Results.Ok(await db.Customers.ToListAsync());
        }
    }
}