using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using TTDL_Backend.Models;
using TTDL_Backend.Services;

namespace TTDL_Backend.Controllers
{
    /// <summary>
    /// The route for all measurement actions
    /// </summary>
    [ApiController]
    [Route("api/measurements")]
    public class MeasurementController : ControllerBase
    {
        private readonly IMeasurementservice _measurementService;

        public MeasurementController(IMeasurementservice measurementservice)
        {
            _measurementService = measurementservice;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("get")]
        public IActionResult GetMeasurement()
        {
            return Ok();
        }

        [HttpPost("register")]
        public IActionResult registerMeasurement()
        {
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult deleteMeasurement()
        {
            return Ok();
        }
    }

}

