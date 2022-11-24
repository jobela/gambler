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

        [HttpPost("Bet")]
        public async Task<ActionResult<Response<GamblerDTO>>> Bet(int id, int value)
        {
            var dto = _service.Bet(id, value);
            return Ok(dto);
        }

        [HttpPost("Lottery")]
        public async Task<ActionResult<int>> Lottery(int id)
        {
            var score = _service.Lottery(id);
            return Ok(score);
        }
    }
}
