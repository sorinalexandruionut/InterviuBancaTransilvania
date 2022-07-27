using MarketingBtrl.DAL.Entities;
using MarketingBtrl.DAL.Repositories.Interfaces;

namespace MarketingBtrl.DAL.Repositories
{
    public class RetailerRepository : RepositoryBase<Retailer>, IRetailerRepository
    {
        public RetailerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
