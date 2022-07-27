using MarketingBtrl.DAL.Repositories;
using MarketingBtrl.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Linq;
using MarketingBtrl.Tests.FakeRepositories;

namespace MarketingBtrl.Tests
{
    public class RepositoryWrapperFake : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IRemunerationRepository _remunerationRepository;
        private IProductRepository _productRepository;
        private IRetailerRepository _retailerRepository;


        public RepositoryWrapperFake(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public RepositoryContext RepositoryContext
        {
            get
            {
                return _repoContext;
            }
        }

        public IRemunerationRepository RemunerationRepository
        {
            get
            {
                if (_remunerationRepository == null)
                {
                    _remunerationRepository = new RemunerationRepositoryFake(_repoContext);
                }

                return _remunerationRepository;
            }
        }

        public IProductRepository ProductRepository
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new ProductRepositoryFake(_repoContext);
                }

                return _productRepository;
            }
        }

        public IRetailerRepository RetailerRepository
        {
            get
            {
                if (_retailerRepository == null)
                {
                    _retailerRepository = new RetailerRepositoryFake(_repoContext);
                }

                return _retailerRepository;
            }
        }

        public void Detach<T>(T obj) where T : class
        {
            _repoContext.Entry<T>(obj).State = EntityState.Detached;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
            foreach (var entry in _repoContext.ChangeTracker.Entries().ToList())
            {
                _repoContext.Entry(entry.Entity).State = EntityState.Detached;
            }
        }
    }
}
