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

    public class ChairControllerTests
    {
        [Fact]
        public async Task GetChairsTest()
        {
            // arrange
            var mockChairService = new Mock<IChairService>();
            mockChairService.Setup(service => service.GetChairs()).ReturnsAsync(new List<Chair>{ new() });
            var controller = new ChairController(mockChairService.Object);

            // act
            var result = await controller.GetChairs();

            // assert
            var okResult = Assert.IsAssignableFrom<ActionResult<List<Chair>>>(result);
            var chairs = Assert.IsType<List<Chair>>(okResult.Value);
            Assert.Single(chairs);
        }

        [Fact]
        public async Task GetChairTest()
        {
            // arrange
            var chairId = "1";
            var mockChairService = new Mock<IChairService>();
            mockChairService.Setup(service => service.GetChair(chairId)).ReturnsAsync(new Chair { ChairId = chairId });
            var controller = new ChairController(mockChairService.Object);

            // act
            var result = await controller.GetChair(chairId);

            // assert
            var okResult = Assert.IsAssignableFrom<ActionResult<Chair>>(result);
            var chair = Assert.IsType<Chair>(okResult.Value);
            Assert.Equal(chairId, chair.ChairId);
        }

        [Fact]
        public async Task PostChairTest()
        {
            // arrange
            var chair = new Chair { ChairId = "1" };
            var mockChairService = new Mock<IChairService>();
            mockChairService.Setup(service => service.CreateChair(chair)).ReturnsAsync("1");
            var controller = new ChairController(mockChairService.Object);

            // act
            var result = await controller.PostChair(chair);

            // assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            var createdChair = Assert.IsType<Chair>(createdAtActionResult.Value);
            Assert.Equal(chair.ChairId, createdChair.ChairId);
        }

        [Fact]
        public async Task PutChairTest()
        {
            // arrange
            var chairId = "1";
            var chair = new Chair { ChairId = chairId };
            var mockChairService = new Mock<IChairService>();
            mockChairService.Setup(service => service.UpdateChair(chairId, chair)).ReturnsAsync(true);
            var controller = new ChairController(mockChairService.Object);

            // act
            var result = await controller.PutChair(chairId, chair);

            // assert
            var noContentResult = Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteChairTest()
        {
            // arrange
            var chairId = "1";
            var mockChairService = new Mock<IChairService>();
            mockChairService.Setup(service => service.DeleteChair(chairId)).ReturnsAsync(true);
            var controller = new ChairController(mockChairService.Object);

            // act
            var result = await controller.DeleteChair(chairId);

            // assert
            var noContentResult = Assert.IsType<NoContentResult>(result);
        }
    }
}
