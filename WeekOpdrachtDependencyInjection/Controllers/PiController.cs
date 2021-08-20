using Microsoft.AspNetCore.Mvc;
using WeekOpdrachtDependencyInjection.Business;
using WeekOpdrachtDependencyInjection.Business.Interfaces;

namespace WeekOpdrachtDependencyInjection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PiController : ControllerBase
    {
        private readonly ICalculatePiService calculatePiService;

        public PiController(ICalculatePiService calculatePiService)
        {
            this.calculatePiService = calculatePiService;
        }

        [HttpGet]
        [Route("add/{number}")]
        public IActionResult Add(int number)
        {
            var result = calculatePiService.Add(number);
            return Ok(result);
        }

        [HttpGet]
        [Route("minus/{number}")]
        public IActionResult Minus(int number)
        {
            var result = calculatePiService.Minus(number);
            return Ok(result);
        }
    }
}
