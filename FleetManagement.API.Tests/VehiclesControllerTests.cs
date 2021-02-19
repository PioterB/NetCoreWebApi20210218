using System;
using FleetManagement.Vehicles;
using FleetManagement.Vehicles.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace FleetManagement.API.Tests
{
    public class VehiclesControllerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void VerifyGetGivesItemForCorrectId()
        {
            var repo = new Mock<IVehiclesRepository>();
            var service = new Mock<IVehiclesService>();
            var id = Guid.NewGuid();

            repo.Setup(s => s.Get(id)).Returns(new Vehicle(id, "some name", 123));

            var controller = new VehiclesController(repo.Object, service.Object);

            var response = controller.Get(id);

            Assert.IsNotNull(response.Value);
            Assert.IsInstanceOf<OkObjectResult>(response);
            Assert.IsInstanceOf<VehicleModel>(response.Value);
        }

        [Test]
        public void VerifyGetGivesNotFoundForBadId()
        {
            var repo = new Mock<IVehiclesRepository>();
            var service = new Mock<IVehiclesService>();
            var id = Guid.NewGuid();

            repo.Setup(s => s.Get(id)).Returns((Vehicle)null);

            var controller = new VehiclesController(repo.Object, service.Object);

            var response = controller.Get(id);

            Assert.IsNotNull(response.Value);
            Assert.IsInstanceOf<MissingItemModel>(response.Value);
        }
    }
}