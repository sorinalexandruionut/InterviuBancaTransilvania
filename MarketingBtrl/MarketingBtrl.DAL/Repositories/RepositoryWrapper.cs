using MarketingBtrl.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketingBtrl.DAL.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IRemunerationRepository _remunerationRepository;
        private IProductRepository _productRepository;
        private IRetailerRepository _retailerRepository;

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }

        public void Detach<T>(T obj) where T : class
        {
            _repoContext.Entry<T>(obj).State = EntityState.Detached;
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
                    _remunerationRepository = new RemunerationRepository(_repoContext);
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
                    _productRepository = new ProductRepository(_repoContext);
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
                    _retailerRepository = new RetailerRepository(_repoContext);
                }

                return _retailerRepository;
            }
        }


    }
}
