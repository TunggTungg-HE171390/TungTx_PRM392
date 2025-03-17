using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PT2.DTO.InstrumentType;
using PT2.InstrumentTypeServices;
using Slot3_CodeFirst.DTO;
using Slot3_CodeFirst.DTO.Player;

namespace PT2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstrumentTypesController : ControllerBase
    {
        private readonly IInstrumentTypeService _instrumentTypeService;

        public InstrumentTypesController(IInstrumentTypeService instrumentTypeService)
        {
            _instrumentTypeService = instrumentTypeService;
        }
        [HttpPost]
        public async Task<IActionResult> PostInstrumentTypeAsync(CreateInstrumentTypeRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _instrumentTypeService.CreateInstrumentTypeAsync(request);
            return Ok(request);
        }

        [HttpGet("{id}/detail")]
        public async Task<IActionResult> GetPlayersDetailsAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var player = await _instrumentTypeService.GetDetailInstrumentTypeAsync(id);
            return Ok(player);
        }

        [HttpGet]
        public async Task<IActionResult> GetInstrumentTypeAsync([FromQuery] UrlQueryParameters urlQueryParameters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var player = await _instrumentTypeService.GetAllInstrumentTypeAsync(urlQueryParameters);
            return Ok(player);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayerAsync(int id, [FromBody] UpdateInstrumentTypeRequest request)
        {
            if (id <= 0 || request == null)
            {
                return BadRequest(ModelState);
            }
            await _instrumentTypeService.UpdateInstrumentTypeAsync(id, request);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstrumentTypeAsync(int id)
        {
            if (!ModelState.IsValid || id <= 0)
            {
                return BadRequest(ModelState);
            }
            await _instrumentTypeService.DeleteInstrumentTypeAsync(id);
            return Ok();
        }
    }
}
