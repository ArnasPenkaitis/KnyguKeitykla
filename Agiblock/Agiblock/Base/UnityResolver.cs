using Agiblock.Base;
using Agiblock.Base.Interface;
using Agiblock.Data;
using Agiblock.Models;
using Agiblock.Repository.Interface;
using Agiblock.Services;
using Agiblock.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http.Dependencies;
using Unity;
using Unity.Lifetime;

namespace Agiblock
{
    public class UnityResolver : IDependencyResolver
    {
        public static UnityResolver Instance { get; private set; }

        protected IUnityContainer container;

        private UnityResolver(IUnityContainer container)
        {
            if (container == null)
                throw new ArgumentNullException("container");

            this.container = container;
        }

        public static UnityResolver CreateResolver(IUnityContainer container)
        {
            if (Instance == null)
                Instance = new UnityResolver(container);

            return Instance;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return container.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return new List<object>();
            }
        }

        public IDependencyScope BeginScope()
        {
            var child = container.CreateChildContainer();
            return new UnityResolver(child);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            container.Dispose();
        }

        public static UnityContainer RegisterDependencies()
        {
            var container = new UnityContainer();
            container.RegisterType<IRepository, Repository.Repository>(new HierarchicalLifetimeManager());
            container.RegisterType<IRealBookService, RealBookService>(new HierarchicalLifetimeManager());
            container.RegisterType<ISearchService, SearchService>(new HierarchicalLifetimeManager());
            container.RegisterType<IBaseService<Book>, BaseService<Book>>(new HierarchicalLifetimeManager());
            container.RegisterType<IBaseService<Filter>, BaseService<Filter>>(new HierarchicalLifetimeManager());
            container.RegisterType<DbContext, ABContext>(new HierarchicalLifetimeManager());
            return container;
        }


    }
}