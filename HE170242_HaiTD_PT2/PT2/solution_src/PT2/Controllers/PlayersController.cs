using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Slot3_CodeFirst.DTO;
using Slot3_CodeFirst.DTO.Player;
using Slot3_CodeFirst.PlayerServices;

namespace Slot3_CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }
        [HttpPost]
        public async Task<IActionResult> PostPlayerAsync(CreatePlayerRequest playerRequest)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            await _playerService.CreatePlayerAsync(playerRequest);
            return Ok(playerRequest);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayerAsync(int id)
        {
            if (!ModelState.IsValid || id <= 0)
            {
                return BadRequest(ModelState);
            }
            await _playerService.DeletePlayerAsync(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetPlayersAsync([FromQuery]UrlQueryParameters urlQueryParameters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var players = await _playerService.GetAllPlayersAsync(urlQueryParameters);
            return Ok(players);
        }
        [HttpGet("{id}/detail")]
        public async Task<IActionResult> GetPlayersDetailsAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var player = await _playerService.GetPlayerDetailAsync(id);
            return Ok(player);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayerAsync(int id, [FromBody] UpdatePlayerRequest playerRequest)
        {
            if(id <= 0 || playerRequest == null)
            {
                return BadRequest(ModelState);
            }
            await _playerService.UpdatePlayerAsync(id, playerRequest);

            return NoContent();
        }
    }
}
