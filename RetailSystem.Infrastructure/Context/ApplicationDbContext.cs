using Microsoft.EntityFrameworkCore;
using RetailSystem.Domain.Models;
using RetailSystem.Infrastructure.Context.Seeding;

namespace RetailSystem.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedCities();
            modelBuilder.SeedBranchs();
            modelBuilder.SeedCashiers();    
            modelBuilder.SeedInvoicesHeader();
            modelBuilder.SeedInvoicesDetails();
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Cashier> Cashier { get; set; }
        public DbSet<InvoiceHeader> InvoiceHeader { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
