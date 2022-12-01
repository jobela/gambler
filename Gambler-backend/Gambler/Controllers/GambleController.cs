namespace Gambler.PoC.Controllers
{
    using Gambler.PoC.Models;
    using Gambler.PoC.Services;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class GambleController : ControllerBase
    {
        private readonly IGamblerService _service;
        private readonly ILogger<GambleController> _logger;

        public GambleController(ILogger<GambleController> logger, IGamblerService service)
        {
            _service = service;
            _logger = logger;
        }

        // You bet'cha
        [HttpPost("Bet")]
        public async Task<ActionResult<Score>> Bet(Guid id, int value)
        {
            try
            {
                var score = _service.Bet(id, value);
                return Ok(score);
            } 
            catch (ThrottlingException texmex)
            {
                return StatusCode(429, texmex.Message);
            }
        }

        // Now no one can use the lottery function! 1337 haXx0r
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPost("Lottery")]
        public async Task<ActionResult<Score>> Lottery(Guid id)
        {
            var score = _service.Lottery(id);

            return Ok(score);
        }
    }
}
