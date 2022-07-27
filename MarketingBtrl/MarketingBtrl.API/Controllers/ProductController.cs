using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MarketingBtrl.Services.Interfaces;

namespace MarketingBtrl.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RetailerController : ControllerBase
    {
        private IRetailerService _retailerService;

        public RetailerController(IRetailerService retailerService)
        {
            _retailerService = retailerService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var retailer = await _retailerService.GetAllAsync();
            if (retailer == null)
                return NotFound();

            return Ok(retailer);
        }
       
    }
}
