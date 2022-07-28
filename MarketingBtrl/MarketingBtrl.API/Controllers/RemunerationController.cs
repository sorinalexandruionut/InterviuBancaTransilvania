using MarketingBtrl.Services.Dtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using MarketingBtrl.Services.Interfaces;

namespace MarketingBtrl.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RemunerationController : ControllerBase
    {
        private IRemunerationService _remunerationService;

        public RemunerationController(IRemunerationService remunerationService)
        {
            _remunerationService = remunerationService;
        }

        //[Route("/remunerations")]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var remunerations = await _remunerationService.GetAll();
            if (remunerations == null)
                return NotFound();

            return Ok(remunerations);
        }


        [Route("save")]
        [HttpPost]
        public ActionResult Save([FromBody] RemunerationEditDto remuneration)
        {
            RemunerationDto remunerationDto = _remunerationService.Save(remuneration);

            if (remunerationDto == null)
                return NotFound();

            return Ok(remunerationDto);
        }


        [Route("pivot")]
        [HttpGet]
        public async Task<ActionResult> GetRemunerationsPivotAsync(int year, int month)
        {
            var results = await _remunerationService.GetRemunerationsPivotAsync(year, month);

            return Ok(results);
        }

        [Route("statistics")]
        [HttpGet]
        public async Task<ActionResult> GetStatistics(int year, int month)
        {
            var results = await _remunerationService.GetStatistics(year, month);

            return Ok(results);
        }
    }
}
