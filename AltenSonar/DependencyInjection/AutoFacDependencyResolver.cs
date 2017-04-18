using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using AltenSonar.Infrastructure.Repos;
using AltenSonar.Core.Interfaces;

namespace AltenSonar.DependencyInjection
{
    public class AutoFacDependencyResolver
    {
        private static IContainer iocContainer;
        public static IContainer IocContainer { get {
                if (iocContainer == null)
                {
                    createContainer();
                }
                return iocContainer;
            } }

        private static void createContainer()
        {
            var builder = new ContainerBuilder();
            builder.Register(c => new DocumentDBCustomersRepo()).As<ICustomersRepo>().SingleInstance();
            iocContainer = builder.Build();
        }
    }
}