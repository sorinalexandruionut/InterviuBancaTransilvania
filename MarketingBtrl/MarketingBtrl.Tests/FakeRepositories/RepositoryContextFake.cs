using MarketingBtrl.DAL.Entities;
using MarketingBtrl.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using System;

namespace MarketingBtrl.Tests
{
    public static class RepositoryContextFake
    {
        private static RepositoryContext _repositoryContext;
    
        private static RepositoryContext GetContextWithData()
        {
            var options = new DbContextOptionsBuilder<RepositoryContext>()
                              .UseInMemoryDatabase(Guid.NewGuid().ToString())
                              .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                              .Options;


            var _configuration = new Mock<IConfiguration>();
            _configuration.SetupGet(x => x[It.Is<string>(s => s == "ConnectionString")]).Returns("mock value");
            _configuration.SetupGet(x => x[It.Is<string>(s => s == "Schema")]).Returns("mock value");


            var context = new RepositoryFake(options, _configuration.Object);


            var p1 = new Product
            {
                Id = 1,
                Name = "Product 1"
            };

            context.Products.Add(p1);


            var p2 = new Product
            {
                Id = 2,
                Name = "Product 2"
            };

            context.Products.Add(p2);

            var p3 = new Product
            {
                Id = 3,
                Name = "Product 3"
            };

            context.Products.Add(p3);

            var p4 = new Product
            {
                Id = 4,
                Name = "Product 4"
            };

            context.Products.Add(p1);


            context.SaveChanges();

            var r1 = new Retailer
            {
                Id = 1,
                Name = "Vanzator 1"
            };

            context.Retailers.Add(r1);



            var r2 = new Retailer
            {
                Id = 2,
                Name = "Vanzator 2"
            };

            context.Retailers.Add(r2);


            var r3 = new Retailer
            {
                Id = 3,
                Name = "Vanzator 3"
            };

            context.Retailers.Add(r3);



            var r4 = new Retailer
            {
                Id = 4,
                Name = "Vanzator 4"
            };

            context.Retailers.Add(r4);


            context.SaveChanges();

           
            return context;
        }

        public static RepositoryContext Context
        {
            get
            {
                if(_repositoryContext == null)
                {
                    _repositoryContext =  GetContextWithData();
                }
                return _repositoryContext;
            }
        }
    }
}
