using MarketingBtrl.Services.Dtos;
using MarketingBtrl.Services.Interfaces;
using MarketingBtrl.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MarketingBtrl.Services.Interfaces
{
    public interface IRetailerService : IBaseService
    {
        Task<List<ItemModel>> GetAllAsync();
    }
}
