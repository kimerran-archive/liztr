using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using Liztr.Data.Repository;
using Liztr.Data.Common;
using Liztr.API;

namespace Liztr.App_Start
{
    public static class ServiceConfig
    {
        private static IContainer _container;

        /// <summary>
        /// Configure IOC Container
        /// </summary>
        public static void RegisterServices()
        {
            var builder = new ContainerBuilder();

            // For all MVC Controllers, manage dependencies
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //// API Service
            builder.RegisterType<LiztrCoreApi>().SingleInstance();

            //// Authentication Service
            //builder.RegisterType<CoreAuthService>().As<IAuthService>();

            //// DB Service
            //builder.RegisterType<SqlCoreDbService>().As<IDbService>();

            //// DB Repository
            builder.RegisterType<LiztrDbRepository>().As<IDbRepository>();

            //// DB Context
            builder.RegisterType<LiztrDbContext>().As<IDbContext>();

            _container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(_container));
        }

        /// <summary>
        /// Resolve a certain interface to its configured implementation
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}