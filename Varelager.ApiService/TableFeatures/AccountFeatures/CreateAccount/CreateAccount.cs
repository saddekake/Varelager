using Microsoft.AspNetCore.Identity;
using Varelager.ApiService.Data;

namespace Varelager.ApiService.TableFeatures.AccountFeatures
{
    public class CreateAccount
    {
        public static async Task<IResult> Handle(AppDbContext db, AccountDto dto)
        {
            var hasher = new PasswordHasher<Account>();

            var account = new Account
            {
                Name = dto.Name,
                Type = dto.Type,
                PasswordHash = hasher.HashPassword(null, dto.Password)
            };

            db.Account.Add(account);
            await db.SaveChangesAsync();

            return Results.Ok(new
            {
                account.Id,
                account.Name,
                account.Type
            });
        }
    }
}