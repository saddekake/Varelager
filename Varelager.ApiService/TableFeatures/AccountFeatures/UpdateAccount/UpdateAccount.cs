using Varelager.ApiService.Data;

namespace Varelager.ApiService.TableFeatures.AccountFeatures
{
    public class UpdateAccount
    {
        public static async Task<IResult> Handle(AppDbContext db, int id, Account updated)
        {
            var account = await db.Account.FindAsync(id);

            if (account == null)
                return Results.NotFound();

            account.Name = updated.Name;
            account.PasswordHash = account.PasswordHash;
            account.Type = updated.Type;

            await db.SaveChangesAsync();

            return Results.Ok(account);
        }
    }
}