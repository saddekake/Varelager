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

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public int SupplierId { get; set; } // "<foreign key name>Id" efcore naming convention
        public Supplier Supplier { get; set; } = null!; // foreign key
        public double Weight { get; set; }
        public int Stock { get; set; }
    }
    public class Customer
    {
        public int Id { get; set; }
        public string FName { get; set; } = "";
        public string LName { get; set; } = "";
        public int Phone { get; set; }
        public string Email { get; set; } = "";
        public string Country { get; set; } = "";
    }
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int Phone { get; set; }
        public string Email { get; set; } = "";
        public string Country { get; set; } = "";
    }
}
