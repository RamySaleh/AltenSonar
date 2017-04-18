using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AltenSonar.Core.Entities;
using AltenSonar.Core.Interfaces;

namespace AltenSonar.Infrastructure
{
    public class FakeCustomersRepo : ICustomersRepo
    {
        public List<Customer> GetCustomers()
        {
            return GetCustomersList();
        }

        private List<Customer> GetCustomersList()
        {
            var customers = new List<Customer>();

            var customer1 = new Customer
            {
                id = "Customer1",
                Name = "Kalles Grustransporter AB",
                Address = "Cementvägen 8, 111 11 Södertälje",
                OwnedVehicles = new List<Vehicle>
                {
                    new Vehicle
                    {
                        id = "YS2R4X20005399401",
                        RegisterationNumber = "ABC123"
                    },
                     new Vehicle
                    {
                        id = "VLUR4X20009093588",
                        RegisterationNumber = "DEF456"
                    },
                       new Vehicle
                    {
                        id = "VLUR4X20009048066",
                        RegisterationNumber = "GHI789"
                    }
                }
            };

            var customer2 = new Customer
            {
                id = "Customer2",
                Name = "Johans Bulk AB",
                Address = "Balkvägen 12, 222 22 Stockholm",
                OwnedVehicles = new List<Vehicle>
                {
                    new Vehicle
                    {
                        id = "YS2R4X20005388011",
                        RegisterationNumber = "JKL012"
                    },
                     new Vehicle
                    {
                        id = "YS2R4X20005387949",
                        RegisterationNumber = "MNO345"
                    }
                }
            };

            var customer3 = new Customer
            {
                id = "Customer3",
                Name = "Haralds Värdetransporter AB",
                Address = "Budgetvägen 1, 333 33 Uppsala",
                OwnedVehicles = new List<Vehicle>
                {
                    new Vehicle
                    {
                        id = "YS2R4X20005387765",
                        RegisterationNumber = "PQR678"
                    },
                     new Vehicle
                    {
                        id = "YS2R4X20005387055",
                        RegisterationNumber = "STU901"
                    }
                }
            };

            customers.AddRange(new Customer[] { customer1, customer2, customer3 });

            return customers;
        }
    }
}
