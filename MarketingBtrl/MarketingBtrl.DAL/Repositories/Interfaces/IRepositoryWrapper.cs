using System;
using System.Collections.Generic;
using System.Text;

namespace MarketingBtrl.DAL.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        RepositoryContext RepositoryContext { get; }

        IRemunerationRepository RemunerationRepository { get; }

        IRetailerRepository RetailerRepository { get; }

        IProductRepository ProductRepository { get; }


        void Save();
    }
}
