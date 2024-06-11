using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TTDL_Backend.Models;
using TTDL_Backend.Services;

namespace TTDL_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChairController : ControllerBase
    {
        private readonly IChairService _chairService;

        public ChairController(IChairService chairService)
        {
            _chairService = chairService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Chair>>> GetChairs()
        {
            return await _chairService.GetChairs();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Chair>> GetChair(string id)
        {
            var chair = await _chairService.GetChair(id);
            if (chair == null)
            {
                return NotFound();
            }
            return chair;
        }

        [HttpPost]
        public async Task<IActionResult> PostChair(Chair chair)
        {
            var id = await _chairService.CreateChair(chair);
            return CreatedAtAction("GetChair", new { id }, chair);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutChair(string id, Chair chair)
        {
            var result = await _chairService.UpdateChair(id, chair);
            if (!result)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChair(string id)
        {
            var result = await _chairService.DeleteChair(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
