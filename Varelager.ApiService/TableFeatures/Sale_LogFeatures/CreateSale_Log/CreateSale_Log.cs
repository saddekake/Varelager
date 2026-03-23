using Varelager.ApiService.Data;

namespace Varelager.ApiService.TableFeatures.Sale_LogFeatures
{
    public class CreateSale_Log
    {
        public static async Task<IResult> Handle(AppDbContext db, Sale_Log sale_log)
        {
            db.Sale_Log.Add(sale_log);
            await db.SaveChangesAsync();
            return Results.Ok(sale_log);
        }
    }
}