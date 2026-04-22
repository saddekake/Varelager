using System.Security.Claims;
using Varelager.ApiService.Data;
using Microsoft.EntityFrameworkCore;

namespace Varelager.ApiService.TableFeatures.Purchase_LogFeatures
{
    public class CreatePurchase_Log
    {
        public static async Task<IResult> Handle(
            AppDbContext db,
            HttpContext http,
            CreatePurchaseLogRequest request)
        {
            var auth0Id = http.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var account = await db.Account
                .FirstOrDefaultAsync(a => a.Auth0UserId == auth0Id);

            if (account == null)
                return Results.Unauthorized();

            var purchase = new Purchase_Log
            {
                ProductId = request.ProductId,
                AmountSold = request.AmountSold,
                AccountId = account.Id
            };

            db.Purchase_Log.Add(purchase);
            await db.SaveChangesAsync();

            return Results.Ok(purchase);
        }
    }
}