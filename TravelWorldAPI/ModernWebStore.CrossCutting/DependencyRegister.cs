﻿using Microsoft.Practices.Unity;
using ModernWebStore.ApplicationService;
using ModernWebStore.Domain.Repositories;
using ModernWebStore.Domain.Services;
using ModernWebStore.Infra.Persistence;
using ModernWebStore.Infra.Persistence.DataContexts;
using ModernWebStore.Infra.Repositories;
using ModernWebStore.SharedKernel;
using ModernWebStore.SharedKernel.Events;

namespace ModernWebStore.CrossCutting
{
    public static class DependencyRegister
    {
        /// <summary>
        /// TransientLifetimeManager - Cada Resolve gera uma nova instância.
        /// ContainerControlledLifetimeManager - Utiliza Singleton
        /// </summary>
        /// <param name="container"></param>
        public static void Register(UnityContainer container)
        {
            container.RegisterType<StoreDataContext, StoreDataContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICategoryRepository, CategoryRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICityRepository, CityRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICountryRepository, CountryRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IContinentRepository, ContinentRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IPostRepository, PostRepository>(new HierarchicalLifetimeManager());

            container.RegisterType<IUserApplicationService, UserApplication>(new HierarchicalLifetimeManager());
            container.RegisterType<ICategoryApplicationService, CategoryApplication>(new HierarchicalLifetimeManager());
            container.RegisterType<ICityApplicationService, CityApplication>(new HierarchicalLifetimeManager());
            container.RegisterType<ICountryApplicationService, CountryApplication>(new HierarchicalLifetimeManager());
            container.RegisterType<IContinentApplicationService, ContinentApplication>(new HierarchicalLifetimeManager());
            container.RegisterType<IPostApplicationService, PostApplication>(new HierarchicalLifetimeManager());

            container.RegisterType<IHandler<DomainNotification>, DomainNotificationHandler>(new HierarchicalLifetimeManager());

            //container.RegisterType<StoreDataContext, StoreDataContext>(new HierarchicalLifetimeManager());
            //container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            //container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());
            //container.RegisterType<ICategoryRepository, CategoryRepository>(new HierarchicalLifetimeManager());
            //container.RegisterType<IProductRepository, ProductRepository>(new HierarchicalLifetimeManager());
            //container.RegisterType<IOrderRepository, OrderRepository>(new HierarchicalLifetimeManager());

            //container.RegisterType<IUserApplicationService, UserApplicationService>(new HierarchicalLifetimeManager());
            //container.RegisterType<ICategoryApplicationService, CategoryApplicationService>(new HierarchicalLifetimeManager());
            //container.RegisterType<IProductApplicationService, ProductApplicationService>(new HierarchicalLifetimeManager());
            //container.RegisterType<IOrderApplicationService, OrderApplicationService>(new HierarchicalLifetimeManager());

            //container.RegisterType<IHandler<DomainNotification>, DomainNotificationHandler>(new HierarchicalLifetimeManager());
        }
    }
}
