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

        [Fact]
        public async Task GetPatientTest()
        {
            // arrange
            var patientId = "1";
            var mockPatientService = new Mock<IPatientService>();
            mockPatientService.Setup(service => service.GetPatient(patientId)).ReturnsAsync(new Patient { PatientId = patientId });
            var controller = new PatientController(mockPatientService.Object);

            // act
            var result = await controller.GetPatient(patientId);

            // assert
            var okResult = Assert.IsAssignableFrom<ActionResult<Patient>>(result);
            var patient = Assert.IsType<Patient>(okResult.Value);
            Assert.Equal(patientId, patient.PatientId);
        }

        [Fact]
        public async Task PostPatientTest()
        {
            // arrange
            var patient = new Patient { PatientId = "1" };
            var mockPatientService = new Mock<IPatientService>();
            mockPatientService.Setup(service => service.CreatePatient(patient)).ReturnsAsync("1");
            var controller = new PatientController(mockPatientService.Object);

            // act
            var result = await controller.PostPatient(patient);

            // assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            var createdPatient = Assert.IsType<Patient>(createdAtActionResult.Value);
            Assert.Equal(patient.PatientId, createdPatient.PatientId);
        }

        [Fact]
        public async Task PutPatientTest()
        {
            // arrange
            var patientId = "1";
            var patient = new Patient { PatientId = patientId };
            var mockPatientService = new Mock<IPatientService>();
            mockPatientService.Setup(service => service.UpdatePatient(patientId, patient)).ReturnsAsync(true);
            var controller = new PatientController(mockPatientService.Object);

            // act
            var result = await controller.PutPatient(patientId, patient);

            // assert
            var noContentResult = Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeletePatientTest()
        {
            // arrange
            var patientId = "1";
            var mockPatientService = new Mock<IPatientService>();
            mockPatientService.Setup(service => service.DeletePatient(patientId)).ReturnsAsync(true);
            var controller = new PatientController(mockPatientService.Object);

            // act
            var result = await controller.DeletePatient(patientId);

            // assert
            var noContentResult = Assert.IsType<NoContentResult>(result);
        }
    }
}
