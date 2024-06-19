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

    public class PatientControllerTests
    {
        [Fact]
        public async Task GetPatientsTest()
        {
            // arrange
            var mockPatientService = new Mock<IPatientService>();
            mockPatientService.Setup(service => service.GetPatients()).ReturnsAsync(new List<Patient>{ new() });
            var controller = new PatientController(mockPatientService.Object);

            // act
            var result = await controller.GetPatients();

            // assert
            var okResult = Assert.IsAssignableFrom<ActionResult<List<Patient>>>(result);
            var patients = Assert.IsType<List<Patient>>(okResult.Value);
            Assert.Single(patients);
        }
    }
}
