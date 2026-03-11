using Microsoft.EntityFrameworkCore;

namespace Varelager.ApiService.Data
{
    public class AppDbContext : DbContext // opens interaction
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) // sets options
            : base(options) { }

        public DbSet<Item> Items { get; set; } = null!; // adds table to db
    }

    public class Item // configure the table
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
    }
}
