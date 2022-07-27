using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MarketingBtrl.Services.Interfaces;

namespace MarketingBtrl.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            if (products == null)
                return NotFound();

            return Ok(products);
        }
       
    }
}
