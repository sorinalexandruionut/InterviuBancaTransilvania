using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarketingBtrl.Services.Interfaces;
using MarketingBtrl.Services.Mappings;
using Microsoft.Extensions.Configuration;

using MarketingBtrl.DAL.Repositories.Interfaces;
using MarketingBtrl.Services;
using MarketingBtrl.Services.Dtos;
using MarketingBtrl.DAL.Entities;
using System.Linq;
using MarketingBtrl.Services.Models;

namespace MarketingBtrl.Services
{
    public class ProductService : BaseService, IProductService
    {
        private IRepositoryWrapper _repositoryWrapper;


        public ProductService(IRepositoryWrapper repoWrapper) : base(repoWrapper)
        {
            _repositoryWrapper = repoWrapper;
        }

        public async Task<List<ItemModel>> GetAllAsync()
        {
            var products = await this._repositoryWrapper.ProductRepository.FindAll()
                                                                            .Select(x => new ItemModel { Value = x.Id, Label = x.Name})
                                                                                .ToListAsync();


            return products;

        }

    }
}
