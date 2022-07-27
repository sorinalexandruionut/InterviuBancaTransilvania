using MarketingBtrl.DAL.Entities;
using MarketingBtrl.DAL.Repositories.Interfaces;

namespace MarketingBtrl.DAL.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
