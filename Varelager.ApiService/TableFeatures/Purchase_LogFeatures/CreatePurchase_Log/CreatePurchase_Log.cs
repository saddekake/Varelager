using Varelager.ApiService.Data;

namespace Varelager.ApiService.TableFeatures.Purchase_LogFeatures
{
    public class CreatePurchase_Log
    {
        public static async Task<IResult> Handle(AppDbContext db, Purchase_Log purchase_log)
        {
            db.Purchase_Log.Add(purchase_log);
            await db.SaveChangesAsync();
            return Results.Ok(purchase_log);
        }
    }
}