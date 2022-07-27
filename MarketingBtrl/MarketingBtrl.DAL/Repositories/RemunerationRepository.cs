using MarketingBtrl.DAL.Entities;
using MarketingBtrl.DAL.Repositories.Interfaces;

namespace MarketingBtrl.DAL.Repositories
{
    public class RemunerationRepository : RepositoryBase<Remuneration>, IRemunerationRepository
    {
        public RemunerationRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
