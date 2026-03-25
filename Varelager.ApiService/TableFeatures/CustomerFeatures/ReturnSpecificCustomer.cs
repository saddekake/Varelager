using Varelager.ApiService.Data;
using Microsoft.EntityFrameworkCore;

namespace Varelager.ApiService.TableFeatures.CustomerFeatures
{
    public class ReturnSpecificCustomer
    {
        public static async Task<IResult> Handle(AppDbContext db, string lname)
        {
            var customer = await db.Customers
                .Include(c => c.Country)
                .FirstOrDefaultAsync(p => p.LName.ToLower() == lname.ToLower());

            if (customer == null)
                return Results.NotFound();

            return Results.Ok(customer);
        }
    }
}