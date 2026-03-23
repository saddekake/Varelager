using Microsoft.AspNetCore.Identity;
using Varelager.ApiService.Data;
using Microsoft.EntityFrameworkCore;

namespace Varelager.ApiService.TableFeatures.AccountFeatures
{
    public class LoginAccount
    {
        public static async Task<IResult> Handle(AppDbContext db, LoginDto dto)
        {
            var account = await db.Account.FirstOrDefaultAsync(a => a.Name == dto.Name);
            if (account == null)
                return Results.BadRequest("Error: account not found");

            var hasher = new PasswordHasher<Account>();
            var result = hasher.VerifyHashedPassword(account, account.PasswordHash, dto.Password);

            if (result == PasswordVerificationResult.Success)
                return Results.Ok(new
                {
                    account.Id,
                    account.Name,
                    account.Type
                });
            else
                return Results.BadRequest("Error: invalid password");
        }
    }

    public class LoginDto
    {
        public string Name { get; set; } = "";
        public string Password { get; set; } = "";
    }
}