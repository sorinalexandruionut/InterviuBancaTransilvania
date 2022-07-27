using MarketingBtrl.DAL.Entities;
using MarketingBtrl.DAL.Repositories;
using MarketingBtrl.DAL.Repositories.Interfaces;


namespace MarketingBtrl.Tests.FakeRepositories
{
    public class ProductRepositoryFake : RepositoryBaseFake<Product>, IProductRepository
    {
        public ProductRepositoryFake(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
