using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AltenSonar.Infrastructure.Repos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AltenSonar.Tests.Repos
{
    [TestClass]
    public class FakeCustomersRepoTests
    {
        [TestMethod]
        public void FakeCustomersRepoShouldReturnThreeCustomers()
        {
            var fakeCustomersRepo = new FakeCustomersRepo();

            var customers = fakeCustomersRepo.GetCustomers();

            var customersListHasThreeCustomers = customers.Count == 3;

            Assert.IsTrue(customersListHasThreeCustomers);
        }

        [TestMethod]
        public void FakeCustomersRepoShouldReturnCustomersAndTheirOwnedVehicles()
        {
            var fakeCustomersRepo = new FakeCustomersRepo();

            var customers = fakeCustomersRepo.GetCustomers();

            var allCustomersHaveVehicles = customers.All(customer => customer.OwnedVehicles.Count > 0);

            Assert.IsTrue(customers.Count > 0 && allCustomersHaveVehicles);
        }
    }
}
