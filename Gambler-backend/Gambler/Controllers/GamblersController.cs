namespace Gambler.PoC.Controllers
{
    using Gambler.PoC.Services;
    using Gambler.PoC.Business.Entities;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Gambler.PoC.Models;
    using Microsoft.AspNetCore.Cors;

    [Route("api/[controller]")]
    [ApiController]
    public class GamblersController : ControllerBase
    {
        private readonly IGamblerService _service;
        private readonly IAuthService _auth;
        private readonly ILogger<GamblersController> _logger;

        public GamblersController(ILogger<GamblersController> logger, IGamblerService service, IAuthService auth)
        {
            _service = service;
            _auth = auth;
            _logger = logger;
        }

        //[DisableCors]
        [HttpGet("GetTop10")]
        public async Task<ActionResult<IEnumerable<Score>>> GetTopList()
        {
            var toplist = _service.GetTop10Gamblers();

            return Ok(toplist);
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> Register(Guid registerKey, string nickname)
        {
            if (!_auth.Verify(registerKey))
                return Unauthorized("Unknown or invalid registerKey");

            var gambler = _service.Register(nickname);

            return Ok(string.Format("Congratulations, your gambler account has been registred. Your unique identity is {0}. Use it while placing bets. You start of with {1} points to gamble with. Make them count!", gambler.UniquieIdentity, gambler.Score));
        }

        [HttpGet("Score")]
        public async Task<ActionResult<Score>> Score(Guid id)
        {
            var score = _service.Score(id);

            return Ok(score);
        }

        [HttpGet("Help")]
        public async Task<ActionResult<string>> Help()
        {
            return Ok("Welcome to Codefellas Gambler API. This is a Gambler service provided to our clients. To register you will need a registerKey. The services is limited to 500 bets pr. day. When you register you will be given 1000 points in free credits.");
        }
    }
}
