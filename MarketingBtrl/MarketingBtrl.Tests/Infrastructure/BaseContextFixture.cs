using MarketingBtrl.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarketingBtrl.Dal.Repositories;

namespace MarketingBtrl.Tests.Infrastructure
{
    public abstract class BaseContextFixture : IDisposable
    {
        protected RepositoryContext _context;
        protected RepositoryWrapperFake _repositoryWrapperFake;

        public BaseContextFixture()
        {
            _context = CreateContext();
            _repositoryWrapperFake = new RepositoryWrapperFake(_context);
            GenerateFakeData();
        }

        private RepositoryContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<RepositoryContext>()
                              .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                              .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                              .UseInMemoryDatabase(Guid.NewGuid().ToString())
                              .Options;

            var _configuration = new Mock<IConfiguration>();
            _configuration.SetupGet(x => x[It.Is<string>(s => s == "ConnectionString")]).Returns("mock value");

            var context = new RepositoryFake(options, _configuration.Object);
            // context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            return context;
        }

        public abstract void GenerateFakeData();

        public RepositoryWrapperFake RepositoryContext => new RepositoryWrapperFake(_context);

        public void Dispose()
        {
            foreach (var entry in _context.ChangeTracker.Entries().ToList())
            {
                _context.Entry(entry.Entity).State = EntityState.Detached;
            }
            _context.Dispose();
        }
    }
}
