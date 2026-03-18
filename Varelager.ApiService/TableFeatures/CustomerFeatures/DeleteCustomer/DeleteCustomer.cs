using Varelager.ApiService.Data;

namespace Varelager.ApiService.TableFeatures.CustomerFeatures
{
    public class DeleteCustomer
    {
        public static async Task<IResult> Handle(AppDbContext db, int id)
        {
            var customer = await db.Customers.FindAsync(id);

            if (customer == null)
                return Results.NotFound();

            db.Customers.Remove(customer);
            await db.SaveChangesAsync();

            return Results.Ok();
        }
    }
}