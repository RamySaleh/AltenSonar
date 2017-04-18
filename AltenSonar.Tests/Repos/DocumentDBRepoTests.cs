using AltenSonar.Infrastructure.Repos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltenSonar.Tests.Repos
{
    [TestClass]
    public class DocumentDBRepoTests
    {
        [TestMethod]
        public void DocumentDBCustomersRepoShouldReturnThreeCustomers()
        {
            var fakeCustomersRepo = new DocumentDBCustomersRepo();

            var customers = fakeCustomersRepo.GetCustomers();

            var customersListHasThreeCustomers = customers.Count == 3;

            Assert.IsTrue(customersListHasThreeCustomers);
        }

        [TestMethod]
        public void DocumentDBCustomersRepoShouldReturnCustomersAndTheirOwnedVehicles()
        {
            var fakeCustomersRepo = new DocumentDBCustomersRepo();

            var customers = fakeCustomersRepo.GetCustomers();

            var allCustomersHaveVehicles = customers.All(customer => customer.OwnedVehicles.Count > 0);

            Assert.IsTrue(customers.Count > 0 && allCustomersHaveVehicles);
        }
    }
}
