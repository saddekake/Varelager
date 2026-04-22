using Microsoft.EntityFrameworkCore;

namespace Varelager.ApiService.Data
{
    public class AppDbContext : DbContext // opens interaction
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) // sets options
            : base(options) { }

        // adds tables to db
        public DbSet<Item> Items { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Supplier> Suppliers { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<Purchase_Log> Purchase_Log { get; set; } = null!;
        public DbSet<Sale_Log> Sale_Log { get; set; } = null!;
        public DbSet<Account> Account { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Country)
                .WithMany()
                .HasForeignKey(c => c.CountryId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Supplier>()
                .HasOne(s => s.Country)
                .WithMany()
                .HasForeignKey(s => s.CountryId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Supplier)
                .WithMany()
                .HasForeignKey(p => p.SupplierId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Sale_Log>()
                .HasOne(s => s.Product)
                .WithMany()
                .HasForeignKey(s => s.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Sale_Log>()
                .HasOne(s => s.Customer)
                .WithMany()
                .HasForeignKey(s => s.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Sale_Log>()
                .HasOne(s => s.Account)
                .WithMany()
                .HasForeignKey(s => s.AccountId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Purchase_Log>()
                .HasOne(p => p.Product)
                .WithMany()
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Purchase_Log>()
                .HasOne(p => p.Account)
                .WithMany()
                .HasForeignKey(p => p.AccountId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Account>()
                .HasIndex(a => a.Auth0UserId)
                .IsUnique()
                .HasFilter("[Auth0UserId] IS NOT NULL");
        }
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
        public Supplier? Supplier { get; set; } // foreign key
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
        public int CountryId { get; set; }
        public Country? Country { get; set; }
    }
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int Phone { get; set; }
        public string Email { get; set; } = "";
        public int CountryId { get; set; }
        public Country? Country { get; set; }
    }
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int Distance { get; set; }
    }
    public class Purchase_Log
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int AmountSold { get; set; }
        public int AccountId { get; set; }
        public Account? Account { get; set; }
    }
    public class Sale_Log
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int AmountSold { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public int AccountId { get; set; }
        public Account? Account { get; set; }
    }
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public string Type { get; set; } = "";
        public string? Auth0UserId { get; set; }
    }
    public class AccountDto
    {
        public string Name { get; set; } = "";
        public string Password { get; set; } = "";
        public string Type { get; set; } = "";
    }

}
