using MarketingBtrl.Services.Dtos;
using MarketingBtrl.Services.Interfaces;
using MarketingBtrl.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MarketingBtrl.Services.Interfaces
{
    public interface IRemunerationService : IBaseService
    {
        Task<List<RemunerationDto>> GetAll();
        RemunerationDto Save(RemunerationEditDto remunerationEditDto);

        Task<int[][]> GetRemunerationsPivotAsync(int year, int month);

        Task<List<RemunerationStatisticModel>> GetStatistics(int month, int year);
    }
}
