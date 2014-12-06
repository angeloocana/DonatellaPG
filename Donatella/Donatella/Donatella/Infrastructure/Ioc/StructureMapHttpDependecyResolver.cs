using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using StructureMap;

namespace Donatella.Infrastructure.Ioc
{
    public class StructureMapHttpDependencyResolver : IDependencyResolver
    {
        private readonly Func<IContainer> _containerFactory;

        public StructureMapHttpDependencyResolver(Func<IContainer> containerFactory)
        {
            _containerFactory = containerFactory;
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType.IsClass)
            {
                return GetConcreteService(serviceType);
            }
            else
            {
                return GetInterfaceService(serviceType);
            }
        }

        private object GetConcreteService(Type serviceType)
        {
            try
            {
                // Can't use TryGetInstance here because it won’t create concrete types
                return _containerFactory().GetInstance(serviceType);
            }
            catch (StructureMapException)
            {
                return null;
            }
        }

        private object GetInterfaceService(Type serviceType)
        {
            return _containerFactory().TryGetInstance(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _containerFactory().GetAllInstances(serviceType).Cast<object>();
        }

        public void Dispose()
        {
        }
    }
}