using Microsoft.AspNetCore.Mvc;
using WeekOpdrachtDependencyInjection.Core.Entities;

namespace WeekOpdrachtDependencyInjection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdController : ControllerBase
    {
        [HttpGet]
        [Route("duck")]
        public IActionResult Duck()
        {
            var sound = new Duck().Sound();
            return Ok(sound);
        }

        [HttpGet]
        [Route("goose")]
        public IActionResult Goose()
        {
            var sound = new Goose().Sound();
            return Ok(sound);
        }

        [HttpGet]
        [Route("chicken")]
        public IActionResult Chicken()
        {
            var sound = new Chicken().Sound();
            return Ok(sound);
        }
    }
}
