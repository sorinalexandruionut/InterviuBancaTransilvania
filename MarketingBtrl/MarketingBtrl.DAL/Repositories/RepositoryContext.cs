using MarketingBtrl.DAL.Entities;
using MarketingBtrl.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MarketingBtrl.DAL.Repositories
{
    public class RepositoryContext : DbContext, IRepositoryContext
    {

        IConfiguration _configuration;

        public RepositoryContext(DbContextOptions options, IConfiguration config)
           : base(options)
        {
            this._configuration = config;
        }

        public  RepositoryContext(DbContextOptions options): base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                    .EnableDetailedErrors()
                    .EnableSensitiveDataLogging()
                    .UseSqlServer(_configuration["ConnectionString"]);


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                                            .HasData(
                                                new Product
                                                {
                                                    Id = 1,
                                                    Name = "Product 1"
                                                },
                                                new Product
                                                {
                                                    Id = 2,
                                                    Name = "Product 2"
                                                },
                                                new Product
                                                {
                                                    Id = 3,
                                                    Name = "Product 3"
                                                },
                                                new Product
                                                {
                                                    Id = 4,
                                                    Name = "Product 4"
                                                }
                                            );

            modelBuilder.Entity<Retailer>()
                                            .HasData(
                                                new Retailer
                                                {
                                                    Id = 1,
                                                    Name = "Vanzator 1"
                                                },
                                                new Retailer
                                                {
                                                    Id = 2,
                                                    Name = "Vanzator 2"
                                                },
                                                new Retailer
                                                {
                                                    Id = 3,
                                                    Name = "Vanzator 3"
                                                },
                                                new Retailer
                                                {
                                                    Id = 4,
                                                    Name = "Vanzator 4"
                                                }
                                            );

            base.OnModelCreating(modelBuilder);
        }



        public DbSet<Product> Products { get; set; }
        public DbSet<Retailer> Retailers { get; set; }

        public DbSet<Remuneration> Remunerations { get; set; }

    }
}
