using System;
using System.Collections.Generic;
using System.Text;
using MarketingBtrl.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MarketingBtrl.Dal.Repositories;

namespace MarketingBtrl.Tests
{
    public class RepositoryFake : RepositoryContext
    {
        public RepositoryFake(DbContextOptions options, IConfiguration config) : base(options, config)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
