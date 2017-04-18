using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AltenSonar.Core.Entities;

namespace AltenSonar.Core.Interfaces
{
    public interface ICustomersRepo
    {
        List<Customer> GetCustomers();
    }
}
