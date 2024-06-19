using Moq;
using Microsoft.AspNetCore.Mvc;

namespace TTDL.Backend.Tests
{
    using TTDL_Backend.Models;
    using TTDL_Backend.Services;
    using TTDL_Backend.Controllers;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;

    public class MeasurementControllerTests
    {
        [Fact]
        public async Task GetMeasurementsTest()
        {
            // arrange
            var mockMeasurementService = new Mock<IMeasurementService>();
            mockMeasurementService.Setup(service => service.GetMeasurements()).ReturnsAsync(new List<Measurement>{ new() });
            var controller = new MeasurementController(mockMeasurementService.Object);

            // act
            var result = await controller.GetMeasurements();

            // assert
            var okResult = Assert.IsAssignableFrom<ActionResult<List<Measurement>>>(result);
            var measurements = Assert.IsType<List<Measurement>>(okResult.Value);
            Assert.Single(measurements);
        }
    }
}
