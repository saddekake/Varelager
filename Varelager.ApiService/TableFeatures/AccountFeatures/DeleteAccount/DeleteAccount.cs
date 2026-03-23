using Varelager.ApiService.Data;

namespace Varelager.ApiService.TableFeatures.AccountFeatures
{
    public class DeleteAccount
    {
        public static async Task<IResult> Handle(AppDbContext db, int id)
        {
            var account = await db.Account.FindAsync(id);

            if (account == null)
                return Results.NotFound();

            db.Account.Remove(account);
            await db.SaveChangesAsync();

            return Results.Ok();
        }
    }
}