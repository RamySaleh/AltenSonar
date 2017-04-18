using AltenSonar.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AltenSonar.Core.Entities;

namespace AltenSonar.Infrastructure.ConnectionCheckers
{
    public class FakeConnectionChecker : IConnectionChecker
    {
        Random rnd;
        public List<Customer> CheckVehiclesConnection(List<Customer> customers)
        {
            rnd = new Random();

            foreach (var vehicle in customers.SelectMany(customer => customer.OwnedVehicles))
            {
                vehicle.Status = CheckConnection(vehicle);                
            }

            return customers;
        }

        private bool CheckConnection(Vehicle vehicle)
        {            
            var randomNumber = rnd.Next(1, 100);
            var randomStatus = (randomNumber % 2) == 0;

            return randomStatus;
        }
    }
}
