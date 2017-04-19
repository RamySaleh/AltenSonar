using AltenSonar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AltenSonar.DependencyInjection;
using AltenSonar.Core.Interfaces;

namespace AltenSonar.WebApi
{
    public class ConnectionCheckerController : ApiController
    {
        [HttpPost]
        public List<Customer> CheckConnectionStatus(List<Customer> customers)
        {
            var connectionChecker = IocContainer.Resolve<IConnectionChecker>();

            customers = connectionChecker.CheckVehiclesConnection(customers);

            return customers;
        }
    }
}
