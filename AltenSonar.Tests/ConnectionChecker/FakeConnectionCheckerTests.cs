using AltenSonar.Core.Entities;
using AltenSonar.Core.Interfaces;
using AltenSonar.Infrastructure.ConnectionCheckers;
using AltenSonar.Infrastructure.Repos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltenSonar.Tests.ConnectionChecker
{
    [TestClass]
    public class FakeConnectionCheckerTests
    {
        private static ICustomersRepo customersRepo;

        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
            // Arrange
            var sampleDocuments = File.ReadAllText(@"..\..\SampleDocuments.json");
            var fakeCustomersList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Customer>>(sampleDocuments);
            var customersRepoMoq = new Mock<ICustomersRepo>();
            customersRepoMoq.Setup(x => x.GetCustomers()).Returns(() => fakeCustomersList);
            customersRepo = customersRepoMoq.Object;
        }

        [TestMethod]
        public void FakeConnectionCheckerChangesVehicleStatus()
        {
            // Arrange
            var customers = customersRepo.GetCustomers();
            var connectionChecker = new FakeConnectionChecker();

            // Act
            connectionChecker.CheckVehiclesConnection(customers);

            // Assert
            // Check if any connection status is changed
            var statusChanged = customers.SelectMany(customer => customer.OwnedVehicles).Any(vehicle => vehicle.Status);

            Assert.IsNotNull(statusChanged);
        }

        [TestMethod]
        public void FakeConnectionCheckerReturnsRandomVehicleStatus()
        {
            // Arrange
            var customers = customersRepo.GetCustomers();
            var connectionChecker = new FakeConnectionChecker();

            // Act
            connectionChecker.CheckVehiclesConnection(customers);
            var firstCheckStatus = customers.First().OwnedVehicles.First().Status;

            System.Threading.Thread.Sleep(100);

            connectionChecker.CheckVehiclesConnection(customers);
            var secondCheckStatus = customers.First().OwnedVehicles.First().Status;

            System.Threading.Thread.Sleep(100);

            connectionChecker.CheckVehiclesConnection(customers);
            var thirdCheckStatus = customers.First().OwnedVehicles.First().Status;

            // Assert
            // Check if the connection status is changed between 3 attempts
            Assert.IsTrue(firstCheckStatus != secondCheckStatus || secondCheckStatus != thirdCheckStatus || firstCheckStatus != thirdCheckStatus);
        }
    }
}
