using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AltenSonar.Controllers;
using System.Web.Mvc;
using AltenSonar.Core.Entities;

namespace AltenSonar.Tests.Controllers
{
    [TestClass]
    public class DashboardControllerTests
    {
        [TestMethod]
        public void DashboardControllerReturnsResult()
        {
            // Arrange
            var controller = new DashboardController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DashboardControllerReturnsModelContainsData()
        {
            // Arrange
            var controller = new DashboardController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            var model = result.Model as List<Customer>;

            // Assert
            Assert.IsTrue(model != null && model.Count > 0);
        }
    }
}
