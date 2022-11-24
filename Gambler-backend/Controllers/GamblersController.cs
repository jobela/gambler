namespace Gambler.PoC.Controllers
{
    using Gambler.PoC.Services;
    using Gambler.PoC.Business.Entities;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class GamblersController : ControllerBase
    {
        private readonly IGamblerService _service;
        private readonly ILogger<GamblersController> _logger;

        public GamblersController(ILogger<GamblersController> logger, IGamblerService service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("GetTop10")]
        public async Task<ActionResult<IEnumerable<Gambler>>> GetTopList()
        {
            var toplist = _service.GetTop10Gamblers();
            return Ok(toplist);
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<ActionResult<Gambler>> Register([FromBody] Gambler gambler)
        {
            _service.Register(gambler);
            return Ok(gambler);
        }

        [HttpGet("Score")]
        public async Task<ActionResult<int>> Score(int id)
        {
            var score = _service.Score(id);
            return Ok(score);
        }
    }
}
