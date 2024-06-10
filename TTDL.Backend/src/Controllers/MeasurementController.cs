using System.Text.Json;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using TTDL_Backend.Models;
using TTDL_Backend.Services;

namespace TTDL_Backend.Controllers
{
    [ApiController]
    [Route("api/measurements")]
    public class MeasurementController : ControllerBase
    {
        private readonly IMeasurementservice _measurementService;

        public MeasurementController(IMeasurementservice measurementservice)
        {
            _measurementService = measurementservice;
        }

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

