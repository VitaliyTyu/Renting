using Lab9.App.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Lab9.App.DAL
{
    public class RentingDbContext : DbContext
    {
        public RentingDbContext(DbContextOptions<RentingDbContext> options) : base(options) { }

        public DbSet<Item> Items => Set<Item>();
        public DbSet<Country> Countries => Set<Country>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine, new[] { RelationalEventId.CommandExecuted });
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.ApplyConfiguration(new ItemConfiguration());
            //builder.ApplyConfiguration(new CountryConfiguration());

            base.OnModelCreating(builder);
        }
    }
}