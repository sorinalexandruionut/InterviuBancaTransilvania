using MarketingBtrl.DAL.Entities;
using MarketingBtrl.DAL.Repositories;
using MarketingBtrl.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;


namespace MarketingBtrl.Tests.FakeRepositories
{
    public class RemunerationRepositoryFake : RepositoryBaseFake<Remuneration>, IRemunerationRepository
    {
        public RemunerationRepositoryFake(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
