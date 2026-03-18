using Varelager.ApiService.Data;

namespace Varelager.ApiService.TableFeatures.CustomerFeatures
{
    public class UpdateCustomer
    {
        public static async Task<IResult> Handle(AppDbContext db, int id, Customer updated)
        {
            var customer = await db.Customers.FindAsync(id);

            if (customer == null)
                return Results.NotFound();

            customer.FName = updated.FName;
            customer.LName = updated.LName;
            customer.Phone = updated.Phone;
            customer.Email = updated.Email;
            customer.Country = updated.Country;

            await db.SaveChangesAsync();

            return Results.Ok(customer);
        }
    }
}