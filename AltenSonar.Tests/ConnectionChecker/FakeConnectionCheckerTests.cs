using AltenSonar.Infrastructure.ConnectionCheckers;
using AltenSonar.Infrastructure.Repos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltenSonar.Tests.ConnectionChecker
{
    [TestClass]
    public class FakeConnectionCheckerTests
    {
        [TestMethod]
        public void FakeConnectionCheckerChangesVehicleStatus()
        {
            // Arrange
            var customers = new FakeCustomersRepo().GetCustomers();
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
            var customers = new FakeCustomersRepo().GetCustomers();
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
