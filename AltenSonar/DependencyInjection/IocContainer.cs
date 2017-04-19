using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AltenSonar.Infrastructure.Repos;
using AltenSonar.Core.Interfaces;
using AltenSonar.Infrastructure.ConnectionCheckers;
using AltenSonar.Infrastructure.DependencyInjection;

namespace AltenSonar.DependencyInjection
{
    public class IocContainer
    {      
        static IDependencyResolver dependencyResolver;

        public static void RegisterDependencies()
        {
            if (dependencyResolver == null)
            {
                dependencyResolver = new AutofacDependencyResolver();
            }
            dependencyResolver.RegisterDependency<ICustomersRepo>(typeof(DocumentDBCustomersRepo));
            dependencyResolver.RegisterDependency<IConnectionChecker>(typeof(FakeConnectionChecker));
        }

        public static T Resolve<T>()
        {
            return dependencyResolver.ResolveDependency<T>();
        }
    }
}