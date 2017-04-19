using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AltenSonar.Infrastructure.Repos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AltenSonar.Core.Interfaces;
using AltenSonar.Core.Entities;
using System.IO;

namespace AltenSonar.Tests.Repos
{
    [TestClass]
    public class FakeCustomersRepoTests
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
        public void FakeCustomersRepoShouldReturnThreeCustomers()
        {
            // Act
            var customers = customersRepo.GetCustomers();

            // Assert
            var customersListHasThreeCustomers = customers.Count == 3;
            Assert.IsTrue(customersListHasThreeCustomers);
        }

        [TestMethod]
        public void FakeCustomersRepoShouldReturnCustomersAndTheirOwnedVehicles()
        {
            // Act
            var customers = customersRepo.GetCustomers();

            // Assert
            var allCustomersHaveVehicles = customers.All(customer => customer.OwnedVehicles.Count > 0);
            Assert.IsTrue(customers.Count > 0 && allCustomersHaveVehicles);
        }
    }
}
