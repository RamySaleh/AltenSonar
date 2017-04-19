using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AltenSonar.Core.Interfaces
{
    public interface IDependencyResolver
    {
        void RegisterDependency<T>(Type dependency);

        T ResolveDependency<T>();
    }
}
