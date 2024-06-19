using Moq;
using Microsoft.AspNetCore.Mvc;

namespace TTDL.Backend.Tests
{
    using TTDL_Backend.Models;
    using TTDL_Backend.Services;
    using TTDL_Backend.Controllers;
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

        [Fact]
        public async Task GetMeasurementTest()
        {
            // arrange
            var measurementId = 1;
            var mockMeasurementService = new Mock<IMeasurementService>();
            mockMeasurementService.Setup(service => service.GetMeasurement(measurementId)).ReturnsAsync(new Measurement { MeasurementId = measurementId });
            var controller = new MeasurementController(mockMeasurementService.Object);

            // act
            var result = await controller.GetMeasurement(measurementId);

            // assert
            var okResult = Assert.IsAssignableFrom<ActionResult<Measurement>>(result);
            var measurement = Assert.IsType<Measurement>(okResult.Value);
            Assert.Equal(measurementId, measurement.MeasurementId);
        }

        [Fact]
        public async Task PostMeasurementTest()
        {
            // arrange
            var measurement = new Measurement { MeasurementId = 1 };
            var mockMeasurementService = new Mock<IMeasurementService>();
            mockMeasurementService.Setup(service => service.CreateMeasurement(measurement)).ReturnsAsync(1);
            var controller = new MeasurementController(mockMeasurementService.Object);

            // act
            var result = await controller.PostMeasurement(measurement);

            // assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            var createdMeasurement = Assert.IsType<Measurement>(createdAtActionResult.Value);
            Assert.Equal(measurement.MeasurementId, createdMeasurement.MeasurementId);
        }

        [Fact]
        public async Task PutMeasurementTest()
        {
            // arrange
            var measurementId = 1;
            var measurement = new Measurement { MeasurementId = measurementId};
            var mockMeasurementService = new Mock<IMeasurementService>();
            mockMeasurementService.Setup(service => service.UpdateMeasurement(measurementId, measurement)).ReturnsAsync(true);
            var controller = new MeasurementController(mockMeasurementService.Object);

            // act
            var result = await controller.PutMeasurement(measurementId, measurement);

            // assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteMeasurementTest()
        {
            // arrange
            var measurementId = 1;
            var mockMeasurementService = new Mock<IMeasurementService>();
            mockMeasurementService.Setup(service => service.DeleteMeasurement(measurementId)).ReturnsAsync(true);
            var controller = new MeasurementController(mockMeasurementService.Object);

            // act
            var result = await controller.DeleteMeasurement(measurementId);

            // assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
