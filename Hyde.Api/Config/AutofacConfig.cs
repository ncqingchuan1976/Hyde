using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac.Builder;
using Autofac;
using Autofac.Integration.WebApi;
using Hyde.Repository;
using Hyde.Context;
using System.Reflection;
using System.Web.Http;
using System.Net.Http;
using Hyde.Api.Services;
namespace Hyde.Api.Config
{
    public class AutofacConfig
    {
        public static void AutofacRegsiter(HttpConfiguration Config)
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<HydeContext>().As<System.Data.Entity.DbContext>().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            InitService(builder);

            var container = builder.Build();

            Config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void InitService(ContainerBuilder builder)
        {
            builder.RegisterType<SupplyService>().As<ISupplyService>();
        }
    }
}