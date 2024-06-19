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
    }
}