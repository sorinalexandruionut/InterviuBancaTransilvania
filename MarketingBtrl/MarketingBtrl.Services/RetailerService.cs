using MarketingBtrl.DAL.Repositories.Interfaces;
using MarketingBtrl.Services;
using MarketingBtrl.Services.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketingBtrl.Services.Interfaces;

namespace MarketingBtrl.Services
{
    public class RetailerService : BaseService, IRetailerService
    {
        private IRepositoryWrapper _repositoryWrapper;


        public RetailerService(IRepositoryWrapper repoWrapper) : base(repoWrapper)
        {
            _repositoryWrapper = repoWrapper;
        }

        public async Task<List<ItemModel>> GetAllAsync()
        {
            var retailers = await this._repositoryWrapper.RetailerRepository.FindAll()
                                                                            .Select(x => new ItemModel { Value = x.Id, Label = x.Name})
                                                                            .ToListAsync();

            return retailers;
        }

    }
}
