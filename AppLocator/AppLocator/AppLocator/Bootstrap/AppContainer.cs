using AppLocator.Interfaces.Repository;
using AppLocator.Interfaces.Services;
using AppLocator.Interfaces.Services.Data;
using AppLocator.Interfaces.Utilities;
using AppLocator.Models.ViewModels;
using AppLocator.Repository;
using AppLocator.Services.Data;
using AppLocator.Utility;
using Autofac;
using System;

namespace AppLocator.Bootstrap
{
    public class AppContainer
    {
        private static IContainer container;

        public static void RegisterDependenies()
        {
            var builder = new ContainerBuilder();

            //ViewModels
            builder.RegisterType<StoreView>();
            builder.RegisterType<StoresView>();
            builder.RegisterType<StoreListViewModel>();

            //Services
            builder.RegisterType<SettingsService>().As<ISettingsService>();
            builder.RegisterType<StoreService>().As<IStoreService>();

            //Repositories
            builder.RegisterType<GenericRepository>().As<IGenericRepository>();

            //Utilities
            builder.RegisterType<GeoLocator>().As<IGeoLocator>();

            container = builder.Build();
        }

        public static object Resolve(Type typeName)
        {
            return container.Resolve(typeName);
        }

        public static T Resolve<T>()
        {
            return container.Resolve<T>();
        }
    }
}
