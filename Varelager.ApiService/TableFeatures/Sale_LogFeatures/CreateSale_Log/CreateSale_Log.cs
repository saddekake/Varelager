using System.Security.Claims;
using Varelager.ApiService.Data;
using Microsoft.EntityFrameworkCore;

namespace Varelager.ApiService.TableFeatures.Sale_LogFeatures
{
    public class CreateSale_Log
    {
        public static async Task<IResult> Handle(
            AppDbContext db,
            HttpContext http,
            CreateSaleLogRequest request)
        {
            var auth0Id = http.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var account = await db.Account
                .FirstOrDefaultAsync(a => a.Auth0UserId == auth0Id);

            if (account == null)
                return Results.Unauthorized();

            var sale = new Sale_Log
            {
                ProductId = request.ProductId,
                AmountSold = request.AmountSold,
                CustomerId = request.CustomerId,
                AccountId = account.Id
            };

            db.Sale_Log.Add(sale);
            await db.SaveChangesAsync();

            return Results.Ok(sale);
        }
    }
}