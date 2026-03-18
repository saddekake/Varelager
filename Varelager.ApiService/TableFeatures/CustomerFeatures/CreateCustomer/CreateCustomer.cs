using Varelager.ApiService.Data;

namespace Varelager.ApiService.TableFeatures.CustomerFeatures
{
    public class CreateCustomer
    {
        public static async Task<IResult> Handle(AppDbContext db, Customer customer)
        {
            db.Customers.Add(customer);
            await db.SaveChangesAsync();
            return Results.Ok(customer);
        }
    }
}