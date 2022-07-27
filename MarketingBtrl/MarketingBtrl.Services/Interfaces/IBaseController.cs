using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MarketingBtrl.Services.Interfaces
{
    public interface IBaseController
    {
        ModelStateDictionary ModelState { get; }
    }
}
