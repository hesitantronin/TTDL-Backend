using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TTDL_Backend.Models;
using TTDL_Backend.Services;

namespace TTDL_Backend.Controllers
{

    /// <summary>
    /// The route for all measurement actions
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementController : ControllerBase
    {
        private readonly IMeasurementService _measurementService;

        public MeasurementController(IMeasurementService measurementService)
        {
            _measurementService = measurementService;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Measurement>>> GetMeasurements()
        {
            return await _measurementService.GetMeasurements();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Measurement>> GetMeasurement(int id)
        {
            var measurement = await _measurementService.GetMeasurement(id);
            if (measurement == null)
            {
                return NotFound();
            }
            return measurement;
        }

        [HttpPost]
        public async Task<IActionResult> PostMeasurement(Measurement measurement)
        {
            var id = await _measurementService.CreateMeasurement(measurement);
            return CreatedAtAction("GetMeasurement", new { id }, measurement);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeasurement(int id, Measurement measurement)
        {
            var result = await _measurementService.UpdateMeasurement(id, measurement);
            if (!result)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeasurement(int id)
        {
            var result = await _measurementService.DeleteMeasurement(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
