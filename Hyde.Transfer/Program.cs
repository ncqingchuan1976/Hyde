using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hyde.External.Highwave;
using Autofac;
using System.Reflection;
using Hyde.Context;
using Hyde.Repository;
using System.Data.Entity;
using Hyde.Service;
using Hyde.External.Highwave.Models;
using Hyde.Domain.Model;
namespace Hyde.Transfer
{
    class Program
    {
        static void Main(string[] args)
        {
            var dal = GetProvider<IHighwave>();

            var result = dal.GetAccessTocken("hk013", "123").Result;

            string acc = result.entity.access_token;


            var list = dal.GetHighwaveCategory(acc).Result.entity;

            var dal1 = GetProvider<ICategroyService>();

            var list1 = dal1.GetCategoryAsync().Result.entity;


            var query = list.GroupJoin(list1, l => new
            {
                code = l.Category
            },
                r => new
                {
                    code = r.name
                }, (l, r) => new
                {
                    l,
                    r
                }).SelectMany(l => l.r.DefaultIfEmpty(), (l, r) => new { l, r }).Where(t => t.r == null).Select(t => new categoryDto()
                {
                    name = t.l.l.Category

                });

            dal1.AddCategoryAsync(query.ToList()).ContinueWith(t => { Console.WriteLine(t.Result.err_info); });

            Console.WriteLine(result.entity.access_token);

            Console.ReadLine();
        }

        private static T GetProvider<T>()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<HydeContext>().As<DbContext>().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<HighwaveOp>().As<IHighwave>().AsImplementedInterfaces();
            var assemblies = new Assembly[] { typeof(IService).Assembly };
            var baseType = typeof(IService);

            builder.RegisterAssemblyTypes(assemblies).Where(t => baseType.IsAssignableFrom(t) && t != baseType).AsImplementedInterfaces();
            var container = builder.Build();

            return container.Resolve<T>();
        }
    }
}
