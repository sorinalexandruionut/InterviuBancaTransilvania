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
using Microsoft.Data.SqlClient;

namespace MarketingBtrl.Services
{
    public class RemunerationService : BaseService, IRemunerationService
    {
        private IRepositoryWrapper _repositoryWrapper;
        private IConfiguration _configuration;

       public RemunerationService(IRepositoryWrapper repoWrapper, IConfiguration config) : base(repoWrapper)
        {
            _repositoryWrapper = repoWrapper;
            _configuration = config;
        }

        public async  Task<List<RemunerationDto>> GetAll()
        {
            var remunerations = await this._repositoryWrapper.RemunerationRepository.FindAll()
                                                                                .Include(x => x.Product)
                                                                                .Include(x => x.Retailer)
                                                                                .ToListAsync();


            return MapperHelper.MapFrom<List<RemunerationDto>>(remunerations);

        }

        public RemunerationDto Save(RemunerationEditDto remunerationEditDto)
        {
            if(remunerationEditDto.Id == null)
            {
                Remuneration newRem = MapperHelper.MapFrom<Remuneration>(remunerationEditDto);

                _repositoryWrapper.RemunerationRepository.Create(newRem);

                _repositoryWrapper.Save();

                return MapperHelper.MapFrom<RemunerationDto>(newRem);
            }
            else
            {
                var remuneration = _repositoryWrapper.RemunerationRepository.FindByCondition(x => x.Id == remunerationEditDto.Id);

                if (remuneration == null)
                    return null;

                Remuneration updateRem = MapperHelper.MapFrom<Remuneration>(remunerationEditDto);


                _repositoryWrapper.RemunerationRepository.Update(updateRem);

                _repositoryWrapper.Save();

                return MapperHelper.MapFrom<RemunerationDto>(updateRem);

            }
        }

        public async Task<int[][]> GetRemunerationsPivotAsync(int year, int month)
        {
            List<RemunerationPivotDto> results = await _repositoryWrapper.RepositoryContext.Remunerations.Where(x => x.Month == month && x.Year == year).GroupBy(x => new { x.ProductId, x.RetailerId }, (key, g) => new RemunerationPivotDto { RetailerId = key.RetailerId, ProdictId = key.ProductId, ProductsNr = g.Count() }).ToListAsync();

            List<Product> products = await _repositoryWrapper.RepositoryContext.Products.Distinct().ToListAsync();

            List<Retailer> retailers = await _repositoryWrapper.RepositoryContext.Retailers.Distinct().ToListAsync();

            int[][] res = new int[retailers.Count][];

            int i = 0, j = 0;

            foreach(var r in retailers)
            {

                res[i] = new int[products.Count];

                foreach(var p in products)
                {
                    var pivot = results.FirstOrDefault(x => x.ProdictId == p.Id && x.RetailerId == r.Id);
                    res[i][j] = pivot == null ? 0 : pivot.ProductsNr;
                    j++;
                }

                i++;
                j = 0;
            }

            return res;

        }


        public async Task<List<RemunerationStatisticModel>> GetStatistics (int month, int year)
        {

            var query = (from r in _repositoryWrapper.RepositoryContext.Remunerations
                                 group r by new { r.Year, r.Month, r.ProductId, r.RetailerId } into g
                                 select new
                                 {
                                     Year = g.Key.Year,
                                     Month = g.Key.Month,
                                     g.Key.ProductId,
                                     g.Key.RetailerId,
                                     ProductsNr = g.Count()
                                 });

            var results = await (from r in query
                          join s in _repositoryWrapper.RepositoryContext.Retailers on r.RetailerId equals s.Id
                          join p in _repositoryWrapper.RepositoryContext.Products on r.ProductId equals p.Id
                          select new RemunerationStatisticModel
                          {
                              Year = r.Year,
                              Month = r.Month,
                              Product = p.Name,
                              Retailer = s.Name,
                              ProductsNr = r.ProductsNr
                          }).ToListAsync();



            return results;


        }
       
    }
}
