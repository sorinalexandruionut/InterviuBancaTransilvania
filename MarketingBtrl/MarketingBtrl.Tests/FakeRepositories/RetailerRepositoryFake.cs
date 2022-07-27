using MarketingBtrl.DAL.Entities;
using MarketingBtrl.DAL.Repositories;
using MarketingBtrl.DAL.Repositories.Interfaces;

namespace MarketingBtrl.Tests.FakeRepositories
{
    public class RetailerRepositoryFake : RepositoryBaseFake<Retailer>, IRetailerRepository
    {
        public RetailerRepositoryFake(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
