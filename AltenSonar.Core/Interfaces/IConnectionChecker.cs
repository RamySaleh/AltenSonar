using AltenSonar.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltenSonar.Core.Interfaces
{
    public interface IConnectionChecker
    {
        List<Customer> CheckVehiclesConnection(List<Customer> customers);
    }
}
