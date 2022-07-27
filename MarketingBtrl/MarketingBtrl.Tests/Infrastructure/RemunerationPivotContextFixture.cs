using MarketingBtrl.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MarketingBtrl.Tests.Infrastructure
{
    public class RemunerationPivotContextFixture : BaseContextFixture
    {
        public RemunerationPivotContextFixture() : base()
        {
        }

        public override void GenerateFakeData()
        {
            

            var p1 = new Product
            {
                Id = 1,
                Name = "Product 1"
            };

            _context.Products.Add(p1);


            var p2 = new Product
            {
                Id = 2,
                Name = "Product 2"
            };

            _context.Products.Add(p2);

            var p3 = new Product
            {
                Id = 3,
                Name = "Product 3"
            };

            _context.Products.Add(p3);

            var p4 = new Product
            {
                Id = 4,
                Name = "Product 4"
            };

            _context.Products.Add(p4);


            _context.SaveChanges();

            var r1 = new Retailer
            {
                Id = 1,
                Name = "Vanzator 1"
            };

            _context.Retailers.Add(r1);



            var r2 = new Retailer
            {
                Id = 2,
                Name = "Vanzator 2"
            };

            _context.Retailers.Add(r2);


            var r3 = new Retailer
            {
                Id = 3,
                Name = "Vanzator 3"
            };

            _context.Retailers.Add(r3);



            var r4 = new Retailer
            {
                Id = 4,
                Name = "Vanzator 4"
            };

            _context.Retailers.Add(r4);


            _context.SaveChanges();

            _context.Remunerations.AddRange(Remunerations);

            _context.SaveChanges();

            foreach (var entry in _context.ChangeTracker.Entries().ToList())
            {
                _context.Entry(entry.Entity).State = EntityState.Detached;
            }

        }

        public void Reset()
        {
            foreach (var a in _context.Remunerations)
            {
                _repositoryWrapperFake.RemunerationRepository.Delete(a);
            }

            foreach (var a in _context.Products)
            {
                _repositoryWrapperFake.ProductRepository.Delete(a);
            }

            foreach (var a in _context.Retailers)
            {
                _repositoryWrapperFake.RetailerRepository.Delete(a);
            }

            _repositoryWrapperFake.Save();

            GenerateFakeData();
        }

        private static List<Remuneration> Remunerations => new List<Remuneration>
            {
                new Remuneration
                {
                    Id = 1,
                    Year = 2020,
                    Month = 3,
                    RetailerId = 1,
                    ProductId = 1
                },
                new Remuneration
                {
                     Id = 2,
                    Year = 2020,
                    Month = 3,
                    RetailerId = 1,
                    ProductId = 2
                },
                new Remuneration
                {
                     Id = 3,
                    Year = 2020,
                    Month = 3,
                    RetailerId = 1,
                    ProductId = 3
                },
                new Remuneration
                {
                     Id = 4,
                    Year = 2020,
                    Month = 3,
                    RetailerId = 1,
                    ProductId = 4
                }

            };

    }
}
